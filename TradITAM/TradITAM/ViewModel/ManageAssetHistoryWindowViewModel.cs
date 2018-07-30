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
    public class ManageAssetHistoryWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> AddAssetHistoryTypeCommand { get; set; }
        public DelegateCommand<object> UpdateAssetHistoryTypeCommand { get; set; }
        public DelegateCommand<object> GetAssetHistoryTypeEvent { get; set; }
        #endregion

        public ManageAssetHistoryWindowViewModel()
        {
            /* Define AddEvent using DelegateCommand */
            AddAssetHistoryTypeCommand = new DelegateCommand<object>(AddAssetHistoryType);

            /* Define UpdateEvent using DelegateCommand */
            UpdateAssetHistoryTypeCommand = new DelegateCommand<object>(UpdateAssetHistoryType);

            /* Define GetEvent using DelegateCommand */
            GetAssetHistoryTypeEvent = new DelegateCommand<object>(GetAssetHistoryTypeInformation);

            LoadAssetHistoryType();    //Load 'Asset History Type' from database to get 'Type_code' in combobox
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
        private AssetHistoryTypeData _listassethistorytype = new AssetHistoryTypeData();
        public AssetHistoryTypeData AssetHistoryTypeList
        {
            get => _listassethistorytype;
            set
            {
                _listassethistorytype = value;
                OnPropertyChanged(nameof(AssetHistoryTypeList));
            }
        }

        private AssetHistoryTypeData _assethistorytypenew = new AssetHistoryTypeData();
        public AssetHistoryTypeData AssetHistoryTypenew
        {
            get => _assethistorytypenew;
            set
            {
                _assethistorytypenew = value;
                OnPropertyChanged(nameof(AssetHistoryTypenew));
            }
        }
        #endregion

        #region Load Asset History Type
        private string _type_code;
        public string Type_code
        {
            get => _type_code;
            set
            {
                _type_code = value;
                OnPropertyChanged(nameof(Type_code));
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

        #region AssetHistoryType (For Update)
        private ObservableCollection<AssetHistoryTypeData> _listassethistorytype_u = new ObservableCollection<AssetHistoryTypeData>();
        public ObservableCollection<AssetHistoryTypeData> AssetHistoryTypeList_u
        {
            get => _listassethistorytype_u;
            set
            {
                _listassethistorytype_u = value;
                OnPropertyChanged(nameof(AssetHistoryTypeList_u));
            }
        }

        private AssetHistoryTypeData _SelectedAssetHistoryType;
        public AssetHistoryTypeData SelectedAssetHistoryType
        {
            get => _SelectedAssetHistoryType;
            set
            {
                _SelectedAssetHistoryType = value;
                OnPropertyChanged(nameof(SelectedAssetHistoryType));

                //update textbox after selected
                GetAssetHistoryTypeInformation(SelectedAssetHistoryType);
            }
        }

        private ICollectionView _AssetHistoryTypeCollectionView;
        public ICollectionView AssetHistoryTypeCollectionView
        {
            get { return _AssetHistoryTypeCollectionView; }
            set { _AssetHistoryTypeCollectionView = value; }
        }

        private void GetAssetHistoryTypeInformation(object obj)
        {
            /* Assign asset history type value into each asset property from ui selection */
            Asset_history_type_id_u = SelectedAssetHistoryType.Asset_history_type_id;
            Type_code_u = SelectedAssetHistoryType.Type_code;
            Is_active_u = SelectedAssetHistoryType.Is_active;
        }
        #endregion

        #region Load Asset Type (For Update)
        private int _asset_history_type_id_u;
        public int Asset_history_type_id_u
        {
            get => _asset_history_type_id_u;
            set
            {
                _asset_history_type_id_u = value;
                OnPropertyChanged(nameof(Asset_history_type_id_u));
            }
        }

        private string _type_code_u;
        public string Type_code_u
        {
            get => _type_code_u;
            set
            {
                _type_code_u = value;
                OnPropertyChanged(nameof(Type_code_u));
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
        public void AddAssetHistoryType(Object o)
        {
            AssetHistoryTypeList.Type_code = Type_code;
            AssetHistoryTypeList.Is_active = Is_active;

            if (AssetHistoryTypeList != null)
            {
                var insertion = new InsertAccess();
                insertion.AddAssetHistoryType(AssetHistoryTypeList);
            }
        }

        public void UpdateAssetHistoryType(object o)
        {
            AssetHistoryTypenew.Asset_history_type_id = Asset_history_type_id_u;
            AssetHistoryTypenew.Type_code = Type_code_u;
            AssetHistoryTypenew.Is_active = Is_active_u;

            if (AssetHistoryTypenew != null)
            {
                var update = new UpdateAccess();
                update.UpdateAssetHistoryType(AssetHistoryTypenew);
            }
        }

        public void LoadAssetHistoryType()
        {
            AssetHistoryTypeList_u = DataAccess.GetAssetTypeHistory();
            AssetHistoryTypeCollectionView = CollectionViewSource.GetDefaultView(AssetHistoryTypeList_u);
        }
        #endregion
    }
}
