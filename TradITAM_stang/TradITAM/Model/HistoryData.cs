using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class HistoryData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private int _history_id;
        public int History_id
        {
            get { return _history_id; }
            set
            {
                _history_id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("History_id"));
            }
        }

        private int _user_id;
        public int User_id
        {
            get { return _user_id; }
            set
            {
                _user_id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("User_id"));
            }
        }

        private int _refernces_id;
        public int Refernces_id
        {
            get { return _refernces_id; }
            set
            {
                _refernces_id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Refernces_id"));
            }
        }

        private string _detail;
        public string Detail
        {
            get { return _detail; }
            set
            {
                _detail = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Detail"));
            }
        }

        private DateTime _history_timestamp;
        public DateTime History_timestamp
        {
            get { return _history_timestamp; }
            set
            {
                _history_timestamp = value;
                OnPropertyChanged(new PropertyChangedEventArgs("History_timestamp"));
            }
        }

        private int _history_type;
        public int History_type
        {
            get { return _history_type; }
            set
            {
                _history_type = value;
                OnPropertyChanged(new PropertyChangedEventArgs("History_type"));
            }
        }
    }
}
