using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    public class DayProductionDAC : IDisposable
    {
        SqlConnection conn;
        public DayProductionDAC()
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

        public DataTable GetDayProduction(DateTime dateFrom, DateTime dateTo)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                //conn.Open();
                cmd = new SqlCommand("SP_DayProduction_Select", conn);
                //cmd.Connection = conn;
                //cmd.CommandText = "SP_DayProduction_Select";
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

        public DataTable GetDayDefect(DateTime dateFrom, DateTime dateTo, string process_code, string wc_Name, string workOrderNo)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {

                //conn.Open();
                cmd = new SqlCommand("SP_DayDefect_Select", conn);
                //cmd.Connection = conn;
                //cmd.CommandText = "SP_DayProduction_Select";
                cmd.Parameters.Add(new SqlParameter("@dateFrom", dateFrom.Date));
                cmd.Parameters.Add(new SqlParameter("@dateTo", dateTo.Date));
                if (process_code.Length < 1)
                    cmd.Parameters.Add(new SqlParameter("@process_code", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@process_code", process_code));
                
                if(wc_Name.Length < 1)
                    cmd.Parameters.Add(new SqlParameter("@wc_Name", DBNull.Value));
                else
                    cmd.Parameters.Add(new SqlParameter("@wc_Name", wc_Name));

                if (workOrderNo.Length < 1)
                    cmd.Parameters.Add(new SqlParameter("@workOrderNo", DBNull.Value));
                else
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

        public DataTable GetDayDefect_Chart(DateTime dateFrom, DateTime dateTo)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                //conn.Open();
                cmd = new SqlCommand("SP_DayDefect_Chart_Select", conn);
                //cmd.Connection = conn;
                //cmd.CommandText = "SP_DayProduction_Select";
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
    }
}


