using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados_Nomina
{
    class EmpleadosRepositorio : IEmpleadosRepositorio
    {
        string connect = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
        public OperationResult Create(Info_Empleados Empleados)
        {
           
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                SqlTransaction Transaction = conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand("CreateEmpleado", conn, Transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Nombre_Completo", Empleados.Nombre_Completo);
                    cmd.Parameters.AddWithValue("Cedula", Empleados.Cedula);
                    cmd.Parameters.AddWithValue("Sueldo_Bruto", Empleados.Sueldo_Bruto);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Transaction.Commit();
                        return new OperationResult() { Result = true, Message = "Empleado Registrado!" };
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback();
                        return new OperationResult(false, $"Se ha producido un error, {ex.Message}");
                    }

                }
            }
        }

        public OperationResult FindByCedula(string Cedula)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlTransaction Transaction = conn.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand("FindByCedula", conn, Transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Cedula", Cedula);

                    DataTable DataT = new DataTable();

                    try
                    {
                        SqlDataReader DataR = cmd.ExecuteReader();
                        DataT.Load(DataR);
                        Transaction.Commit();

                        if (DataT.Rows.Count > 0)
                        {
                            return new OperationResult() { Result = true, Data = DataT };
                        }
                        return new OperationResult() { Result = false, Message = $"No existe el empleado registrado con la celuda '{Cedula}'." };
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback();
                        return new OperationResult() { Result = false, Message = $"Ha ocurrido un error. {ex.Message}" };
                        
                    }
                }
            }
        }

        public OperationResult SoftDelete(string Cedula)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();

                SqlTransaction Transaction = conn.BeginTransaction();

                using (SqlCommand cmd = new SqlCommand("SoftDelete", conn, Transaction))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Cedula", Cedula);



                    try
                    {
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            return new OperationResult(false, $"No se encontro empleado con la Cedula '{Cedula}'.");
                        }
                        Transaction.Commit();
                        return new OperationResult() { Result = true, Message = "Empleado Eliminado Satisfactoriamente" };
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback();
                        return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                    }
                }
            }
        }

        public OperationResult Update(Info_Empleados UEmpleados, string Cedula)
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    conn.Open();
                    SqlTransaction Transaction = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand("UpdateEmpleado", conn, Transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Nombre_Completo", UEmpleados.Nombre_Completo);
                        cmd.Parameters.AddWithValue("Sueldo_Bruto", UEmpleados.Sueldo_Bruto);
                        cmd.Parameters.AddWithValue("Cedula", Cedula);

                        try
                        {
                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                return new OperationResult(false, $"No se encontro el empleado con la cedula '{Cedula}'");
                            }
                            Transaction.Commit();
                            return new OperationResult() { Result = true, Message = "Empleado actualizado con exito!" };
                        }
                        catch (Exception ex)
                        {
                            Transaction.Rollback();
                            return new OperationResult(false, $"Ha ocurrido un error. {ex.Message}");
                        }
                    }
                }
            }
        
    }
}
