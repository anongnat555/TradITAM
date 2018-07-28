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
        public DelegateCommand<object> Addsuppliercommand { get; set; }
        private UserData User { get; set; }
        public AddSupplierWindowViewModel(UserData UserList)
        {
            User = new UserData();
            User = UserList;
            Addsuppliercommand = new DelegateCommand<object>(AddSupplier);
        }

        #region Fields and Properties
        //private Staff CurrentStaff { get; set; }
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
        //public ObservableCollection<Staff> StaffCollectionList { get; set; }
        #endregion

        #region Method

        public void AddSupplier(Object o)
        {
            var addsupplier = new InsertAccess();
            addsupplier.AddSupplier(SupplierList);

            historyUser.User_id = User.User_id;
            var adduser = new InsertAccess();
            adduser.historyStaff(historyUser);
        }
        #endregion
    }
}
