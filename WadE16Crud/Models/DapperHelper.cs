using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace WadE16Crud.Models
{
    public class DapperHelper
    {
        public readonly SqlConnection _connection;
        public DapperHelper()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString.ToString());
        }


    }
}