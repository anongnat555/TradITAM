using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class UserData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private int _user_id;
        public int user_id
        {
            get { return _user_id; }
            set
            {
                _user_id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("user_id"));
            }
        }

        private string _username;
        public string username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(new PropertyChangedEventArgs("username"));
            }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(new PropertyChangedEventArgs("password"));
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
