using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TradITAM.Helper;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
    public class CreateWindowViewModel // : Staff
    {
        //private RelayCommand<object> AddStaffCommand { get; set; }

        //public CreateWindowViewModel(Staff selectedStaff)
        //{
        //    AddStaffCommand = new RelayCommand<object>(AddStaff);

        //    CurrentStaff = selectedStaff;

        //    LoadStaffData();
        //}

        #region Fields and Properties

        private StaffData CurrentStaff { get; set; }
        private AssetData CurrentAsset { get; set; }

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

        public ObservableCollection<StaffData> StaffCollectionList { get; set; }
        public ObservableCollection<AssetData> AssetCollectionList { get; set; }

        #endregion

        #region Method

        //private void AddStaff(object o)
        //{
        //    Staff pNewStaff = new Staff();
        //    bool result = DataAccess.AddStaff(pNewStaff);
        //}

        private void LoadStaffData()
        {
            StaffCollectionList = DataAccess.GetStaff();
        }

        private void LoadAssetData()
        {
            AssetCollectionList = DataAccess.GetAsset();
        }

        #endregion

        //public DelegateCommand<object> AddStaffCommand { get; set; }
        //public DelegateCommand<object> AddSupplierCommand { get; set; }

        //public CreateWindowViewModel()
        //{
        //    AddStaffCommand = new DelegateCommand<object>(AddStaff);
        //    AddSupplierCommand = new DelegateCommand<object>(Addsupplier);

        //    getAka();
        //    getSid();
        //    getAid();
        //    getATypeId();
        //    getOs();

        //}

        ////-----------------------------------------------------------------------------------
        ////------------------------------ GET DATA INTO GRID ---------------------------------
        ////-----------------------------------------------------------------------------------

        ////select staff 
        //private string _firstname;
        //private string _lastname;
        //private string _aka;
        //private DateTime _startdate;
        //private DateTime _enddate;
        //private bool _isactive;

        //private ObservableCollection<staff> _liststaff = new ObservableCollection<staff>();
        //public ObservableCollection<staff> listStaff
        //{
        //    get => _liststaff;
        //    set
        //    {
        //        _liststaff = value;
        //        OnPropertyChanged(nameof(listStaff));
        //    }
        //}

        //public string Firstname
        //{
        //    get => _firstname;
        //    set
        //    {
        //        _firstname = value;
        //        OnPropertyChanged(nameof(Firstname));
        //    }
        //}

        //public string Lastname
        //{
        //    get => _lastname;
        //    set
        //    {
        //        _lastname = value;
        //        OnPropertyChanged(nameof(Lastname));
        //    }
        //}

        //public string Aka
        //{
        //    get => _aka;
        //    set
        //    {
        //        _aka = value;
        //        OnPropertyChanged(nameof(Aka));
        //    }
        //}

        //public DateTime StartDate
        //{
        //    get => _startdate;
        //    set
        //    {
        //        _startdate = value;
        //        OnPropertyChanged(nameof(StartDate));
        //    }
        //}

        //public DateTime EndDate
        //{
        //    get => _enddate;
        //    set
        //    {
        //        _enddate = value;
        //        OnPropertyChanged(nameof(EndDate));
        //    }
        //}

        //public bool Isactive
        //{
        //    get => _isactive;
        //    set
        //    {
        //        _isactive = value;
        //        OnPropertyChanged(nameof(Isactive));
        //    }
        //}

        //private void AddStaff(object o)
        //{
        //    try
        //    {
        //        using (var db = new TradAssetDBEntities())
        //        {
        //            var data = new staff
        //            {
        //                firstname = Firstname,
        //                lastname = Lastname,
        //                aka = Aka,
        //                start_date = StartDate,
        //                end_date = EndDate,
        //                is_active = Isactive,
        //                create_date = DateTime.Now,
        //                modified_date = DateTime.Now
        //            };
        //            Console.WriteLine(data);
        //            db.staff.Add(data);
        //            db.SaveChanges();

        //        }
        //        listStaff = MainWindowViewModel.getStaff();
        //        MessageBox.Show("Insert complete");

        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Insert incomplete");

        //    }
        //}

        ////-----------------------------------------------------------------------------------
        ////select supplier

        //private string _companyname;
        //private string _contactperson;
        //private string _address;
        //private string _email;
        //private string _phone;
        //private bool _isactives;

        //private ObservableCollection<supplier> _listsupplier = new ObservableCollection<supplier>();
        //public ObservableCollection<supplier> listSupplier
        //{
        //    get => _listsupplier;
        //    set
        //    {
        //        _listsupplier = value;
        //        OnPropertyChanged(nameof(listSupplier));
        //    }
        //}

        //public string Companyname
        //{
        //    get => _companyname;
        //    set
        //    {
        //        _companyname = value;
        //        OnPropertyChanged(nameof(Companyname));
        //    }
        //}

        //public string Contactperson
        //{
        //    get => _contactperson;
        //    set
        //    {
        //        _contactperson = value;
        //        OnPropertyChanged(nameof(Contactperson));
        //    }
        //}

        //public string Address
        //{
        //    get => _address;
        //    set
        //    {
        //        _address = value;
        //        OnPropertyChanged(nameof(Address));
        //    }
        //}

        //public string Email
        //{
        //    get => _email;
        //    set
        //    {
        //        _email = value;
        //        OnPropertyChanged(nameof(Email));
        //    }
        //}

        //public string Phone
        //{
        //    get => _phone;
        //    set
        //    {
        //        _phone = value;
        //        OnPropertyChanged(nameof(Phone));
        //    }
        //}

        //public bool Isactives
        //{
        //    get => _isactives;
        //    set
        //    {
        //        _isactives = value;
        //        OnPropertyChanged(nameof(Isactives));
        //    }
        //}

        //private void Addsupplier(object o)
        //{
        //    try
        //    {
        //        using (var db = new TradAssetDBEntities())
        //        {
        //            var data = new supplier
        //            {

        //                company_name = Companyname,
        //                contact_person = Contactperson,
        //                address = Address,
        //                email = Email,
        //                phone = Phone,
        //                is_active = Isactives,
        //                create_date = DateTime.Now,
        //                modified_date = DateTime.Now
        //            };
        //            //Console.WriteLine(data);
        //            db.supplier.Add(data);
        //            db.SaveChanges();

        //        }
        //        listSupplier = MainWindowViewModel.getSupplier();
        //        MessageBox.Show("Insert complete");

        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Insert incomplete");
        //    }


        //}

        ////-----------------------------------------------------------------------------------
        ////----------------------------- GET DATA INTO COMBO ---------------------------------
        ////-----------------------------------------------------------------------------------
        //private void getAka()
        //{
        //    var db = new TradAssetDBEntities();

        //    //var query = db.staff.Select(o => o.aka).ToList();

        //    //foreach (var c in query)
        //    //{
        //    //    listAka.Add(c);
        //    //}
        //    db.staff.Select(o => o.aka).ToList().ForEach(listAka.Add);

        //    db.Dispose();
        //}

        //private List<string> _listAka = new List<string>();
        //public List<string> listAka
        //{
        //    get => _listAka;
        //    set
        //    {
        //        _listAka = value;
        //        OnPropertyChanged(nameof(listAka));
        //    }
        //}

        ////-----------------------------------------------------------------------------------

        //private void getSid()
        //{
        //    var db = new TradAssetDBEntities();

        //    var query = db.supplier.Select(o => o.company_name).ToList();

        //    foreach (var c in query)
        //    {
        //        listSid.Add(c);
        //    }

        //    db.Dispose();
        //}

        //private List<string> _listSid = new List<string>();
        //public List<string> listSid
        //{
        //    get => _listSid;
        //    set
        //    {
        //        _listSid = value;
        //        OnPropertyChanged(nameof(listSid));
        //    }
        //}

        ////-----------------------------------------------------------------------------------

        //private void getAid()
        //{
        //    var db = new TradAssetDBEntities();

        //    var query = db.asset.Select(o => o.asset_code).ToList();

        //    foreach (var c in query)
        //    {
        //        listAid.Add(c);
        //    }

        //    db.Dispose();
        //}

        //private List<string> _listAid = new List<string>();
        //public List<string> listAid
        //{
        //    get => _listAid;
        //    set
        //    {
        //        _listAid = value;
        //        OnPropertyChanged(nameof(listAid));
        //    }
        //}

        ////-----------------------------------------------------------------------------------

        //private void getATypeId()
        //{
        //    var db = new TradAssetDBEntities();

        //    var query = db.asset_type.Select(o => o.asset_type_name).ToList();

        //    foreach (var c in query)
        //    {
        //        listATypeId.Add(c);
        //    }

        //    db.Dispose();
        //}

        //private List<string> _listATypeId = new List<string>();
        //public List<string> listATypeId
        //{
        //    get => _listATypeId;
        //    set
        //    {
        //        _listATypeId = value;
        //        OnPropertyChanged(nameof(listATypeId));
        //    }
        //}

        ////-----------------------------------------------------------------------------------

        //private void getOs()
        //{
        //    var db = new TradAssetDBEntities();

        //    var query = db.os.Select(o => o.os_name).ToList();

        //    foreach (var c in query)
        //    {
        //        listOs.Add(c);
        //    }

        //    db.Dispose();
        //}

        //private List<string> _listOs = new List<string>();
        //public List<string> listOs
        //{
        //    get => _listOs;
        //    set
        //    {
        //        _listOs = value;
        //        OnPropertyChanged(nameof(listOs));
        //    }
        //}
        ////-----------------------------------------------------------------------------------
        ////---------------------------------- GET DATA ---------------------------------------
        ////-----------------------------------------------------------------------------------

        //private string _selectedAid;
        //public string selectedAid
        //{
        //    get
        //    {
        //        return _selectedAid;
        //    }
        //    set
        //    {
        //        _selectedAid = value;
        //        OnPropertyChanged(nameof(selectedAid));

        //        //combobox trigger
        //        getSelectedUid();
        //        getSelectedSid();

        //        ////toggle trigger
        //        //getCheckStatus();

        //        ////textbox trigger
        //        //getBrand();
        //        //getPrice();
        //        //getOs();
        //        //getNote();
        //    }
        //}

        ////-----------------------------------------------------------------------------------
        //private void getSelectedUid()
        //{
        //    try
        //    {
        //        using (var db = new TradAssetDBEntities())
        //        {
        //            int id;

        //            var match = from asset in db.asset
        //                        where asset.asset_code == _selectedAid.ToString()
        //                        select asset;

        //            id = match.First().asset_id;

        //            var query = from a in db.asset
        //                        join s in db.staff on a.using_by_staff_id equals s.staff_id
        //                        where a.asset_id == id
        //                        select s;

        //            selectedUid = query.First().aka;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private string _selectedUid;
        //public string selectedUid
        //{
        //    get => _selectedUid;
        //    set
        //    {
        //        _selectedUid = value;
        //        OnPropertyChanged(nameof(selectedUid));
        //    }
        //}

        ////-----------------------------------------------------------------------------------
        //private void getSelectedSid()
        //{
        //    try
        //    {
        //        using (var db = new TradAssetDBEntities())
        //        {
        //            int id;

        //            var match = from asset in db.asset
        //                        where asset.asset_code == _selectedAid.ToString()
        //                        select asset;

        //            id = match.FirstOrDefault().asset_id;

        //            var query = from a in db.asset
        //                        join s in db.supplier on a.supplier_id equals s.supplier_id
        //                        where a.asset_id == id
        //                        select s;

        //            selectedSid = query.FirstOrDefault().company_name;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private string _selectedSid;
        //public string selectedSid
        //{
        //    get => _selectedSid;
        //    set
        //    {
        //        _selectedSid = value;
        //        OnPropertyChanged(nameof(selectedSid));
        //    }
        //}

        //-----------------------------------------------------------------------------------
        //private void getCheckStatus()
        //{
        //    try
        //    {
        //        using (var db = new TradAssetDBEntities())
        //        {
        //            int id;

        //            var match = from asset in db.asset
        //                        where asset.asset_code == _selectedAid.ToString()
        //                        select asset;

        //            id = match.FirstOrDefault().asset_id;

        //            var query = from asset in db.asset
        //                        where asset.asset_id == id
        //                        select asset;

        //            checkStatus = (bool)query.FirstOrDefault().is_active;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private bool _checkStatus;
        //public bool checkStatus
        //{
        //    get => _checkStatus;
        //    set
        //    {
        //        _checkStatus = value;
        //        OnPropertyChanged(nameof(checkStatus));
        //    }
        //}

        ////-----------------------------------------------------------------------------------
        //private void getBrand()
        //{
        //    try
        //    {
        //        using (var db = new TradAssetDBEntities())
        //        {
        //            int id;

        //            var match = from asset in db.asset
        //                        where asset.asset_code == _selectedAid.ToString()
        //                        select asset;

        //            id = match.FirstOrDefault().asset_id;

        //            var query = from asset in db.asset
        //                        where asset.asset_id == id
        //                        select asset;

        //            strBrand = query.FirstOrDefault().brand;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private string _strBrand;
        //public string strBrand
        //{
        //    get => _strBrand;
        //    set
        //    {
        //        _strBrand = value;
        //        OnPropertyChanged(nameof(strBrand));
        //    }
        //}

        ////-----------------------------------------------------------------------------------
        //private void getPrice()
        //{
        //    try
        //    {
        //        using (var db = new TradAssetDBEntities())
        //        {
        //            int id;

        //            var match = from asset in db.asset
        //                        where asset.asset_code == _selectedAid.ToString()
        //                        select asset;

        //            id = match.FirstOrDefault().asset_id;

        //            var query = from asset in db.asset
        //                        where asset.asset_id == id
        //                        select asset;

        //            strPrice = (decimal)query.FirstOrDefault().price;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private decimal _strPrice;
        //public decimal strPrice
        //{
        //    get => _strPrice;
        //    set
        //    {
        //        _strPrice = value;
        //        OnPropertyChanged(nameof(strPrice));
        //    }
        //}

        ////-----------------------------------------------------------------------------------
        //private void getOs()
        //{
        //    try
        //    {
        //        using (var db = new TradAssetDBEntities())
        //        {
        //            int id;

        //            var match = from asset in db.asset
        //                        where asset.asset_code == _selectedAid.ToString()
        //                        select asset;

        //            id = match.FirstOrDefault().asset_id;

        //            var query = from a in db.asset join o in db.os on a.os_id equals o.os_id
        //                        where a.asset_id == id
        //                        select o;

        //            strOs = query.FirstOrDefault().os_name;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private string _strOs;
        //public string strOs
        //{
        //    get => _strOs;
        //    set
        //    {
        //        _strOs = value;
        //        OnPropertyChanged(nameof(strOs));
        //    }
        //}

        ////-----------------------------------------------------------------------------------
        //private void getNote()
        //{
        //    try
        //    {
        //        using (var db = new TradAssetDBEntities())
        //        {
        //            int id;

        //            var match = from asset in db.asset
        //                        where asset.asset_code == _selectedAid.ToString()
        //                        select asset;

        //            id = match.FirstOrDefault().asset_id;

        //            var query = from a in db.asset
        //                        where a.asset_id == id
        //                        select a;

        //            strNote = query.FirstOrDefault().notes;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private string _strNote;
        //public string strNote
        //{
        //    get => _strNote;
        //    set
        //    {
        //        _strNote = value;
        //        OnPropertyChanged(nameof(strNote));
        //    }
        //}
    }

}
