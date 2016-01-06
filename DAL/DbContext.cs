using System;
using System.Data;
using JAMM.Data.MSSQL;
//using System.Data.SqlClient;

namespace BLL
{
	public partial class DbContext : DataContext
	{
		public DbContext() : base(Config.ConnectionString) { }
	}
}