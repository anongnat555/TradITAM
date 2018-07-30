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
        #region Global Variable
        public DelegateCommand<object> AddStaffCommand { get; set; }

        private UserData UserInfo { get; set; }
        #endregion

        public AddStaffWindowViewModel(UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;
            
            /* Define AddEvent using DelegateCommand */
            AddStaffCommand = new DelegateCommand<object>(AddStaff);
        }

        #region A Property use for Database
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
        public void AddStaff(Object o)
        {
            if(Check == false)
            {
                StaffList.end_date = DateTime.MinValue;
            }

            var insertion = new InsertAccess();
            insertion.AddStaff(StaffList);

            /*  Add User Log */
            historyUser.User_id = UserInfo.user_id;
            historyUser.Detail = "Insert " + StaffList.aka + " in Staff Table";
            var insertionLog = new InsertAccess();
            insertionLog.LogHistory(historyUser);
        }
        #endregion
    }
}
