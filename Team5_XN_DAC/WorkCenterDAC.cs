using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Team5_XN
{
    public class WorkCenterDAC : IDisposable
    {
        SqlConnection conn;
        public WorkCenterDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public DataTable GetWorkCenter()
        {
            string sql = @"
SELECT 
    Wc_Code, Wc_Name, Wc_Group, Process_Code, Remark
	, (select DetailName from CommonCodeSystem where DetailCode = Use_YN)Use_YN
	, (select DetailName from CommonCodeSystem where DetailCode = Pallet_YN)Pallet_YN
    , (select DetailName from CommonCodeSystem where DetailCode = Monitoring_YN) Monitoring_YN
    , Ins_Date, Up_Date, Ins_Emp, Up_Emp
FROM 
    WorkCenter_Master";
            //, Ins_Date, Ins_Emp, Up_Date, Up_Emp
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
    }
}
