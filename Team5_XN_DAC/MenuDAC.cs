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
            string sql = @"SELECT WorkOrderNo, Start_Hour, In_Qty_Sub, In_Qty_Main, Out_Qty_Main, Out_Qty_Sub, Prd_Qty, Prd_Unit FROM Time_Production_History";

            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
    }
}
