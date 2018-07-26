using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TradITAM.Model;
using TradITAM.Helper;
using System.Windows;

namespace TradITAM.ViewModel
{
    public class UpdateStaffWindowViewModel : ViewModelBase
    {
        //public DelegateCommand<object> GetStaffEvent { get; set; }
        public DelegateCommand<object> Updatecommand { get; set; }
        public UpdateStaffWindowViewModel(StaffData staffDt)
        {
            //GetStaffEvent = new DelegateCommand<object>(GetStaffInformation);
            Updatecommand = new DelegateCommand<object>(Update);
            
            //_aaid = staffDt.staff_id - 1;
            //Aaid(staffDt.staff_id);
            LoadAka();

            show(staffDt);
        }

        //call dataaccess
        private DataAccess _DataAccess;
        public DataAccess DataAccess
        {
            get
            {
                if (_DataAccess == null)
                    _DataAccess = new DataAccess();
                return _DataAccess;
            }
        }



        #region Staff
        private ObservableCollection<StaffData> _liststaff = new ObservableCollection<StaffData>();
        public ObservableCollection<StaffData> StaffList
        {
            get => _liststaff;
            set
            {
                _liststaff = value;
                OnPropertyChanged(nameof(StaffList));
            }
        }


        private StaffData _newstaff = new StaffData();
        public StaffData Staffnew
        {
            get => _newstaff;
            set
            {
                _newstaff = value;
                OnPropertyChanged(nameof(Staffnew));
            }
        }

        private StaffData _SelectedStaff;
        public StaffData SelectedStaff
        {
            get => _SelectedStaff;
            set
            {
                _SelectedStaff = value;
                OnPropertyChanged(nameof(SelectedStaff));

                //update textbox after selected
                GetStaffInformation(SelectedStaff);
            }
        }

        private ICollectionView _StaffCollectionView;
        public ICollectionView StaffCollectionView
        {
            get { return _StaffCollectionView; }
            set
            {
                _StaffCollectionView = value;
                OnPropertyChanged(nameof(StaffCollectionView));
            }
        }



        private Collection<StaffData> _StaffCollection;
        public Collection<StaffData> StaffCollection
        {
            get { return _StaffCollection; }
            set { _StaffCollection = value; }
        }

        public void GetStaffInformation(Object obj)
        {
            if (SelectedStaff != null)
            {
                staff_id = SelectedStaff.staff_id;
                aka = SelectedStaff.aka;
                firstname = SelectedStaff.firstname;
                lastname = SelectedStaff.lastname;
                is_active = SelectedStaff.is_active;
                start_date = SelectedStaff.start_date;
                end_date = SelectedStaff.end_date;

            }
        }

        #endregion

        #region Load Data

        private int _staffid;
        public int staff_id
        {
            get { return _staffid; }
            set
            {
                _staffid = value;
                OnPropertyChanged(nameof(staff_id));
            }
        }

        private string _firstname;
        public string firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(firstname));
            }
        }

        private string _lastname;
        public string lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(lastname));
            }
        }

        private string _aka;
        public string aka
        {
            get { return _aka; }
            set
            {
                _aka = value;
                OnPropertyChanged(nameof(aka));
            }
        }

        private DateTime _start_date;
        public DateTime start_date
        {
            get { return _start_date; }
            set
            {
                _start_date = value;
                OnPropertyChanged(nameof(start_date));
            }
        }

        private DateTime _end_date;
        public DateTime end_date
        {
            get { return _end_date; }
            set
            {
                _end_date = value;
                OnPropertyChanged(nameof(end_date));
            }
        }

        private bool _is_active;
        public bool is_active
        {
            get { return _is_active; }
            set
            {
                _is_active = value;
                OnPropertyChanged(nameof(is_active));
            }
        }

        private DateTime _create_date;
        public DateTime create_date
        {
            get { return _create_date; }
            set
            {
                _create_date = value;
                OnPropertyChanged(nameof(create_date));
            }
        }

        private DateTime _modified_date;
        public DateTime modified_date
        {
            get { return _modified_date; }
            set
            {
                _modified_date = value;
                OnPropertyChanged(nameof(modified_date));
            }
        }
        #endregion

        #region Method
        public void LoadAka()
         {
            StaffList = DataAccess.GetStaff();
            
            StaffCollectionView = CollectionViewSource.GetDefaultView(StaffList);
            
            //StaffCollectionView.MoveCurrentToFirst();
            SelectedStaff = (StaffData)StaffCollectionView.CurrentItem;
        }

        public void Update(object o)
        {
            if (SelectedStaff != null)
            {
                Staffnew.staff_id = staff_id;
                Staffnew.aka = aka;
                Staffnew.firstname = firstname;
                Staffnew.lastname = lastname;
                Staffnew.is_active = is_active;
                Staffnew.start_date = start_date;
                Staffnew.end_date = end_date;
                Staffnew.create_date = create_date;
                Staffnew.modified_date = modified_date;
            }
            var updatestaff = new UpdateAccess();
            updatestaff.UpdateStaff(Staffnew);
        }

        public void show(StaffData staffDt)
        {
            S = staffDt;
        }

        private StaffData _S;
        public StaffData S
        {
            get => _S;
            set
            {
                _S = value;
                OnPropertyChanged(nameof(S));
            }
        }
        #endregion
    }
}
