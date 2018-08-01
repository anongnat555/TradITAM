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
    /// Interaction logic for UpdateAssetWindow.xaml
    /// </summary>
    public partial class UpdateAssetWindow : Window
    {
        public UpdateAssetWindow(UserData UserList)
        {
            InitializeComponent();
            this.DataContext = new UpdateAssetWindowViewModel(UserList);
        }

        public void Button_ClearAsset(object sender, RoutedEventArgs e)
        {
            cb1.SelectedIndex = -1;
            cb2.SelectedIndex = -1;
            cb3.SelectedIndex = -1;
            cb4.SelectedIndex = -1;
            cb5.SelectedIndex = -1;
            cb6.SelectedIndex = -1;
            cb7.SelectedIndex = -1;

            cb1.Text = null;
            cb2.Text = null;
            cb3.Text = null;
            cb4.Text = null;
            cb5.Text = null;
            cb6.Text = null;
            cb7.Text = null;

            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;
            tb4.Text = null;
            tb5.Text = null;

            dp1.SelectedDate = DateTime.MinValue;
            dp2.SelectedDate = DateTime.MinValue;

            tgb1.IsChecked = false;
        }
    }
}
