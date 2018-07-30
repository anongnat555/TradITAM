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
            n.ShowDialog();
            this.Close();
        }
    }
}
