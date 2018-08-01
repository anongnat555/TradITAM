using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TradITAM.Model
{
    public class UpdateAccess
    {
        public bool hasError = false;
        public string errorMessage;
        public UpdateAccess()
        {

        }

        #region Asset
        public void UpdateAsset(AssetData newitem)
        {
            hasError = false;
            try
            {
                using (TraditionAssetEntities db = new TraditionAssetEntities())
                {
                    var asset_ = db.asset.FirstOrDefault(x => x.asset_id == newitem.Asset_id);
                    if (asset_ != null)
                    {
                        asset_.asset_id = newitem.Asset_id;
                        asset_.os_id = newitem.Os_id;
                        asset_.asset_type_id = newitem.Asset_type_id;
                        asset_.supplier_id = newitem.Supplier_id;
                        asset_.using_by_staff_id = newitem.Using_by_staff_id;
                        asset_.asset_code = newitem.Asset_code;
                        asset_.brand = newitem.Brand;
                        asset_.price = newitem.Price;
                        asset_.cpu = newitem.Cpu;
                        asset_.ram = newitem.Ram;
                        asset_.hdd = newitem.Hdd;
                        asset_.notes = newitem.Note;
                        asset_.is_active = newitem.Is_active;
                        asset_.start_date_warranty = newitem.Start_date_warranty;
                        asset_.expiry_date_warranty = newitem.Expiry_date_warranty;
                        asset_.modified_date = DateTime.Now;

                        db.asset.AddOrUpdate(asset_);
                        db.SaveChanges();
                        MessageBox.Show("Update complete");
                    }
                    else
                    {
                        MessageBox.Show("Can not update");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region Staff
        public void UpdateStaff(StaffData newitem)
        {
            hasError = false;
            try
            {
                using (TraditionAssetEntities db = new TraditionAssetEntities())
                {
                    var staff_ = db.staff.FirstOrDefault(x => x.staff_id == newitem.staff_id);
                    if(staff_ != null)
                    {
                        staff_.firstname = newitem.firstname;
                        staff_.lastname = newitem.lastname;
                        staff_.aka = newitem.aka;
                        staff_.start_date = newitem.start_date;
                        staff_.end_date = newitem.end_date;
                        staff_.is_active = newitem.is_active;
                        staff_.modified_date = DateTime.Now;

                        db.staff.AddOrUpdate(staff_);
                        db.SaveChanges();
                        MessageBox.Show("Update complete");
                    }
                    else
                    {
                        MessageBox.Show("Can not update");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region Supplier
        public void UpdateSupplier(SupplierData newitem)
        {
            hasError = false;
            try
            {
                using (TraditionAssetEntities db = new TraditionAssetEntities())
                {
                    var supplier_ = db.supplier.FirstOrDefault(x => x.supplier_id == newitem.supplier_id);
                    if (supplier_ != null)
                    {
                        supplier_.company_name = newitem.company_name;
                        supplier_.contact_person = newitem.contact_person;
                        supplier_.address = newitem.address;
                        supplier_.email = newitem.email;
                        supplier_.phone = newitem.phone;
                        supplier_.is_active = newitem.is_active;
                        //supplier_.create_date = DateTime.Now;
                        supplier_.modified_date = DateTime.Now;

                        db.supplier.AddOrUpdate(supplier_);
                        db.SaveChanges();
                        MessageBox.Show("Update complete");
                    }
                    else
                    {
                        MessageBox.Show("Can not update");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region AssetType
        public void UpdateAssetType(AssetTypeData newitem)
        {
            hasError = false;
            try
            {
                using (TraditionAssetEntities db = new TraditionAssetEntities())
                {
                    var assettype_ = db.asset_type.FirstOrDefault(x => x.asset_type_id == newitem.asset_type_id);
                    if (assettype_ != null)
                    {
                        assettype_.asset_type_name = newitem.asset_type_name;
                        assettype_.is_active = newitem.is_active;
                        assettype_.modified_date = DateTime.Now;

                        db.asset_type.AddOrUpdate(assettype_);
                        db.SaveChanges();
                        MessageBox.Show("Update complete");
                    }
                    else
                    {
                        MessageBox.Show("Can not update");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region Os
        public void UpdateOs(OsData newitem)
        {
            hasError = false;
            try
            {
                using (TraditionAssetEntities db = new TraditionAssetEntities())
                {
                    var os_ = db.os.FirstOrDefault(x => x.os_id == newitem.os_id);
                    if (os_ != null)
                    {
                        os_.os_name = newitem.os_name;
                        os_.is_active = newitem.is_active;
                        os_.modified_date = DateTime.Now;

                        db.os.AddOrUpdate(os_);
                        db.SaveChanges();
                        MessageBox.Show("Update complete");
                    }
                    else
                    {
                        MessageBox.Show("Can not update");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion

        #region AssetHistoryType
        public void UpdateAssetHistoryType(AssetHistoryTypeData newitem)
        {
            hasError = false;
            try
            {
                using (TraditionAssetEntities db = new TraditionAssetEntities())
                {
                    var aht_ = db.asset_history_type.FirstOrDefault(x => x.asset_history_type_id == newitem.Asset_history_type_id);
                    if (aht_ != null)
                    {
                        aht_.type_code = newitem.Type_code;
                        aht_.type_description = newitem.Type_description;
                        aht_.is_active = newitem.Is_active;
                        aht_.modified_date = DateTime.Now;

                        db.asset_history_type.AddOrUpdate(aht_);
                        db.SaveChanges();
                        MessageBox.Show("Update complete");
                    }
                    else
                    {
                        MessageBox.Show("Can not update");
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Update error, " + ex.Message;
                hasError = true;
            }
        }
        #endregion
    }
}

