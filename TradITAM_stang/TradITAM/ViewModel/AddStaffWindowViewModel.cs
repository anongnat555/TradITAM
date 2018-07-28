using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TradITAM.Helper;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
    public class AddStaffWindowViewModel : ViewModelBase
    {
        public DelegateCommand<object> Addstaffcommand { get; set; }
        private UserData User { get; set; }
        public AddStaffWindowViewModel(UserData userlist)
        {
            User = new UserData();
            User = userlist;
            Addstaffcommand = new DelegateCommand<object>(AddStaff);
          
        }
        #region Fields and Properties

        //private Staff CurrentStaff { get; set; }


        private StaffData _liststaff = new StaffData();
        public StaffData StaffList
        {
            get => _liststaff;
            set
            {
                _liststaff = value;
                OnPropertyChanged(nameof(StaffList));
            }
        }

        private HistoryData _listuser = new HistoryData();
        public HistoryData historyUser
        {
            get { return _listuser; }
            set
            { _listuser  = value;
            OnPropertyChanged(nameof(historyUser));
            }
        }


        //public ObservableCollection<Staff> StaffCollectionList { get; set; }


        #endregion

        #region Load History Data
        private int _history_id;
        public int History_id
        {
            get { return _history_id; }
            set
            {
                _history_id = value;
                OnPropertyChanged(nameof(History_id));
            }
        }

        private int _user_id;
        public int User_id
        {
            get { return _user_id; }
            set
            {
                _user_id = value;
                OnPropertyChanged("User_id");
            }
        }

        private int _refernces_id;
        public int Refernces_id
        {
            get { return _refernces_id; }
            set
            {
                _refernces_id = value;
                OnPropertyChanged("Refernces_id");
            }
        }

        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set
            {
                _detail = value;
                OnPropertyChanged("Detail");
            }
        }

        private DateTime _history_timestamp;
        public DateTime History_timestamp
        {
            get { return _history_timestamp; }
            set
            {
                _history_timestamp = value;
                OnPropertyChanged("History_timestamp");
            }
        }

        private int _history_type;
        public int History_type
        {
            get { return _history_type; }
            set
            {
                _history_type = value;
                OnPropertyChanged("History_type");
            }
        }

        #endregion

        #region Method

        public void AddStaff(object o)
        {
            var addstaff = new InsertAccess();
            addstaff.AddStaff(StaffList);

            historyUser.User_id = User.User_id;
            var adduser = new InsertAccess();
            adduser.historyStaff(historyUser);
        }

       
        #endregion
    }
}
