using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBHelper
{
    public class DataBaseAccess
    {
        #region 变量
        private string connectionText;
        private string server;
        private string database;
        private string userid;
        private string password;
        private string databasefile;
        private string databasetype;
        private IDbCommand command;
        private IDbDataAdapter dataadapter;
        private IDbConnection connection;
        #endregion

        #region 属性

        #region string ConnectionText 数据库连接字符串
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectionText { get { return connectionText; } }
        #endregion

        #region string Server 数据库服务器
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public string Server { get { return server; } set { server = value; UpdateDataBaseAccessInfo(); } }
        #endregion

        #region string DataBase 数据库名称
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DataBase { get { return database; } set { database = value; UpdateDataBaseAccessInfo(); } }
        #endregion

        #region string UserId 数据库用户名称
        /// <summary>
        /// 数据库用户名称
        /// </summary>
        public string UserId { get { return userid; } set { userid = value; UpdateDataBaseAccessInfo(); } }
        #endregion

        #region string Password 数据库用户密码
        /// <summary>
        /// 数据库用户密码
        /// </summary>
        public string Password { get { return password; } set { password = value; UpdateDataBaseAccessInfo(); } }
        #endregion

        #region string DataBaseFile 数据库文件
        /// <summary>
        /// 数据库文件
        /// </summary>
        public string DataBaseFile { get { return databasefile; } set { databasefile = value; UpdateDataBaseAccessInfo(); } }
        #endregion

        #region string DataBaseType 数据库类型
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DataBaseType
        {
            get
            {
                return databasetype;
            }
            set
            {
                databasetype = value.ToLower();
                UpdateDataBaseAccessInfo();
            }
        }
        #endregion

        #region System.Data.ConnectionState State 数据库连接状态
        /// <summary>
        /// 数据库连接状态
        /// </summary>
        public System.Data.ConnectionState State
        {
            get
            {
                if (this.connection != null)
                {
                    return this.connection.State;
                }
                else
                {
                    return ConnectionState.Closed;
                }
            
            }
          
        }
        #endregion

        #region IDbConnection Connection 数据库连接
        /// <summary>
        /// 数据库连接
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return connection;
            }
        }
        #endregion 

        #region IDbCommand Command 数据库命令
        /// <summary>
        /// 数据库命令
        /// </summary>
        public IDbCommand Command
        {
            get
            {
                return command;
            }
        }
        #endregion 

        #region IDbDataAdapter DataAdapter 数据库适配器
        /// <summary>
        /// 数据库适配器
        /// </summary>
        public IDbDataAdapter DataAdapter
        {
            get
            {
                return dataadapter;
            }
        }
        #endregion 

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataBaseAccess()
        {
            this.connectionText = string.Empty;
            this.DataBaseType = string.Empty;
            this.Server = string.Empty;
            this.DataBase = string.Empty;
            this.UserId = string.Empty;
            this.Password = string.Empty;
            this.DataBaseFile = string.Empty;
            this.connection = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DataBaseType">数据库类型</param>
        /// <param name="Server">数据库服务器</param>
        /// <param name="DataBase">数据库名字</param>
        /// <param name="UserId">数据库用户</param>
        /// <param name="Password">数据库用户密码</param>
        /// <param name="DataBaseFile">数据库文件</param>
        public DataBaseAccess(string DataBaseType, string Server, string DataBase, string UserId, string Password, string DataBaseFile)
        {
            this.connectionText = string.Empty;
            this.DataBaseType = DataBaseType;
            this.Server = Server;
            this.DataBase = DataBase;
            this.UserId = UserId;
            this.Password = Password;
            this.DataBaseFile = DataBaseFile;
            this.connection = null;

        }
        
        #endregion

        #region 内部方法

        #region void UpdateDataBaseAccessInfo() 更新连接字符串信息
        /// <summary>
        /// 更新连接字符串信息
        /// </summary>
        private void UpdateDataBaseAccessInfo()
        {
            switch (databasetype)
            {
                case "sqlserver":
                    connectionText = "server=" + server + @";database=" + database + @";user id=" + userid + @";pwd=" + password + ";";
                    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                    {
                        this.connection = new System.Data.SqlClient.SqlConnection(this.ConnectionText);
                        this.dataadapter = new System.Data.SqlClient.SqlDataAdapter();
                    }
                    break;
                case "access":
                    connectionText = "provider=microsoft.jet.oledb.4.0;data source='" + databasefile + "'";
                    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                    {
                        this.connection = new System.Data.OleDb.OleDbConnection(this.ConnectionText);
                        this.dataadapter = new System.Data.OleDb.OleDbDataAdapter();
                    }
                    break;
                case "mysql":
                    connectionText = "server=" + server + @";database=" + database + @";uid=" + userid + @";pwd=" + password + ";";
                    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                    {
                        this.connection = new MySql.Data.MySqlClient.MySqlConnection(this.ConnectionText);
                        this.dataadapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
                    }
                    break;
                case "excel":
                    connectionText = "Provider=Microsoft.Jet.OLEDB.12.0;Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ="+databasefile+";";
                    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                    {
                        this.connection = new System.Data.OleDb.OleDbConnection(this.ConnectionText);
                        this.dataadapter = new System.Data.OleDb.OleDbDataAdapter();
                      
                    }
                    break;
                case "oracle":
                    connectionText = "Driver={Microsoft ODBC for Oracle};Server="+server+";Uid="+userid+";Pwd="+password+";";
                    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                    {
                        this.connection = new System.Data.Odbc.OdbcConnection(this.ConnectionText);
                        this.dataadapter = new System.Data.Odbc.OdbcDataAdapter();
                    }
                    break;
            }
        }
        #endregion 

        #endregion

        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            this.connection.Open();
            this.command = this.connection.CreateCommand();
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = sql;

            this.dataadapter.SelectCommand = this.command;
            DataSet ds=new DataSet();
            this.dataadapter.Fill(ds);
            dt = ds.Tables[0];

            ds.Dispose();
            this.connection.Close();
            return dt;
        }

        public DataTable GetDataTable(string sql,System.Data.IDataParameterCollection parameters)
        {
            DataTable dt = new DataTable();
            this.connection.Open();
            this.command = this.connection.CreateCommand();
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = sql;
            this.command.CreateParameter();
            foreach (IDataParameter parameter in parameters) 
            {
                this.command.Parameters.Add(parameter);
            }

            this.dataadapter.SelectCommand = this.command;
            DataSet ds = new DataSet();
            this.dataadapter.Fill(ds);
            dt = ds.Tables[0];

            ds.Dispose();
            this.connection.Close();
            return dt;
        }
    }
}
