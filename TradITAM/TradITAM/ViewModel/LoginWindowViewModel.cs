using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradITAM.Helper;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public DelegateCommand<object> LoginCommand { get; set; }
        public LoginWindowViewModel()
        {
            LoginCommand = new DelegateCommand<object>(LoginCheck);
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
        public void LoginCheck(object o)
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
                UserList.User_id = user_id;
                MainWindow n = new MainWindow(UserList);
                n.Show();
            }
        }
        #endregion

    }
}
