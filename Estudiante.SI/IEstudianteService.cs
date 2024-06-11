using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Estudiante.SI.Datos;
namespace Estudiante.SI
{
    public interface IEstudianteService
    {
        List<Estudiante.SI.Datos.Estudiante> ListaEstudiantes();
        bool Insertar(Estudiante.SI.Datos.Estudiante estudiante);
        bool Actualizar(Estudiante.SI.Datos.Estudiante estudiante);
        bool Eliminar(string cedulaEstudiante);
        Estudiante.SI.Datos.Estudiante Obtener(string cedulaEstudiante);
    }
}
