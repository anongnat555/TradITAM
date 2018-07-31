using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using TradITAM;
using TradITAM.ViewModel;
using System.Windows;

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

                    if (pTemp.is_active == true)
                    {
                        _staff.Add(pTemp);
                    }
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
                    if (item.cpu == null) { pTemp.Cpu = "-"; } else { pTemp.Cpu = item.cpu; }
                    if (item.ram == null) { pTemp.Ram = "-"; } else { pTemp.Ram = item.ram; }
                    if (item.hdd == null) { pTemp.Hdd = "-"; } else { pTemp.Hdd = item.hdd; }
                    pTemp.Note = item.notes;
                    pTemp.Start_date_warranty = (DateTime)item.start_date_warranty;
                    pTemp.Expiry_date_warranty = (DateTime)item.expiry_date_warranty;
                    pTemp.Is_active = (bool)item.is_active;
                    pTemp.Create_date = (DateTime)item.create_date;
                    pTemp.Modified_date = (DateTime)item.modified_date;

                    if (pTemp.Is_active == true)
                    {
                        _asset.Add(pTemp);
                    }
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

                    if (pTemp.is_active == true)
                    {
                        _supplier.Add(pTemp);
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "GetStaff() error, " + ex.Message;
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
                    pTemp.asset_type_id = item.asset_type_id;
                    pTemp.asset_type_name = item.asset_type_name;
                    pTemp.is_active = (bool)item.is_active;
                    pTemp.create_date = (DateTime)item.create_date;
                    pTemp.modified_date = (DateTime)item.modified_date;

                    _asset_type.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "GetAsset() error, " + ex.Message;
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
                    pTemp.os_id = item.os_id;
                    pTemp.os_name = item.os_name;
                    pTemp.is_active = (bool)item.is_active;
                    pTemp.create_date = (DateTime)item.create_date;
                    pTemp.modified_date = (DateTime)item.modified_date;

                    _os.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "GetAsset() error, " + ex.Message;
                hasError = true;
            }
            return _os;
        }
        #endregion

        #region AssetTypeHistory
        public ObservableCollection<AssetHistoryTypeData> GetAssetTypeHistory()
        {
            hasError = false;
            ObservableCollection<AssetHistoryTypeData> _asset_history_type = new ObservableCollection<AssetHistoryTypeData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var query = db.asset_history_type.ToList();
                foreach (var item in query)
                {
                    AssetHistoryTypeData pTemp = new AssetHistoryTypeData(/*item*/);
                    pTemp.Asset_history_type_id = item.asset_history_type_id;
                    pTemp.Type_code = item.type_code;
                    pTemp.Type_description = item.type_description;
                    pTemp.Is_active = (bool)item.is_active;
                    pTemp.Create_date = (DateTime)item.create_date;
                    pTemp.Modified_date = (DateTime)item.modified_date;

                    _asset_history_type.Add(pTemp);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "GetAsset() error, " + ex.Message;
                hasError = true;
            }
            return _asset_history_type;
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

        #region AssetHistory
        public ObservableCollection<ReportData> GetAssetHistory()
        {
            hasError = false;
            ObservableCollection<ReportData> _history = new ObservableCollection<ReportData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var query = db.asset_history.ToList();
                foreach (var item in query)
                {
                    ReportData pTemp = new ReportData(/*item*/);
                    pTemp.asset_history_id = item.asset_history_id;
                    pTemp.user_id = (int)item.user_id;
                    pTemp.asset_id = (int)item.asset_id;
                    pTemp.asset_history_type = (int)item.asset_history_type;
                    pTemp.remark = item.remark;
                    pTemp.history_timestamp = (DateTime)item.history_timestamp;

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

        #region Get value for UpdateAssetWindow's Combobox

        #region Get Staff's Aka 
        public string GetStaffAka(int Uid)
        {
            hasError = false;
            string _result = null;
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();

                var query = db.staff.FirstOrDefault(x => x.staff_id == Uid);

                if (query != null)
                {
                    _result = query.aka;
                }
                else
                {
                    MessageBox.Show("NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                errorMessage = "GetStaffAka() error, " + ex.Message;
                hasError = true;
            }
            return _result;
        }
        #endregion

        #region  Get Supplier's Company_name 
        public string GetSupplierCompanyName(int Sid)
        {
            hasError = false;
            string _result = null;
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();

                var query = db.supplier.FirstOrDefault(x => x.supplier_id == Sid);

                if (query != null)
                {
                    _result = query.company_name;
                }
                else
                {
                    MessageBox.Show("NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                errorMessage = "GetSupplierCompanyName() error, " + ex.Message;
                hasError = true;
            }
            return _result;
        }
        #endregion

        #region  Get AssetType's Asset_type_name 
        public string GetAssetTypeName(int Tid)
        {
            hasError = false;
            string _result = null;
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();

                var query = db.asset_type.FirstOrDefault(x => x.asset_type_id == Tid);

                if (query != null)
                {
                    _result = query.asset_type_name;
                }
                else
                {
                    MessageBox.Show("NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                errorMessage = "GetAssetTypeName() error, " + ex.Message;
                hasError = true;
            }
            return _result;
        }
        #endregion

        #region  Get Os's Os_name 
        public string GetOsName(int Oid)
        {
            hasError = false;
            string _result = null;
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();

                var query = db.os.FirstOrDefault(x => x.os_id == Oid);

                if (query != null)
                {
                    _result = query.os_name;
                }
                else
                {
                    MessageBox.Show("NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                errorMessage = "GetOsName() error, " + ex.Message;
                hasError = true;
            }
            return _result;
        }
        #endregion

        #endregion

        #region Get foreign key value for ReportWindow

        #region Join Asset Type via Asset
        public ObservableCollection<AssetTypeData> GetAssetTypeFromAsset(AssetData item)
        {
            hasError = false;
            ObservableCollection<AssetTypeData> _result = new ObservableCollection<AssetTypeData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();

                var query = db.asset_type.FirstOrDefault(x => x.asset_type_id == item.Asset_type_id);

                if (query != null)
                {
                    AssetTypeData pTemp = new AssetTypeData(/*item*/);
                    pTemp.asset_type_id = query.asset_type_id;
                    pTemp.asset_type_name = query.asset_type_name;

                    _result.Add(pTemp);
                }
                else
                {
                    MessageBox.Show("NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                errorMessage = "GetAssetTypeFromAsset() error, " + ex.Message;
                hasError = true;
            }
            return _result;
        }
        #endregion

        #region Join Staff via Asset
        public ObservableCollection<StaffData> GetStaffFromAsset(AssetData item)
        {
            hasError = false;
            ObservableCollection<StaffData> _result = new ObservableCollection<StaffData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();

                var query = db.staff.FirstOrDefault(x => x.staff_id == item.Using_by_staff_id);

                if (query != null)
                {
                    StaffData pTemp = new StaffData(/*item*/);
                    pTemp.staff_id = query.staff_id;

                    _result.Add(pTemp);
                }
                else
                {
                    MessageBox.Show("NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                errorMessage = "GetAssetTypeFromAsset() error, " + ex.Message;
                hasError = true;
            }
            return _result;
        }
        #endregion

        #region Join Supplier via Asset
        public ObservableCollection<SupplierData> GetSupplierFromAsset(AssetData item)
        {
            hasError = false;
            ObservableCollection<SupplierData> _result = new ObservableCollection<SupplierData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();

                var query = db.supplier.FirstOrDefault(x => x.supplier_id == item.Supplier_id);

                if (query != null)
                {
                    SupplierData pTemp = new SupplierData(/*item*/);
                    pTemp.company_name = query.company_name;
                    pTemp.email = query.email;
                    pTemp.contact_person = query.contact_person;
                    pTemp.phone = query.phone;
                    pTemp.address = query.address;

                    _result.Add(pTemp);
                }
                else
                {
                    MessageBox.Show("NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                errorMessage = "GetAssetTypeFromAsset() error, " + ex.Message;
                hasError = true;
            }
            return _result;
        }
        #endregion

        #region Join Os via Asset
        public ObservableCollection<OsData> GetOsFromAsset(AssetData item)
        {
            hasError = false;
            ObservableCollection<OsData> _result = new ObservableCollection<OsData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();

                var query = db.os.FirstOrDefault(x => x.os_id == item.Os_id);

                if (query != null)
                {
                    OsData pTemp = new OsData(/*item*/);
                    pTemp.os_id = query.os_id;
                    pTemp.os_name = query.os_name;

                    _result.Add(pTemp);
                }
                else
                {
                    MessageBox.Show("NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                errorMessage = "GetAssetTypeFromAsset() error, " + ex.Message;
                hasError = true;
            }
            return _result;
        }
        #endregion

        #region Join Asset Type via Asset
        public ObservableCollection<AssetHistoryTypeData> GetAssetHistoryTypeNameFromAssetHistoryType(AssetHistoryData item)
        {
            hasError = false;
            ObservableCollection<AssetHistoryTypeData> _result = new ObservableCollection<AssetHistoryTypeData>();
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();

                var query = db.asset_history_type.FirstOrDefault(x => x.asset_history_type_id == item.Asset_history_type);

                if (query != null)
                {
                    AssetHistoryTypeData pTemp = new AssetHistoryTypeData(/*item*/);
                    pTemp.Type_code = query.type_code;

                    _result.Add(pTemp);
                }
                else
                {
                    MessageBox.Show("NOT FOUND");
                }

            }
            catch (Exception ex)
            {
                errorMessage = "GetAssetHistoryTypeNameFromAssetHistoryType() error, " + ex.Message;
                hasError = true;
            }
            return _result;
        }
        #endregion

        #endregion
    }
}
