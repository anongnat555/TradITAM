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
        public AddStaffWindowViewModel()
        {
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

        //public ObservableCollection<Staff> StaffCollectionList { get; set; }


        #endregion

        #region Method
        public void AddStaff(Object o)
        {
            var addstaff = new InsertAccess();
            addstaff.AddStaff(StaffList);
        }
        #endregion
    }
}
