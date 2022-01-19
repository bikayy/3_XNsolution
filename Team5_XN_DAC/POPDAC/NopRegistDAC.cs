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
using Team5_XN_VO;

namespace Team5_XN
{
    public class NopRegistDAC
    {
        SqlConnection conn;
        public NopRegistDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }


        public DataTable GetNopRegist_Ma(string wcCode)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("SP_NopRegist_Ma_Select", conn);
                cmd.Parameters.Add(new SqlParameter("@WcCode", wcCode));
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
            }
            return dt;

        }
        public DataTable GetNopRegist_Mi(string nopMaCode)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("SP_NopRegist_Mi_Select", conn);
                cmd.Parameters.Add(new SqlParameter("@NopMaCode", nopMaCode));
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
            }
            return dt;

        }
        
        public bool NopRegist_Stop(NopInfoVO NopInfo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NopRegist_Stop", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Connection.Open();         
                cmd.Parameters.AddWithValue("@wcCode", NopInfo.Wc_Code);
                cmd.Parameters.AddWithValue("@nopMaCode", NopInfo.Nop_Ma_Code);
                cmd.Parameters.AddWithValue("@nopMiCode", NopInfo.Nop_Mi_Code);
                cmd.Parameters.AddWithValue("@nopTime", NopInfo.Nop_DateTime_Start);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public bool NopRegist_Start(NopHistoryVO nopHistory)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NopRegist_Start", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Connection.Open();         
                cmd.Parameters.AddWithValue("@wcCode", nopHistory.Wc_Code);
                cmd.Parameters.AddWithValue("@Nop_DateTime_Start", nopHistory.Nop_DateTime_Start);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }

        }

        public bool NopRegist_Stop(string wcCode, string nopMaCode, string nopMiCode, DateTime nopTime)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NopRegist_Stop", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Connection.Open();         
                cmd.Parameters.AddWithValue("@wcCode", wcCode);
                cmd.Parameters.AddWithValue("@nopMaCode", nopMaCode);
                cmd.Parameters.AddWithValue("@nopMiCode", nopMiCode);
                cmd.Parameters.AddWithValue("@nopTime", nopTime);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public DataTable GetNopHistory(string wcCode)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("SP_NopHistory_Select", conn);
                cmd.Parameters.Add(new SqlParameter("@wcCode", wcCode));
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
            }
            return dt;

        }
        
        public DataTable GetNopHistoryAll(DateTime dateFrom, DateTime dateTo)
        {
            SqlCommand cmd = null;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("SP_NopHistoryAll_Select", conn);
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
            }
            return dt;

        }
        public bool NopRegist_Update(NopInfoVO NopInfo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NopRegist_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Connection.Open();         
                cmd.Parameters.AddWithValue("@wcCode", NopInfo.Wc_Code);
                cmd.Parameters.AddWithValue("@nopMaCode", NopInfo.Nop_Ma_Code);
                cmd.Parameters.AddWithValue("@nopMiCode", NopInfo.Nop_Mi_Code);
                cmd.Parameters.AddWithValue("@Nop_DateTime_Start", NopInfo.Nop_DateTime_Start);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public bool NopRegist_Delete(NopHistoryVO nopHistory)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NopRegist_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Connection.Open();         
                cmd.Parameters.AddWithValue("@wcCode", nopHistory.Wc_Code);
                cmd.Parameters.AddWithValue("@Nop_DateTime_Start", nopHistory.Nop_DateTime_Start);
                cmd.Parameters.AddWithValue("@NopTime", Convert.ToDecimal(nopHistory.Nop_Time));

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }

        }

        public int NopRegistAll_Update(DataTable dt)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NopRegistAll_Update", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Connection.Open();

                cmd.Parameters.Add(new SqlParameter("@nop_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "dbo.NopRegist_Type",
                    Value = dt
                });

                return cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return -1;
            }
        }
        public bool NopRegistAll_Delete(int seq)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_NopRegistAll_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Connection.Open();         
                cmd.Parameters.AddWithValue("@nopSeq", seq);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }

        }
        

    }
}
