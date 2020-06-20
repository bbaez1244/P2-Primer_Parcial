using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados_Nomina
{
    public class Registrar_Empleado
    {
        static IEmpleadosRepositorio empleadosRepositorio = new EmpleadosRepositorio();


        public void RegistroEmpleados()
        {
            char Continuar = 'Z';
            while (Continuar != 'M')
            {
                Console.Clear();

                Console.WriteLine("Escribir el nombre del empleado: ");
                string nombre_completo = Console.ReadLine();

                Console.WriteLine("Escribir la cedula: ");
                string cedula = Console.ReadLine();

                Console.WriteLine("Escribir el sueldo: ");
                double sueldo_bruto = double.Parse(Console.ReadLine());



                var resultado = empleadosRepositorio.Create(new Info_Empleados() { Nombre_Completo = nombre_completo, Cedula = cedula, Sueldo_Bruto = sueldo_bruto });

                Console.WriteLine(resultado.Message);

                Console.WriteLine("");
                Console.WriteLine("C - Registrar otro Empleado");
                Console.WriteLine("M - Volver al Menu");
                Console.Write("Opcion: ");
                Continuar = Console.ReadLine().ToUpper()[0];
            }

        }
    }
}
