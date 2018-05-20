using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PAMS.Models;
using System.Configuration;

namespace PAMS.DAL
{
    public class Dept
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        public int AddDept(Models.Department objModelDept)
        {
            con.Open();
            string query = "insert into dept (dno, dname) values ('"+objModelDept.Dno+"','"+objModelDept.Dname+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public IEnumerable<Models.Department> GetDept()
        {
            List<Models.Department> depts = new List<Department>();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from dept", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Models.Department d1 = new Department();
                    d1.Dno = dr[1].ToString();
                    d1.Dname = dr[2].ToString();
                    depts.Add(d1);
                }
            }
            return depts;
        }

        public int DeleteDept(Models.Department objModelDept)
        {
            con.Open();
            string query = "delete from dept where dno='"+objModelDept.Dno+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}