using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace DBHelper
{
    public class DataBase
    {
        #region 变量
        private string connectionText;
        private string server;
        private string databasename;
        private string userid;
        private string password;
        private string databasefile;
        private string databasetype;
        private DataBaseAccess databaseaccess;
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

        #region string DataBaseName 数据库名称
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DataBaseName { get { return databasename; } set { databasename = value; UpdateDataBaseAccessInfo(); } }
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

        #region DBHelper.DataBaseAccess DataBaseAccess 数据库连接对象
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public DBHelper.DataBaseAccess DataBaseAccess
        {
            get
            {
                return this.databaseaccess;              
            }
            set { this.databaseaccess = value; }
          
        }
        #endregion

        #region DateTime DataBaseDateTime 数据库时间
        /// <summary>
        /// 数据库时间
        /// </summary>
        public DateTime DataBaseDateTime
        {
            get
            {
                return GetDateTime();
            }
           
        }
        #endregion

        #region string DateYMD 数据库日期
        /// <summary>
        /// 数据库日期
        /// </summary>
        public string DateYMD
        {
            get
            {
                return DataBaseDateTime.ToString("yyyy/MM/dd", DateTimeFormatInfo.InvariantInfo);
            }

        }
        #endregion

        #region string TimeHMS 数据库时间
        /// <summary>
        /// 数据库时间
        /// </summary>
        public string TimeHMS
        {
            get
            {
                return DataBaseDateTime.ToString("HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            }

        }
        #endregion

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataBase()
        {
            this.connectionText = string.Empty;
            this.DataBaseType = string.Empty;
            this.Server = string.Empty;
            this.DataBaseName = string.Empty;
            this.UserId = string.Empty;
            this.Password = string.Empty;
            this.DataBaseFile = string.Empty;
            this.databaseaccess = null;
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
        public DataBase(string DataBaseType, string Server, string DataBaseName, string UserId, string Password, string DataBaseFile)
        {
            this.connectionText = string.Empty;
            this.DataBaseType = DataBaseType;
            this.Server = Server;
            this.DataBaseName = DataBaseName;
            this.UserId = UserId;
            this.Password = Password;
            this.DataBaseFile = DataBaseFile;
            this.databaseaccess = null;

            this.UpdateDataBaseAccessInfo();

        }
        
        #endregion

        #region 内部方法

        #region private void UpdateDataBaseAccessInfo() 更新连接字符串信息
        /// <summary>
        /// 更新连接字符串信息
        /// </summary>
        private void UpdateDataBaseAccessInfo()
        {
            switch (databasetype)
            {
                case "sqlserver":
                    connectionText = "server=" + server + @";database=" + databasename + @";user id=" + userid + @";pwd=" + password + ";";
                    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                    {
                        this.databaseaccess = new SqlServer(this.ConnectionText);
                    }
                    break;
                //case "access":
                //    connectionText = "provider=microsoft.jet.oledb.4.0;data source='" + databasefile + "'";
                //    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                //    {
                //        this.connection = new System.Data.OleDb.OleDbConnection(this.ConnectionText);
                //        this.dataadapter = new System.Data.OleDb.OleDbDataAdapter();
                //    }
                //    break;
                //case "mysql":
                //    connectionText = "server=" + server + @";database=" + database + @";uid=" + userid + @";pwd=" + password + ";";
                //    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                //    {
                //        this.connection = new MySql.Data.MySqlClient.MySqlConnection(this.ConnectionText);
                //        this.dataadapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
                //    }
                //    break;
                //case "excel":
                //    connectionText = "Provider=Microsoft.ACE.OLEDB.12.0;Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" + databasefile + ";";
                //    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                //    {
                //        this.connection = new System.Data.OleDb.OleDbConnection(this.ConnectionText);
                //        this.dataadapter = new System.Data.OleDb.OleDbDataAdapter();
                      
                //    }
                //    break;
                //case "oracle":
                //    connectionText = "Driver={Microsoft ODBC for Oracle};Server="+server+";Uid="+userid+";Pwd="+password+";";
                //    if (!string.IsNullOrWhiteSpace(this.ConnectionText))
                //    {
                //        this.connection = new System.Data.Odbc.OdbcConnection(this.ConnectionText);
                //        this.dataadapter = new System.Data.Odbc.OdbcDataAdapter();
                //    }
                //    break;
            }
        }
        #endregion     

        #region private DateTime GetDateTime() 获取数据库当前日期时间
        /// <summary>
        /// 获取数据库当前日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        private DateTime GetDateTime()
        {
            return this.DataBaseAccess.GetDateTime("select getdate()");
        } 
        #endregion

        #endregion

        #region 公开方法

        #region GetDataTable

        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string sql)
        {
            return this.DataBaseAccess.GetDataTable(sql);
        }

        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="Parameters">参数</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string sql, Dictionary<string, object> Parameters)
        {

            return this.DataBaseAccess.GetDataTable(sql, Parameters);
        }
        #endregion 

        #endregion
    }
}
