using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace DBHelper
{
    public class SqlServer:DataBaseAccess
    {
        public SqlServer()
        {
            this.Connection = null;
            this.Command = null;
            this.DataAdapter = null;
        }

        public SqlServer(string ConnectionText)
        {
            this.Connection = new System.Data.SqlClient.SqlConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
        }
        public SqlServer(string Server, string DataBaseName, string UserId, string Password)
        {
            string ConnectionText = "server=" + Server + @";database=" + DataBaseName + @";user id=" + UserId + @";pwd=" + Password + ";";
            this.Connection = new System.Data.SqlClient.SqlConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            
        }

        public override DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            this.Connection.Open();
            this.Command = this.Connection.CreateCommand();
            this.Command.CommandType = CommandType.Text;
            this.Command.CommandText = sql;

            this.DataAdapter.SelectCommand = this.Command;
            DataSet ds = new DataSet();
            this.DataAdapter.Fill(ds);
            dt = ds.Tables[0];

            ds.Dispose();
            this.Connection.Close();
            return dt;
        }

        public override DataTable GetDataTable(string sql, Dictionary<string, string> Parameters)
        {

            DataTable dt = new DataTable();
            this.Connection.Open();
            this.Command = this.Connection.CreateCommand();
            this.Command.CommandType = CommandType.Text;
            this.Command.CommandText = sql;
            this.Command.CreateParameter();
            foreach (string key in Parameters.Keys)
            {
                this.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter(key,Parameters[key]));
            }

            this.DataAdapter.SelectCommand = this.Command;
            DataSet ds = new DataSet();
            this.DataAdapter.Fill(ds);
            dt = ds.Tables[0];

            ds.Dispose();
            this.Connection.Close();
            return dt;
        }


        public override IDataReader GetDataTableReader(string sql)
        {

            DataTable dt = new DataTable();
            this.Connection.Open();
            this.Command = this.Connection.CreateCommand();
            this.Command.CommandType = CommandType.Text;
            this.Command.CommandText = sql;

            this.DataAdapter.SelectCommand = this.Command;
            DataSet ds = new DataSet();
            this.DataAdapter.Fill(ds);
            dt = ds.Tables[0];

            ds.Dispose();
            this.Connection.Close();
            return dt.CreateDataReader();
        }
    }
}
