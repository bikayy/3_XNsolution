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
    }
}
