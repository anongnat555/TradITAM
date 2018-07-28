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
using TradITAM.View;
using TradITAM.Model;
using TradITAM.ViewModel;

namespace TradITAM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(UserData Userlist)
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(Userlist);
        }

        public void Button_Report(object sender, RoutedEventArgs e)
        {
            ReportWindow n = new ReportWindow();
            n.Show();
        }

    }
}
