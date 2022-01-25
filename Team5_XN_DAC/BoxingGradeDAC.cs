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

namespace Team5_XN_DAC
{
    public class BoxingGradeDAC : IDisposable
    {
        SqlConnection conn;

        public BoxingGradeDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }
        public void Dispose()
        {
            conn.Close();
        }
        public DataTable GetBoxingGradeMaster()
        {
            string sql = @"SELECT DISTINCT Boxing_Grade_Code, 
(select DetailName from CommonCodeSystem where Code ='Box_Grade' and DetailCode= Boxing_Grade_Code) Boxing_Grade_Name
FROM BoxingGrade_Detail_Master";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetBoxingGradeDetail(string code)
        {
            string sql = @"SELECT Grade_Detail_Code, Grade_Detail_Name, Boxing_Grade_Code,
(select DetailName from CommonCodeSystem where Code='USE_YN' and DetailCode = USE_YN) USE_YN,
Ins_Date, Ins_Emp, Up_Date, Up_Emp
FROM BoxingGrade_Detail_Master WHERE Boxing_Grade_Code = @Boxing_Grade_Code";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@Boxing_Grade_Code", code);

                da.Fill(dt);
            }
            return dt;
        }
        public int SaveBoxing(DataTable dt, int check)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Boxing_Grade_Save", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Boxing_Grade_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "Boxing_Grade_Master_Type",
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
        public bool DeleteBoxDetail(string code)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Boxing_Detail_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grade_Detail_Code", code);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }
        }
        public List<BoxingGradeVO> GetBoxingGradeList()
        {
            string sql = @"SELECT DISTINCT Boxing_Grade_Code, 
(select DetailName from CommonCodeSystem where Code ='Box_Grade' and DetailCode= Boxing_Grade_Code) Boxing_Grade_Name
FROM BoxingGrade_Detail_Master";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<BoxingGradeVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }
    }
}
