using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace DBHelper
{
    public class SqlServer
    {

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
