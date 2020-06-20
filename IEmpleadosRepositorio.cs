using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados_Nomina
{
    interface IEmpleadosRepositorio
    {
        OperationResult Create(Info_Empleados Empleados);
        OperationResult FindByCedula(string Cedula);
        OperationResult Update(Info_Empleados UEmpleados, string Cedula);
        OperationResult SoftDelete(string Cedula);

    }
}
