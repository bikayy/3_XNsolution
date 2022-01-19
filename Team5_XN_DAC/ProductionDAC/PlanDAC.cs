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
    public class PlanDAC : IDisposable
    {
        SqlConnection conn;

        public PlanDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<GetPlanListVO> GetPlanList(PlanSearchVO ps)
        {  //planMonth, ItemCode, WCCode
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Plan_Select";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PlanMonth", ps.PlanMonth);
            cmd.Parameters.AddWithValue("@ItemCode", ps.ItemCode);
            cmd.Parameters.AddWithValue("@WcCode", ps.WCCode);

            return Helper.DataReaderMapToList<GetPlanListVO>(cmd.ExecuteReader());
        }

            public List<GetPlanListVO> GetPlanList2()
        {
            SqlTransaction trans = conn.BeginTransaction();
            SqlCommand cmd = null;
            try
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    cmd.CommandText = @"select pp.Prd_Plan_No,  pp.Wc_Code, Wc_Name, pp.Item_Code, Item_Name,
pp.Plan_Qty, Plan_Month, Customer_Name, convert(varchar(10), Delivery_Date, 23) Delivery_Date,
Prd_Plan_Status, pp.Remark, pp.Ins_Emp
from Production_Plan_Detail pp join Item_Master im
	on pp.Item_Code = im.Item_Code
join WorkCenter_Master wm
	on pp.Wc_Code = wm.Wc_Code
join Prd_Req_Plan_Allocation pa
	on pp.Prd_Plan_No = pa.Prd_Plan_No
join Production_Req pr
	on pr.Prd_Req_No = pa.Prd_Req_No";
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();
                return Helper.DataReaderMapToList<GetPlanListVO>(cmd.ExecuteReader());
            }
            catch (Exception err)
            {
                trans.Rollback();
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public bool CreatePlan(PlanVO cp)
        {  //Prd_Req_No, Plan_Month, Item_Code, Plan_Qty, Wc_Code, Remark, Ins_Emp
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Plan_Insert";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Prd_Req_No", cp.Prd_Req_No);
            cmd.Parameters.AddWithValue("@Plan_Month", cp.Plan_Month);
            cmd.Parameters.AddWithValue("@Item_Code", cp.Item_Code);
            cmd.Parameters.AddWithValue("@Plan_Qty", cp.Plan_Qty);
            cmd.Parameters.AddWithValue("@Wc_Code", cp.Wc_Code);
            cmd.Parameters.AddWithValue("@Remark", cp.Remark);
            cmd.Parameters.AddWithValue("@Ins_Emp", cp.Ins_Emp);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool AddPlan(PlanVO ap)
        {  //Plan_Month, Item_Code, Plan_Qty, Wc_Code, Remark, Ins_Emp
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Plan_Add";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Plan_Month", ap.Plan_Month);
            cmd.Parameters.AddWithValue("@Item_Code", ap.Item_Code);
            cmd.Parameters.AddWithValue("@Plan_Qty", ap.Plan_Qty);
            cmd.Parameters.AddWithValue("@Wc_Code", ap.Wc_Code);
            cmd.Parameters.AddWithValue("@Remark", ap.Remark);
            cmd.Parameters.AddWithValue("@Ins_Emp", ap.Ins_Emp);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool UpdatePlan(GetPlanListVO up)
        {
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;

                    cmd.CommandText = @"update Production_Plan_Detail
set Wc_Code = @Wc_Code,  Item_Code = @Item_Code, 
Plan_Qty = @Plan_Qty, Remark = @Remark,
Up_Date = getdate(), Up_Emp = @Up_Emp
where Prd_Plan_No = @Prd_Plan_No";

                    cmd.Parameters.AddWithValue("@Wc_Code", up.Wc_Code);
                    cmd.Parameters.AddWithValue("@Item_Code", up.Item_Code);
                    cmd.Parameters.AddWithValue("@Plan_Qty", up.Plan_Qty);
                    cmd.Parameters.AddWithValue("@Remark", up.Remark);
                    cmd.Parameters.AddWithValue("@Up_Emp", up.Ins_Emp);
                    //cmd.Parameters.AddWithValue("@Plan_Month", up.Plan_Month);
                    cmd.Parameters.AddWithValue("@Prd_Plan_No", up.Prd_Plan_No);


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

        public bool DeletePlan(string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Plan_Delete";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Prd_Plan_No", id);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool EndPlan(string no)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Plan_End";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Prd_Plan_No", no);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool EndCanclePlan(string no)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Plan_End_Cancle";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Prd_Plan_No", no);
            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
