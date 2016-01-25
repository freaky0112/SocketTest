using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpLua;


namespace OfficeOASystem.Security {
    public abstract class LuaHelper {
        public static void ConfigRead() {
            LuaInterface lua = LuaRuntime.GetLua();

            //lua.RegisterFunction("getSSHInfo", my, my.GetType().GetMethod("getSSHInfo"));
            lua.DoFile(Constant.Config);
            object[] objs= lua.GetFunction("getSSHInfo").Call();
            Constant.sshServer = objs[0].ToString();
            Constant.sshPort =Int32.Parse(objs[1].ToString());
            Constant.sshUID = objs[2].ToString();
            Constant.sshPWD = objs[3].ToString();
        }
    }
}
