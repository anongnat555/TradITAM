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

            MainWindowViewModel vm = new MainWindowViewModel(UserList);
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Reload(object sender, RoutedEventArgs e)
        {
            MainWindow n = new MainWindow(UserInfo);
            n.Show();
            this.Close();
        }
    }
}
