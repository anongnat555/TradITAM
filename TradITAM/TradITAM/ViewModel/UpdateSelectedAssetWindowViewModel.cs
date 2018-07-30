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

namespace TradITAM.ViewModel
{
    public class UpdateSelectedAssetWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> GetStaffEvent { get; set; }
        public DelegateCommand<object> GetSupplierEvent { get; set; }
        public DelegateCommand<object> GetAssetTypeEvent { get; set; }
        public DelegateCommand<object> GetOsEvent { get; set; }

        public DelegateCommand<object> UpdateCommand { get; set; }

        private AssetData AssetInfo { get; set; }
        #endregion

        public UpdateSelectedAssetWindowViewModel(AssetData AssetSelect)
        {
            AssetInfo = new AssetData();
            AssetInfo = AssetSelect;

            /* Define GetEvent using DelegateCommand */
            GetStaffEvent = new DelegateCommand<object>(GetStaffInformation);
            GetSupplierEvent = new DelegateCommand<object>(GetSupplierInformation);
            GetAssetTypeEvent = new DelegateCommand<object>(GetAssetTypeInformation);
            GetOsEvent = new DelegateCommand<object>(GetOsInformation);

            /* Define UpdateEvent using DelegateCommand */
            UpdateCommand = new DelegateCommand<object>(Update);

            LoadStaff();        //Load 'Staff' from database to get 'Aka' in combobox
            LoadSupplier();     //Load 'Supplier' from database to get 'Company_name' in combobox
            LoadAssetType();    //Load 'AssetType' from database to get 'Asset_type_name' in combobox
            LoadOs();           //Load 'Os' from database to get 'Os_name' in combobox

            LoadSelected(AssetSelect);
        }

        #region call dataaccess
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
        private AssetData _newasset = new AssetData();
        public AssetData Assetnew
        {
            get => _newasset;
            set
            {
                _newasset = value;
                OnPropertyChanged(nameof(Assetnew));
            }
        }
        #endregion

        #region Asset
        private ObservableCollection<AssetData> _listasset = new ObservableCollection<AssetData>();
        public ObservableCollection<AssetData> AssetList
        {
            get => _listasset;
            set
            {
                _listasset = value;
                OnPropertyChanged(nameof(AssetList));
            }
        }

        private AssetData _SelectedAsset;
        public AssetData SelectedAsset
        {
            get => _SelectedAsset;
            set
            {
                _SelectedAsset = value;
                OnPropertyChanged(nameof(SelectedAsset));

                //update textbox after selected
                GetAssetInformation(SelectedAsset);
            }
        }

        private ICollectionView _AssetCollectionView;
        public ICollectionView AssetCollectionView
        {
            get { return _AssetCollectionView; }
            set { _AssetCollectionView = value; }
        }

        public void GetAssetInformation(Object obj)
        {
            if (SelectedAsset != null)
            {
                
            }
        }
        #endregion

        #region Staff
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
                /* Assign staff value into each asset property from ui selection */
                Staff_id = SelectedStaff.staff_id;
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
            if (SelectedSupplier != null)
            {
                /* Assign supplier value into each asset property from ui selection */
                Supplier_id_s = SelectedSupplier.supplier_id;
            }
        }
        #endregion

        #region AssetType
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
            if (SelectedSupplier != null)
            {
                /* Assign asset type value into each asset property from ui selection */
                Asset_type_id_at = SelectedAssetType.asset_type_id;
            }
        }
        #endregion

        #region Os
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
                /* Assign os value into each asset property from ui selection */
                Os_id_o = SelectedOs.os_id;
            }
        }
        #endregion

        #region Load Asset Data
        private int _asset_id;
        public int Asset_id
        {
            get => _asset_id;
            set
            {
                _asset_id = value;
                OnPropertyChanged(nameof(Asset_id));
            }
        }

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

        private DateTime _create_date_a;
        public DateTime Create_date_a
        {
            get { return _create_date_a; }
            set
            {
                _create_date_a = value;
                OnPropertyChanged(nameof(Create_date_a));
            }
        }

        private DateTime _modified_date_a;
        public DateTime Modified_date_a
        {
            get { return _modified_date_a; }
            set
            {
                _modified_date_a = value;
                OnPropertyChanged(nameof(Modified_date_a));
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
        private int _supplier_id_s;
        public int Supplier_id_s
        {
            get => _supplier_id_s;
            set
            {
                _supplier_id_s = value;
                OnPropertyChanged(nameof(Supplier_id_s));
            }
        }

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

        #region Load AssetType Data
        private int _asset_type_id_at;
        public int Asset_type_id_at
        {
            get => _asset_type_id_at;
            set
            {
                _asset_type_id_at = value;
                OnPropertyChanged(nameof(Asset_type_id_at));
            }
        }

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

        #region Load Os Data
        private int _os_id_o;
        public int Os_id_o
        {
            get => _os_id_o;
            set
            {
                _os_id_o = value;
                OnPropertyChanged(nameof(Os_id_o));
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

        #region Method

        #region Load Default Data
        public void LoadStaff()
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

        #region Load Selected Data
        public void LoadSelected(AssetData AssetSelect)
        {
            /* Load value to combobox */
            Aka = DataAccess.GetStaffAka(AssetSelect.Using_by_staff_id);
            Company_name = DataAccess.GetSupplierCompanyName(AssetSelect.Supplier_id);
            Asset_type_name = DataAccess.GetAssetTypeName(AssetSelect.Asset_type_id);
            Os_name = DataAccess.GetOsName(AssetSelect.Os_id);

            /* Load other value */
            Asset_id = AssetSelect.Asset_id;
            Os_id_o = AssetSelect.Os_id;
            Asset_type_id_at = AssetSelect.Asset_type_id;
            Original_supplier_id = AssetSelect.Original_supplier_id;
            Supplier_id_s = AssetSelect.Supplier_id;
            Using_by_staff_id = AssetSelect.Using_by_staff_id;
            Asset_code = AssetSelect.Asset_code;
            Brand = AssetSelect.Brand;
            Price = AssetSelect.Price;
            Cpu = AssetSelect.Cpu;
            Ram = AssetSelect.Ram;
            Hdd = AssetSelect.Hdd;
            Is_active_a = AssetSelect.Is_active;
            Start_date_warranty = AssetSelect.Start_date_warranty;
            Expiry_date_warranty = AssetSelect.Expiry_date_warranty;
            Note = AssetSelect.Note;

        }
        #endregion

        #region Update to database
        public void Update(object obj)
        {
            if (Assetnew != null)
            {
                Assetnew.Asset_id = Asset_id;
                Assetnew.Asset_type_id = Asset_type_id_at;
                Assetnew.Asset_code = Asset_code;
                Assetnew.Brand = Brand;
                Assetnew.Cpu = Cpu;
                Assetnew.Ram = Ram;
                Assetnew.Hdd = Hdd;
                Assetnew.Price = Price;
                Assetnew.Os_id = Os_id_o;
                Assetnew.Using_by_staff_id = Staff_id;
                Assetnew.Supplier_id = Supplier_id_s;
                Assetnew.Note = Note;
                Assetnew.Is_active = Is_active_a;
                Assetnew.Start_date_warranty = Start_date_warranty;
                Assetnew.Expiry_date_warranty = Expiry_date_warranty;

                var update = new UpdateAccess();
                update.UpdateAsset(Assetnew);
            }
        }
        #endregion

        #endregion
    }
}
