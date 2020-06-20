using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados_Nomina
{
    public class Actualizar_Empleado
    {
        static IEmpleadosRepositorio empleadosRepositorio = new EmpleadosRepositorio();


        public void ActualizarEmpleado()
        {
            char Continuar = 'Z';
            while (Continuar != 'M')
            {
                Console.Clear();

                Console.WriteLine("Cedula de empleado a modificar: ");
                string cedula_Empleado = Console.ReadLine();

                OperationResult empleado = empleadosRepositorio.FindByCedula(cedula_Empleado);

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

                    Console.Write("Nuevo Nombre: ");
                    var Nombre_completo = Console.ReadLine();
                    Console.Write("Nuevo Sueldo Bruto: ");
                    double Sueldo_bruto = double.Parse(Console.ReadLine());

                    var actualizar = empleadosRepositorio.Update(new Info_Empleados() { Nombre_Completo = Nombre_completo, Sueldo_Bruto = Sueldo_bruto }, cedula_Empleado);
                    Console.WriteLine(actualizar.Message);

                    Console.WriteLine("");
                    Console.WriteLine("U - Actualizar Datos de otro Empleado");
                    Console.WriteLine("M - Volver al Menu");
                    Console.Write("Opcion: ");
                    Continuar = Console.ReadLine().ToUpper()[0];
                }

            }
        }
    }
}
