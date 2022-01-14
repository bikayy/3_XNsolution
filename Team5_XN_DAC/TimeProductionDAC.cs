using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    public class TimeProductionDAC : IDisposable
    {
        SqlConnection conn;
        public TimeProductionDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }


        public DataTable GetTimeProduction(DateTime dateFrom, DateTime dateTo)
        {
            //SqlCommand cmd = new SqlCommand("SP_TimeProduction_Select", conn);
            //cmd.Connection = conn;
            //cmd.CommandText = "SP_TimeProduction_Select";
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
            //cmd.Parameters.AddWithValue("@dateTo", dateTo);

            
            //using (SqlDataAdapter da = new SqlDataAdapter(cmd, conn))
            //{
            //    DataTable dt = new DataTable();
            //    da.SelectCommand.Parameters.AddWithValue("@dateFrom", dateFrom);
            //    da.SelectCommand.Parameters.AddWithValue("@dateTo", dateTo);
                
            //    da.Fill(dt);

            //    return dt;
            //}

            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                //conn.Open();
                cmd = new SqlCommand("SP_TimeProduction_Select", conn);
                //cmd.Connection = conn;
                //cmd.CommandText = "SP_TimeProduction_Select";
                cmd.Parameters.Add(new SqlParameter("@dateFrom", dateFrom.Date));
                cmd.Parameters.Add(new SqlParameter("@dateTo", dateTo.Date));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd; 
                da.Fill(dt);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                //conn.Close();
            }
            return dt;

        }

        public DataTable GetTimeProduction_Chart(string workOrderNo)
        {

            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                //conn.Open();
                cmd = new SqlCommand("SP_TimeProduction_Chart_Select", conn);
                //cmd.Connection = conn;
                //cmd.CommandText = "SP_TimeProduction_Select";
                cmd.Parameters.Add(new SqlParameter("@workOrderNo", workOrderNo));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                //conn.Close();
            }
            return dt;
        }
    }
}
