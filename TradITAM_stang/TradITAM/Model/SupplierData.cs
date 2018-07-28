using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class SupplierData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private int _supplier_id;
        public int supplier_id
        {
            get { return _supplier_id; }
            set
            {
                _supplier_id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("supplier_id"));
            }
        }

        private string _company_name;
        public string company_name
        {
            get { return _company_name; }
            set
            {
                _company_name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("company_name"));
            }
        }

        private string _contact_person;
        public string contact_person
        {
            get { return _contact_person; }
            set
            {
                _contact_person = value;
                OnPropertyChanged(new PropertyChangedEventArgs("contact_person"));
            }
        }

        private string _address;
        public string address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(new PropertyChangedEventArgs("address"));
            }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(new PropertyChangedEventArgs("email"));
            }
        }

        private string _phone;
        public string phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(new PropertyChangedEventArgs("phone"));
            }
        }


        private bool _is_active;
        public bool is_active
        {
            get { return _is_active; }
            set
            {
                _is_active = value;
                OnPropertyChanged(new PropertyChangedEventArgs("is_active"));
            }
        }

        private DateTime _create_date;
        public DateTime create_date
        {
            get { return _create_date; }
            set
            {
                _create_date = value;
                OnPropertyChanged(new PropertyChangedEventArgs("create_date"));
            }
        }

        private DateTime _modified_date;
        public DateTime modified_date
        {
            get { return _modified_date; }
            set
            {
                _modified_date = value;
                OnPropertyChanged(new PropertyChangedEventArgs("modified_date"));
            }
        }
    }
}
