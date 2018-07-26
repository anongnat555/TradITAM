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
        public DelegateCommand<object> GetStaffEvent { get; set; }
        public DelegateCommand<object> GetSupplierEvent { get; set; }
        public DelegateCommand<object> GetAssetTypeEvent { get; set; }
        public DelegateCommand<object> GetOsEvent { get; set; }

        public UpdateSelectedAssetWindowViewModel(AssetData assetDt)
        {
            MessageBox.Show(assetDt.Asset_code.ToString());

            GetStaffEvent = new DelegateCommand<object>(GetStaffInformation);
            GetSupplierEvent = new DelegateCommand<object>(GetSupplierInformation);
            GetAssetTypeEvent = new DelegateCommand<object>(GetAssetTypeInformation);
            GetOsEvent = new DelegateCommand<object>(GetOsInformation);

            #region Load Default Data
            LoadAka();
            LoadCompanyName();
            LoadAssetTypeName();
            LoadOsName();
            #endregion

            LoadSelected(assetDt);
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

        #region Load Os Data
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
        public void LoadAka()
        {
            StaffList = DataAccess.GetStaff();
            StaffCollectionView = CollectionViewSource.GetDefaultView(StaffList);
        }

        public void LoadCompanyName()
        {
            SupplierList = DataAccess.GetSupplier();
            SupplierCollectionView = CollectionViewSource.GetDefaultView(SupplierList);
        }

        public void LoadAssetTypeName()
        {
            AssetTypeList = DataAccess.GetAssetType();
            AssetTypeCollectionView = CollectionViewSource.GetDefaultView(AssetTypeList);
        }

        public void LoadOsName()
        {
            OsList = DataAccess.GetOs();
            OsCollectionView = CollectionViewSource.GetDefaultView(OsList);
        }
        #endregion

        public void LoadSelected(AssetData assetDt)
        {
            Asset_id = assetDt.Asset_id;
            Os_id = assetDt.Os_id;
            Asset_type_id = assetDt.Asset_type_id;
            Original_supplier_id = assetDt.Original_supplier_id;
            Supplier_id = assetDt.Supplier_id - 1;
            Using_by_staff_id = assetDt.Using_by_staff_id - 1;
            Asset_code = assetDt.Asset_code;
            Brand = assetDt.Brand;
            Price = assetDt.Price;
            Cpu = assetDt.Cpu;
            Ram = assetDt.Ram;
            Hdd = assetDt.Hdd;
            Is_active_a = assetDt.Is_active;
            Start_date_warranty = assetDt.Start_date_warranty;
            Expiry_date_warranty = assetDt.Expiry_date_warranty;
            Note = assetDt.Note;
        }
        #endregion
    }
}
