using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObj;

namespace DataAccess
{

   public class UserDAL
    {
        private UserDBEntities objuserDBEntities;

        public UserDAL()
        {
            objuserDBEntities = new UserDBEntities();
        }

        public CustomBO Adduser(UserBO objuserBO)
        {
            CustomBO objcustomBO = new CustomBO();
            User objuser = new User()
            {
                UserAddress = objuserBO.UserAddress,
                UserEmail = objuserBO.UserEmail,
                UserMobile = objuserBO.UserPhone,
                UserName = objuserBO.UserName
            };

            objuserDBEntities.Users.Add(objuser);
            int returnvalue = objuserDBEntities.SaveChanges();

            if (returnvalue > 0)
            {
                objcustomBO.CustomMessage = "Data Successfully Added.";
                objcustomBO.CustomMessageNumber = returnvalue.ToString();
            }
            else 
            {
                objcustomBO.CustomMessage = "There is some problem to add user.";
                objcustomBO.CustomMessageNumber = returnvalue.ToString();
            }

            return objcustomBO;          
        
        }

    }
}
