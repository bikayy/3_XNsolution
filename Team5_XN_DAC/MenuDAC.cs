using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Team5_XN
{
    public class MenuDAC : IDisposable
    {
        SqlConnection conn;
        public MenuDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }
        public void Dispose()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        public DataTable GetUserMenuList(string userid)
        {
            string sql = @"select Seq, M.Screen_Code, S.WordKey, Parent_Screen_Code, M.Sort_Index, S.Screen_Path
from MenuTree_Master M inner join Screenitem_Master S on M.Screen_Code = S.Screen_Code
where Seq in (select Seq 
                from UserGroup_Mapping P inner join ScreenItem_Authority A on P.UserGroup_Code = A.UserGroup_Code
                where P.User_ID = @userid)
union
select distinct MM.Seq, MM.Screen_Code, SS.WordKey, MM.Parent_Screen_Code, MM.Sort_Index, SS.Screen_Path
from MenuTree_Master MM inner join Screenitem_Master SS on MM.Screen_Code = SS.Screen_Code
inner join MenuTree_Master C on MM.Screen_Code = C.Parent_Screen_Code
where C.Seq in (select C.Seq 
                from UserGroup_Mapping P inner join ScreenItem_Authority A on P.UserGroup_Code = A.UserGroup_Code
                where P.User_ID = @userid)";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@userid", userid);

                da.Fill(dt);
            }
            return dt;
        }
		
		public DataTable GetTimeProductHistory()
        {
            string sql = @"SELECT 
		 distinct tp.WorkOrderNo
		,w.Wo_Status
		,w.Plan_Date
		,w.Plan_Qty_Box
		,w.Item_Code
		,(select Item_Name from Item_Master where Item_Code = w.Item_Code)Item_Name
		,(select Item_Name_Eng from Item_Master where Item_Code = w.Item_Code) Item_Name_Eng 
		,wc.Wc_Name  
		,(select Process_Name from process_master where process_code = wc.Process_Code) Process_Name  
		,w.Prd_Date
		,w.Prd_StartTime
		,w.Prd_EndTime
		,SUM(tp.Prd_Qty) OVER (PARTITION BY tp.WorkOrderNo) Prd_Qty

	FROM Time_Production_History tp
		JOIN WorkOrder w ON tp.WorkOrderNo = w.WorkOrderNo
		JOIN WorkCenter_Master wc ON w.Wc_Code = wc.Wc_Code";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetDayProduction()
        {
            string sql = @"SELECT 
		 DISTINCT tp.WorkOrderNo
		,w.Prd_Date

		,(select Process_Name from process_master where process_code = wc.Process_Code) Process_Name 
		,wc.Wc_Name 

		,(select Item_Name from Item_Master where Item_Code = w.Item_Code)Item_Name
		,(select Item_Code from Item_Master where Item_Code = w.Item_Code) Item_Code 

		,w.Plan_Qty_Box
		,SUM(tp.Prd_Qty) OVER (PARTITION BY tp.WorkOrderNo) as Prd_Qty
		,CAST((100.0*SUM(tp.Prd_Qty) OVER (PARTITION BY tp.WorkOrderNo) / w.Plan_Qty_Box) as DECIMAL(10,2))Achieve_Rate
		
		,w.Prd_StartTime
		,w.Prd_EndTime	
		,CAST((DATEDIFF(SECOND, w.Prd_StartTime, w.Prd_EndTime) /3600.0) as decimal(7,2)) as Prd_Time

		,CAST(SUM(tp.Prd_Qty) OVER (PARTITION BY tp.WorkOrderNo) / (DATEDIFF(MINUTE, w.Prd_StartTime, w.Prd_EndTime) /60.0)as DECIMAL(10,2))  as Prd_Qty_Time

	FROM Time_Production_History tp
		JOIN WorkOrder w ON tp.WorkOrderNo = w.WorkOrderNo
		JOIN WorkCenter_Master wc ON w.Wc_Code = wc.Wc_Code";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetDayDefect()
        {
            string sql = @"WITH Filter_Goods AS
	(
		SELECT 
			distinct w.workorderno
			,w.Prd_Date 
			,w.Item_Code
			,(select Item_Name from Item_Master i where w.Item_Code = i.Item_Code) Item_Name
			,(select Wc_Name from WorkCenter_Master wm where w.Wc_Code = wm.Wc_Code) Wc_Name
			,(select Process_Code from WorkCenter_Master wm where w.Wc_Code = wm.Wc_Code) Process_Code
			,w.Plan_Qty_Box
			,SUM(g.In_Qty) OVER (PARTITION BY w.workorderno) as Prd_Qty
			--,w.Prd_Qty
			,SUM(CASE WHEN g.grade_code='c1000' THEN g.In_Qty END) OVER (PARTITION BY w.workorderno) good_qty
			,SUM(CASE WHEN g.grade_code='c2000' THEN g.In_Qty END) OVER (PARTITION BY w.workorderno) bad_qty
			--,G.In_Qty 
			--,Grade_Code
		FROM Goods_In_History G
		JOIN WorkOrder W ON G.WorkOrderNo = W.WorkOrderNo
	)
	,Filter_Goods_rollup as
	(
		SELECT 
			Prd_Date
			,WorkOrderNo
			,Item_Code
			,Item_Name
			,Wc_Name
			,Process_Code
			,SUM(Plan_Qty_Box) Plan_Qty_Box 
			,SUM(ISNULL(Prd_Qty,0)) Prd_Qty
			,SUM(ISNULL(good_qty,0)) good_qty
			,SUM(ISNULL(bad_qty,0)) bad_qty
		FROM filter_goods
		GROUP BY ROLLUP ((Prd_Date, workorderno, Item_Code, Item_Name, Wc_Name,Process_Code ))
	)
	SELECT 
		 cast(Prd_Date as nvarchar(10)) Prd_Date
		,WorkOrderNo
		,Item_Code
		,Item_Name
		,Wc_Name
		,(select Process_Name from Process_Master p where F.Process_Code = p.Process_Code) Process_Name
		,Plan_Qty_Box
		,Prd_Qty
		,(Prd_Qty-bad_qty)Good_Qty
		,bad_qty
		
		,CAST(100.0 * bad_qty / Prd_Qty as DECIMAL(10,2)) as Defect_Rate 
	FROM Filter_Goods_rollup F";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
    }
}
