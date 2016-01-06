//using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
	public partial class DbContext
	{
		public static bool AgregarEmpleado(Empleado empleado)
		{
			DbContext ctx = new DbContext();
			try
			{
				ctx.ExecuteNonQuery("AddNewEmployee", new[] {
					new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = empleado.Apellido },
					new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = empleado.Nombre },
					new SqlParameter("@Title", SqlDbType.NVarChar) { Value = empleado.Puesto },
					new SqlParameter("@Address", SqlDbType.NVarChar) { Value = empleado.Direccion },
					new SqlParameter("@City", SqlDbType.NVarChar) { Value = empleado.Ciudad },
					new SqlParameter("@Region", SqlDbType.NVarChar) { Value = empleado.Region },
					new SqlParameter("@PostalCode", SqlDbType.NVarChar) {  Value = empleado.CodigoPostal },
					new SqlParameter("@Country", SqlDbType.NVarChar) { Value = empleado.Pais },
					new SqlParameter("@Extension", SqlDbType.NVarChar) { Value = empleado.Extension }
				});
				return true;
			}
			catch
			{
				//Log
				return false;
			}
		}

		public static bool ActualizarEmpleado(Empleado empleado)
		{
			DbContext ctx = new DbContext();
			try
			{
				ctx.ExecuteNonQuery("UpdateEmployee", new[] {
					new SqlParameter("@EmployeeID", SqlDbType.Int) { Value = empleado.EmpleadoID },
					new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = empleado.Apellido },
					new SqlParameter("@FirstName", SqlDbType.NVarChar) { Value = empleado.Nombre },
					new SqlParameter("@Title", SqlDbType.NVarChar) { Value = empleado.Puesto },
					new SqlParameter("@Address", SqlDbType.NVarChar) { Value = empleado.Direccion },
					new SqlParameter("@City", SqlDbType.NVarChar) { Value = empleado.Ciudad },
					new SqlParameter("@Region", SqlDbType.NVarChar) { Value = empleado.Region },
					new SqlParameter("@PostalCode", SqlDbType.NVarChar) {  Value = empleado.CodigoPostal },
					new SqlParameter("@Country", SqlDbType.NVarChar) { Value = empleado.Pais },
					new SqlParameter("@Extension", SqlDbType.NVarChar) { Value = empleado.Extension }
				});
				return true;
			}
			catch
			{
				//Log
				return false;
			}
		}

		public static bool BorrarEmpleado(int EmpleadoID)
		{
			DbContext ctx = new DbContext();
			try
			{
				ctx.ExecuteNonQuery("DeleteEmployee", new[] {
					new SqlParameter("@EmployeeID", SqlDbType.Int) { Value = EmpleadoID }
				});
				return true;
			}
			catch
			{
				//Log
				return false;
			}

		}

		public static Empleado ObtenerEmpleadoDetalle(int EmpleadoID)
		{
			Empleado empleado = null;

			DbContext ctx = new DbContext();

			DataTable table = ctx.ExecuteDataTable("GetEmployeeDetails", new[] {
				new SqlParameter("@EmployeeID", SqlDbType.Int) { Value = EmpleadoID }
			});
			//Lets get the list of all employees in a datataable
			//check if any record exist or not
			if (table.Rows.Count == 1)
			{
				DataRow row = table.Rows[0];

				//Lets go ahead and create the list of employees
				empleado = new Empleado();

				//Now lets populate the employee details into the list of employees                                           
				empleado.EmpleadoID = Convert.ToInt32(row["EmployeeID"]);
				empleado.Apellido = row["LastName"].ToString();
				empleado.Nombre = row["FirstName"].ToString();
				empleado.Puesto = row["Title"].ToString();
				empleado.Direccion = row["Address"].ToString();
				empleado.Ciudad = row["City"].ToString();
				empleado.Region = row["Region"].ToString();
				empleado.CodigoPostal = row["PostalCode"].ToString();
				empleado.Pais = row["Country"].ToString();
				empleado.Extension = row["Extension"].ToString();
			}
			return empleado;
		}

		public static List<Empleado> ObtenerEmpleadosLista()
		{
			List<Empleado> ListaEmpleados = null;

			DbContext ctx = new DbContext();
			DataTable table = ctx.ExecuteDataTable("GetEmployeeList", new[] { new SqlParameter() });

			// Oracle
			//DataTable table = ctx.ExecuteDataTable("EMPLOYEES_tapi.GetAll", new[] {
			//    new OracleParameter("registrosCursor", OracleDbType.RefCursor) {
			//    Direction = ParameterDirection.Output}
			//});


			//check if any record exist or not
			if (table.Rows.Count > 0)
			{
				//Lets go ahead and create the list of employees
				ListaEmpleados = new List<Empleado>();

				//Now lets populate the employee details into the list of employees
				foreach (DataRow row in table.Rows)
				{
					Empleado empleado = new Empleado();
					empleado.EmpleadoID = Convert.ToInt32(row["EmployeeID"]);
					empleado.Apellido = row["LastName"].ToString();
					empleado.Nombre = row["FirstName"].ToString();
					empleado.Puesto = row["Title"].ToString();
					empleado.Direccion = row["Address"].ToString();
					empleado.Ciudad = row["City"].ToString();
					empleado.Region = row["Region"].ToString();
					empleado.CodigoPostal = row["PostalCode"].ToString();
					empleado.Pais = row["Country"].ToString();
					empleado.Extension = row["Extension"].ToString();

					ListaEmpleados.Add(empleado);
				}
			}

			return ListaEmpleados;
		}        
	}
}
