using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControl_change_interface4
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public  int i = 0;

        private  string _myStr = "0";
        public  string myStr //Label 标签内容绑定到这个myStr字符串
        {
            get { return _myStr; }
            set
            {
                _myStr = value;
                OnPropertyChanged("myStr");//异步更新属性
            }
        }
        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;//设置绑定数据的上下文为UserControl1类
        }

        //累加按键处理事件
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i++;//按一下数值累加一次
            myStr = i.ToString();//把累加完后的数值转换成字符串赋给标签内容值（立刻更新标签内容）
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            i = 0;
            myStr = "0";
        }
    }
}
