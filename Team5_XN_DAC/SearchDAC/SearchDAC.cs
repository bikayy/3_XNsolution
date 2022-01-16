using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Team5_XN_VO;
using System.Data.SqlClient;

namespace Team5_XN_DAC
{
    public class SearchDAC : IDisposable
    {
        SqlConnection conn;

        public SearchDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<SearchVO> GetItemList()
        {
            //string sql = @"select @code, @name from @table";
            string sql = @"select Item_Code, Item_Name from Item_Master";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<SearchVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public List<WCSearchVO> GetWCList()
        {
            SqlTransaction trans = conn.BeginTransaction();
            SqlCommand cmd = null;
            try
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    cmd.CommandText = @"select Wc_Code, Wc_Name, Wc_Group, Process_Name 
from WorkCenter_Master wc join Process_Master pm
on wc.Process_Code = pm.Process_Code";
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                return Helper.DataReaderMapToList<WCSearchVO>(cmd.ExecuteReader());
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return null;
            }
        }
    }
}