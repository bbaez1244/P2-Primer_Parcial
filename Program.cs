using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados_Nomina
{
    class Program
    {
        static IEmpleadosRepositorio empleadosRepositorio = new EmpleadosRepositorio();
        static void Main(string[] args)
        {
            string opcion = null;
            do
            {
                Console.Clear();

                Console.WriteLine("Sistema de Registro de Empleados");
                Console.WriteLine("");

                Console.WriteLine("C - Registrar Empleado");
                Console.WriteLine("S - Buscar Empleado por su Cedula");
                Console.WriteLine("U - Actualizar Datos de Empleado");
                Console.WriteLine("D - Borrar Empleado");
                Console.WriteLine("E - Salir");
                Console.WriteLine("");
                Console.Write("Opcion: ");
                opcion = Console.ReadLine();

                if (opcion.ToUpper() == "C")
                {
                    Registrar_Empleado registrarempleado = new Registrar_Empleado();
                    registrarempleado.RegistroEmpleados();
                }
                if (opcion.ToUpper() == "S")
                {
                    Buscar_Cedula buscarcedula = new Buscar_Cedula();
                    buscarcedula.BuscarCedula();
                }
                if (opcion.ToUpper() == "U")
                {
                    Actualizar_Empleado actualizarempleado = new Actualizar_Empleado();
                    actualizarempleado.ActualizarEmpleado();
                }
                if (opcion.ToUpper() == "D")
                {
                    Eliminar_Empleado eliminarempleado = new Eliminar_Empleado();
                    eliminarempleado.EliminarEmpleado();
                }
            } while (opcion.ToUpper() != "E");
        }
    }
}
