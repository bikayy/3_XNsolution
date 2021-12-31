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
    public class ProcessDAC : IDisposable
    {
        SqlConnection conn;
        public ProcessDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DataTable GetProcess()
        {
            string sql = @"SELECT Process_Code, Process_Name, Process_Group, Remark, Use_YN, Ins_Date, Ins_Emp, Up_Date, Up_Emp from Process_Master;";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                //da.SelectCommand.Parameters.AddWithValue("@aaa", aaa);

                da.Fill(dt);
            }
            return dt;
        }
    }
}
