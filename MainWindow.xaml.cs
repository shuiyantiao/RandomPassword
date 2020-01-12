using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomPassword
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PasswordViewModel(new PasswordModel(DateTime.Now.Second));
            doCreatePassword.Click += DoCreatePassword_Click;
            passwordBits.SelectedIndex = 0;
            passwordNums.SelectedIndex = 4;
        }

        private void MouseLeftButtonDoubleDownRoutedEvent(object sender, MouseButtonEventArgs e)
        {
            object o = passwordsList.SelectedItem;
            if (o == null)
                return;
            var item = o as PasswordClass;
            Clipboard.SetText(item.Password);
            MessageBox.Show("已复制到剪贴板");
        }

        private void DoCreatePassword_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as PasswordViewModel).ReloadList(Convert.ToInt32((passwordNums.SelectedItem as ComboBoxItem).Content),
                                                          Convert.ToInt32((passwordBits.SelectedItem as ComboBoxItem).Content));
        }
    }
}
