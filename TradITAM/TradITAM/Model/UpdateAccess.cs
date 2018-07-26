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
        
        #region Staff
        public void UpdateStaff(StaffData newitem)
        {
            hasError = false;
            try
            {
                using (TradAssetDBEntities db = new TradAssetDBEntities())
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
                        //staff_.create_date = DateTime.Now;
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
                using (TradAssetDBEntities db = new TradAssetDBEntities())
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
    }
}

