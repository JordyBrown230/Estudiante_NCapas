using System;
using System.Collections.Generic;
using Estudiante.DS;
using Estudiante.SI.Datos;

namespace Estudiante.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase DataLayer
            DataLayer dataLayer = new DataLayer();

            // Llamar al método Lista() para obtener la lista de estudiantes
            List<Estudiante.SI.Datos.Estudiante> estudiantes = dataLayer.Lista();

            // Mostrar los estudiantes en la consola
            Console.WriteLine("Lista de Estudiantes:");
            foreach (var estudiante in estudiantes)
            {
                Console.WriteLine("No hay");
                Console.WriteLine($"Cedula: {estudiante.Cedula}, Nombre: {estudiante.Nombre}, Apellidos: {estudiante.Apellidos}, Fecha de Nacimiento: {estudiante.FechaNacimiento}, Correo: {estudiante.Correo}, Telefono: {estudiante.Telefono}");
            }

            // Esperar a que el usuario presione una tecla antes de cerrar la aplicación
            Console.ReadKey();
        }
    }
}
