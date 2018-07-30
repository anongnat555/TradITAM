using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
    public class ReportViewWindowViewModel : ViewModelBase
    {
        public ReportViewWindowViewModel()
        {
            LoadReport();
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

        #region History
        private ObservableCollection<ReportData> _listreport = new ObservableCollection<ReportData>();
        public ObservableCollection<ReportData> ReportList
        {
            get => _listreport;
            set
            {
                _listreport = value;
                OnPropertyChanged(nameof(ReportList));
            }
        }

        private ICollectionView _reportCollectionView;
        public ICollectionView ReportCollectionView
        {
            get { return _reportCollectionView; }
            set { _reportCollectionView = value; }
        }

        private ReportData _Selectedreport;
        public ReportData SelectedReport
        {
            get { return _Selectedreport; }
            set
            {
                _Selectedreport = value;
            }
        }

        #endregion

        #region Method
        public void LoadReport()
        {
            ReportList = DataAccess.GetAssetHistory();
            ReportCollectionView = CollectionViewSource.GetDefaultView(ReportList);

            SelectedReport = (ReportData)ReportCollectionView.CurrentItem;

        }

        #endregion
    }
}
