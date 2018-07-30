using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TradITAM.Helper;
using TradITAM.Model;
using TradITAM.View;

namespace TradITAM.ViewModel
{
    public class AddAssetWindowViewModel : ViewModelBase
    {

        #region Global Variable
        public DelegateCommand<object> GetStaffEvent { get; set; }
        public DelegateCommand<object> GetSupplierEvent { get; set; }
        public DelegateCommand<object> GetAssetTypeEvent { get; set; }
        public DelegateCommand<object> GetOsEvent { get; set; }

        public DelegateCommand<object> AddAssetTypeEvent { get; set; }
        public DelegateCommand<object> AddOsEvent { get; set; }

        public DelegateCommand<object> AddAssetCommand { get; set; }

        private UserData UserInfo { get; set; }
        #endregion

        public AddAssetWindowViewModel(UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;

            /* Define GetEvent using DelegateCommand */
            GetStaffEvent = new DelegateCommand<object>(GetStaffInformation);
            GetSupplierEvent = new DelegateCommand<object>(GetSupplierInformation);
            GetAssetTypeEvent = new DelegateCommand<object>(GetAssetTypeInformation);
            GetOsEvent = new DelegateCommand<object>(GetOsInformation);

            /* Define AddEvent using DelegateCommand */
            AddAssetTypeEvent = new DelegateCommand<object>(AddAssetType);
            AddOsEvent = new DelegateCommand<object>(AddOs);

            LoadAsset();                //Load 'Asset' from database to get 'AKA' in combobox
            LoadSupplier();             //Load 'Supplier' from database to get 'Company_name' in combobox
            LoadAssetType();            //Load 'AssetType' from database to get 'Asset_type_name' in combobox
            LoadOs();                   //Load 'Os' from database to get 'Os_name' in combobox

            /* Define AddEvent using DelegateCommand */
            AddAssetCommand = new DelegateCommand<object>(AddAsset);
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
        private AssetData _assetlist = new AssetData();
        public AssetData AssetList
        {
            get => _assetlist;
            set
            {
                _assetlist = value;
                OnPropertyChanged(nameof(AssetList));
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

        #region Staff Properties
        private ObservableCollection<StaffData> _liststaff = new ObservableCollection<StaffData>();
        public ObservableCollection<StaffData> StaffList
        {
            get => _liststaff;
            set
            {
                _liststaff = value;
                OnPropertyChanged(nameof(StaffList));
            }
        }

        private StaffData _SelectedStaff;
        public StaffData SelectedStaff
        {
            get => _SelectedStaff;
            set
            {
                _SelectedStaff = value;
                OnPropertyChanged(nameof(SelectedStaff));

                //update textbox after selected
                GetStaffInformation(SelectedStaff);
            }
        }

        private ICollectionView _StaffCollectionView;
        public ICollectionView StaffCollectionView
        {
            get { return _StaffCollectionView; }
            set { _StaffCollectionView = value; }
        }

        public void GetStaffInformation(Object obj)
        {
            if (SelectedStaff != null)
            {
                Staff_id = SelectedStaff.staff_id;
            }
        }
        #endregion

        #region Supplier Properties
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
            if (SelectedSupplier != null)
            {
                Supplier_id = SelectedSupplier.supplier_id;
            }
        }
        #endregion

        #region AssetType Properties
        private ObservableCollection<AssetTypeData> _listassettype = new ObservableCollection<AssetTypeData>();
        public ObservableCollection<AssetTypeData> AssetTypeList
        {
            get => _listassettype;
            set
            {
                _listassettype = value;
                OnPropertyChanged(nameof(AssetTypeList));
            }
        }

        private AssetTypeData _SelectedAssetType;
        public AssetTypeData SelectedAssetType
        {
            get => _SelectedAssetType;
            set
            {
                _SelectedAssetType = value;
                OnPropertyChanged(nameof(SelectedAssetType));

                //update textbox after selected
                GetAssetTypeInformation(SelectedAssetType);
            }
        }

        private ICollectionView _AssetTypeCollectionView;
        public ICollectionView AssetTypeCollectionView
        {
            get { return _AssetTypeCollectionView; }
            set { _AssetTypeCollectionView = value; }
        }

        public void GetAssetTypeInformation(Object obj)
        {
            if (SelectedAssetType != null)
            {
                Asset_type_id = SelectedAssetType.asset_type_id;
            }
        }
        #endregion

        #region Os Properties
        private ObservableCollection<OsData> _listos = new ObservableCollection<OsData>();
        public ObservableCollection<OsData> OsList
        {
            get => _listos;
            set
            {
                _listos = value;
                OnPropertyChanged(nameof(OsList));
            }
        }

        private OsData _SelectedOs;
        public OsData SelectedOs
        {
            get => _SelectedOs;
            set
            {
                _SelectedOs = value;
                OnPropertyChanged(nameof(SelectedOs));

                //update textbox after selected
                GetOsInformation(SelectedOs);
            }
        }

        private ICollectionView _OsCollectionView;
        public ICollectionView OsCollectionView
        {
            get { return _OsCollectionView; }
            set { _OsCollectionView = value; }
        }

        public void GetOsInformation(Object obj)
        {
            if (SelectedOs != null)
            {
                Os_id = SelectedOs.os_id;
                Os_name = SelectedOs.os_name;
            }
        }
        #endregion

        #region Load Asset Data
        private int _os_id_a;
        public int Os_id_a
        {
            get => _os_id_a;
            set
            {
                _os_id_a = value;
                OnPropertyChanged(nameof(Os_id_a));
            }
        }

        private int _asset_type_id;
        public int Asset_type_id
        {
            get => _asset_type_id;
            set
            {
                _asset_type_id = value;
                OnPropertyChanged(nameof(Asset_type_id));
            }
        }

        private int _original_supplier_id;
        public int Original_supplier_id
        {
            get => _original_supplier_id;
            set
            {
                _original_supplier_id = value;
                OnPropertyChanged(nameof(Original_supplier_id));
            }
        }

        private int _supplier_id;
        public int Supplier_id
        {
            get => _supplier_id;
            set
            {
                _supplier_id = value;
                OnPropertyChanged(nameof(Supplier_id));
            }
        }

        private int _using_by_staff_id;
        public int Using_by_staff_id
        {
            get => _using_by_staff_id;
            set
            {
                _using_by_staff_id = value;
                OnPropertyChanged(nameof(Using_by_staff_id));
            }
        }

        private string _asset_code;
        public string Asset_code
        {
            get => _asset_code;
            set
            {
                _asset_code = value;
                OnPropertyChanged(nameof(Asset_code));
            }
        }

        private string _brand;
        public string Brand
        {
            get => _brand;
            set
            {
                _brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string _cpu;
        public string Cpu
        {
            get => _cpu;
            set
            {
                _cpu = value;
                OnPropertyChanged(nameof(Cpu));
            }
        }

        private string _ram;
        public string Ram
        {
            get => _ram;
            set
            {
                _ram = value;
                OnPropertyChanged(nameof(Ram));
            }
        }

        private string _hdd;
        public string Hdd
        {
            get => _hdd;
            set
            {
                _hdd = value;
                OnPropertyChanged(nameof(Hdd));
            }
        }

        private string _note;
        public string Note
        {
            get => _note;
            set
            {
                _note = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        private DateTime _start_date_warranty;
        public DateTime Start_date_warranty
        {
            get => _start_date_warranty;
            set
            {
                _start_date_warranty = value;
                OnPropertyChanged(nameof(Start_date_warranty));
            }
        }

        private DateTime _expiry_date_warranty;
        public DateTime Expiry_date_warranty
        {
            get => _expiry_date_warranty;
            set
            {
                _expiry_date_warranty = value;
                OnPropertyChanged(nameof(Expiry_date_warranty));
            }
        }

        private bool _is_active_a;
        public bool Is_active_a
        {
            get { return _is_active_a; }
            set
            {
                _is_active_a = value;
                OnPropertyChanged(nameof(Is_active_a));
            }
        }
        #endregion

        #region Load Staff Data
        private int _staff_id;
        public int Staff_id
        {
            get { return _staff_id; }
            set
            {
                _staff_id = value;
                OnPropertyChanged(nameof(Staff_id));
            }
        }

        private string _aka;
        public string Aka
        {
            get { return _aka; }
            set
            {
                _aka = value;
                OnPropertyChanged(nameof(Aka));
            }
        }
        #endregion

        #region Load Supplier Data
        private string _company_name;
        public string Company_name
        {
            get => _company_name;
            set
            {
                _company_name = value;
                OnPropertyChanged(nameof(Company_name));
            }
        }
        #endregion

        #region Load Os Data
        private int _os_id;
        public int Os_id
        {
            get => _os_id;
            set
            {
                _os_id = value;
                OnPropertyChanged(nameof(Os_id));
            }
        }

        private string _os_name;
        public string Os_name
        {
            get => _os_name;
            set
            {
                _os_name = value;
                OnPropertyChanged(nameof(Os_name));
            }
        }
        #endregion

        #region Load AssetType Data
        private string _asset_type_name;
        public string Asset_type_name
        {
            get => _asset_type_name;
            set
            {
                _asset_type_name = value;
                OnPropertyChanged(nameof(Asset_type_name));
            }
        }
        #endregion

        #region Method

        #region Add
        public void AddAsset(Object o)
        {
            /* From object 'SelectedStaff' */
            AssetList.Os_id = Os_id;

            /* From object 'SelectedAssetType' */
            AssetList.Asset_type_id = Asset_type_id;

            /* From object 'SelectedSupplier' */
            AssetList.Original_supplier_id = Supplier_id;
            AssetList.Supplier_id = Supplier_id;

            /* From object 'SelectedStaff' */
            AssetList.Using_by_staff_id = Staff_id;

            /* From UI's TextBox (Binding) */
            AssetList.Is_active = Is_active_a;
            AssetList.Asset_code = Asset_code;
            AssetList.Brand = Brand;
            AssetList.Price = Price;
            AssetList.Cpu = Cpu;
            AssetList.Ram = Ram;
            AssetList.Hdd = Hdd;
            AssetList.Note = Note;
            AssetList.Start_date_warranty = Start_date_warranty;
            AssetList.Expiry_date_warranty = Expiry_date_warranty;

            /* Insert to Database */
            if (Os_id == 0)
            {
                MessageBox.Show("Please Select some OS");
            }
            else
            {
                var insertion = new InsertAccess();
                insertion.AddAsset(AssetList);

                /*  Add User Log */
                historyUser.User_id = UserInfo.user_id;
                historyUser.Detail = "Insert " + Asset_code + " in Asset Table";
                var insertionLog = new InsertAccess();
                insertionLog.LogHistory(historyUser);
            }
        }
        #endregion

        #region Get
        public void LoadAsset()
        {
            StaffList = DataAccess.GetStaff();
            StaffCollectionView = CollectionViewSource.GetDefaultView(StaffList);
        }

        public void LoadSupplier()
        {
            SupplierList = DataAccess.GetSupplier();
            SupplierCollectionView = CollectionViewSource.GetDefaultView(SupplierList);
        }

        public void LoadAssetType()
        {
            AssetTypeList = DataAccess.GetAssetType();
            AssetTypeCollectionView = CollectionViewSource.GetDefaultView(AssetTypeList);
        }

        public void LoadOs()
        {
            OsList = DataAccess.GetOs();
            OsCollectionView = CollectionViewSource.GetDefaultView(OsList);
        }
        #endregion

        #endregion

        #region Send UserList Data to other form

        public void AddAssetType(Object obj)
        {
            ManageAssetTypeWindow n = new ManageAssetTypeWindow(UserInfo);
            n.ShowDialog();
        }

        public void AddOs(Object obj)
        {
            ManageOsWindow n = new ManageOsWindow(UserInfo);
            n.ShowDialog();
        }

        #endregion
    }
}
