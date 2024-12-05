using ContactManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ContactManagementSystem.DataAccess
{
    public class DataAccess
    {
        private SqlConnection _connection;
        public DataTable Retrieve(string sqlQuery)
        {
            DataTable dt = new DataTable();
            string conectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlCommand cmd = new SqlCommand(sqlQuery, _connection)
            {
                CommandType = System.Data.CommandType.Text
            };
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            _connection.Open();
            adapter.Fill(dt);
            _connection.Close();
            return dt;
        }

        public void Update(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand(sqlQuery, _connection)
            {
                CommandType = System.Data.CommandType.Text
            };
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            _connection.Open();
            int noOfRows = cmd.ExecuteNonQuery();
            _connection.Close();
            if (noOfRows < 1)
            {
                throw new Exception("Updation Failed");
            }
        }

        public void Delete(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand(sqlQuery, _connection)
            {
                CommandType = System.Data.CommandType.Text
            };
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            _connection.Open();
            int noOfRows = cmd.ExecuteNonQuery();
            _connection.Close();
            if (noOfRows < 1)
            {
                throw new Exception("Deletion Failed");
            }
        }

        public void Insert(string sqlQuery)
        {
            SqlCommand cmd = new SqlCommand(sqlQuery, _connection)
            {
                CommandType = System.Data.CommandType.Text
            };
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            _connection.Open();
            int noOfRows = cmd.ExecuteNonQuery();
            _connection.Close();
            if (noOfRows < 1)
            {
                throw new Exception("Insertion Failed");
            }
        }

        private void ConnectDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new SqlConnection(connectionString);
        }
    }
}