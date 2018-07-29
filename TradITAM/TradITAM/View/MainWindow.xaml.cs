using System;
using System.Collections.Generic;
using System.Data;
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
using TradITAM.Model;
using TradITAM.View;
using TradITAM.ViewModel;

namespace TradITAM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Global Variable
        private UserData UserInfo { get; set; }
        #endregion

        public MainWindow(UserData UserList)
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(UserList);

            UserInfo = new UserData();
            UserInfo = UserList;
        }

        #region Open Add Form
        private void Button_Add_Asset(object sender, RoutedEventArgs e)
        {
            AddAssetWindow n = new AddAssetWindow();
            n.Show();
        }

        private void Button_Add_Staff(object sender, RoutedEventArgs e)
        {
            AddStaffWindow n = new AddStaffWindow();
            n.Show();
        }

        private void Button_Add_Supplier(object sender, RoutedEventArgs e)
        {
            AddSupplierWindow n = new AddSupplierWindow();
            n.Show();
        }
        #endregion

        #region Open Update Form
        private void Button_Update_Asset(object sender, RoutedEventArgs e)
        {
            UpdateAssetWindow n = new UpdateAssetWindow();
            n.Show();
        }

        private void Button_Update_Staff(object sender, RoutedEventArgs e)
        {
            UpdateStaffWindow n = new UpdateStaffWindow();
            n.Show();
        }

        private void Button_Update_Supplier(object sender, RoutedEventArgs e)
        {
            UpdateSupplierWindow n = new UpdateSupplierWindow();
            n.Show();
        }
        #endregion

    }
}
