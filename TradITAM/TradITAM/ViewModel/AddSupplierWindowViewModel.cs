using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradITAM.Helper;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
    public class AddSupplierWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> AddSupplierCommand { get; set; }

        private UserData UserInfo { get; set; }
        #endregion

        public AddSupplierWindowViewModel(UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;

            /* Define AddEvent using DelegateCommand */
            AddSupplierCommand = new DelegateCommand<object>(AddSupplier);
        }

        #region A Property use for Database
        private SupplierData _listsupplier = new SupplierData();
        public SupplierData SupplierList
        {
            get => _listsupplier;
            set
            {
                _listsupplier = value;
                OnPropertyChanged(nameof(SupplierList));
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

        #region Method
        public void AddSupplier(Object o)
        {
            var insertion = new InsertAccess();
            insertion.AddSupplier(SupplierList);

            /*  Add User Log */
            historyUser.User_id = UserInfo.user_id;
            historyUser.History_id = 1;
            historyUser.Detail = "Insert " + SupplierList.company_name + " in Supplier Table";
            var insertionLog = new InsertAccess();
            insertionLog.LogHistory(historyUser);
        }
        #endregion
    }
}
