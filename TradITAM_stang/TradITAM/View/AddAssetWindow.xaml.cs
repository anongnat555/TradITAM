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
using TradITAM.ViewModel;
using TradITAM.Model;

namespace TradITAM.View
{
    /// <summary>
    /// Interaction logic for AddAssetWindow.xaml
    /// </summary>
    public partial class AddAssetWindow : Window
    {
        public AddAssetWindow(UserData UserList)
        {
            InitializeComponent();
            this.DataContext = new AddAssetWindowViewModel(UserList);
        }

        public void Button_ClearAsset(object sender, RoutedEventArgs e)
        {
            //cb1.SelectedIndex = -1;
            cb2.SelectedIndex = -1;
            cb3.SelectedIndex = -1;
            cb4.SelectedIndex = -1;
            cb5.SelectedIndex = -1;

            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;
            tb4.Text = null;
            tb5.Text = null;

            dp1.Text = null;
            dp2.Text = null;

            tgb1.IsChecked = false;
        }
    }
}
