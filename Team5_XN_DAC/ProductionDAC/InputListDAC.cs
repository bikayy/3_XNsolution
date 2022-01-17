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
    public class InputListDAC : IDisposable
    {
        SqlConnection conn;

        public InputListDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public List<SelectInputVO> SelectInputList(InputVO input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select Convert(char(10), w.Prd_Date, 23) Prd_Date, 
    w.Item_Code, i.Item_Name,
	c.DetailName, g.Grade_Detail_Code, g.Grade_Detail_Name,
	g.Pallet_No, g.In_Qty, g.Closed_Time, 
	g.WorkOrderNo
	from WorkOrder w join Goods_In_History g
	on w.WorkOrderNo = g.WorkOrderNo
	join Item_Master i
	on w.Item_Code = i.Item_Code
	join CommonCodeSystem c
	on g.Grade_Code = c.DetailCode
	where 1 = 1
	and w.Prd_Date between @FromDate and @ToDate
	and c.DetailCode = @DetailCode ");
            if (!string.IsNullOrWhiteSpace(input.WorkOrderNo))
            {
                sb.Append(" and g.WorkOrderNo like '%" + input.WorkOrderNo + "%'");
            }
            if (!string.IsNullOrWhiteSpace(input.ItemCode))
            {
                sb.Append(" and i.Item_Code = @ItemCOde ");
            }

            using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
            {
                cmd.Parameters.AddWithValue("@FromDate", input.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", input.ToDate);
                cmd.Parameters.AddWithValue("@DetailCode", input.DetailCode);
                cmd.Parameters.AddWithValue("@ItemCode", input.ItemCode);
                return Helper.DataReaderMapToList<SelectInputVO>(cmd.ExecuteReader());
            }
        }
    }
}
