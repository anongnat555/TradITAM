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

namespace TradITAM.View
{
    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow(/*taff pStaff*/)
        {
            InitializeComponent();
            //this.DataContext = CreateWindowViewModel(pStaff);
        }

        //public CreateWindow(Staff pStaff)
        //{
        //    this.DataContext = CreateWindowViewModel(pStaff);
        //}

        public void Button_ClearAsset(object sender, RoutedEventArgs e)
        {
            cb1.SelectedIndex = -1;
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
