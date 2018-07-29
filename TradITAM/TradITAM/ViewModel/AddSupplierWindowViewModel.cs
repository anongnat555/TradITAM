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
        #endregion

        public AddSupplierWindowViewModel()
        {
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

        #region Method
        public void AddSupplier(Object o)
        {
            var insertion = new InsertAccess();
            insertion.AddSupplier(SupplierList);
        }
        #endregion
    }
}
