using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradITAM.Helper;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
    public class RegisterWindowViewModel : ViewModelBase
    {
        #region Global variable
        public DelegateCommand<object> AddUserCommand { get; set; }

        private UserData UserInfo { get; set; }
        #endregion

        public RegisterWindowViewModel(UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;

            /* Define AddEvent using DelegateCommand */
            AddUserCommand = new DelegateCommand<object>(AddUser);
        }

        #region A Property use for Database
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

        #region A Property use for Log
        private HistoryData _listusernew = new HistoryData();
        public HistoryData historyUser
        {
            get { return _listusernew; }
            set
            {
                _listusernew = value;
                OnPropertyChanged(nameof(historyUser));
            }
        }
        #endregion

        #region Load User Data
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private int _user_role;
        public int User_role
        {
            get => _user_role;
            set
            {
                _user_role = value;
                OnPropertyChanged(nameof(User_role));
            }
        }

        private bool _is_active;
        public bool Is_active
        {
            get => _is_active;
            set
            {
                _is_active = value;
                OnPropertyChanged(nameof(Is_active));
            }
        }

        /* for check condition */
        private string _password_confirm;
        public string Password_confirm
        {
            get => _password_confirm;
            set
            {
                _password_confirm = value;
                OnPropertyChanged(nameof(Password_confirm));
            }
        }
        #endregion

        #region Method
        public void AddUser(object o)
        {
            UserList.username = Username;
            UserList.password = Password;
            UserList.is_active = Is_active;

            if (Password == Password_confirm)
            {
                var insertion = new InsertAccess();
                insertion.AddUser(UserList);

                /*  Add User Log */
                historyUser.User_id = UserInfo.user_id;
                historyUser.Detail = "Insert " + Username + " in UserLogin Table";
                var insertionLog = new InsertAccess();
                insertionLog.LogHistory(historyUser);
            }
            else
            {
                MessageBox.Show("Password is not correct!");
            }
        }
        #endregion
    }
}
