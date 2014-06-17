using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace DBHelper
{
    public class SqlServer
    {

        #region 变量
        private string connectionText;
        private string server;
        private string database;
        private string userid;
        private string password; 
        #endregion

        #region string ConnectionText 数据库连接字符串
        public string ConnectionText { get { return connectionText; } } 
        #endregion

        #region string Server 数据库服务器
        public string Server { get { return server; } set { server = value; connectionText = "server=" + server + ";database=" + database + ";user id=" + userid + ";password=" + password; } } 
        #endregion

        #region string DataBase 数据库名称
        public string DataBase { get { return database; } set { database = value; connectionText = "server=" + server + ";database=" + database + ";user id=" + userid + ";password=" + password; } }
        #endregion

        #region string UserId 数据库用户名称
        public string UserId { get { return userid; } set { userid = value; connectionText = "server=" + server + ";database=" + database + ";user id=" + userid + ";password=" + password; } }
        #endregion

        #region string Password 数据库用户密码
        public string Password { get { return password; } set { password = value; connectionText = "server=" + server + ";database=" + database + ";user id=" + userid + ";password=" + password; } }
        #endregion

        public SqlServer()
        {
            this.Server = string.Empty;
            this.DataBase = string.Empty;
            this.UserId = string.Empty;
            this.Password = string.Empty;
        }

        public SqlServer(string ConnectionText)
        {
            this.Server = string.Empty;
            this.DataBase = string.Empty;
            this.UserId = string.Empty;
            this.Password = string.Empty;
            this.connectionText = ConnectionText;
        }

        public SqlServer(string Server, string DataBase, string UserId, string Password)
        {
            this.Server = Server;
            this.DataBase = DataBase;
            this.UserId = UserId;
            this.Password = Password;
        }

    }
}
