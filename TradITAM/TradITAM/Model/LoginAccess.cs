using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradITAM.Model
{
    public class LoginAccess
    {
        public bool hasError = false;
        public string errorMessage;
        public LoginAccess()
        {

        }

        #region User
        public int UserLogin(UserData item)
        {
            hasError = false;
            TraditionAssetEntities db = new TraditionAssetEntities();
            int result = 0;
            try
            {
                var query = db.user_login.FirstOrDefault(x => x.username == item.username);

                if (query.username == item.username && query.password == item.password)
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
