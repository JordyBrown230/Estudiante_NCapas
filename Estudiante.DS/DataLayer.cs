using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estudiante.SI.Datos;
using System.Configuration;
namespace Estudiante.DS
{
    public class DataLayer
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["cadenaSQL"].ToString();

        public List<Estudiante.SI.Datos.Estudiante> Lista()
        {
            List<Estudiante.SI.Datos.Estudiante> lista = new List<Estudiante.SI.Datos.Estudiante>();
            using(SqlConnection con = new SqlConnection(connectionString)) {
                con.Open(); 
                SqlCommand cmd = new SqlCommand("exec paSelectAllStudent", con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Estudiante.SI.Datos.Estudiante estudiante = new Estudiante.SI.Datos.Estudiante();
                        estudiante.Cedula = reader["Cedula"].ToString();
                        estudiante.Nombre = reader["Nombre"].ToString();
                        estudiante.Apellidos = reader["Apellidos"].ToString();
                        estudiante.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                        estudiante.Correo = reader["Correo"].ToString();
                        estudiante.Telefono = reader["Telefono"].ToString();

                        lista.Add(estudiante);
                    }
                }
            }
            return lista;
        }

        public bool Insertar(Estudiante.SI.Datos.Estudiante estudiante)
        {
            bool respuesta=false;
            int filasAfectadas;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("paInsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", estudiante.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", estudiante.Apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Correo", estudiante.Correo);
                cmd.Parameters.AddWithValue("@Telefono", estudiante.Telefono);

                con.Open();
                filasAfectadas=cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }

        public bool Actualizar(Estudiante.SI.Datos.Estudiante estudiante)
        {
            bool respuesta = false;
            int filasAfectadas;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("paUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", estudiante.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", estudiante.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", estudiante.Apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", estudiante.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Correo", estudiante.Correo);
                cmd.Parameters.AddWithValue("@Telefono", estudiante.Telefono);

                con.Open();
                filasAfectadas=cmd.ExecuteNonQuery();
                if(filasAfectadas > 0)
                {
                    respuesta=true;
                }

            }
            return respuesta;
        }

        public bool Eliminar(string cedulaEstudiante)
        {
            bool respuesta = false;
            int filasAfectadas;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("paDeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", cedulaEstudiante);
               filasAfectadas=cmd.ExecuteNonQuery();
                if(filasAfectadas > 0)
                {
                    respuesta =true;
                }
            }
            return respuesta;
        }

        public Estudiante.SI.Datos.Estudiante Obtener(string cedulaEstudiante)
        {
            Estudiante.SI.Datos.Estudiante estudiante = new Estudiante.SI.Datos.Estudiante();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("paSelectStudentByCedula", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", cedulaEstudiante);
                try
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            estudiante.Cedula = reader["Cedula"].ToString();
                            estudiante.Nombre = reader["Nombre"].ToString();
                            estudiante.Apellidos = reader["Apellidos"].ToString();
                            estudiante.FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
                            estudiante.Correo = reader["Correo"].ToString();
                            estudiante.Telefono = reader["Telefono"].ToString();
                        }

                    }
                    return estudiante;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

    }
}
