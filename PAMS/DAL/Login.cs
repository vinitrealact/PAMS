using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PAMS.DAL
{
    public class Login
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        public int CheckLogin(PAMS.Models.Login objModelLogin)
        {
            string query = "select count(*) from tblLogin where UserName='"+objModelLogin.username+"'and Password='"+objModelLogin.password+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return i;
        }
    }
}