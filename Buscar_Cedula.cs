using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados_Nomina
{
    public class Buscar_Cedula
    {
        static IEmpleadosRepositorio empleadosRepositorio = new EmpleadosRepositorio();


        public void BuscarCedula()
        {

           
            char Continuar = 'Z';
            while (Continuar != 'M')
            {
                Console.Clear();

                Console.WriteLine("Escriba la cedula del empleado a buscar: ");

                string cedula_empleado = Console.ReadLine();



                var cedula_Empleado = empleadosRepositorio.FindByCedula(cedula_empleado);

                if (!cedula_Empleado.Result)
                {
                    Console.WriteLine(cedula_Empleado.Message);
                }
                else
                {
                    DataTable dataEmpleado = (DataTable)cedula_Empleado.Data;

                    foreach (DataRow emp in dataEmpleado.Rows)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Cedula: {emp["Cedula"]}");
                        Console.WriteLine($"Nombre Completo: {emp["Nombre_Completo"]}");
                        Console.WriteLine($"Sueldo Bruto: RD{emp["Sueldo_Bruto"]:C2}");
                        Console.WriteLine($"AFP: RD{emp["AFP"]:C2}");
                        Console.WriteLine($"ARS: RD{emp["ARS"]:C2}");
                        Console.WriteLine($"Total Retencion: RD{emp["Total_Retencion"]:C2}");
                        Console.WriteLine($"Sueldo Neto: RD{emp["Sueldo_Neto"]:C2}");
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("S - Buscar otro Empleado por su Cedula");
                Console.WriteLine("M - Volver al Menu");
                Console.Write("Opcion: ");
                Continuar = Console.ReadLine().ToUpper()[0];

            }
        }
    }
}
