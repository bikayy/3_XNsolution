using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using Team5_XN_VO;
using System.Windows.Forms;

namespace Team5_XN
{
    public class CommonDAC : IDisposable
    {
        SqlConnection conn;
        public CommonDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        public DataTable GetCommonCodeSys(string[] codes)
        {
            string code = string.Join("','", codes);

            string sql = $@"select CodeNum, Code, Name, DetailCode, DetailName
from CommonCodeSystem
where Code in ('{code}')
ORDER BY DetailCode desc";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetCommonCodeUser(string[] codes)
        {
            string code = string.Join("','", codes);

            string sql = $@"select CodeNum, Code, Name, DetailCode, DetailName
from CommonCodeUser
where Code in ('{code}');";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetSystemCodeMaster()
        {
            string sql = @"SELECT DISTINCT Code, Name FROM CommonCodeSystem";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetSystemCodeDetail(string name)
        {
            string sql = @"SELECT DetailCode, DetailName, Sort_Index, Remark, 
(select DetailName from CommonCodeSystem where Code='USE_YN' and DetailCode = UseYN) UseYN, CodeNum
FROM CommonCodeSystem WHERE Name = @Name ORDER BY DetailCode ASC";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@Name", name);

                da.Fill(dt);
            }
            return dt;
        }
        public int SaveCode(DataTable dt, int check)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CommonCode_Save", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CommonCode_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "dbo.CommonCode_Master_Type",
                    Value = dt
                });
                cmd.Parameters.AddWithValue("@Check", check);
                                
                return cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return -1;
            }
        }

        public int SaveMasterCode(DataTable dt, int check)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_CommonCodeMaster_Save", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CommonCode_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "dbo.CommonCode_Master_Type",
                    Value = dt
                });
                cmd.Parameters.AddWithValue("@Check", check);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return -1;
            }
        }
        public bool DeleteDetailCode(string code)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SysCommonCodeDetail_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DetailCode", code);

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
