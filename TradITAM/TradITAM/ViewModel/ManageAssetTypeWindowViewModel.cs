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
    public class ManageAssetTypeWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> AddAssetTypeCommand { get; set; }
        public DelegateCommand<object> UpdateAssetTypeCommand { get; set; }
        public DelegateCommand<object> GetAssetTypeEvent { get; set; }

        private UserData UserInfo { get; set; }
        #endregion

        public ManageAssetTypeWindowViewModel(UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;

            /* Define AddEvent using DelegateCommand */
            AddAssetTypeCommand = new DelegateCommand<object>(AddAssetType);

            /* Define UpdateEvent using DelegateCommand */
            UpdateAssetTypeCommand = new DelegateCommand<object>(UpdateAssetType);

            /* Define GetEvent using DelegateCommand */
            GetAssetTypeEvent = new DelegateCommand<object>(GetAssetTypeInformation);

            LoadAssetType();    //Load 'Asset Type' from database to get 'Asset_type_name' in combobox
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
        private AssetTypeData _listassettype = new AssetTypeData();
        public AssetTypeData AssetTypeList
        {
            get => _listassettype;
            set
            {
                _listassettype = value;
                OnPropertyChanged(nameof(AssetTypeList));
            }
        }

        private AssetTypeData _assettypenew = new AssetTypeData();
        public AssetTypeData AssetTypenew
        {
            get => _assettypenew;
            set
            {
                _assettypenew = value;
                OnPropertyChanged(nameof(AssetTypenew));
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

        #region Load Asset Type
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

        private bool _is_active;
        public bool Is_active
        {
            get => _is_active;
            set
            {
                _is_active = value;
                OnPropertyChanged(nameof(Is_active));
            }
        }
        #endregion

        #region AssetType (For Update)
        private ObservableCollection<AssetTypeData> _listassettype_u = new ObservableCollection<AssetTypeData>();
        public ObservableCollection<AssetTypeData> AssetTypeList_u
        {
            get => _listassettype_u;
            set
            {
                _listassettype_u = value;
                OnPropertyChanged(nameof(AssetTypeList_u));
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

        private void GetAssetTypeInformation(object obj)
        {
            /* Assign asset type value into each asset property from ui selection */
            Asset_type_id_u = SelectedAssetType.asset_type_id;
            Is_active_u = SelectedAssetType.is_active;
        }
        #endregion

        #region Load Asset Type (For Update)
        private int _asset_type_id_u;

        public int Asset_type_id_u
        {
            get => _asset_type_id_u;
            set
            {
                _asset_type_id_u = value;
                OnPropertyChanged(nameof(Asset_type_id_u));
            }
        }

        private string _asset_type_name_u;
        public string Asset_type_name_u
        {
            get => _asset_type_name_u;
            set
            {
                _asset_type_name_u = value;
                OnPropertyChanged(nameof(Asset_type_name_u));
            }
        }

        private bool _is_active_u;
        public bool Is_active_u
        {
            get => _is_active_u;
            set
            {
                _is_active_u = value;
                OnPropertyChanged(nameof(Is_active_u));
            }
        }
        #endregion

        #region Method
        public void AddAssetType(Object o)
        {
            AssetTypeList.asset_type_name = Asset_type_name;
            AssetTypeList.is_active = Is_active;

            if (AssetTypeList != null)
            {
                var insertion = new InsertAccess();
                insertion.AddAssetType(AssetTypeList);

                /*  Add User Log */
                historyUser.User_id = UserInfo.user_id;
                historyUser.History_id = 1;
                historyUser.Detail = "Insert " + Asset_type_name + " in AssetType Table";
                var insertionLog = new InsertAccess();
                insertionLog.LogHistory(historyUser);
            }
        }

        public void UpdateAssetType(object o)
        {
            AssetTypenew.asset_type_id = Asset_type_id_u;
            AssetTypenew.asset_type_name = Asset_type_name_u;
            AssetTypenew.is_active = Is_active_u;

            if (AssetTypenew != null)
            {
                var update = new UpdateAccess();
                update.UpdateAssetType(AssetTypenew);

                /*  Add User Log */
                historyUser.User_id = UserInfo.user_id;
                historyUser.History_id = 2;
                historyUser.Detail = "Update " + Asset_type_name_u + " in AssetType Table";
                var insertionLog = new InsertAccess();
                insertionLog.LogHistory(historyUser);
            }
        }

        public void LoadAssetType()
        {
            AssetTypeList_u = DataAccess.GetAssetType();
            AssetTypeCollectionView = CollectionViewSource.GetDefaultView(AssetTypeList_u);
        }
        #endregion
    }
}
