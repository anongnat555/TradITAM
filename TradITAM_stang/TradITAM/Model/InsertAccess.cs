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

        #region Asset
        public void AddAsset(AssetData item)
        {
            hasError = false;
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
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
                TradAssetDBEntities db = new TradAssetDBEntities();
                var data = new staff()
                {
                    staff_id = item.staff_id,
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
                TradAssetDBEntities db = new TradAssetDBEntities();
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

        #region history add staff
        public void historyStaff(HistoryData item)
        {
            hasError = false;
            try
            {
                TradAssetDBEntities db = new TradAssetDBEntities();
                var data = new history()
                {
                    //history_id = item.History_id,
                    user_id = item.User_id,
                    references_id = item.Refernces_id,
                    detail = "Insert",
                    history_timestamp = DateTime.Now,
                    history_type = 1
                };
                db.history.Add(data);
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

    }

}
