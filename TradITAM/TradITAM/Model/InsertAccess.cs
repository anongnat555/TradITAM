using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TradITAM.Model
{
    public class InsertAccess
    {
        public bool hasError = false;
        public string errorMessage;
        public InsertAccess()
        {

        }

        #region User
        public void AddUser(UserData item)
        {
            hasError = false;
            try
            {
                TraditionAssetEntities db = new TraditionAssetEntities();
                var data = new user_login()
                {
                    username = item.username,
                    password = item.password,
                    is_active = item.is_active,
                    create_date = DateTime.Now,
                    modified_date = DateTime.Now
                };
                db.user_login.Add(data);
                db.SaveChanges();
                MessageBox.Show("Insert complete");
            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region Asset
        public void AddAsset(AssetData item)
        {
            hasError = false;
            try
            {
                TraditionAssetEntities db = new TraditionAssetEntities();
                var data = new asset()
                {
                    //asset_id = item.Asset_id,
                    os_id = item.Os_id,
                    asset_type_id = item.Asset_type_id,
                    original_supplier_id = item.Original_supplier_id,
                    supplier_id = item.Supplier_id,
                    using_by_staff_id = item.Using_by_staff_id,
                    asset_code = item.Asset_code,
                    brand = item.Brand,
                    price = item.Price,
                    cpu = item.Cpu,
                    ram = item.Ram,
                    hdd = item.Hdd,
                    notes = item.Note,
                    start_date_warranty = item.Start_date_warranty,
                    expiry_date_warranty = item.Expiry_date_warranty,
                    is_active = item.Is_active,
                    create_date = DateTime.Now,
                    modified_date = DateTime.Now
                };
                db.asset.Add(data);
                db.SaveChanges();
                MessageBox.Show("Insert complete");
            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region Staff
        public void AddStaff(StaffData item)
        {
            hasError = false;
            try
            {
                TraditionAssetEntities db = new TraditionAssetEntities();
                var data = new staff()
                {
                    //staff_id = item.staff_id,
                    firstname = item.firstname,
                    lastname = item.lastname,
                    aka = item.aka,
                    start_date = item.start_date,
                    end_date = item.end_date,
                    is_active = item.is_active,
                    create_date = DateTime.Now,
                    modified_date = DateTime.Now
                };
                db.staff.Add(data);
                db.SaveChanges();
                MessageBox.Show("Insert complete");

            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region Suplier
        public void AddSupplier(SupplierData item)
        {
            hasError = false;
            try
            {
                TraditionAssetEntities db = new TraditionAssetEntities();
                var data = new supplier()
                {
                    supplier_id = item.supplier_id,
                    company_name = item.company_name,
                    contact_person = item.contact_person,
                    address = item.address,
                    email = item.email,
                    phone = item.phone,
                    is_active = item.is_active,
                    create_date = DateTime.Now,
                    modified_date = DateTime.Now
                };
                db.supplier.Add(data);
                db.SaveChanges();
                MessageBox.Show("Insert complete");
            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region AssetHistory
        public void AddAssetHistory(AssetHistoryData item)
        {
            hasError = false;
            try
            {
                TraditionAssetEntities db = new TraditionAssetEntities();
                var data = new asset_history()
                {
                    asset_history_id = item.Asset_history_id,
                    user_id = item.User_id,
                    asset_id = item.Asset_id,
                    asset_history_type = item.Asset_history_type,
                    remark = item.Remark,
                    history_timestamp = item.History_timestamp
                };
                db.asset_history.Add(data);
                db.SaveChanges();
                MessageBox.Show("Insert complete");
            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region AssetType
        public void AddAssetType(AssetTypeData item)
        {
            hasError = false;
            try
            {
                TraditionAssetEntities db = new TraditionAssetEntities();
                var data = new asset_type()
                {
                    asset_type_name = item.asset_type_name,
                    is_active = item.is_active,
                    create_date = DateTime.Now,
                    modified_date = DateTime.Now
                };
                db.asset_type.Add(data);
                db.SaveChanges();
                MessageBox.Show("Insert complete");
            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region Os
        public void AddOs(OsData item)
        {
            hasError = false;
            try
            {
                TraditionAssetEntities db = new TraditionAssetEntities();
                var data = new os()
                {
                    os_name = item.os_name,
                    is_active = item.is_active,
                    create_date = DateTime.Now,
                    modified_date = DateTime.Now
                };
                db.os.Add(data);
                db.SaveChanges();
                MessageBox.Show("Insert complete");
            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region AssetHistoryType
        public void AddAssetHistoryType(AssetHistoryTypeData item)
        {
            hasError = false;
            try
            {
                TraditionAssetEntities db = new TraditionAssetEntities();
                var data = new asset_history_type()
                {
                    type_code = item.Type_code,
                    type_description = item.Type_description,
                    is_active = item.Is_active,
                    create_date = DateTime.Now,
                    modified_date = DateTime.Now
                };
                db.asset_history_type.Add(data);
                db.SaveChanges();
                MessageBox.Show("Insert complete");
            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region Add Log History
        public void LogHistory(HistoryData item)
        {
            hasError = false;
            try
            {
                TraditionAssetEntities db = new TraditionAssetEntities();
                var data = new history()
                {
                    //history_id = item.History_id,
                    user_id = item.User_id,
                    detail = item.Detail,
                    history_timestamp = DateTime.Now,
                    history_type = item.History_id
                };
                db.history.Add(data);
                db.SaveChanges();
                //MessageBox.Show("Insert complete");

            }
            catch (Exception ex)
            {
                errorMessage = "Add error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion
    }
}
