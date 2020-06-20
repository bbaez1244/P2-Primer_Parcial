using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados_Nomina
{
    public class Eliminar_Empleado
    {
        static IEmpleadosRepositorio empleadosRepositorio = new EmpleadosRepositorio();


        public void EliminarEmpleado()
        {
            char Continuar = 'Z';
            while (Continuar != 'M')
            {
                Console.Clear();

                Console.WriteLine("Cedula de empleado a eliminar: ");
                string cedula_empleado = Console.ReadLine();

                OperationResult empleado = empleadosRepositorio.FindByCedula(cedula_empleado);

                if (!empleado.Result)
                {
                    Console.WriteLine(empleado.Message);
                }
                else
                {
                    DataTable dataEmpleado = (DataTable)empleado.Data;

                    foreach (DataRow emp in dataEmpleado.Rows)
                    {
                        Console.WriteLine($"Cedula: {emp["Cedula"]}");
                        Console.WriteLine($"Nombre Completo: {emp["Nombre_Completo"]}");
                        Console.WriteLine($"Sueldo Bruto: {emp["Sueldo_Bruto"]}");
                        Console.WriteLine("");
                    }

                    Console.Write("Esta seguro que desea borrar este empleado? S/N: ");
                    var confirmar = Console.ReadLine();

                    if (confirmar.ToUpper() == "S")
                    {
                        var delete = empleadosRepositorio.SoftDelete(cedula_empleado);
                        Console.WriteLine(delete.Message);
                    }
                }


                Console.WriteLine("");
                Console.WriteLine("D - Eliminar otro Empleado");
                Console.WriteLine("M - Volver al Menu");
                Console.Write("Opcion: ");
                Continuar = Console.ReadLine().ToUpper()[0];

            }

        }
    }
}
