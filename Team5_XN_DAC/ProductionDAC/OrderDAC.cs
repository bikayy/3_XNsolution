using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_VO;

namespace Team5_XN_DAC
{
    public class OrderDAC : IDisposable
    {
        SqlConnection conn;

        public OrderDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public bool CreateOrder(OrderVO io)
        {  //Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code, Plan_StartTime,
	        //Plan_EndTime, Remark, Prd_Plan_No, Ins_Date, Ins_Emp

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Order_Insert";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Plan_Date", io.Plan_Date);
            cmd.Parameters.AddWithValue("@Plan_Qty_Box", io.Plan_Qty_Box);
            cmd.Parameters.AddWithValue("@Item_Code", io.Item_Code);
            cmd.Parameters.AddWithValue("@Wc_Code", io.Wc_Code);
            cmd.Parameters.AddWithValue("@Plan_StartTime", io.Plan_StartTime);
            cmd.Parameters.AddWithValue("@Plan_EndTime", io.Plan_EndTime);
            cmd.Parameters.AddWithValue("@Remark", io.Remark);
            cmd.Parameters.AddWithValue("@Prd_Plan_No", io.Prd_Plan_No);
            cmd.Parameters.AddWithValue("@Ins_Emp", io.Ins_Emp);

            return cmd.ExecuteNonQuery() > 0;
        }

        public List<OrderVO> SelectOrder(PlanSearchVO ps)
        {  //Wo_Status, WorkOrderNo, Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code,
           //Prd_Date, Prd_Qty, Plan_StartTime, Plan_EndTime, Prd_StartTime, Prd_EndTime,
           //Worker_CloseTime, Manager_CloseTime, Close_CancelTime, Remark, 
           //Prd_Plan_No, Ins_Date, Ins_Emp, Up_Date, Up_Emp

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Order_Select";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PlanMonth", ps.PlanMonth);
            cmd.Parameters.AddWithValue("@ItemCode", ps.ItemCode);
            cmd.Parameters.AddWithValue("@WcCode", ps.WCCode);

            return Helper.DataReaderMapToList<OrderVO>(cmd.ExecuteReader());
        }

        public bool EndOrder(string orderNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Order_End";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", orderNo);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool EndCancleOrder(string orderNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Order_End_Cancle";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", orderNo);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdateOrder(OrderVO uo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Order_Update";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", uo.WorkOrderNo);
            cmd.Parameters.AddWithValue("@Plan_Date", uo.Plan_Date);
            cmd.Parameters.AddWithValue("@Plan_Qty_Box", uo.Plan_Qty_Box);
            cmd.Parameters.AddWithValue("@Wc_Code", uo.Wc_Code);
            cmd.Parameters.AddWithValue("@Plan_StartTime", uo.Plan_StartTime);
            cmd.Parameters.AddWithValue("@Plan_EndTime", uo.Plan_EndTime);
            cmd.Parameters.AddWithValue("@Remark", uo.Remark);
            cmd.Parameters.AddWithValue("@Up_Emp", uo.Up_Emp);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
