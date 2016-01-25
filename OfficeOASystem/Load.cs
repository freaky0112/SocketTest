using OfficeOASystem.Common;
using OfficeOASystem.DataOperator;
using System;
using System.Collections.Generic;

namespace OfficeOASystem {


    public static class Load {
        public static List<DLMC> loadDLMC() {
            List<DLMC> dlmcs = XmlHelper.FieldTypeRead();
            ;
            return dlmcs;
        }

        public static bool sshConnected() {

            if(Methods.sshConnected(Constant.sshServer, Constant.sshPort, Constant.sshUID, Constant.sshPWD)) {
                return true;
            } else {
                throw new Exception("");
            }            
        }

    }
}

