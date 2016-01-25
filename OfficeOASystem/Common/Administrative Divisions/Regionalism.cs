using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeOASystem.Common.Administrative_Divisions {
    /// <summary>
    /// 镇级行政区划
    /// </summary>
    public class Regionalism {
        /// <summary>
        /// 初始化类
        /// </summary>
        public Regionalism(){
            }

        string xzqdm;
        /// <summary>
        /// 行政区编码
        /// </summary>
        public string XZQDM {
            get { return xzqdm; }
            set { xzqdm = value; }
        }

        string xzqmc;
        /// <summary>
        /// 行政区名称
        /// </summary>
        public string XZQMC {
            get { return xzqmc; }
            set { xzqmc = value; }
        }

        public override string ToString() {
            return XZQMC;
        }
    }

    public class Village {
        /// <summary>
        /// 初始化类
        /// </summary>
        public Village() { }

        string xzqdm;
        /// <summary>
        /// 行政区编码
        /// </summary>
        public string XZQDM {
            get { return xzqdm; }
            set { xzqdm = value; }
        }

        string xzqmc;
        /// <summary>
        /// 行政区名称
        /// </summary>
        public string XZQMC {
            get { return xzqmc; }
            set { xzqmc = value; }
        }

        public override string ToString() {
            return XZQMC;
        }
    }
}
