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

namespace Team5_XN
{
    public class CommonDAC : IDisposable
    {
        SqlConnection conn;
        public CommonDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
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
(select DetailName from CommonCodeSystem where Code='USE_YN' and DetailCode = UseYN) UseYN
FROM CommonCodeSystem WHERE Name = @Name";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@Name", name);

                da.Fill(dt);
            }
            return dt;
        }
    }
}
