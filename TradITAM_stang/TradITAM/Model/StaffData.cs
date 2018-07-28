using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class StaffData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private int _staff_id;
        public int staff_id
        {
            get { return _staff_id; }
            set
            {
                _staff_id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("staff_id"));
            }
        }

        private string _firstname;
        public string firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged(new PropertyChangedEventArgs("firstname"));
            }
        }

        private string _lastname;
        public string lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(new PropertyChangedEventArgs("lastname"));
            }
        }

        private string _aka;
        public string aka
        {
            get { return _aka; }
            set
            {
                _aka = value;
                OnPropertyChanged(new PropertyChangedEventArgs("aka"));
            }
        }

        private DateTime _start_date;
        public DateTime start_date
        {
            get { return _start_date; }
            set
            {
                _start_date = value;
                OnPropertyChanged(new PropertyChangedEventArgs("start_date"));
            }
        }

        private DateTime _end_date;
        public DateTime end_date
        {
            get { return _end_date; }
            set
            {
                _end_date = value;
                OnPropertyChanged(new PropertyChangedEventArgs("end_date"));
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
