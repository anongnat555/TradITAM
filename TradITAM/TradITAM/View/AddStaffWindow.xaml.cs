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
    /// Interaction logic for AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        public AddStaffWindow(UserData UserList)
        {
            InitializeComponent();
            this.DataContext = new AddStaffWindowViewModel(UserList);
        }

        private void Button_ClearStaff(object sender, RoutedEventArgs e)
        {
            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;

            tgb1.IsChecked = false;

            chb1.IsChecked = false;

            dtp1.SelectedDate = DateTime.MinValue;
            dtp2.SelectedDate = DateTime.MinValue;
        }
    }
}
