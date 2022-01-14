using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Team5_XN
{
    public class WorkCenterDAC : IDisposable
    {
        SqlConnection conn;
        public WorkCenterDAC()
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

        public DataTable GetWorkCenter()
        {
            string sql = @"
SELECT 
    Wc_Code, Wc_Name, Wc_Group, Process_Code
	, (select Process_Name from Process_Master pm where pm.Process_Code = wm.Process_Code)Process_Name 
	, (select DetailName from CommonCodeSystem where DetailCode = Use_YN)Use_YN
	, (select DetailName from CommonCodeSystem where DetailCode = Pallet_YN)Pallet_YN
    , (select DetailName from CommonCodeSystem where DetailCode = Monitoring_YN) Monitoring_YN
    , Remark, Ins_Date, Up_Date, Ins_Emp, Up_Emp
FROM 
    WorkCenter_Master wm";
            //, Ins_Date, Ins_Emp, Up_Date, Up_Emp
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }


        public int SaveWorkCenter(DataTable dt, int check)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_WorkCenter_Save", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Connection.Open();

                cmd.Parameters.Add(new SqlParameter("@WorkCenter_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "dbo.WorkCenter_Master_Type",
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

        public bool DeleteWorkCenter(string wcCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_WorkCenter_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@Wc_Code", wcCode);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                if (err.Message.Contains("DELETE 문이 REFERENCE 제약 조건 \"FK") && err.Message.Contains("과(와) 충돌했습니다."))
                {
                    MessageBox.Show("해당 항목은 다른 테이블에서 이미 사용중이므로 삭제할 수 없습니다.");
                }
                else
                {
                    Debug.WriteLine(err.Message);
                    MessageBox.Show(err.Message);
                }
                return false;
            }
        }
    }
}
