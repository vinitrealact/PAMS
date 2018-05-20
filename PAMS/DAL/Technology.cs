using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PAMS.DAL
{
    public class Technology
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        public int UpdateTechnology(Models.Technology objModelTech)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@techid", objModelTech.techid);
            cmd.Parameters.AddWithValue("@techid", objModelTech.technology);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int AddTechnology(Models.Technology objmodeltech)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@techid", objmodeltech.techid);
            cmd.Parameters.AddWithValue("@techname", objmodeltech.technology);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public int deleteTechnology(Models.Technology objmodeltech)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@techid", objmodeltech.techid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public IEnumerable<Models.Technology> selectTechnology()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_select",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            List<Models.Technology> tech = new List<Models.Technology>();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    Models.Technology objmodeltech = new Models.Technology();

                    objmodeltech.techid = dr[1].ToString();
                    objmodeltech.technology = dr[2].ToString();
                    tech.Add(objmodeltech);
                }
            }
            con.Close();
            return tech;
        }
    }
}