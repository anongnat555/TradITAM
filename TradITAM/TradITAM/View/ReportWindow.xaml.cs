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
using System.Windows.Shapes;
using TradITAM.Model;
using TradITAM.ViewModel;

namespace TradITAM.View
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        #region Global Variable
        private UserData UserInfo { get; set; }
        #endregion

        public ReportWindow(UserData UserList)
        {
            InitializeComponent();
            this.DataContext = new ReportWindowViewModel(UserList);

            UserInfo = new UserData();
            UserInfo = UserList;
        }

        private void Button_Reload(object sender, RoutedEventArgs e)
        {
            ReportWindow n = new ReportWindow(UserInfo);
            this.Close();
            n.ShowDialog();
        }

        private void Button_ClearReport(object sender, RoutedEventArgs e)
        {
            cb1.SelectedIndex = -1;
            cb2.SelectedIndex = -1;

            tb1.Text = null;

            lb1.Content = null;
            lb2.Content = null;
            lb3.Content = null;
            lb4.Content = null;
            lb5.Content = null;
            lb6.Content = null;
            lb7.Content = null;
            lb8.Content = null;
        }
    }
}
