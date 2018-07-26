using inventory.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace inventory.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public DelegateCommand<object> DeleteCommand { get; set; }
        public DelegateCommand<object> AddUserCommand { get; set; }
        public DelegateCommand<object> SaveChangesCommand { get; set; }
        public ObservableCollection<User> users { get; set; }
        public MainWindowViewModel()
        {
            users = new ObservableCollection<User>();
            getData();
            //deleteData();
            DeleteCommand = new DelegateCommand<object>(deleteData);
            AddUserCommand = new DelegateCommand<object>(AddUser);
            SaveChangesCommand = new DelegateCommand<object>(SaveUser);
        }

        //select
        private void getData()
        {
            var db = new assetEntities();
            var con = db.user_login.ToList();
            listStr = new ObservableCollection<user_login>(con);
            db.Dispose();

        }

        private ObservableCollection<user_login> _listStr = new ObservableCollection<user_login>();
        public ObservableCollection<user_login> listStr
        {
            get => _listStr;
            set
            {
                _listStr = value;
                OnPropertyChanged(nameof(listStr));
            }
        }

       


        //delete
        private user_login _selecteddata;
        public user_login Selecteddata
        {
            get => _selecteddata;
            set
            {
                _selecteddata = value;
                OnPropertyChanged(nameof(Selecteddata));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private void deleteData(object obj)
        {
            using (assetEntities db = new assetEntities())
            {
                user_login user_ = db.user_login.Find(Selecteddata.user_id);
                db.user_login.Remove(user_);
                db.SaveChanges();
            }
            getData();
        }
        //insert
        private int _userid;
        private string _username;
        private string _password;
        private int _userrole;
        private bool _isactive;
        private DateTime _createdate;
        private DateTime _modifieddate;


        public int UserId
        {
            get => _userid;
            set
            {
                _userid = value;
                OnPropertyChanged(nameof(UserId));
            }
        }


        public string UserName
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
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

        public DateTime CreateDate
        {
            get => _createdate;
            set
            {
                _createdate = value;
                OnPropertyChanged(nameof(CreateDate));
            }
        }

        public DateTime ModifiedDate
        {
            get => _modifieddate;
            set
            {
                _modifieddate = value;
                OnPropertyChanged(nameof(ModifiedDate));
            }

        }

        private void AddUser(object o)
        {
            using (var db = new assetEntities())
            {
                var data = new user_login
                {
                    user_id = UserId,
                    username = UserName,
                    password = Password,
                    user_role = Userrole,
                    is_active = Isactive,
                    create_date = CreateDate,
                    modified_date = ModifiedDate
                };
                Console.WriteLine(data);
                db.user_login.Add(data);
                db.SaveChanges();
                
            }
            getData();
           
        }
        //update
        public user_login CurrentUser { get; set; }
        private void SaveUser(object o)
        {
            using (assetEntities db = new assetEntities())
            {
                user_login user_ = db.user_login.Find(Selecteddata.user_id);
                Console.WriteLine(user_.username);
                user_.user_id = Selecteddata.user_id;
                user_.username = Selecteddata.username;
                user_.password = Selecteddata.password;
                user_.user_role = Selecteddata.user_role;
                user_.is_active = Selecteddata.is_active;
                user_.create_date = Selecteddata.create_date;
                user_.modified_date = Selecteddata.modified_date;
                db.SaveChanges();
            }
            getData();

        }
    }
}

