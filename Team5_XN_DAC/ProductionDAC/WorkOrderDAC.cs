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
    public class WorkOrderDAC : IDisposable
    {
        SqlConnection conn;

        public WorkOrderDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<WOSelectVO> WOSelect(string planFrom, string planTo, string prCode, string wcCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select w.Wo_Status, WorkOrderNo, convert(varchar(10), Plan_Date, 23) Plan_Date,
		Plan_Qty_Box, w.Item_Code, i.Item_Name,
		w.Wc_Code, wc.Wc_Name,  wc.Process_Code, Process_Name,
		convert(varchar(10), Prd_Date, 23) Prd_Date, Prd_Qty, 
		Plan_StartTime,	Plan_EndTime, Prd_StartTime, Prd_EndTime,
		Worker_CloseTime, Manager_CloseTime, Close_CancelTime, 
		w.Remark, Prd_Plan_No, 
		w.Ins_Date, w.Ins_Emp,
		w.Up_Date, w.Up_Emp
		from WorkOrder w join Item_Master i
		on w.Item_Code = i.Item_Code
		join WorkCenter_Master wc
		on w.Wc_Code = wc.Wc_Code
        join Process_Master p
		on wc.Process_Code = p.Process_Code
		where Plan_Date between @planFrom and @planTo ");
            if (!string.IsNullOrWhiteSpace(prCode))
            {
                sb.Append(" and p.Process_Code = @Process_Code ");
            }

            if (!string.IsNullOrWhiteSpace(wcCode))
            {
                sb.Append(" and  w.Wc_Code = @WcCode ");
            }

            using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@planFrom", planFrom);
                cmd.Parameters.AddWithValue("@planTo", planTo);
                cmd.Parameters.AddWithValue("@Process_Code", prCode);
                cmd.Parameters.AddWithValue("@WcCode", wcCode);

                return Helper.DataReaderMapToList<WOSelectVO>(cmd.ExecuteReader());
            }

        }

        public bool WOInsert(WOUpsertVO woInsert)
        {  //Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code, Process_Code,
            //Plan_StartTime, Plan_EndTime, Remark, Ins_Emp
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_WOPalette_Insert";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Plan_Date", woInsert.Plan_Date);
            cmd.Parameters.AddWithValue("@Plan_Qty_Box", woInsert.Plan_Qty_Box);
            cmd.Parameters.AddWithValue("@Item_Code", woInsert.Item_Code);
            cmd.Parameters.AddWithValue("@Wc_Code", woInsert.Wc_Code);
            cmd.Parameters.AddWithValue("@Process_Code", woInsert.Process_Code);
            cmd.Parameters.AddWithValue("@Plan_StartTime", woInsert.Plan_StartTime);
            cmd.Parameters.AddWithValue("@Plan_EndTime", woInsert.Plan_EndTime);
            cmd.Parameters.AddWithValue("@Remark", woInsert.Remark);
            cmd.Parameters.AddWithValue("@Ins_Emp", woInsert.Ins_Emp);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool WOUpdate(WOUpsertVO woInsert)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_WO_Update";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@WorkOrderNo", woInsert.WorkOrderNo);
            cmd.Parameters.AddWithValue("@Plan_Date", woInsert.Plan_Date);
            cmd.Parameters.AddWithValue("@Plan_Qty_Box", woInsert.Plan_Qty_Box);
            cmd.Parameters.AddWithValue("@Item_Code", woInsert.Item_Code);
            cmd.Parameters.AddWithValue("@Wc_Code", woInsert.Wc_Code);
            cmd.Parameters.AddWithValue("@Plan_StartTime", woInsert.Plan_StartTime);
            cmd.Parameters.AddWithValue("@Plan_EndTime", woInsert.Plan_EndTime);
            cmd.Parameters.AddWithValue("@Remark", woInsert.Remark);
            cmd.Parameters.AddWithValue("@Up_Emp", woInsert.Up_Emp);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool WODelete(string woNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_WO_Delete";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", woNo);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool WOEnd(string woNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_WO_End";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", woNo);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool WOEndCancle(string woNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_WO_End_Cancle";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", woNo);

            return cmd.ExecuteNonQuery() > 0;
        }

    }
}
