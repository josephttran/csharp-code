using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataLibrary
{
    public class DataAccess
    {
        string ConnectionString { get; set; }
        IDbConnection Conn { get; set; }

        public DataAccess()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DapperDemoDB"].ConnectionString;
            Conn = new SqlConnection(ConnectionString);
        }

        public List<T> GetRecords<T>(object filterObj = null)
        {
            if (filterObj == null)
            {
                return Conn.Query<T>("spSystemUser_Get", commandType: CommandType.StoredProcedure).ToList();
            }
            else
            {
                return Conn.Query<T>("spSystemUser_GetFiltered", filterObj, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void CreateRecord(Object firstLastName)
        {
            Conn.Execute("dbo.spSystemUser_Create", firstLastName, commandType: CommandType.StoredProcedure);
        }
    }
}
