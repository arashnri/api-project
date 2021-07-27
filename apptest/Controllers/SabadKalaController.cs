using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using apptest.Models;
using apptest.Controllers;

namespace apptest.Controllers
{
    public class SabadKalaController : ApiController
    {
        public void insertsabad(string name,string kala)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insertsabad";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@kala", kala);
            cmd.ExecuteNonQuery();
        }
        public static List<Sabad> show1(string name)
        {
            List<Sabad> sabadshow = new List<Sabad>();
            SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "show_sabad";
            cmd.Parameters.AddWithValue("@name", name);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sabad sabad = new Sabad();
                sabad.nameuser = dt.Rows[i]["U_Name"].ToString();
                //sabad.id = Convert.ToInt16(dt.Rows[i]["ID_"]);
                sabadshow.Add(sabad);
            }
            return sabadshow;
        }
        public static List<Sabad> show2(string name)
        {
            List<Sabad> sabadshow = new List<Sabad>();
            SqlConnection con = new SqlConnection(Properties.Settings.Default.connection);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "showuser_sabad";
            cmd.Parameters.AddWithValue("@namekala", name);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sabad sabad = new Sabad();
                sabad.nameuser = dt.Rows[i]["U_Name"].ToString();
                //sabad.id = Convert.ToInt16(dt.Rows[i]["ID_"]);
                sabadshow.Add(sabad);
            }
            return sabadshow;
        }
    }
    
}
