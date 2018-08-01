using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class ReportData
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private int _asset_history_id;
        public int asset_history_id
        {
            get { return _asset_history_id; }
            set { _asset_history_id = value; OnPropertyChanged(new PropertyChangedEventArgs("asset_history_id")); }
        }

        private int _user_id;
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; OnPropertyChanged(new PropertyChangedEventArgs("user_id")); }
        }

        private int _asset_id;
        public int asset_id
        {
            get { return _asset_id; }
            set { _asset_id = value; OnPropertyChanged(new PropertyChangedEventArgs("asset_id")); }
        }

        private int _asset_history_type;
        public int asset_history_type
        {
            get { return _asset_history_type; }
            set { _asset_history_type = value; OnPropertyChanged(new PropertyChangedEventArgs("asset_history_type")); }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set { _remark = value; OnPropertyChanged(new PropertyChangedEventArgs("remark")); }
        }

        private DateTime _history_timestamp;
        public DateTime history_timestamp
        {
            get { return _history_timestamp; }
            set { _history_timestamp = value; OnPropertyChanged(new PropertyChangedEventArgs("history_timestamp")); }
        }
    }
}
