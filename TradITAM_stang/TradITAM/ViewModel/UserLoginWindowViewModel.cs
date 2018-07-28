using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradITAM.Helper;
using TradITAM.Model;
using TradITAM.View;

namespace TradITAM.ViewModel
{
    public class UserLoginWindowViewModel : ViewModelBase
    {
        public DelegateCommand<object> logincommand { get; set; }
        public UserLoginWindowViewModel()
        {
            logincommand = new DelegateCommand<object>(userLogin);
        }

        #region Properties
        private UserData _listuser = new UserData();
        public UserData UserList
        {
            get => _listuser;
            set
            {
                _listuser = value;
                OnPropertyChanged(nameof(UserList));
            }
        }
        #endregion

        #region Method
        public void userLogin(object o)
        {
            int x;
            var login = new Login();
            x =  login.UserLogin(UserList);
            if ( x == 0)
            {
                MessageBox.Show("Invalid username or password");
               
            }
            else
            {
                UserList.User_id = x;
                MainWindow dashboard = new MainWindow(UserList);
                dashboard.Show();
                MessageBox.Show("Hello");
            }
        }
        #endregion


    }
}
