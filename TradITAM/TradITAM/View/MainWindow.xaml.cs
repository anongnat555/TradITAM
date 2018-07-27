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

        public MainWindow(UserData UserList)
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(UserList);
        }

        private void btnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            AddStaffWindow n = new AddStaffWindow();
            n.Show();
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            AddSupplierWindow n = new AddSupplierWindow();
            n.Show();
        }

        private void Button_EditAsset(object sender, RoutedEventArgs e)
        {
            UpdateAssetWindow n = new UpdateAssetWindow();
            n.Show();
        }
    }
}
