using OfficeOASystem.Common;
/*
 * Created by SharpDevelop.
 * User: Freaky
 * Date: 2015/11/17
 * Time: 9:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using OfficeOASystem.Common.Administrative_Divisions;
using OfficeOASystem.DataOperator;
using OfficeOASystem.Security;
namespace OfficeOASystem
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
        /// <summary>
        /// 初始化赋值
        /// </summary>
        List<DLMC> dlmcs = Load.loadDLMC();
        //private bool loaded = false;
		public Window1()
		{
			InitializeComponent();
            //dlmcs = Load.loadDLMC();
            //MessageBox.Show(dlmcs["011"].Name);
            //RubyHelper.ConfigRead();
            //LuaHelper.ConfigRead();
            //MessageBox.Show(Constant.sshServer+Constant.sshPort+Constant.sshUID+Constant.sshPWD);
            //Transmission.Transfer.sendFile("127.0.0.1", 7788, Constant.XZXZQconfig);
            this.Loaded += Window1_Loaded;
            
            
		}

        void Window1_Loaded(object sender, RoutedEventArgs e) {
            dgdDLMC.ItemsSource = dlmcs;
            //权属性质
            List<string> landOwner = Enum.GetNames(typeof(Constant.LandOwner)).ToList<string>();
            cbxQSXZ.ItemsSource = landOwner;
            //所在乡镇选择
            List<Regionalism> regions = XmlHelper.RegionalismRead();
            cbxXZXZQ.ItemsSource = regions;
            cbxXZXZQ.SelectedIndex = 5;
            //下属行政村选择
            List<Village> villages=XmlHelper.VillagesRead((Regionalism)cbxXZXZQ.SelectedItem);
            cbxCXZQ.ItemsSource = villages;

        }

        private void cbxXZXZQ_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {

        }

        private void cbxXZXZQ_DropDownClosed(object sender, EventArgs e) {
            //下属行政村选择
            List<Village> villages = XmlHelper.VillagesRead((Regionalism)cbxXZXZQ.SelectedItem);
            cbxCXZQ.ItemsSource = villages;
        }





        
	}
}