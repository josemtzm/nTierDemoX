//using Oracle.ManagedDataAccess.Client;
//using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Data.OracleClient;

namespace SIAJ.Data.Oracle
{
	/// <summary>
	/// Clase que obtiene la información consultada en procedimientos almacenados oracle
	/// </summary>
	public class DataContext
	{
		/// <summary>
		/// Oracle Params List
		/// </summary>
		private List<OracleParameter> Params;

		/// <summary>
		/// The connection string.
		/// </summary>
		private string ConnectionString;

		/// <summary>
		/// Initialize the Oracle Params List
		/// </summary>
		public DataContext(string connectionString)
		{
			this.ConnectionString = connectionString;
			this.Params = new List<OracleParameter>();
		}

		/// <summary>
		/// Valida si se puede abrir la conexión.
		/// </summary>
		public bool IsConnected
		{
			get
			{
				OracleConnection Connection = new OracleConnection(ConnectionString);
				try
				{
					Connection.Open();
					return true;
				}
				catch (OracleException ex)
				{
//					Logger.Error("Error de conexion.", ex);
					return false;
				}
				finally
				{
					Connection.Dispose();
					Connection.Close();
				}
			}
		}

		/// <summary>
		/// Obtiene la dirección IP del HOST
		/// </summary>
		public string GetServer
		{
			get
			{
				return ConnectionString.Substring(ConnectionString.IndexOf("HOST"), 20);
			}
		}

		/// <summary>
		/// Obtiene la lista de parametros y valores en formato json.
		/// </summary>
		public string GetParams
		{
			get
			{
				StringBuilder strLogParams = new StringBuilder("{Params: ");
				if (this.Params != null && this.Params.Count > 0)
				{
					foreach (OracleParameter parameter in this.Params)
					{
						strLogParams.Append("[");
						strLogParams.Append((parameter.ParameterName != null) ? parameter.ParameterName : string.Empty);
						strLogParams.Append(",");
						strLogParams.Append((parameter.Value != null) ? parameter.Value.ToString() : string.Empty);
						strLogParams.Append(",");
						strLogParams.Append(parameter.Direction.ToString());
						strLogParams.Append(",");
						strLogParams.Append(parameter.OracleType.ToString());
						strLogParams.Append("]");
					}
				}
				strLogParams.Append("}");
				return strLogParams.ToString();
			}
		}

		/// <summary>
		/// Get an OUTPUT value from an stored procedure
		/// </summary>
		/// <param name="Param">Parameter name</param>
		/// <returns>Parameter Value</returns>
		public string GetParamValue(string Param)
		{
			string result = string.Empty;
			try
			{
				foreach (OracleParameter parameter in this.Params)
				{
					if (parameter.ParameterName.Equals(Param))
					{
						result = parameter.Value.ToString();
						break;
					}
				}
				return result;
			}
			catch (OracleException ex)
			{
//				Logger.Error("Param : " + Param + " : " + GetServer + ". Params : " + GetParams, ex);
				return result;
			}
		}
		/// <summary>
		/// Obtiene los datos de un refCursor y los asigna a la entidad
		/// </summary>
		/// <typeparam name="T">Entidad compatible con los campos del cursor</typeparam>
		/// <param name="CursorParam"></param>
		/// <returns></returns>
		public List<T> GetCursorValue<T>(string CursorParam)
		{
			List<T> list = new List<T>();
			T obj = default(T);
			OracleDataReader DataReader = null;
			try
			{
				foreach (OracleParameter parameter in this.Params)
				{
					if (parameter.ParameterName.Equals(CursorParam))
					{
//						DataReader = ((OracleRefCursor)parameter.Value).GetDataReader();
					}
				}

				while (DataReader.Read())
				{
					obj = Activator.CreateInstance<T>();
					foreach (PropertyInfo prop in obj.GetType().GetProperties())
					{
						if (!object.Equals(DataReader[prop.Name], DBNull.Value))
						{
							prop.SetValue(obj, DataReader[prop.Name], null);
						}
					}
					list.Add(obj);
				}

			}
			catch (OracleException ex)
			{
//				Logger.Error("Cursor : " + CursorParam + " : " + GetServer + ". Params : " + GetParams, ex);
			}
			return list;
		}

		/// <summary>
		/// Adds the parameter.
		/// </summary>
		/// <param name="Param">Parameter.</param>
		/// <param name="Type">Type.</param>
		/// <param name="Value">Value.</param>
		/// <param name="Direction">Direction.</param>
		public void AddParam(string Param, OracleType Type, object Value, ParameterDirection Direction)
		{
			OracleParameter param = new OracleParameter();
			param.ParameterName = Param;
			param.OracleType = Type;
			param.Value = Value;
			param.Direction = Direction;
			this.Params.Add(param);
		}

		/// <summary>
		/// Adds the parameter.
		/// </summary>
		/// <param name="Param">Parameter.</param>
		/// <param name="Type">Type.</param>
		/// <param name="Direction">Direction.</param>
		public void AddParam(string Param, OracleType Type, ParameterDirection Direction)
		{
			OracleParameter param = new OracleParameter();
			param.ParameterName = Param;
			param.OracleType = Type;
			param.Direction = Direction;
			this.Params.Add(param);
		}

		/// <summary>
		/// Adds the parameter.
		/// </summary>
		/// <param name="Param">Parameter.</param>
		/// <param name="Type">Type.</param>
		/// <param name="Direction">Direction.</param>
		/// <param name="Size">Size.</param>
		public void AddParam(string Param, OracleType Type, ParameterDirection Direction, int Size)
		{
			OracleParameter param = new OracleParameter();
			param.ParameterName = Param;
			param.OracleType = Type;
			param.Direction = Direction;
			param.Size = Size;
			this.Params.Add(param);
		}
		public void AddParam(string ParamName, OracleParameter Param, ParameterDirection Direction)
		{
			Param.ParameterName = ParamName;
			Param.Direction = Direction;
			this.Params.Add(Param);
		}
		public void AddParam(string Param, OracleType Type, object Value, int Size, ParameterDirection Direction)
		{
			OracleParameter param = new OracleParameter();
			param.ParameterName = Param;
			param.OracleType = Type;
//			param.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
			param.Direction = Direction;
			param.Value = Value;
			param.Size = Size;
			this.Params.Add(param);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="StoredProcedure"></param>
		/// <returns></returns>
		public DataTable ExecuteDataTable(string StoredProcedure)
		{
			try
			{
				DataTable DT = new DataTable();
				DT.Load(ExecuteReader(StoredProcedure, CommandType.StoredProcedure));
				return DT;
			}
			catch (Exception ex)
			{
//				Logger.Error("StoredProcedure : " + StoredProcedure + " : " + GetServer + ". Params : " + GetParams, ex);
				return null;
			}
		}

		/// <summary>
		/// Executes the reader without transaction.
		/// </summary>
		/// <returns>The reader.</returns>
		/// <param name="Qry">Qry (Only SELECT).</param>
		/// <param name="Type">Command Type.</param>
		protected OracleDataReader ExecuteReader(string Qry, CommandType Type)
		{
			OracleConnection Connection = new OracleConnection(ConnectionString);
			OracleCommand Command = new OracleCommand();
			OracleDataReader DataReader = null;

			try
			{
				Connection.Open();

				Command.Connection = Connection;
				Command.CommandText = Qry;
				Command.CommandType = Type;

				if (this.Params.Count > 0)
				{
					foreach (OracleParameter param in this.Params)
					{
						Command.Parameters.Add(param);
					}
				}

				Command.Prepare();
				DataReader = Command.ExecuteReader(CommandBehavior.CloseConnection);
				return DataReader;
			}
			catch (OracleException ex)
			{
//				Logger.Error("Qry : " + Qry + " : " + GetServer + ". Params : " + GetParams, ex);
				Connection.Dispose();
				Connection.Close();
				return null;
			}
		}

		/// <summary>
		/// Executes the command with transaction.
		/// </summary>
		/// <param name="Cmd">Command to execute</param>
		protected void ExecuteCommand(string Cmd)
		{
			OracleConnection Connection = new OracleConnection(ConnectionString);
			OracleCommand Command = new OracleCommand();
			OracleTransaction trx = null;
			try
			{
				Command.Connection = Connection;
				Command.CommandText = Cmd;
				Command.CommandType = CommandType.Text;

				Connection.Open();
				trx = Connection.BeginTransaction();
				Command.Transaction = trx;
				Command.ExecuteNonQuery();
				trx.Commit();
			}
			catch (OracleException ex)
			{
				trx.Rollback();
//				Logger.Error("Command : " + Cmd + " : " + GetServer + ". Params : " + GetParams, ex);
			}
		}

		/// <summary>
		/// Executes the stored procedure with transaction.
		/// </summary>
		/// <param name="StoredProcedure">Stored procedure.</param>
		protected void ExecuteStoredProcedure(string StoredProcedure)
		{
			OracleConnection Connection = new OracleConnection(ConnectionString);
			OracleCommand Command = new OracleCommand();
			OracleTransaction trx = null;
			try
			{
				Command.Connection = Connection;
				Command.CommandText = StoredProcedure;
				Command.CommandType = CommandType.StoredProcedure;

				Connection.Open();
				if (this.Params.Count > 0)
				{
					foreach (OracleParameter param in this.Params)
					{
						Command.Parameters.Add(param);
					}
				}

				trx = Connection.BeginTransaction();
				Command.Transaction = trx;
				Command.ExecuteNonQuery();
				trx.Commit();//check if connection is close
			}
			catch (OracleException ex)
			{
				trx.Rollback();
//				Logger.Error("SP : " + StoredProcedure + " : " + GetServer + ". Params : " + GetParams, ex);
			}

		}

		/// <summary>
		/// Executa un SP que contiene varios refcursor y los almacena en un DataSet.
		/// </summary>
		/// <param name="StoredProcedure"></param>
		/// <returns></returns>
		public DataSet ExecuteDataSet(string StoredProcedure)
		{
			OracleConnection Connection = new OracleConnection(ConnectionString);
			OracleCommand Command = new OracleCommand();
			OracleTransaction trx = null;
			DataSet DS = new DataSet();
			OracleDataAdapter adapter = null;
			int intCountTables = 0;

			try
			{
				adapter = new OracleDataAdapter(Command);
				Command.Connection = Connection;
				Command.CommandText = StoredProcedure;
				Command.CommandType = CommandType.StoredProcedure;

				Connection.Open();

				if (this.Params.Count > 0)
				{
					foreach (OracleParameter param in this.Params)
					{
						Command.Parameters.Add(param);
//						if (param.OracleDbType.ToString().Equals(OracleDbType.RefCursor.ToString()))
//						{
//							adapter.TableMappings.Add("Table" + ((intCountTables > 0)
//								? intCountTables.ToString()
//								: string.Empty), param.ParameterName);
//							intCountTables++;
//						}
					}
				}
				adapter.Fill(DS);
				trx = Connection.BeginTransaction();
				Command.Transaction = trx;
				Command.ExecuteNonQuery();
				trx.Commit();//check if connection is close
			}
			catch(OracleException ex)
			{
				trx.Rollback();
//				Logger.Error("SP : " + StoredProcedure + " : " + GetServer + ". Params : " + GetParams, ex);
			}

			return DS;
		}
		/// <summary>
		/// Clears the parameters.
		/// </summary>
		public void ClearParams()
		{
			this.Params.Clear();
		}


		/// <summary>
		/// Executes the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="StoredProcedure">Stored procedure.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public List<T> ExecuteList<T>(string StoredProcedure)
		{
			List<T> list = new List<T>();
			T obj = default(T);
			try
			{
				OracleDataReader DataReader = ExecuteReader(StoredProcedure, CommandType.StoredProcedure);

				while (DataReader.Read())
				{
					obj = Activator.CreateInstance<T>();
					foreach (PropertyInfo prop in obj.GetType().GetProperties())
					{
						if (!object.Equals(DataReader[prop.Name], DBNull.Value))
						{
							prop.SetValue(obj, DataReader[prop.Name], null);
						}
					}
					list.Add(obj);
				}
			}
			catch (OracleException ex)
			{
//				Logger.Error("SP : " + StoredProcedure + " : " + GetServer + ". Params : " + GetParams, ex);
			}

			return list;
		}

		/// <summary>
		/// Crea una entidad desde BD
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="StoredProcedure"></param>
		/// <returns></returns>
		public T ExecuteEntity<T>(string StoredProcedure)
		{
			T obj = default (T);
			try
			{

				OracleDataReader DataReader = ExecuteReader(StoredProcedure, CommandType.StoredProcedure);

				while (DataReader.Read())
				{
					obj = Activator.CreateInstance<T>();
					foreach (PropertyInfo prop in obj.GetType().GetProperties())
					{
						if (!object.Equals(DataReader[prop.Name], DBNull.Value))
						{
							prop.SetValue(obj, DataReader[prop.Name], null);
						}
					}
				}
			}
			catch (OracleException ex)
			{
//				Logger.Error("SP : " + StoredProcedure + " : " + GetServer + ". Params : " + GetParams, ex);
			}
			return obj;
		}
	}
}