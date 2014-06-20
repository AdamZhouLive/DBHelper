using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBHelper
{
    public abstract class DataBaseAccess
    {
        #region 变量      
        private IDbCommand command;
        private IDbDataAdapter dataadapter;
        private IDbConnection connection;
        #endregion

        #region 属性

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
            set { connection = value; }
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
            set { command = value; }
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
            set { dataadapter = value; }
        }
        #endregion 

        #endregion

        public abstract DataTable GetDataTable(string sql);

        public abstract DataTable GetDataTable(string sql, Dictionary<string, string> Parameters);

        public abstract IDataReader GetDataTableReader(string sql);

    }
}
