using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using TradITAM;
using TradITAM.ViewModel;

namespace TradITAM.Model
{
    public class DataAccess
    {
        public bool hasError = false;
        public string errorMessage;

        #region Constructor
        public DataAccess()
        {

        }
        #endregion

        #region Staff 
        public ObservableCollection<StaffData> GetStaff()
        {
            hasError = false;
            ObservableCollection<StaffData> _staff = new ObservableCollection<StaffData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var query = db.staff.ToList(); 
                foreach (var item in query)
                {
                    StaffData pTemp = new StaffData(/*item*/);
                    pTemp.staff_id = item.staff_id;
                    pTemp.aka = item.aka;
                    pTemp.firstname = item.firstname;
                    pTemp.lastname = item.lastname;
                    pTemp.start_date = (DateTime)item.start_date;
                    pTemp.end_date = (DateTime)item.end_date;
                    pTemp.is_active = (bool)item.is_active;
                    pTemp.create_date = (DateTime)item.create_date;
                    pTemp.modified_date = (DateTime)item.modified_date;

                    _staff.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "GetStaff() error, " + ex.Message;
                hasError = true;
            }
            return _staff;
        }
        #endregion

        #region Asset
        public ObservableCollection<AssetData> GetAsset()
        {
            hasError = false;
            ObservableCollection<AssetData> _asset = new ObservableCollection<AssetData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var query = db.asset.ToList();
                foreach (var item in query)
                {
                    AssetData pTemp = new AssetData(/*item*/);
                    pTemp.Asset_id = item.asset_id;
                    pTemp.Os_id = (int)item.os_id;
                    pTemp.Asset_type_id = (int)item.asset_type_id;
                    pTemp.Original_supplier_id = (int)item.original_supplier_id;
                    pTemp.Supplier_id = (int)item.supplier_id;
                    pTemp.Using_by_staff_id = (int)item.using_by_staff_id;
                    pTemp.Asset_code = item.asset_code;
                    pTemp.Brand = item.brand;
                    pTemp.Price = (decimal)item.price;
                    pTemp.Cpu = item.cpu;
                    pTemp.Ram = item.ram;
                    pTemp.Hdd = item.hdd;
                    pTemp.Note = item.notes;
                    pTemp.Start_date_warranty = (DateTime)item.start_date_warranty;
                    pTemp.Expiry_date_warranty = (DateTime)item.expiry_date_warranty;
                    pTemp.Is_active = (bool)item.is_active;
                    pTemp.Create_date = (DateTime)item.create_date;
                    pTemp.Modified_date = (DateTime)item.modified_date;

                    _asset.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "GetAsset() error, " + ex.Message;
                hasError = true;
            }
            return _asset;
        }
        #endregion

        #region Supplier
        public ObservableCollection<SupplierData> GetSupplier()
        {
            hasError = false;
            ObservableCollection<SupplierData> _supplier = new ObservableCollection<SupplierData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var query = db.supplier.ToList();
                foreach (var item in query)
                {
                    SupplierData pTemp = new SupplierData(/*item*/);
                    pTemp.supplier_id = item.supplier_id;
                    pTemp.company_name = item.company_name;
                    pTemp.contact_person = item.contact_person;
                    pTemp.address = item.address;
                    pTemp.email = item.email;
                    pTemp.phone = item.phone;
                    pTemp.is_active = (bool)item.is_active;
                    pTemp.create_date = (DateTime)item.create_date;
                    pTemp.modified_date = (DateTime)item.modified_date;

                    _supplier.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "GetSupplier() error, " + ex.Message;
                hasError = true;
            }
            return _supplier;
        }

        #endregion

        #region AssetType
        public ObservableCollection<AssetTypeData> GetAssetType()
        {
            hasError = false;
            ObservableCollection<AssetTypeData> _asset_type = new ObservableCollection<AssetTypeData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var query = db.asset_type.ToList();
                foreach (var item in query)
                {
                    AssetTypeData pTemp = new AssetTypeData(/*item*/);
                    pTemp.Asset_type_id = item.asset_type_id;
                    pTemp.Asset_type_name = item.asset_type_name;
                    pTemp.Is_active = (bool)item.is_active;
                    pTemp.Create_date = (DateTime)item.create_date;
                    pTemp.Modified_date = (DateTime)item.modified_date;

                    _asset_type.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "GetAssettype() error, " + ex.Message;
                hasError = true;
            }
            return _asset_type;
        }
        #endregion

        #region Os
        public ObservableCollection<OsData> GetOs()
        {
            hasError = false;
            ObservableCollection<OsData> _os = new ObservableCollection<OsData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var query = db.os.ToList();
                foreach (var item in query)
                {
                    OsData pTemp = new OsData(/*item*/);
                    pTemp.Os_id = item.os_id;
                    pTemp.Os_name = item.os_name;
                    pTemp.Is_active = (bool)item.is_active;
                    pTemp.Create_date = (DateTime)item.create_date;
                    pTemp.Modified_date = (DateTime)item.modified_date;

                    _os.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Getos() error, " + ex.Message;
                hasError = true;
            }
            return _os;
        }
        #endregion

        #region user
        public ObservableCollection<UserData> GetUser()
        {
            hasError = false;
            ObservableCollection<UserData> _user = new ObservableCollection<UserData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var query = db.user_login.ToList();
                foreach (var item in query)
                {
                    UserData pTemp = new UserData(/*item*/);
                    pTemp.Username = item.username;
                    pTemp.Password = item.password;


                    _user.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Getuser() error, " + ex.Message;
                hasError = true;
            }
            return _user;
        }
        #endregion

        #region History
        public ObservableCollection<HistoryData> GetHistory()
        {
            hasError = false;
            ObservableCollection<HistoryData> _history = new ObservableCollection<HistoryData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var query = db.history.ToList();
                foreach (var item in query)
                {
                    HistoryData pTemp = new HistoryData(/*item*/);
                    pTemp.History_id = item.history_id;
                    pTemp.Refernces_id = (int)item.references_id;
                    pTemp.User_id = (int)item.user_id;
                    pTemp.Detail = item.detail;
                    pTemp.History_timestamp = (DateTime)item.history_timestamp;
                    pTemp.History_type = (int)item.history_type;

                    _history.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Gethistory() error, " + ex.Message;
                hasError = true;
            }
            return _history;
        }

        #endregion
    }
}
