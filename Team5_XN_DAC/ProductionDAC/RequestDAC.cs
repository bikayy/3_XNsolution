using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_VO;

namespace Team5_XN_DAC
{
    public class RequestDAC : IDisposable
    {
        SqlConnection conn;

        public RequestDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        /// <summary>
        /// 생산요청리스트
        /// </summary>
        /// <returns>List</returns>
        public List<RequestVO> GetRequestList()
        {
            string sql = @"select Prd_Req_No, convert(varchar(10), Req_Date, 23) Req_Date, Req_Seq, pr.Item_Code, 
Item_Name, Req_Qty, Customer_Name, Project_Nm, Sale_Prsn_Nm, 
convert(varchar(10), Delivery_Date, 23) Delivery_Date, Plan_Qty, Prd_Progress_Status
from Production_Req pr join Item_Master im
on pr.Item_Code = im.Item_Code";

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return Helper.DataReaderMapToList<RequestVO>(cmd.ExecuteReader());
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        /// <summary>
        /// 생산요청생성
        /// </summary>
        /// <param name="cr"></param>
        /// <returns>bool</returns>
        public bool ProductionRequest(RequestVO cr)
        {  //Item_Code / Req_Qty / Customer_Name / Project_Nm / Sale_Prsn_Nm / Delivery_Date
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Request_ChaeBeon_In";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Item_Code", cr.Item_Code);
            cmd.Parameters.AddWithValue("@Req_Qty", cr.Req_Qty);
            cmd.Parameters.AddWithValue("@Customer_Name", cr.Customer_Name);
            cmd.Parameters.AddWithValue("@Project_Nm", cr.Project_Nm);
            cmd.Parameters.AddWithValue("@Sale_Prsn_Nm", cr.Sale_Prsn_Nm);
            cmd.Parameters.AddWithValue("@Delivery_Date", cr.Delivery_Date);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdateRequest(RequestVO ur)
        {
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    cmd.CommandText = @"update Production_Req
set Item_Code = @Item_Code, Req_Qty = @Req_Qty, Customer_Name = @Customer_Name,
Project_Nm = @Project_Nm, Delivery_Date = @Delivery_Date, 
Up_Date = getdate(), Up_Emp = @Up_Emp
where Prd_Req_No = @Prd_Req_No";

                    cmd.Parameters.AddWithValue("@Item_Code", ur.Item_Code);
                    cmd.Parameters.AddWithValue("@Req_Qty", ur.Req_Qty);
                    cmd.Parameters.AddWithValue("@Customer_Name", ur.Customer_Name);
                    cmd.Parameters.AddWithValue("@Project_Nm", ur.Project_Nm);
                    cmd.Parameters.AddWithValue("@Delivery_Date", ur.Delivery_Date);
                    cmd.Parameters.AddWithValue("@Up_Emp", ur.Sale_Prsn_Nm);
                    cmd.Parameters.AddWithValue("@Prd_Req_No", ur.Prd_Req_No);


                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }
            catch(Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool DeleteRequest(string id)
        {
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    cmd.CommandText = @"delete from Production_Req where Prd_Req_No = @Prd_Req_No";
                    cmd.Parameters.AddWithValue("@Prd_Req_No", id);
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                return true;
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return false;
            }
        }
    }
}
