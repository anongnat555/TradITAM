using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class AssetData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

 
        private int _asset_id;
        public int Asset_id
        {
            get { return _asset_id; }
            set { _asset_id = value; OnPropertyChanged(new PropertyChangedEventArgs("Asset_id")); }
        }

        private int _os_id;
        public int Os_id
        {
            get { return _os_id; }
            set { _os_id = value; OnPropertyChanged(new PropertyChangedEventArgs("Os_id")); }
        }

        private int _asset_type_id;
        public int Asset_type_id
        {
            get { return _asset_type_id; }
            set { _asset_type_id = value; OnPropertyChanged(new PropertyChangedEventArgs("Asset_type_id")); }
        }

        private int _original_supplier_id;
        public int Original_supplier_id
        {
            get { return _original_supplier_id; }
            set { _original_supplier_id = value; OnPropertyChanged(new PropertyChangedEventArgs("Original_supplier_id")); }
        }

        private int _supplier_id;
        public int Supplier_id
        {
            get { return _supplier_id; }
            set { _supplier_id = value; OnPropertyChanged(new PropertyChangedEventArgs("Supplier_id")); }
        }

        private int _using_by_staff_id;
        public int Using_by_staff_id
        {
            get { return _using_by_staff_id; }
            set { _using_by_staff_id = value; OnPropertyChanged(new PropertyChangedEventArgs("Using_by_staff_id")); }
        }

        private string _asset_code;
        public string Asset_code
        {
            get { return _asset_code; }
            set { _asset_code = value; OnPropertyChanged(new PropertyChangedEventArgs("Asset_code")); }
        }

        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; OnPropertyChanged(new PropertyChangedEventArgs("Brand")); }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(new PropertyChangedEventArgs("Price")); }
        }

        private string _cpu;
        public string Cpu
        {
            get { return _cpu; }
            set { _cpu = value; OnPropertyChanged(new PropertyChangedEventArgs("Cpu")); }
        }

        private string _ram;
        public string Ram
        {
            get { return _ram; }
            set { _ram = value; OnPropertyChanged(new PropertyChangedEventArgs("Ram")); }
        }

        private string _hdd;
        public string Hdd
        {
            get { return _hdd; }
            set { _hdd = value; OnPropertyChanged(new PropertyChangedEventArgs("Hdd")); }
        }

        private string _note;
        public string Note
        {
            get { return _note; }
            set { _note = value; OnPropertyChanged(new PropertyChangedEventArgs("Note")); }
        }

        private DateTime _start_date_warranty;
        public DateTime Start_date_warranty
        {
            get { return _start_date_warranty; }
            set { _start_date_warranty = value; OnPropertyChanged(new PropertyChangedEventArgs("Start_date_warranty")); }
        }

        private DateTime _expiry_date_warranty;
        public DateTime Expiry_date_warranty
        {
            get { return _expiry_date_warranty; }
            set { _expiry_date_warranty = value; OnPropertyChanged(new PropertyChangedEventArgs("Expiry_date_warranty")); }
        }

        private bool _is_active;
        public bool Is_active
        {
            get { return _is_active; }
            set { _is_active = value; OnPropertyChanged(new PropertyChangedEventArgs("Is_active")); }
        }

        private DateTime _create_date;
        public DateTime Create_date
        {
            get { return _create_date; }
            set { _create_date = value; OnPropertyChanged(new PropertyChangedEventArgs("Create_date")); }
        }

        private DateTime _modified_date;
        public DateTime Modified_date
        {
            get { return _modified_date; }
            set { _modified_date = value; OnPropertyChanged(new PropertyChangedEventArgs("Modified_date")); }
        }
    }
}
