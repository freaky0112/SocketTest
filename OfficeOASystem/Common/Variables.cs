using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeOASystem.Common {
    class Variables {
    }

    
    /// <summary>
    /// 地块
    /// </summary>
    public class DK {

        string name;
        /// <summary>
        /// 地块名称
        /// </summary>
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private int qsxz;
        /// <summary>
        /// 权属性质
        /// </summary>
        public int QSXZ {
            get { return qsxz; }
            set { qsxz = value; }
        }

        string town;
        /// <summary>
        /// 乡(镇)街道
        /// </summary>
        public string Town {
            get { return town; }
            set { town = value; }
        }

        string village;
        /// <summary>
        /// 村
        /// </summary>
        public string Village {
            get { return village; }
            set { village = value; }
        }


        List<DLMC> dlmc;
        /// <summary>
        /// 地类统计
        /// </summary>
        public List<DLMC> Dlmc {
            get { return dlmc; }
            set { dlmc = value; }
        }

        double gjlyd;
        /// <summary>
        /// 国家利用等级
        /// </summary>
        public double GJLYD {
            get { return gjlyd; }
            set { gjlyd = value; }
        }

        string guid;
        /// <summary>
        /// guid
        /// </summary>
        public string GUID {
            get { return guid; }
            set { guid = value; }
        }

        private string summary;
        /// <summary>
        /// 备注
        /// </summary>
        public string Summary {
            get { return summary; }
            set { summary = value; }
        }

        List<GdalPoint> points;
        /// <summary>
        /// 地块坐标
        /// </summary>
        public List<GdalPoint> Points {
            get { return points; }
            set { points = value; }
        }
        
    }
    /// <summary>
    /// 坐标点
    /// </summary>
    public  class GdalPoint {
        /// <summary>
        /// 初始化坐标
        /// </summary>
        public GdalPoint() {
            x = 0;
            y = 0;
        }
        /// <summary>
        /// 生成类
        /// </summary>
        /// <param name="origin_x">X坐标</param>
        /// <param name="origin_y">Y坐标</param>
        public GdalPoint(double origin_x, double origin_y) {
            x = origin_x;
            y = origin_y;
        }
        double x;
        /// <summary>
        /// X轴变量
        /// </summary>
        public double X {
            get { return x; }
            set { x = value; }
        }

        double y;
        /// <summary>
        /// Y轴变量
        /// </summary>
        public double Y {
            get { return y; }
            set { y = value; }
        }

        private int no;
        /// <summary>
        /// 地块编码
        /// </summary>
        public int No {
            get { return no; }
            set { no = value; }
        }
        /// <summary>
        /// 重戴运算符+
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static GdalPoint operator +(GdalPoint p1, GdalPoint p2) {
            return new GdalPoint(p1.x + p2.x, p1.y + p2.y);
        }
        /// <summary>
        /// 重载运算符-
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static GdalPoint operator -(GdalPoint p1, GdalPoint p2) {
            return new GdalPoint(p1.x - p2.x, p1.y - p2.y);
        }
        
    }
}
