using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TradITAM.Model;
using TradITAM.Helper;
using System.Windows;

namespace TradITAM.ViewModel
{
    public class UpdateStaffWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> UpdateStaffCommand { get; set; }

        private UserData UserInfo { get; set; }
        #endregion

        public UpdateStaffWindowViewModel(UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;

            /* Define UpdateEvent using DelegateCommand */
            UpdateStaffCommand = new DelegateCommand<object>(UpdateStaff);

            LoadStaff();    //Load 'Staff' from database to get 'AKA' in combobox
        }

        #region Call DataAccess
        private DataAccess _DataAccess;
        public DataAccess DataAccess
        {
            get
            {
                if (_DataAccess == null)
                    _DataAccess = new DataAccess();
                return _DataAccess;
            }
        }
        #endregion

        #region A Property use for Database
        private StaffData _newstaff = new StaffData();
        public StaffData Staffnew
        {
            get => _newstaff;
            set
            {
                _newstaff = value;
                OnPropertyChanged(nameof(Staffnew));
            }
        }
        #endregion

        #region A Property use for Log
        private HistoryData _listuser = new HistoryData();
        public HistoryData historyUser
        {
            get { return _listuser; }
            set
            {
                _listuser = value;
                OnPropertyChanged(nameof(historyUser));
            }
        }
        #endregion

        #region checkbox value
        private bool _check;
        public bool Check
        {
            get { return _check; }
            set
            {
                _check = value;
                OnPropertyChanged(nameof(Check));
            }
        }
        #endregion

        #region Staff
        private ObservableCollection<StaffData> _liststaff = new ObservableCollection<StaffData>();
        public ObservableCollection<StaffData> StaffList
        {
            get => _liststaff;
            set
            {
                _liststaff = value;
                OnPropertyChanged(nameof(StaffList));
            }
        }

        private StaffData _SelectedStaff;
        public StaffData SelectedStaff
        {
            get => _SelectedStaff;
            set
            {
                _SelectedStaff = value;
                OnPropertyChanged(nameof(SelectedStaff));

                //update textbox after selected
                GetStaffInformation(SelectedStaff);
            }
        }

        private ICollectionView _StaffCollectionView;
        public ICollectionView StaffCollectionView
        {
            get { return _StaffCollectionView; }
            set
            {
                _StaffCollectionView = value;
                OnPropertyChanged(nameof(StaffCollectionView));
            }
        }

        private Collection<StaffData> _StaffCollection;
        public Collection<StaffData> StaffCollection
        {
            get { return _StaffCollection; }
            set { _StaffCollection = value; }
        }

        public void GetStaffInformation(Object obj)
        {
            /* Assign value from UI (Bindinig) */
            if (SelectedStaff != null)
            {
                Staff_id = SelectedStaff.staff_id;
                Aka = SelectedStaff.aka;
                Firstname = SelectedStaff.firstname;
                Lastname = SelectedStaff.lastname;
                Is_active = SelectedStaff.is_active;
                Start_date = SelectedStaff.start_date;
                End_date = SelectedStaff.end_date;

                if(End_date != DateTime.MinValue)
                {
                    Check = true;
                }
                else
                {
                    Check = false;
                }
            }
        }

        #endregion

        #region Load Data
        private int _staffid;
        public int Staff_id
        {
            get { return _staffid; }
            set
            {
                _staffid = value;
                OnPropertyChanged(nameof(Staff_id));
            }
        }

        private string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        private string _aka;
        public string Aka
        {
            get { return _aka; }
            set
            {
                _aka = value;
                OnPropertyChanged(nameof(Aka));
            }
        }

        private DateTime _start_date;
        public DateTime Start_date
        {
            get { return _start_date; }
            set
            {
                _start_date = value;
                OnPropertyChanged(nameof(Start_date));
            }
        }

        private DateTime _end_date;
        public DateTime End_date
        {
            get { return _end_date; }
            set
            {
                _end_date = value;
                OnPropertyChanged(nameof(End_date));
            }
        }

        private bool _is_active;
        public bool Is_active
        {
            get { return _is_active; }
            set
            {
                _is_active = value;
                OnPropertyChanged(nameof(Is_active));
            }
        }
        #endregion

        #region Method
        public void LoadStaff()
         {
            StaffList = DataAccess.GetStaff();
            StaffCollectionView = CollectionViewSource.GetDefaultView(StaffList);
        }

        public void UpdateStaff(object o)
        {
            if (SelectedStaff != null)
            {
                Staffnew.staff_id = Staff_id;
                Staffnew.aka = Aka;
                Staffnew.firstname = Firstname;
                Staffnew.lastname = Lastname;
                Staffnew.is_active = Is_active;
                Staffnew.start_date = Start_date;
                if (Check == false) {
                    Staffnew.end_date = DateTime.MinValue;
                }
                else
                {
                    Staffnew.end_date = End_date;
                }
            }
            var update = new UpdateAccess();
            update.UpdateStaff(Staffnew);

            /*  Add User Log */
            historyUser.User_id = UserInfo.user_id;
            historyUser.History_id = 2;
            historyUser.Detail = "Update " + Staffnew.aka + " in Staff Table";
            var insertionLog = new InsertAccess();
            insertionLog.LogHistory(historyUser);
        }

        #endregion
    }
}
