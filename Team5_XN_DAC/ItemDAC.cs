using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    public class ItemDAC : IDisposable
    {
        SqlConnection conn;
        public ItemDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// frmItem 폼의 조회(Select) 기능
        /// </summary>
        /// <returns></returns>
        public DataTable GetItem()
        {
            string sql = @"
SELECT Item_Code, Item_Name, Item_Name_Eng, Item_Type,  Item_Unit, Remark
    ,(select DetailName from CommonCodeSystem where DetailCode = Use_YN) Use_YN
    ,PrdQty_Per_Hour, Cavity_qty, Ins_Date, Ins_Emp, Up_Date, Up_Emp
FROM Item_Master;";
            //, Ins_Date, Ins_Emp, Up_Date, Up_Emp
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// frmItem 폼의 저장(save) 기능 SP
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        public int SaveItem(DataTable dt, int check)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Item_Save", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();

                cmd.Parameters.Add(new SqlParameter("@Item_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "dbo.Item_Master_Type",
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

        /// <summary>
        /// frmItem 폼의 삭제(Delete) 기능 SP 
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public bool DeleteItem(string itemCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_Item_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@Item_Code", itemCode);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }
        }
    }
}
