using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
    public class UserInfo
    {
        #region 变量
        private string userno;
        private string userpwd;
        private string username;
        private List<string> role; 
        #endregion

        #region 属性

        #region string UserNo 用户代号
        /// <summary>
        /// 用户代号
        /// </summary>
        public string UserNo { get { return userno; } set { userno = value; } }
        #endregion 

        #region string UserPwd 用户密码
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd { get { return userpwd; } set { userpwd = value; } }
        #endregion 

        #region string UserName 用户名称
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get { return username; } set { username = value; } }
        #endregion 

        #region List<string> Role 角色
        /// <summary>
        /// 角色
        /// </summary>
        public List<string> Role { get { return role; } set { role = value; } }
        #endregion 

        #region string XmlString 用户信息XML字符串
        /// <summary>
        /// 用户信息XML字符串
        /// </summary>
        public string XmlString { get { return ToXmlString(); }  }
        #endregion 

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserInfo()
        {
            this.UserNo = string.Empty;
            this.UserPwd = string.Empty;
            this.UserName = string.Empty;
            this.Role = new List<string>();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xmlString">用户信息</param>
        public UserInfo(string xmlString)
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(xmlString);

            try
            {
                this.UserNo = xmlDoc.SelectSingleNode("//UserNo").InnerText;
                this.UserPwd = xmlDoc.SelectSingleNode("//UserPwd").InnerText;
                this.UserName = xmlDoc.SelectSingleNode("//UserName").InnerText;
                this.Role = new List<string>();

                System.Xml.XmlNode RoleNode = xmlDoc.SelectSingleNode("//Role");
                foreach (System.Xml.XmlNode r in RoleNode.ChildNodes)
                {
                    this.Role.Add(r.InnerText);
                }
            }
            catch
            {
                this.UserNo = string.Empty;
                this.UserPwd = string.Empty;
                this.UserName = string.Empty;
                this.Role = new List<string>();
            }
        } 

        #endregion



        #region 私有方法

        #region  private string ToXmlString()
        /// <summary>
        /// 把UserInfo对象转换成XML字符串
        /// </summary>
        /// <returns>用户信息XML字符串</returns>
        private string ToXmlString()
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            System.Xml.XmlElement element;
            System.Xml.XmlNode node;

            node = xmlDoc.CreateElement("UserInfo");
            xmlDoc.AppendChild(node);

            element = xmlDoc.CreateElement("UserNo");
            element.InnerText = this.UserNo;
            node.AppendChild(element);

            element = xmlDoc.CreateElement("UserPwd");
            element.InnerText = this.UserPwd;
            node.AppendChild(element);

            element = xmlDoc.CreateElement("UserName");
            element.InnerText = this.UserName;
            node.AppendChild(element);

            node = xmlDoc.CreateElement("Role");

            foreach (string r in this.Role)
            {
                element = xmlDoc.CreateElement("Item");
                element.InnerText = r;
                node.AppendChild(element);
            }

            xmlDoc.FirstChild.AppendChild(node);


            return xmlDoc.InnerXml;
        }
        #endregion 

        #endregion

        
    }
}
