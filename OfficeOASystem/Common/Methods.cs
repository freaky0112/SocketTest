using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Reflection;
using System.IO;
using Renci.SshNet;

namespace OfficeOASystem.Common {
    public abstract  class Methods {
        /// <summary>
        /// 生成GUID
        /// </summary>
        /// <returns>返回guid值</returns>
        public static string Guid_Genarate() {
            System.Guid guid = new Guid();
            return guid.ToString();
        }
        /// <summary>
        /// 是否为IP
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <returns></returns>
        public static bool isIP(string ipAddress) {
            Regex reg = new Regex(@"(?<ip>(((\d{1,2})|(1\d{2,2})|(2[0-4][0-9])|(25[0-5]))\.){3,3}((\d{1,2})|(1\d{2,2})|(2[0-4][0-9])|(25[0-5])))");
            return reg.IsMatch(ipAddress);
        }
        /// <summary>
        /// 是否为端口号
        /// </summary>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public static bool isPort(string port) {
            Regex reg = new Regex(@"^([0-9]|[1-9]\d|[1-9]\d{2}|[1-9]\d{3}|[1-5]\d{4}|6[0-4]\d{3}|65[0-4]\d{2}|655[0-2]\d|6553[0-5])$");
            return reg.IsMatch(port);
        }
        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="strNumber">数字</param>
        /// <returns></returns>
        public static bool IsNumber(string strNumber) {
            //看要用哪種規則判斷，自行修改strValue即可

            //strValue = @"^\d+[.]?\d*$";//非負數字
            string strValue = @"^\d+(\.)?\d*$";//數字
            //strValue = @"^\d+$";//非負整數
            //strValue = @"^-?\d+$";//整數
            //strValue = @"^-[0-9]*[1-9][0-9]*$";//負整數
            //strValue = @"^[0-9]*[1-9][0-9]*$";//正整數
            //strValue = @"^((-\d+)|(0+))$";//非正整數

            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(strValue);
            return r.IsMatch(strNumber);
        }

        /// <summary>
        /// SSH连接端口转发
        /// </summary>
        /// <param name="server">服务器地址</param>
        /// <param name="port">服务器端口</param>
        /// <param name="uid">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static bool sshConnected(string server, int port, string uid, string pwd) {
            bool sshState = false;
            var client = new SshClient(server, port, uid, pwd);
            try {
                client.Connect();
                Constant.sshConnected = client.IsConnected;
            } catch(Exception ex) {
                throw ex;
            }
            var porcik = new ForwardedPortLocal("localhost", 3306, "localhost", 3306);
            try {
                client.AddForwardedPort(porcik);
                porcik.Start();
                sshState = true;
            } catch(Exception ex) {
                throw ex;
            }
            return sshState;

        }
        // 网上抄来的，将 int 转成字节  
        public static byte[] i2b(int i) {
            return new byte[]{  
                (byte) ((i >> 24) & 0xFF),  
                (byte) ((i >> 16) & 0xFF),  
                (byte) ((i >> 8) & 0xFF),  
                (byte) (i & 0xFF)  
        };
        }  

    }
}
