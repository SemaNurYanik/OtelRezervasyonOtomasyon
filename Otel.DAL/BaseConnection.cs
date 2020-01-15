using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL
{
    public class BaseConnection
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public BaseConnection()
        {
            con = new SqlConnection(Properties.Settings.Default.otelDB);
        }

        public int ExecuteCommand()
        {
            try
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
