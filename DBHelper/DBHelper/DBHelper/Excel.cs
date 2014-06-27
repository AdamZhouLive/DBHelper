using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace DBHelper
{
    /// <summary>
    /// Excel连接器
    /// </summary>
    public class Excel:DataBaseAccess
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Excel()
        {
            this.Connection = null;
            this.Command = null;
            this.DataAdapter = null;
            this.ConnectionOffline = null;
            this.CommandOffline = null;
            this.DataAdapterOffline = null;
            this.DataReader = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ConnectionText">连接字符串</param>
        public Excel(string ConnectionText)
        {
            this.Connection = new System.Data.OleDb.OleDbConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.ConnectionOffline = new System.Data.OleDb.OleDbConnection(ConnectionText);
            this.CommandOffline = this.Connection.CreateCommand();
            this.DataAdapterOffline = new System.Data.OleDb.OleDbDataAdapter();
            this.DataReader = null;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DataBasePath">数据库路径</param>
        /// <param name="DataBaseFileName">数据库文件名</param>
        public Excel(string DataBasePath, string DataBaseFileName)
        {
            string DataBaseFile = DataBasePath + @"\" + DataBaseFileName;
            string ConnectionText = "Provider=Microsoft.ACE.OLEDB.12.0;Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=" + DataBaseFile + ";";
            this.Connection = new System.Data.OleDb.OleDbConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.OleDb.OleDbDataAdapter();
            this.ConnectionOffline = new System.Data.OleDb.OleDbConnection(ConnectionText);
            this.CommandOffline = this.Connection.CreateCommand();
            this.DataAdapterOffline = new System.Data.OleDb.OleDbDataAdapter();
            this.DataReader = null;

        } 

        #endregion
    }
}
