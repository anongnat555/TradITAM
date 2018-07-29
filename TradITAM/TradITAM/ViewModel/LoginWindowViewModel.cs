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
    public class LoginWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> LoginCommand { get; set; }
        #endregion

        public LoginWindowViewModel()
        {
            /* Define 'LoginCommand' to authenticate using DelegateCommand */
            LoginCommand = new DelegateCommand<object>(LoginCheck);
        }

        #region Properties
        /* Define UserList to get value from VIEW */
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
        /* Login Checking */
        public void LoginCheck(object obj)
        {
            int user_id;

            var login = new LoginAccess();
            user_id = login.UserLogin(UserList);

            if (user_id == 0)
            {
                MessageBox.Show("Invalid username or password");
            }
            else
            {
                UserList.user_id = user_id;                 // assign 'User_id' value into 'UserList'
                MainWindow n = new MainWindow(UserList);    // share 'UserList' to MainWindow
                n.Show();
            }
        }
        #endregion

    }
}
