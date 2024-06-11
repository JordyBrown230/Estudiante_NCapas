using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Estudiante.SI.Datos;
using Estudiante.SI;
using Estudiante.BS;
using System.Globalization;
namespace Estudiante.UI
{
    public partial class Contact : Page
    {
        private static string ced = "";
        IEstudianteService _estudianteService = new ReglasDeNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!(Request.QueryString["Cedula"] == null))
                {
                    ced = Request.QueryString["Cedula"].ToString();
                    if (ced == "0")
                    {
                        title.Text = "Nuevo Estudiante";
                        btnSubmit.Text = "Guardar";
                    }
                    else
                    {
                        Estudiante.SI.Datos.Estudiante estudiante = new Estudiante.SI.Datos.Estudiante();
                        estudiante = _estudianteService.Obtener(ced);
                        txtCedula.Text = estudiante.Cedula;
                        txtNombre.Text = estudiante.Nombre;
                        txtApellidos.Text = estudiante.Apellidos;
                        txtFechaNacimiento.Text = Convert.ToDateTime(estudiante.FechaNacimiento, new CultureInfo("es-PE")).ToString("yyyy-MM-dd");
                        txtCorreo.Text = estudiante.Correo;
                        txtTelefono.Text = estudiante.Telefono;
                        title.Text = "Editar Estudiante";
                        txtCedula.Enabled = false;
                        btnSubmit.Text = "Editar";
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void btnSubmit_Clk(object sender, EventArgs e)
        {
            Estudiante.SI.Datos.Estudiante estudiante = new Estudiante.SI.Datos.Estudiante()
            {
                Cedula = txtCedula.Text,
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                Correo = txtCorreo.Text,
                Telefono = Convert.ToInt32(txtTelefono.Text).ToString()
            };

            bool respuesta;

            if (ced == "0")
            {
                respuesta = _estudianteService.Insertar(estudiante);
            }
            else
            {
                respuesta = _estudianteService.Actualizar(estudiante);
            }

            if (respuesta)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operacion')", true);
            }
        }
    }
}