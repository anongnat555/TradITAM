using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradITAM.View;

namespace TradITAM.Model
{
    public class Login
    {
        public bool hasError = false;
        public string errorMessage;
        public Login()
        {

        }

        #region User
        public int UserLogin(UserData item)
        {
            hasError = false;
            TradAssetDBEntities db = new TradAssetDBEntities();
            int result = 0;
            try
            {
                var query = db.user_login.FirstOrDefault(x => x.username == item.Username);
                
                if (query.username == item.Username && query.password == item.Password)
                {
                    result = query.user_id;
                }
                else
                {
                    result = 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Login error, " + ex.Message;
                hasError = true;
            }
            return result;
        }
        #endregion
    }
}
