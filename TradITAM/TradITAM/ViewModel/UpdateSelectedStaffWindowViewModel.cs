using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradITAM.Helper;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
    public class UpdateSelectedStaffWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> Updatecommand { get; set; }

        private UserData UserInfo { get; set; }
        #endregion

        public UpdateSelectedStaffWindowViewModel(StaffData StaffSelect, UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;

            LoadSelected(StaffSelect);
            Updatecommand = new DelegateCommand<object>(Update);
        }

        #region Load Staff Data
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

        private DateTime _create_date;
        public DateTime Create_date
        {
            get { return _create_date; }
            set
            {
                _create_date = value;
                OnPropertyChanged(nameof(Create_date));
            }
        }

        private DateTime _modified_date;
        public DateTime Modified_date
        {
            get { return _modified_date; }
            set
            {
                _modified_date = value;
                OnPropertyChanged(nameof(Modified_date));
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

        #region Method
        public void LoadSelected(StaffData StaffSelect)
        {
            Staff_id = StaffSelect.staff_id;
            Aka = StaffSelect.aka;
            Firstname = StaffSelect.firstname;
            Lastname = StaffSelect.lastname;
            Is_active = StaffSelect.is_active;
            Start_date = StaffSelect.start_date;
            End_date = StaffSelect.end_date;

            if (End_date != DateTime.MinValue)
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
        }

        public void Update(object o)
        {
            if (Staffnew != null)
            {
                Staffnew.staff_id = Staff_id;
                Staffnew.aka = Aka;
                Staffnew.firstname = Firstname;
                Staffnew.lastname = Lastname;
                Staffnew.is_active = Is_active;
                Staffnew.start_date = Start_date;
                Staffnew.create_date = Create_date;
                Staffnew.modified_date = Modified_date;

                if (Check == false)
                {
                    Staffnew.end_date = DateTime.MinValue;
                }
                else
                {
                    Staffnew.end_date = End_date;
                }
            }
            var updatestaff = new UpdateAccess();
            updatestaff.UpdateStaff(Staffnew);

            /*  Add User Log */
            historyUser.User_id = UserInfo.user_id;
            historyUser.Detail = "Update " + Staffnew.aka + " in Staff Table";
            var insertionLog = new InsertAccess();
            insertionLog.LogHistory(historyUser);
        }

        #endregion
    }
}
