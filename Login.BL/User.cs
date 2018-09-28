using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.BL
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UserBusinessLogin
    {
        string conString = ConfigurationManager.ConnectionStrings["LaunSysCon"].ConnectionString;
        public int CheckUserLogin(User User)
        {
            using (SqlConnection connObject = new SqlConnection(conString))
            {
                SqlCommand comObj = new SqlCommand("sp_login", connObject);
                comObj.CommandType = CommandType.StoredProcedure;
                comObj.Parameters.Add(new SqlParameter("@Email", User.Email));
                comObj.Parameters.Add(new SqlParameter("@Password", User.Password));


                connObject.Open();
                return Convert.ToInt32 (comObj.ExecuteScalar());
            }
        }
    }
}
