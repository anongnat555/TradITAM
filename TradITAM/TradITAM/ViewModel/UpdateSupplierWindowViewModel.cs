using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TradITAM.Helper;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
    public class UpdateSupplierWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> UpdateCommand { get; set; }

        private UserData UserInfo { get; set; }
        #endregion

        public UpdateSupplierWindowViewModel(UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;

            /* Define UpdateEvent using DelegateCommand */
            UpdateCommand = new DelegateCommand<object>(Update);

            LoadSupplier();    //Load 'Supplier' from database to get 'Company_name' in combobox
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
        private SupplierData _newsupplier = new SupplierData();
        public SupplierData Suppliernew
        {
            get => _newsupplier;
            set
            {
                _newsupplier = value;
                OnPropertyChanged(nameof(Suppliernew));
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

        #region Supplier
        private ObservableCollection<SupplierData> _listsupplier = new ObservableCollection<SupplierData>();
        public ObservableCollection<SupplierData> SupplierList
        {
            get => _listsupplier;
            set
            {
                _listsupplier = value;
                OnPropertyChanged(nameof(SupplierList));
            }
        }

        private SupplierData _SelectedSupplier;
        public SupplierData SelectedSupplier
        {
            get => _SelectedSupplier;
            set
            {
                _SelectedSupplier = value;
                OnPropertyChanged(nameof(SelectedSupplier));

                //update textbox after selected
                GetSupplierInformation(SelectedSupplier);
            }
        }

        private ICollectionView _SupplierCollectionView;
        public ICollectionView SupplierCollectionView
        {
            get { return _SupplierCollectionView; }
            set { _SupplierCollectionView = value; }
        }

        public void GetSupplierInformation(Object obj)
        {
            Supplier_id = SelectedSupplier.supplier_id;
            Company_name = SelectedSupplier.company_name;
            Contact_person = SelectedSupplier.contact_person;
            Phone = SelectedSupplier.phone;
            Email = SelectedSupplier.email;
            Address = SelectedSupplier.address;
            Is_active = SelectedSupplier.is_active;
        }
        #endregion

        #region Load supplier data
        private int _supplierid;
        public int Supplier_id
        {
            get { return _supplierid; }
            set
            {
                _supplierid = value;
                OnPropertyChanged(nameof(Supplier_id));
            }
        }

        private string _companyname;
        public string Company_name
        {
            get { return _companyname; }
            set
            {
                _companyname = value;
                OnPropertyChanged(nameof(Company_name));
            }
        }

        private string _contactperson;
        public string Contact_person
        {
            get { return _contactperson; }
            set
            {
                _contactperson = value;
                OnPropertyChanged(nameof(Contact_person));
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
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
        public void Update(object obj)
        {
            Suppliernew.supplier_id = Supplier_id;
            Suppliernew.company_name = Company_name;
            Suppliernew.contact_person = Contact_person;
            Suppliernew.phone = Phone;
            Suppliernew.email = Email;
            Suppliernew.address = Address;
            Suppliernew.is_active = Is_active;

            var update = new UpdateAccess();
            update.UpdateSupplier(Suppliernew);

            /*  Add User Log */
            historyUser.User_id = UserInfo.user_id;
            historyUser.Detail = "Update " + Suppliernew.company_name + " in Supplier Table";
            var insertionLog = new InsertAccess();
            insertionLog.LogHistory(historyUser);
        }

        public void LoadSupplier()
        {
            SupplierList = DataAccess.GetSupplier();
            SupplierCollectionView = CollectionViewSource.GetDefaultView(SupplierList);
        }
        #endregion

    }
}
