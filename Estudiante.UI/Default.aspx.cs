using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Estudiante.SI.Datos;
using Estudiante.SI;
using Estudiante.BS;
namespace Estudiante.UI
{
    public partial class _Default : Page
    {

        IEstudianteService _estudianteService = new ReglasDeNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarEstudiantes();
        }

        private void mostrarEstudiantes()
        {
            List<Estudiante.SI.Datos.Estudiante> lista = _estudianteService.ListaEstudiantes();
            GVEstudiantes.DataSource = lista;
            GVEstudiantes.DataBind();
        }

        protected void Nuevo_Clk(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx?Cedula=0");
        }
        protected void Editar_Clk(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            string cedula = btn.CommandArgument;

            Response.Redirect($"~/Contact.aspx?Cedula={cedula}");
        }

        protected void Eliminar_Clk(object sender, EventArgs e)
        {
            bool respuesta;
            LinkButton btn = (LinkButton)sender;
            string cedula = btn.CommandArgument;
            respuesta = _estudianteService.Eliminar(cedula);
            if (respuesta)
            {
                mostrarEstudiantes();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se pudo realizar la operacion')", true);
            }
        }

        /* protected void Unnamed_Click(object sender, EventArgs e)
         {

         }*/
    }
}