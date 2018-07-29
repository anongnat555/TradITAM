using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TradITAM.Model;
using TradITAM.View;

namespace TradITAM.ViewModel
{
    public class HistoryWindowViewModel : ViewModelBase
    {
        public HistoryWindowViewModel()
        {
            LoadHistory();
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

        #region History
        private ObservableCollection<HistoryData> _listhistory = new ObservableCollection<HistoryData>();
        public ObservableCollection<HistoryData> HistoryList
        {
            get => _listhistory;
            set
            {
                _listhistory = value;
                OnPropertyChanged(nameof(HistoryList));
            }
        }

        private ICollectionView _historyCollectionView;
        public ICollectionView HistoryCollectionView
        {
            get { return _historyCollectionView; }
            set { _historyCollectionView = value; }
        }

        private HistoryData _Selectedhistory;
        public HistoryData SelectedHistory
        {
            get { return _Selectedhistory; }
            set
            {
                _Selectedhistory = value;
            }
        }

        #endregion

        #region Method
        public void LoadHistory()
        {
            HistoryList = DataAccess.GetHistory();
            HistoryCollectionView = CollectionViewSource.GetDefaultView(HistoryList);

            SelectedHistory = (HistoryData)HistoryCollectionView.CurrentItem;

        }
     
        #endregion
    }
}
