using OfficeOASystem.Common;
using OfficeOASystem.Common.Administrative_Divisions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace OfficeOASystem.DataOperator {
    /// <summary>
    /// Xml文件读写by Linq
    /// </summary>
    public static partial class XmlHelper {
        /// <summary>
        /// 地类信息配置文件读取
        /// </summary>
        /// <returns>地类信息</returns>
        public static List<DLMC> FieldTypeRead() {
            List<DLMC> dlmcs = new List<DLMC>();
            try {
                XElement dlmcconfig = XElement.Load(Constant.DLMCconfig);
                IEnumerable<XElement> elements = from el in dlmcconfig.Elements("GeneralDesignation") select el;
                //List<DLMC> types = new List<DLMC>();
                foreach(XElement general in elements) {
                    foreach(XElement el in general.Nodes()) {
                        DLMC dlmc = new DLMC();
                        //地类名称
                        dlmc.Name = el.Attribute("name").Value;
                        //地类编码
                        dlmc.Code = el.Attribute("code").Value;
                        //地类说明
                        dlmc.Summary = el.Attribute("summary").Value;
                        //总地类说明
                        dlmc.GeneralDesignation = general.Attribute("summary").Value;
                        dlmcs.Add(dlmc);
                    }
                }
            } catch(Exception e) {
                throw e;
            }
            return dlmcs;
        }
        /// <summary>
        /// 读取所有行政区规划乡镇街道
        /// </summary>
        /// <returns></returns>
        public static List<Regionalism> RegionalismRead() {
            List<Regionalism> regions = new List<Regionalism>();
            try {
                XElement xzxzqconfig = XElement.Load(Constant.XZXZQconfig);
                IEnumerable<XElement> elements = from el in xzxzqconfig.Elements("Town") select el;
                foreach(XElement el in elements) {
                    Regionalism region = new Regionalism();
                    //行政区编码
                    region.XZQDM = el.Attribute("XZQDM").Value;
                    //行政区名称
                    region.XZQMC = el.Attribute("XZQMC").Value;
                    regions.Add(region);
                }
            } catch(Exception e) {
                throw e;
            }
            return regions;
        }
        /// <summary>
        /// 读取该乡镇所有村级信息
        /// </summary>
        /// <param name="region">所在乡镇</param>
        /// <returns></returns>
        public static List<Village> VillagesRead(Regionalism region) {
            List<Village> villages = new List<Village>();
            try {
                XElement cxzqconfig = XElement.Load(Constant.CSZQcofnig);
                IEnumerable<XElement> elements = from el in cxzqconfig.Elements("Village")
                                                 where el.Attribute("XZQDM").Value.Contains(region.XZQDM)
                                                 select el;
                foreach(XElement el in elements) {
                    Village village = new Village();
                    //行政区编码
                    village.XZQDM = el.Attribute("XZQDM").Value;
                    //行政区名称
                    village.XZQMC = el.Attribute("XZQMC").Value;
                    villages.Add(village);
                }
            } catch(Exception e) {
                throw e;
            }
            return villages;
        }
    }

    /// <summary>
    /// XmlHelper 的摘要说明
    /// </summary>
    public static partial class XmlHelper {


        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时返回该属性值，否则返回串联值</param>
        /// <returns>string</returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Read(path, "/Node", "")
         * XmlHelper.Read(path, "/Node/Element[@Attribute='Name']", "Attribute")
         ************************************************/
        public static string Read(string path, string node, string attribute) {
            string value = "";
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                value = (attribute.Equals("") ? xn.InnerText : xn.Attributes[attribute].Value);
            } catch {
            }
            return value;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="element">元素名，非空时插入新元素，否则在该元素中插入属性</param>
        /// <param name="attribute">属性名，非空时插入该元素属性值，否则插入元素值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "Element", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Element", "Attribute", "Value")
         * XmlHelper.Insert(path, "/Node", "", "Attribute", "Value")
         ************************************************/
        public static void Insert(string path, string node, string element, string attribute, string value) {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                if(element.Equals("")) {
                    if(!attribute.Equals("")) {
                        XmlElement xe = (XmlElement)xn;
                        xe.SetAttribute(attribute, value);
                    }
                } else {
                    XmlElement xe = doc.CreateElement(element);
                    if(attribute.Equals(""))
                        xe.InnerText = value;
                    else
                        xe.SetAttribute(attribute, value);
                    xn.AppendChild(xe);
                }
                doc.Save(path);
            } catch {
            }
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时修改该节点属性值，否则修改节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Insert(path, "/Node", "", "Value")
         * XmlHelper.Insert(path, "/Node", "Attribute", "Value")
         ************************************************/
        public static void Update(string path, string node, string attribute, string value) {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if(attribute.Equals(""))
                    xe.InnerText = value;
                else
                    xe.SetAttribute(attribute, value);
                doc.Save(path);
            } catch {
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="node">节点</param>
        /// <param name="attribute">属性名，非空时删除该节点属性值，否则删除节点值</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        /**************************************************
         * 使用示列:
         * XmlHelper.Delete(path, "/Node", "")
         * XmlHelper.Delete(path, "/Node", "Attribute")
         ************************************************/
        public static void Delete(string path, string node, string attribute) {
            try {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode xn = doc.SelectSingleNode(node);
                XmlElement xe = (XmlElement)xn;
                if(attribute.Equals(""))
                    xn.ParentNode.RemoveChild(xn);
                else
                    xe.RemoveAttribute(attribute);
                doc.Save(path);
            } catch {
            }
        }
    }
}
