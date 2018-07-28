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
    public class ReportWindowViewModel : ViewModelBase
    {
        public DelegateCommand<object> GetAssetEvent { get; set; }
        public DelegateCommand<object> GetStaffEvent { get; set; }

        public ReportWindowViewModel()
        {
            GetAssetEvent = new DelegateCommand<object>(GetAssetInformation);
            GetStaffEvent = new DelegateCommand<object>(GetStaffInformation);

            LoadAssetCode();
            LoadAka();
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
                Brand = SelectedAsset.Brand;
                Price = SelectedAsset.Price;
                Asset_code = SelectedAsset.Asset_code;
                Asset_type_id = SelectedAsset.Asset_type_id - 1;
                Using_by_staff_id = SelectedAsset.Using_by_staff_id - 1;
                Supplier_id = SelectedAsset.Supplier_id - 1;
                Os_id = SelectedAsset.Os_id - 1;
                Cpu = SelectedAsset.Cpu;
                Ram = SelectedAsset.Ram;
                Hdd = SelectedAsset.Hdd;
                Note = SelectedAsset.Note;
                Is_active_a = SelectedAsset.Is_active;
                Start_date_warranty = SelectedAsset.Start_date_warranty;
                Expiry_date_warranty = SelectedAsset.Expiry_date_warranty;
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
                //MessageBox.Show(SelectedStaff.firstname);
                Aka = SelectedStaff.aka;
                Firstname = SelectedStaff.firstname;
                Lastname = SelectedStaff.lastname;
                Is_active_s = SelectedStaff.is_active;
                Start_date = SelectedStaff.start_date;
                End_date = SelectedStaff.end_date;
                //CreateWindow xxx = new CreateWindow(SelectedStaff);
                //xxx.ShowDialog();
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
        private string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
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

        private DateTime _start_date;
        public DateTime Start_date
        {
            get { return _start_date; }
            set
            {
                _start_date = value;
                OnPropertyChanged(nameof(Start_date));
            }
        }

        private DateTime _end_date;
        public DateTime End_date
        {
            get { return _end_date; }
            set
            {
                _end_date = value;
                OnPropertyChanged(nameof(End_date));
            }
        }

        private bool _is_active_s;
        public bool Is_active_s
        {
            get { return _is_active_s; }
            set
            {
                _is_active_s = value;
                OnPropertyChanged(nameof(Is_active_s));
            }
        }

        private DateTime _create_date_s;
        public DateTime Create_date_s
        {
            get { return _create_date_s; }
            set
            {
                _create_date_s = value;
                OnPropertyChanged(nameof(Create_date_s));
            }
        }

        private DateTime _modified_date_s;
        public DateTime Modified_date_s
        {
            get { return _modified_date_s; }
            set
            {
                _modified_date_s = value;
                OnPropertyChanged(nameof(Modified_date_s));
            }
        }
        #endregion

        #region Method
        public void LoadAssetCode()
        {
            AssetList = DataAccess.GetAsset();
            AssetCollectionView = CollectionViewSource.GetDefaultView(AssetList);
        }

        public void LoadAka()
        {
            StaffList = DataAccess.GetStaff();
            StaffCollectionView = CollectionViewSource.GetDefaultView(StaffList);
        }
        #endregion
    }
}
