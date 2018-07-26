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
        public AddSupplierWindowViewModel()
        {
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
        //public ObservableCollection<Staff> StaffCollectionList { get; set; }
        #endregion

        #region Method

        public void AddSupplier(Object o)
        {
            var addsupplier = new InsertAccess();
            addsupplier.AddSupplier(SupplierList);
        }
        #endregion
    }
}
