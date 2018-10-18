using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KickStartMVCDemo.Models
{
    public class BusinessLogic
    {
        public IEnumerable<Children> Children
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["KickStartReactProject"].ConnectionString;
                //string conn = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
                List<Children> childrens = new List<Children>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllChildren", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Children children = new Children();
                        children.ID = Convert.ToInt32(rdr["Id"]);
                        children.FirstName = rdr["FirstName"].ToString();
                        children.LastName = rdr["LastName"].ToString();
                        children.Gender = rdr["Gender"].ToString();
                        children.Address = rdr["Address"].ToString();
                        children.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);
                        children.ChildType = rdr["ChildType"].ToString();
                        childrens.Add(children);
                    }
                }

                return childrens;
            }
        }
        public void AddChildren(Children children)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["KickStartReactProject"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddChildren", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramFirstName = new SqlParameter();
                paramFirstName.ParameterName = "@FirstName";
                paramFirstName.Value = children.FirstName;
                cmd.Parameters.Add(paramFirstName);

                SqlParameter paramLastName = new SqlParameter();
                paramLastName.ParameterName = "@LastName";
                paramLastName.Value = children.LastName;
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = children.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramAddress = new SqlParameter();
                paramAddress.ParameterName = "@Address";
                paramAddress.Value = children.Address;
                cmd.Parameters.Add(paramAddress);

                SqlParameter paramBirthDate = new SqlParameter();
                paramBirthDate.ParameterName = "@BirthDate";
                paramBirthDate.Value = children.BirthDate;
                cmd.Parameters.Add(paramBirthDate);

                SqlParameter paramChildType = new SqlParameter();
                paramChildType.ParameterName = "@ChildType";
                paramChildType.Value = children.ChildType;
                cmd.Parameters.Add(paramChildType);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveChild(Children children)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["KickStartReactProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveChildren", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = children.ID;
                cmd.Parameters.Add(paramId);

                SqlParameter paramFirstName = new SqlParameter();
                paramFirstName.ParameterName = "@FirstName";
                paramFirstName.Value = children.FirstName;
                cmd.Parameters.Add(paramFirstName);

                SqlParameter paramLastName = new SqlParameter();
                paramLastName.ParameterName = "@LastName";
                paramLastName.Value = children.LastName;
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = children.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramAddress = new SqlParameter();
                paramAddress.ParameterName = "@Address";
                paramAddress.Value = children.Address;
                cmd.Parameters.Add(paramAddress);

                SqlParameter paramBirthDate = new SqlParameter();
                paramBirthDate.ParameterName = "@BirthDate";
                paramBirthDate.Value = children.BirthDate;
                cmd.Parameters.Add(paramBirthDate);


                SqlParameter paramChildType = new SqlParameter();
                paramChildType.ParameterName = "@ChildType";
                paramChildType.Value = children.ChildType;
                cmd.Parameters.Add(paramChildType);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteChild(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["KickStartReactProject"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteChild", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}