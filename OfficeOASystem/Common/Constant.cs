using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOASystem {
    /// <summary>
    /// 常量
    /// </summary>
    public static class Constant {
        #region ssh连接信息
        public static string sshServer = "";
        public static int sshPort;
        public static string sshUID = "";
        public static string sshPWD = "";

        public static Boolean sshConnected = false;
        #endregion


        #region mysql数据库链接
        private const string SERVER = "localhost";

        private const uint PORT = 3306;

        private const string DATABASE = "cfsj";

        private const string UID = "root";

        private const string PWD = "admin";

        private const string CHARSET = "'utf8'";

        public static string table = "";

        /// <summary>
        /// 返回数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string strConntection() {
            StringBuilder conn = new StringBuilder();
            conn.Append("server=");
            conn.Append(SERVER);
            conn.Append(";port=");
            conn.Append(PORT);
            conn.Append(";database=");
            conn.Append(DATABASE);
            conn.Append(";uid=");
            conn.Append(UID);
            conn.Append(";pwd=");
            conn.Append(PWD);
            conn.Append(";charset=");
            conn.Append(CHARSET);
            return conn.ToString();

        }
        #endregion

        #region 配置文件
        /// <summary>
        /// 全国土地利用现状分类
        /// </summary>
        public const string DLMCconfig = @"./Config/DLMC.xml";
        /// <summary>
        /// 镇级行政区分布
        /// </summary>
        public const string XZXZQconfig = @"./Config/XZXZQ.xml";
        /// <summary>
        /// 村级行政区分布
        /// </summary>
        public const string CSZQcofnig = @"./Config/CXZQ.xml";
        /// <summary>
        /// 连接配置文件
        /// </summary>
        public const string Config = @"./Config/Config";
        #endregion
         
        #region 土地权属性质
        public enum LandOwner {
            国有,
            集体
        };




        #endregion
    }
}
