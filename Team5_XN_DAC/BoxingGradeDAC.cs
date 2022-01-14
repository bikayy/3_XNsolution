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
            string sql = @"SELECT Grade_Detail_Code, Grade_Detail_Name,
(select DetailName from CommonCodeSystem where Code='USE_YN' and DetailCode = USE_YN) USE_YN
FROM BoxingGrade_Detail_Master WHERE Boxing_Grade_Code = @Boxing_Grade_Code";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@Boxing_Grade_Code", code);

                da.Fill(dt);
            }
            return dt;
        }
    }
}
