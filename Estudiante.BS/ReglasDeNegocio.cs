using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Estudiante.DS;
using Estudiante.SI.Datos;
using Estudiante.SI;
namespace Estudiante.BS
{
    public class ReglasDeNegocio : IEstudianteService
    {
        DataLayer estudianteDs = new DataLayer();

        public List<Estudiante.SI.Datos.Estudiante> ListaEstudiantes()
        {
            try
            {
                return estudianteDs.Lista();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(Estudiante.SI.Datos.Estudiante estudiante)
        {
            if (datosEstudianteNoVacios(estudiante))
            {
                if (!(estudianteDs.Obtener(estudiante.Cedula).Cedula == estudiante.Cedula))
                {
                    return estudianteDs.Insertar(estudiante);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new OperationCanceledException("Los datos del estudiante no pueden estar vacíos.");
            }
        }

        public bool Actualizar(Estudiante.SI.Datos.Estudiante estudiante)
        {
            if (datosEstudianteNoVacios(estudiante))
            {
                Estudiante.SI.Datos.Estudiante estudianteExistente = estudianteDs.Obtener(estudiante.Cedula);
                if (!(EstudiantesSonIguales(estudianteExistente, estudiante)))
                {
                    return estudianteDs.Actualizar(estudiante);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new OperationCanceledException("Los datos del estudiante no pueden estar vacíos.");
            }
        }

        public bool Eliminar(string cedulaEstudiante)
        {
            if (!string.IsNullOrWhiteSpace(cedulaEstudiante))
            {
                return estudianteDs.Eliminar(cedulaEstudiante);
            }
            else
            {
                throw new OperationCanceledException("Los datos del estudiante no pueden estar vacíos.");
            }
        }


        public Estudiante.SI.Datos.Estudiante Obtener(string cedulaEstudiante)
        {
            if (!string.IsNullOrWhiteSpace(cedulaEstudiante))
            {
                Estudiante.SI.Datos.Estudiante estudianteEncontrado = estudianteDs.Obtener(cedulaEstudiante);

                if (estudianteEncontrado != null)
                {
                    return estudianteEncontrado;
                }
                else
                {
                    throw new InvalidOperationException("No se encontró ningún estudiante con la cédula proporcionada.");
                }
            }
            else
            {
                throw new ArgumentException("La cédula del estudiante no puede estar vacía o ser nula.");
            }
        }




        private bool datosEstudianteNoVacios(Estudiante.SI.Datos.Estudiante estudiante)
        {
            return !string.IsNullOrWhiteSpace(estudiante.Cedula) &&
                   !string.IsNullOrWhiteSpace(estudiante.Nombre) &&
                   !string.IsNullOrWhiteSpace(estudiante.Apellidos) &&
                   estudiante.FechaNacimiento != DateTime.MinValue &&
                   !string.IsNullOrWhiteSpace(estudiante.Correo) &&
                   !string.IsNullOrWhiteSpace(estudiante.Telefono);
        }

        private bool EstudiantesSonIguales(Estudiante.SI.Datos.Estudiante estudianteDatosOld, Estudiante.SI.Datos.Estudiante estudianteDatosNew)
        {
            return estudianteDatosOld.Cedula == estudianteDatosNew.Cedula &&
                   estudianteDatosOld.Nombre == estudianteDatosNew.Nombre &&
                   estudianteDatosOld.Apellidos == estudianteDatosNew.Apellidos &&
                   estudianteDatosOld.FechaNacimiento == estudianteDatosNew.FechaNacimiento &&
                   estudianteDatosOld.Correo == estudianteDatosNew.Correo &&
                   estudianteDatosOld.Telefono == estudianteDatosNew.Telefono;
        }
    }
}



