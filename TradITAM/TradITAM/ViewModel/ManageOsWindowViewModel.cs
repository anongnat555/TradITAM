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
    public class ManageOsWindowViewModel : ViewModelBase
    {
        #region Global Variable
        public DelegateCommand<object> AddOsCommand { get; set; }
        public DelegateCommand<object> UpdateOsCommand { get; set; }
        public DelegateCommand<object> GetOsEvent { get; set; }

        private UserData UserInfo { get; set; }
        #endregion

        public ManageOsWindowViewModel(UserData UserList)
        {
            UserInfo = new UserData();
            UserInfo = UserList;

            /* Define AddEvent using DelegateCommand */
            AddOsCommand = new DelegateCommand<object>(AddOs);

            /* Define UpdateEvent using DelegateCommand */
            UpdateOsCommand = new DelegateCommand<object>(UpdateOs);

            /* Define GetEvent using DelegateCommand */
            GetOsEvent = new DelegateCommand<object>(GetOsInformation);

            LoadOs();    //Load 'Os' from database to get 'Os_name' in combobox
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
        private OsData _listos = new OsData();
        public OsData OsList
        {
            get => _listos;
            set
            {
                _listos = value;
                OnPropertyChanged(nameof(OsList));
            }
        }

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

        private OsData _osnew = new OsData();
        public OsData Osnew
        {
            get => _osnew;
            set
            {
                _osnew = value;
                OnPropertyChanged(nameof(Osnew));
            }
        }
        #endregion

        #region Load Os
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

        #region Os (For Update)
        private ObservableCollection<OsData> _listos_u = new ObservableCollection<OsData>();
        public ObservableCollection<OsData> OsList_u
        {
            get => _listos_u;
            set
            {
                _listos_u = value;
                OnPropertyChanged(nameof(OsList_u));
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

        private void GetOsInformation(object obj)
        {
            /* Assign os value into each os property from ui selection */
            Os_id_u = SelectedOs.os_id;
            Is_active_u = SelectedOs.is_active;
        }
        #endregion

        #region Load Os (For Update)
        private int _os_id_u;
        public int Os_id_u
        {
            get => _os_id_u;
            set
            {
                _os_id_u = value;
                OnPropertyChanged(nameof(Os_id_u));
            }
        }

        private string _os_name_u;
        public string Os_name_u
        {
            get => _os_name_u;
            set
            {
                _os_name_u = value;
                OnPropertyChanged(nameof(Os_name_u));
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
        public void AddOs(Object o)
        {
            OsList.os_name = Os_name;
            OsList.is_active = Is_active;

            if (OsList != null)
            {
                var insertion = new InsertAccess();
                insertion.AddOs(OsList);

                /*  Add User Log */
                historyUser.User_id = UserInfo.user_id;
                historyUser.Detail = "Insert " + Os_name + " in Os Table";
                var insertionLog = new InsertAccess();
                insertionLog.LogHistory(historyUser);
            }
        }

        public void UpdateOs(object o)
        {
            Osnew.os_id = Os_id_u;
            Osnew.os_name = Os_name_u;
            Osnew.is_active = Is_active_u;

            if (Osnew != null)
            {
                var update = new UpdateAccess();
                update.UpdateOs(Osnew);

                /*  Add User Log */
                historyUser.User_id = UserInfo.user_id;
                historyUser.Detail = "Update " + Os_name_u + " in Os Table";
                var insertionLog = new InsertAccess();
                insertionLog.LogHistory(historyUser);
            }
        }

        public void LoadOs()
        {
            OsList_u = DataAccess.GetOs();
            OsCollectionView = CollectionViewSource.GetDefaultView(OsList_u);
        }
        #endregion
    }
}
