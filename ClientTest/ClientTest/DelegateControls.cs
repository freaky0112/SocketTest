using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClientTest {
    public class DelegateControls {
        protected Control _control;
        public DelegateControls() {
        }

        public DelegateControls(Control control) {
            this._control = control;
        }
        /// <summary>
        /// 代理函数
        /// </summary>
        /// <param name="value">传值</param>
        protected delegate void outputDelegate(object value);
        /// <summary>
        /// 设置控件是否显示
        /// </summary>
        /// <param name="value">Visibility.Hidden||Visibility.Visable</param>
        public void setVisibility(Visibility value) {
            this._control.Dispatcher.Invoke(new outputDelegate(setVisibilityAction), value);
        }

        private void setVisibilityAction(object visibility) {
            this._control.Visibility = (Visibility)visibility;
        }
    }

    public class DelegateListBox : DelegateControls {
        public DelegateListBox(Control control) {
            this._control = control;
        }

        public void addItem(string value) {
            this._control.Dispatcher.Invoke(new outputDelegate(addItemAction), value);
        }

        private void addItemAction(object value) {
            ((ListBox)this._control).Items.Add(value.ToString());
        }

    }
}
