using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace PlayerLogApp
{
    public class Helper
    {
        SqlConnection connection = null;

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p)
        {

            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString);

            SqlCommand cmd = new SqlCommand(cmdtext, connection);
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            ConnectionOpen();
            int sonuc = cmd.ExecuteNonQuery();
            ConnectionClose();
            return sonuc;
        }
        private void ConnectionOpen()
        {
            try
            {
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ConnectionClose()
        {
            try
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}




