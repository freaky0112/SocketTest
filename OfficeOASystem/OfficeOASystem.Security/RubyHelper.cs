using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronRuby;

namespace OfficeOASystem.Security {
    public abstract class RubyHelper {
        /// <summary>
        /// 读取连接配置文件
        /// </summary>
        public static void ConfigRead() {
            var rubyEngine = Ruby.CreateEngine();
            rubyEngine.ExecuteFile(Constant.Config);
            dynamic ruby = rubyEngine.Runtime.Globals;

            dynamic config = ruby.Config.@new();
            
            #region 获取SSH连接信息
            Constant.sshServer = config.getServer().ToString();
            Constant.sshPort = int.Parse(config.getPort().ToString());
            Constant.sshUID = config.getUID().ToString();
            Constant.sshPWD = config.getPWD().ToString();
            #endregion

        }
    }
}
