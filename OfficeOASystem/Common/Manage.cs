using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace OfficeOASystem.Common {
    /// <summary>
    /// 农转用批次补充耕地方案
    /// </summary>
    public class NZYbatch {
        string batch;
        /// <summary>
        /// 批次号
        /// </summary>
        public string Batch {
            get { return batch; }
            set { batch = value; }
        }

        List<DK> dks;
        /// <summary>
        /// 分地块信息
        /// </summary>
        public List<DK> Dks {
            get { return dks; }
            set { dks = value; }
        }
    }
    /// <summary>
    /// 补充耕地台帐
    /// </summary>
    public class CultivatedAccounting {
        List<CultivatedProject> projbets;
        /// <summary>
        /// 补充耕地项目
        /// </summary>
        public List<CultivatedProject> Projbets {
            get { return projbets; }
            set { projbets = value; }
        }

    }
    /// <summary>
    /// 补充耕地项目
    /// </summary>
    public class CultivatedProject {
        string guid;
        /// <summary>
        /// guid
        /// </summary>
        public string GUID {
            get { return guid; }
            set { guid = value; }
        }

        string project;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Project {
            get { return project; }
            set { project = value; }
        }
        string check_no;
        /// <summary>
        /// 验收文号
        /// </summary>
        public string Check_No {
            get { return check_no; }
            set { check_no = value; }
        }
        string record_no;
        /// <summary>
        /// 部备案号
        /// </summary>
        public string Record_No {
            get { return record_no; }
            set { record_no = value; }
        }

        List<DK> dks;
        /// <summary>
        /// 分地块信息
        /// </summary>
        public List<DK> Dks {
            get { return dks; }
            set { dks = value; }
        }


    }


}
