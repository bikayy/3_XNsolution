using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_VO;
using Team5_XN_DAC;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Team5_XN_DAC
{
    public class NopDAC : IDisposable
    {
        SqlConnection conn;
        public NopDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public DataTable GetNopMaster()
        {
            string sql = @"SELECT Nop_Ma_Code, Nop_Ma_Name, 
(select DetailName from CommonCodeSystem where Code='USE_YN' and DetailCode = Use_YN)Use_YN
FROM Nop_Ma_Master";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetNopDetail(string code)
        {
            //sql 수정 필요
            string sql = @"SELECT Nop_Mi_Code, Nop_Mi_Name, Nop_Ma_Code,
(select DetailName from CommonCodeSystem where Code='USE_YN' and DetailCode = M.Use_YN) Use_YN, 
(select DetailName from CommonCodeUser where Code='PROC_GROUP' and DetailCode = M.Process_Group) Process_Group, Process_Group Process_Group_Code, Remark,
(select DetailName from CommonCodeSystem where Code='NOP_CODE_TYPE' and DetailCode = M.Regular_Type) Nop_type, Nop_type Nop_type_Code,
(select DetailName from CommonCodeSystem where Code='REGULAR_TYPE' and DetailCode = M.Regular_Type) Regular_Type, Regular_Type Regular_Type_Code,
Ins_Date, Ins_Emp, Up_Date, Up_Emp
FROM Nop_Mi_Master M
WHERE Nop_Ma_Code = @Nop_Ma_Code";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@Nop_Ma_Code", code);

                da.Fill(dt);
            }
            return dt;
        }
        public List<NopCodeVO> GetNopList()
        {
            string sql = @"SELECT Nop_Ma_Code, Nop_Ma_Name from Nop_Ma_Master";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<NopCodeVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
        public int SaveNopCode(DataTable dt, int check)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Nop_Code_Save", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Nop_Code_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "dbo.Nop_Code_Master_Type",
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
        public bool DeleteNopDetail(string code)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Nop_Code_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nop_Mi_Code", code);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}
