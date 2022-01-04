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
    public class ProcessDAC : IDisposable
    {
        SqlConnection conn;
        public ProcessDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public DataTable GetProcess()
        {
            string sql = @"
SELECT 
    Process_Code, Process_Name, Process_Group, Remark
    , (select DetailName from CommonCodeSystem where DetailCode = Use_YN) Use_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp 
FROM 
    Process_Master;";
            //, Ins_Date, Ins_Emp, Up_Date, Up_Emp
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                //da.SelectCommand.Parameters.AddWithValue("@aaa", aaa);

                da.Fill(dt);
            }
            return dt;
        }

        public int SaveProcess(DataTable dt, int check)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Process_Save", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();

                cmd.Parameters.Add(new SqlParameter("@Process_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "dbo.Process_Master_Type2",
                    Value = dt
                });
                cmd.Parameters.AddWithValue("@Check", check);

                return cmd.ExecuteNonQuery();
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return -1;
            }
        }


        public bool DeleteProcess(string processCode)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("SP_Process_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();

                
                cmd.Parameters.AddWithValue("@Process_Code", processCode);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch(Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }
        }
    }

}
