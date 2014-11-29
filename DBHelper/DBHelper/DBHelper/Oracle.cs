﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace DBHelper
{
    /// <summary>
    /// Oracle数据库连接器
    /// </summary>
    public class Oracle:DataBaseAccess
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Oracle()
        {
            this.Connection = null;
            this.Command = null;
            this.DataAdapter = null;
            this.ConnectionOffline = null;
            this.CommandOffline = null;
            this.DataAdapterOffline = null;
            this.DataReader = null;
            this.DBType = "Oracle";
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ConnectionText">连接字符串</param>
        public Oracle(string ConnectionText)
        {
            this.ConnectionText = ConnectionText;
            this.Connection = new System.Data.Odbc.OdbcConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
            this.ConnectionOffline = new System.Data.Odbc.OdbcConnection(ConnectionText);
            this.CommandOffline = this.ConnectionOffline.CreateCommand();
            this.DataAdapterOffline = new System.Data.Odbc.OdbcDataAdapter();
            this.DataReader = null;
            this.DBType = "Oracle";
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Server">服务器</param>
        /// <param name="UserId">数据库用户</param>
        /// <param name="Password">用户密码</param>
        public Oracle(string Server, string UserId,string Password)
        {
            ConnectionText =  "Driver={Microsoft ODBC for Oracle};Server=" + Server + ";Uid=" + UserId + ";Pwd=" + Password + ";";
            this.Connection = new System.Data.Odbc.OdbcConnection(ConnectionText);
            this.Command = this.Connection.CreateCommand();
            this.DataAdapter = new System.Data.Odbc.OdbcDataAdapter();
            this.ConnectionOffline = new System.Data.Odbc.OdbcConnection(ConnectionText);
            this.CommandOffline = this.ConnectionOffline.CreateCommand();
            this.DataAdapterOffline = new System.Data.Odbc.OdbcDataAdapter();
            this.DataReader = null;
            this.DBType = "Oracle";

        } 

        #endregion

        #region GetDateTimeNow
        /// <summary>
        /// 使用离线数据库连接器，无需使用Open方法，获取数据库当前时间
        /// </summary>
        public override DateTime GetDateTimeNow()
        {
            DateTime ret = DateTime.Now;
            using (System.Data.Odbc.OdbcConnection con = new System.Data.Odbc.OdbcConnection(this.ConnectionText))
            {
                using (System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand("select sysdate()", con))
                {
                    con.Open();
                    ret = Convert.ToDateTime(cmd.ExecuteScalar());
                    con.Close();
                }
            }

            return ret;
        }
        #endregion
    }
}
