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
    /// Interaction logic for UpdateStaffWindow.xaml
    /// </summary>
    public partial class UpdateStaffWindow : Window
    {
        #region Global Variable
        private UserData UserInfo { get; set; }
        #endregion

        public UpdateStaffWindow(UserData UserList)
        {
            InitializeComponent();
            this.DataContext = new UpdateStaffWindowViewModel(UserList);

            UserInfo = new UserData();
            UserInfo = UserList;
        }

        

        private void Button_Clear(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClearStaff(object sender, RoutedEventArgs e)
        {
            UpdateStaffWindow n = new UpdateStaffWindow(UserInfo);
            this.Close();
            n.ShowDialog();
        }
    }
}
