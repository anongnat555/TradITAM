using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradITAM.Model;

namespace TradITAM.ViewModel
{
    public class UpdateWindowViewModel : ViewModelBase
    {
        public DelegateCommand<object> getAssetCommand { get; set; }
        public UpdateWindowViewModel()
        {
            getAsset();
            getAssetCommand = new DelegateCommand<object>(getasset);
        }

        //select asset
        private void getAsset()
        {
            var db = new TradAssetDBEntities();
            var con = db.asset.ToList();
            _listasset = new ObservableCollection<asset>(con);
            db.Dispose();

        }

        private ObservableCollection<asset> _listasset = new ObservableCollection<asset>();
        public ObservableCollection<asset> listAsset
        {
            get => _listasset;
            set
            {
                _listasset = value;
                OnPropertyChanged(nameof(listAsset));
            }
        }

        private void getasset(object o)
        {
            getAsset();
        }

     
    }
}