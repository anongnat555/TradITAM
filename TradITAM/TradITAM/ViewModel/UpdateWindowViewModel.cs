using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using TradITAM.Helper;

namespace TradITAM.ViewModel
{
    public class UpdateWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public DelegateCommand<object> SaveChangesAsset { get; set; }
        public DelegateCommand<object> SaveChangesStaff { get; set; }
        public DelegateCommand<object> SaveChangesSupplier { get; set; }

        public UpdateWindowViewModel()
        {
            getAsset();
            getStaff();
            getSupplier();

            SaveChangesAsset = new DelegateCommand<object>(SaveAsset);
            SaveChangesStaff = new DelegateCommand<object>(SaveStaff);
            SaveChangesSupplier = new DelegateCommand<object>(SaveSupplier);
        }

        //------------------------ SELECT ------------------------

        //--- select asset ---
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

  
        //--- select staff ---
        private void getStaff()
        {
            var db = new TradAssetDBEntities();
            var con = db.staff.ToList();
            _liststaff = new ObservableCollection<staff>(con);
            db.Dispose();

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



        //--- select supplier ---
        private void getSupplier()
        {
            var db = new TradAssetDBEntities();
            var con = db.supplier.ToList();
            _listsupplier = new ObservableCollection<supplier>(con);
            db.Dispose();

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

        


        //------------------------ UPDATE ASSET ------------------------
        private asset _selectedasset;
        public asset Selectedasset
        {
            get => _selectedasset;
            set
            {
                _selectedasset = value;
                OnPropertyChanged(nameof(Selectedasset));
            }
        }

        private void SaveAsset(object o)
        {
            using (TradAssetDBEntities context = new TradAssetDBEntities())
            {
                asset asset_ = context.asset.Find(Selectedasset.asset_id);
                asset_.asset_id = Selectedasset.asset_id;
                asset_.os_id = Selectedasset.os_id;
                asset_.asset_type_id = Selectedasset.asset_type_id;
                asset_.original_supplier_id = Selectedasset.original_supplier_id;
                asset_.supplier_id = Selectedasset.supplier_id;
                asset_.using_by_staff_id = Selectedasset.using_by_staff_id;
                asset_.asset_code = Selectedasset.asset_code;
                asset_.brand = Selectedasset.brand;
                asset_.price = Selectedasset.price;
                asset_.cpu = Selectedasset.cpu;
                asset_.ram = Selectedasset.ram;
                asset_.hdd = Selectedasset.hdd;
                asset_.notes = Selectedasset.notes;
                asset_.start_date_warranty = asset_.start_date_warranty;
                asset_.expiry_date_warranty = Selectedasset.expiry_date_warranty;
                asset_.is_active = Selectedasset.is_active;
                asset_.create_date = DateTime.Now;
                asset_.modified_date = DateTime.Now;

                context.asset.AddOrUpdate(asset_);
                context.SaveChanges();
            }
            getAsset();
        }

        //------------------------ UPDATE STAFF ------------------------
        private staff _selectedstaff;
        public staff Selectedstaff
        {
            get => _selectedstaff;
            set
            {
                _selectedstaff = value;
                OnPropertyChanged(nameof(Selectedstaff));
            }
        }

        private void SaveStaff(object o)
        {
            using (TradAssetDBEntities context = new TradAssetDBEntities())
            {
                staff staff_ = context.staff.Find(Selectedstaff.staff_id);
                staff_.staff_id = Selectedstaff.staff_id;
                staff_.firstname = Selectedstaff.firstname;
                staff_.lastname = Selectedstaff.lastname;
                staff_.aka = Selectedstaff.aka;
                staff_.start_date = Selectedstaff.start_date;
                staff_.end_date = Selectedstaff.end_date;
                staff_.is_active = Selectedstaff.is_active;
                staff_.create_date = DateTime.Now;
                staff_.modified_date = DateTime.Now;

                context.staff.AddOrUpdate(staff_);
                context.SaveChanges();
            }
            getStaff();
        }

        //------------------------ UPDATE Supplier ------------------------
        private supplier _selectedsupplier;
        public supplier Selectedsupplier
        {
            get => _selectedsupplier;
            set
            {
                _selectedsupplier = value;
                OnPropertyChanged(nameof(Selectedsupplier));
            }
        }

        private void SaveSupplier(object o)
        {
            using (TradAssetDBEntities context = new TradAssetDBEntities())
            {
                supplier supplier_ = context.supplier.Find(Selectedsupplier.supplier_id);
                supplier_.supplier_id = Selectedsupplier.supplier_id;
                supplier_.company_name = Selectedsupplier.company_name;
                supplier_.contact_person = Selectedsupplier.contact_person;
                supplier_.address = Selectedsupplier.address;
                supplier_.email = Selectedsupplier.email;
                supplier_.phone = Selectedsupplier.phone;
                supplier_.is_active = Selectedsupplier.is_active;
                supplier_.create_date = DateTime.Now;
                supplier_.modified_date = DateTime.Now;

                context.supplier.AddOrUpdate(supplier_);
                context.SaveChanges();
            }
            getSupplier();
        }
    }
}

