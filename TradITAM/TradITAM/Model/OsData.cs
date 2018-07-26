using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class OsData
    {
        private int _os_id;
        public int Os_id
        {
            get { return _os_id; }
            set { _os_id = value; OnPropertyChanged(new PropertyChangedEventArgs("Os_id")); }
        }

        private string _os_name;
        public string Os_name
        {
            get { return _os_name; }
            set { _os_name = value; OnPropertyChanged(new PropertyChangedEventArgs("Os_name")); }
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}
