using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradITAM.Helper;

namespace TradITAM.ViewModel
{
    public class RegisterWindowViewModel : ViewModelBase
    {
        public DelegateCommand<object> AddUserCommand { get; set; }
        public RegisterWindowViewModel()
        {
            getUser();
            AddUserCommand = new DelegateCommand<object>(AddUser);
        }

        //select user 
        private string _username;
        private string _password;
        private int _userrole;
        private bool _isactive;

        private void getUser()
        {
            var db = new TradAssetDBEntities();
            var con = db.user_login.ToList();
            _listuser = new ObservableCollection<user_login>(con);
            db.Dispose();
            
        }
       
        private ObservableCollection<user_login> _listuser = new ObservableCollection<user_login>();
        public ObservableCollection<user_login> listuser
        {
            get => _listuser;
            set
            {
                _listuser = value;
                OnPropertyChanged(nameof(listuser));
            }
        }

      

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public int Userrole
        {
            get => _userrole;
            set
            {
                _userrole = value;
                OnPropertyChanged(nameof(Userrole));
            }
        }

        public bool Isactive
        {
            get => _isactive;
            set
            {
                _isactive = value;
                OnPropertyChanged(nameof(Isactive));
            }
        }

        private void AddUser(object o)
        {
            try
            {
                using (var db = new TradAssetDBEntities())
                {
                    var data = new user_login
                    {
                        username = Username,
                        password = Password,
                        user_role = Userrole,
                        is_active = Isactive,
                        create_date = DateTime.Now,
                        modified_date = DateTime.Now
                    };
                    Console.WriteLine(data);
                    db.user_login.Add(data);
                    db.SaveChanges();

                }
                getUser();
                MessageBox.Show("Insert complete");

            }
            catch (Exception)
            {
                MessageBox.Show("Insert incomplete");

            }
        }

    }
}
