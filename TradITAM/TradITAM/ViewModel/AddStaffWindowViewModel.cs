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
        #endregion

        public AddStaffWindowViewModel()
        {
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

        #region Method
        public void AddStaff(Object o)
        {
            var insertion = new InsertAccess();
            insertion.AddStaff(StaffList);
        }
        #endregion
    }
}
