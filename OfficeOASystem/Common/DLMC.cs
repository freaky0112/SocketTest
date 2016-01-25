using System;
using System.ComponentModel;


namespace OfficeOASystem.Common {
    /// <summary>
    /// 地类名称
    /// </summary>
    public partial class DLMC : INotifyPropertyChanged {
        //double shuitian;
        ///// <summary>
        ///// 水田
        ///// </summary>
        //public double Shuitian {
        //    get { return shuitian; }
        //    set { shuitian = value; }
        //}

        //double handi;
        ///// <summary>
        ///// 旱地
        ///// </summary>
        //public double Handi {
        //    get { return handi; }
        //    set { handi = value; }
        //}

        //double shuitian_lv;
        ///// <summary>
        ///// 水田等级
        ///// </summary>
        //public double Shuitian_lv {
        //    get { return shuitian_lv; }
        //    set { shuitian_lv = value; }
        //}

        //double handi_lv;
        ///// <summary>
        ///// 旱地等级
        ///// </summary>
        //public double Handi_lv {
        //    get { return handi_lv; }
        //    set { handi_lv = value; }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        string name;
        /// <summary>
        /// 类型
        /// </summary>
        public string Name {
            get { return name; }
            set {
                name = value;
                this.NotifyPropertyChanged("Name");
            }
        }

        string summary;
        /// <summary>
        /// 含义
        /// </summary>
        public string Summary {
            get { return summary; }
            set { summary = value; }
        }

        string generaldesignation;
        /// <summary>
        /// 统称
        /// </summary>
        public string GeneralDesignation {
            get { return generaldesignation; }
            set { generaldesignation = value; }
        }

        string code;
        /// <summary>
        /// 地类代码
        /// </summary>
        public string Code {
            get { return code; }
            set { code = value; }
        }

        double? level;
        /// <summary>
        /// 等级
        /// 非耕地类无等级
        /// </summary>
        public double? Level {
            get { return level; }
            set { level = value;
                this.NotifyPropertyChanged("Level");
            }
        }

        double area;
        /// <summary>
        /// 面积
        /// </summary>
        public double Area {
            get { return area; }
            set {
                area = Math.Round(value, 4);
                this.NotifyPropertyChanged("Area");
            }
        }
    }

    public partial class DLMC {
        DLMC dlmc;

        public DLMC Dlmc {
            get { return dlmc; }
            set { dlmc = value; }
        }
    }
}

