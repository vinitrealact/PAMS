using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PAMS.Services
{
    public class AutoGenerate
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        public string AutoGenerateId(Models.AutoGenerate objModelAuto)
        {
            con.Open();
            string query = "select "+objModelAuto.ColumnName+"  from  "+objModelAuto.TableName+" where id in (select max(id) from "+
                objModelAuto.TableName+")";
           
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                 
                string s = cmd.ExecuteScalar().ToString();
                string[] s1 = s.Split('_');
                int i = int.Parse(s1[1]);
                i++;
                string x = s1[0] + "_" + i;
                con.Close();
                return x;

            }
            catch (Exception ex)
            {

                return objModelAuto.ColumnName + "_1";//ex.Message;
            }
         
           
           // return " ";
        }
    }
}