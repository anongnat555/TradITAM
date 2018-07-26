using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TradITAM.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {

            _listasset = getAsset();
            _liststaff = getStaff();
            _listsupplier =getSupplier();
        }


        //select asset
        public static ObservableCollection<asset> getAsset()
        {
            var db = new TradAssetDBEntities();
            var con = db.asset.ToList();
            var asset = new ObservableCollection<asset>(con);
            db.Dispose();
            return asset;

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

        //select staff 
        public static ObservableCollection<staff> getStaff()
        {
            var db = new TradAssetDBEntities();
            var con = db.staff.ToList();
            var staff = new ObservableCollection<staff>(con);
            db.Dispose();
            return staff;

        }

        private ObservableCollection<staff> _liststaff = new ObservableCollection<staff>();
        public ObservableCollection<staff> listStaff
        {
            get => _liststaff;
            set
            {
                _liststaff = value;
                OnPropertyChanged(nameof(listStaff));
            }
        }


        //select supplier
        public static ObservableCollection<supplier> getSupplier()
        {
            var db = new TradAssetDBEntities();
            var con = db.supplier.ToList();
            var supplier = new ObservableCollection<supplier>(con);
            db.Dispose();
            return supplier;

        }

        private ObservableCollection<supplier> _listsupplier = new ObservableCollection<supplier>();
        public ObservableCollection<supplier> listSupplier
        {
            get => _listsupplier;
            set
            {
                _listsupplier = value;
                OnPropertyChanged(nameof(listSupplier));
            }
        }  
    }
}
