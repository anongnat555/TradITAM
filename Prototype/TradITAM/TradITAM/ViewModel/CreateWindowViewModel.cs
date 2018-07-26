using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace TradITAM.ViewModel
{
    public class CreateWindowViewModel : ViewModelBase 
    {

        public DelegateCommand<object> AddStaffCommand { get; set; }
        public DelegateCommand<object> AddSupplierCommand { get; set; }
        public CreateWindowViewModel()
        {

           
            getSupplier();
            AddStaffCommand = new DelegateCommand<object>(AddStaff);
            AddSupplierCommand = new DelegateCommand<object>(Addsupplier);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------
        //select staff 
    

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


        private string _firstname;
        private string _lastname;
        private string _aka;
        private DateTime _startdate;
        private DateTime _enddate;
        private bool _isactive;
        


        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }


        public string Aka
        {
            get => _aka;
            set
            {
                _aka = value;
                OnPropertyChanged(nameof(Aka));
            }
        }



        public DateTime StartDate
        {
            get => _startdate;
            set
            {
                _startdate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get => _enddate;
            set
            {
                _enddate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }


        public bool Isactive
        {
            get => _isactive;
            set
            {
                _isactive = value;
                OnPropertyChanged(nameof(Isactive));
            }
        }

        private void AddStaff(object o)
        {
            try
            {
                using (var db = new TradAssetDBEntities())
                {
                    var data = new staff
                    {
                        firstname = Firstname,
                        lastname = Lastname,
                        aka = Aka,
                        start_date = StartDate,
                        end_date = EndDate,
                        is_active = Isactive,
                        create_date = DateTime.Now,
                        modified_date = DateTime.Now
                    };
                    Console.WriteLine(data);
                    db.staff.Add(data);
                    db.SaveChanges();

                }
                listStaff = MainWindowViewModel.getStaff();
                MessageBox.Show("Insert complete");
                
            }
            catch (Exception )
            {
                 MessageBox.Show("Insert incomplete");
               
            }
            

        }
      
        
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //select supplier
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

    
        private string _companyname;
        private string _contactperson;
        private string _address;
        private string _email;
        private string _phone;
        private bool _isactives;
 

        public string Companyname
        {
            get => _companyname;
            set
            {
                _companyname = value;
                OnPropertyChanged(nameof(Companyname));
            }
        }

        public string Contactperson
        {
            get => _contactperson;
            set
            {
                _contactperson = value;
                OnPropertyChanged(nameof(Contactperson));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public bool Isactives
        {
            get => _isactives;
            set
            {
                _isactives = value;
                OnPropertyChanged(nameof(Isactives));
            }
        }

        private void Addsupplier(object o)
        {
            try
            {
                using (var db = new TradAssetDBEntities())
                {
                    var data = new supplier
                    {

                        company_name = Companyname,
                        contact_person = Contactperson,
                        address = Address,
                        email = Email,
                        phone = Phone,
                        is_active = Isactives,
                        create_date = DateTime.Now,
                        modified_date = DateTime.Now   
                    };
                    Console.WriteLine(data);
                    db.supplier.Add(data);
                    db.SaveChanges();

                }
                listSupplier = MainWindowViewModel.getSupplier();
                MessageBox.Show("Insert complete");

            }
            catch (Exception)
            {
                MessageBox.Show("Insert incomplete");
            }
            

        }
    }
}
