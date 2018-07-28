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
    public class MainWindowViewModel : ViewModelBase
    {
        public DelegateCommand<object> EditAssetEvent { get; set; }
        public DelegateCommand<object> EditStaffEvent { get; set; }
        public DelegateCommand<object> EditSupplierEvent { get; set; }
        public DelegateCommand<UserData> AddStaffEvent { get; set; }

        private UserData User { get; set; }
        public MainWindowViewModel(UserData Userlist)
        {
            User = new UserData();

            User = Userlist;

            EditAssetEvent = new DelegateCommand<object>(EditAsset);
            EditStaffEvent = new DelegateCommand<object>(EditStaff);
            EditSupplierEvent = new DelegateCommand<object>(EditSupplier);
            AddStaffEvent = new DelegateCommand<UserData>(AddStaff);
            

            LoadStaff();
            LoadAsset();
            LoadSupplier();
            LoadSelected(Userlist);
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
            get { return _SelectedAsset; }
            set
            {
                _SelectedAsset = value;
            }
        }

        public void EditAsset(Object obj)
        {
            if (SelectedStaff != null)
            {
                UpdateSelectedAssetWindow update = new UpdateSelectedAssetWindow(SelectedAsset,User);
                update.ShowDialog();

            }
        }

        public void AddAsset(Object obj)
        {
            AddAssetWindow n = new AddAssetWindow(User);
            n.ShowDialog();
        }



        private ICollectionView _AssetCollectionView;
        public ICollectionView AssetCollectionView
        {
            get { return _AssetCollectionView; }
            set { _AssetCollectionView = value; }
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
        get { return _SelectedStaff; }
        set
            {
                _SelectedStaff = value;
            }
        }

        public void EditStaff(Object obj)
        {
            if (SelectedStaff != null)
            {
                //MessageBox.Show(SelectedStaff.firstname);


                UpdateSelectedStaffWindow update = new UpdateSelectedStaffWindow(SelectedStaff,User);
                update.ShowDialog();

            }
        }

        public void AddStaff(Object obj)
        {
            AddStaffWindow n = new AddStaffWindow(User);
            n.ShowDialog();
        }

        private ICollectionView _StaffCollectionView;
        public ICollectionView StaffCollectionView
        {
            get { return _StaffCollectionView; }
            set { _StaffCollectionView = value; }
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
            get { return _SelectedSupplier; }
            set
            {
                _SelectedSupplier = value;
            }
        }

        private ICollectionView _SupplierCollectionView;
        public ICollectionView SupplierCollectionView
        {
            get { return _SupplierCollectionView; }
            set { _SupplierCollectionView = value; }
        }

        public void EditSupplier(Object obj)
        {
            if (SelectedStaff != null)
            {
                 UpdateSupplierWindow  supplierwindow= new UpdateSupplierWindow(SelectedSupplier,User);
                 supplierwindow.ShowDialog();

            }
        }

        public void AddSupplier(Object obj)
        {
            AddSupplierWindow n = new AddSupplierWindow(User);
            n.ShowDialog();
        }
        #endregion

        #region Load User
        private int _user_id;
        public int User_id
        {
            get { return _user_id; }
            set
            {
                _user_id = value;
                OnPropertyChanged("User_id");
            }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        #endregion

        #region Methods 
        public void LoadAsset()
        {
            AssetList = DataAccess.GetAsset();
            AssetCollectionView = CollectionViewSource.GetDefaultView(AssetList);

           // AssetCollectionView.MoveCurrentToFirst();
            SelectedAsset = (AssetData)AssetCollectionView.CurrentItem;
        
        }

        public void LoadStaff()
        {
            StaffList = DataAccess.GetStaff();
            StaffCollectionView = CollectionViewSource.GetDefaultView(StaffList);

            //StaffCollectionView.MoveCurrentToFirst();
            SelectedStaff = (StaffData)StaffCollectionView.CurrentItem;
        }

        public void LoadSupplier()
        {
            SupplierList = DataAccess.GetSupplier();
            SupplierCollectionView = CollectionViewSource.GetDefaultView(SupplierList);

            //SupplierCollectionView.MoveCurrentToFirst();
            SelectedSupplier = (SupplierData)SupplierCollectionView.CurrentItem;
        }


        public void LoadSelected(UserData Userlist)
        {
            User_id = Userlist.User_id;
            Username = Userlist.Username;
           
        }
        #endregion
    }
}
