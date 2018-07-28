using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradITAM.Helper;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
     public class UpdateSelectedSupplierWindowViewModel : ViewModelBase
    {
        public DelegateCommand<object> Updatecommand { get; set; }
        private UserData User { get; set; }
        public UpdateSelectedSupplierWindowViewModel(SupplierData supplierSL, UserData UserList)
        {
            User = new UserData();
            User = UserList;
            LoadSelected(supplierSL);
            Updatecommand = new DelegateCommand<object>(Update);
        }


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

        public void LoadSelected(SupplierData supplierSL)
        {
            Supplier_id = supplierSL.supplier_id;
            Company_name = supplierSL.company_name;
            Contact_person = supplierSL.contact_person;
            Address = supplierSL.address;
            Email = supplierSL.email;
            Phone = supplierSL.phone;
            Is_active = supplierSL.is_active;
           
        }

        #region Properties
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
        public void Update(object o)
        {

            Suppliernew.supplier_id = Supplier_id;
            Suppliernew.company_name = Company_name;
            Suppliernew.contact_person = Contact_person;
            Suppliernew.address = Address;
            Suppliernew.is_active = Is_active;
            Suppliernew.email = Email;
            Suppliernew.phone = Phone;
            Suppliernew.create_date = Create_date;
            Suppliernew.modified_date = Modified_date;

            var updatesupplier = new UpdateAccess();
            updatesupplier.UpdateSupplier(Suppliernew);

            historyUser.User_id = User.User_id;
            var adduser = new UpdateAccess();
            adduser.historyStaff(historyUser);

        #endregion
    }
}
