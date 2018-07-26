using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class AssetModel : ViewModel.ViewModelBase
    {
        private string _asset_id;
        private string _os_id;
        private string _asset_type_id;
        private string _original_supplier_id;
        private string _supplier_id;
        private string _using_by_staff_id;
        private string _asset_code;
        private string _brand;
        private string _price;
        private string _cpu;
        private string _ram;
        private string _hdd;
        private string _note;
        private string _start_date_warranty;
        private string _expiry_date_warranty;
        private string _is_active;
        private string _create_date;
        private string _modified_date;

        public string Asset_id
        {
            get { return _asset_id; }
            set { _asset_id = value; OnPropertyChanged(); }
        }

        public string Os_id
        {
            get { return _os_id; }
            set { _os_id = value; OnPropertyChanged(); }
        }
        public string Asset_type_id
        {
            get { return _asset_type_id; }
            set { _asset_type_id = value; OnPropertyChanged(); }
        }
        public string Original_supplier_id
        {
            get { return _original_supplier_id; }
            set { _original_supplier_id = value; OnPropertyChanged(); }
        }
        public string Supplier_id
        {
            get { return _supplier_id; }
            set { _supplier_id = value; OnPropertyChanged(); }
        }
        public string Using_by_staff_id
        {
            get { return _using_by_staff_id; }
            set { _using_by_staff_id = value; OnPropertyChanged(); }
        }
        public string Asset_code
        {
            get { return _asset_code; }
            set { _asset_code = value; OnPropertyChanged(); }
        }
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; OnPropertyChanged(); }
        }
        public string Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(); }
        }
        public string Cpu
        {
            get { return _cpu; }
            set { _cpu = value; OnPropertyChanged(); }
        }
        public string Ram
        {
            get { return _ram; }
            set { _ram = value; OnPropertyChanged(); }
        }
        public string Hdd
        {
            get { return _hdd; }
            set { _hdd = value; OnPropertyChanged(); }
        }
        public string Note
        {
            get { return _note; }
            set { _note = value; OnPropertyChanged(); }
        }
        public string Start_date_warranty
        {
            get { return _start_date_warranty; }
            set { _start_date_warranty = value; OnPropertyChanged(); }
        }
        public string Expiry_date_warranty
        {
            get { return _expiry_date_warranty; }
            set { _expiry_date_warranty = value; OnPropertyChanged(); }
        }
        public string Is_active
        {
            get { return _is_active; }
            set { _is_active = value; OnPropertyChanged(); }
        }
        public string Create_date
        {
            get { return _create_date; }
            set { _create_date = value; OnPropertyChanged(); }
        }
        public string Modified_date
        {
            get { return _modified_date; }
            set { _modified_date = value; OnPropertyChanged(); }
        }
    }
}
