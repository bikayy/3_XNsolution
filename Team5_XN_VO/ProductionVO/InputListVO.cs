using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{
    class InputListVO
    {
    }

    public class SelectInputVO
    {   /*
        w.Prd_Date, w.Item_Code, i.Item_Name,
	c.DetailName, g.Grade_Detail_Code, g.Grade_Detail_Name,
	g.Pallet_No, g.In_Qty, g.Closed_Time, 
	g.WorkOrderNo
        */
        public string Prd_Date { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string PDetailName { get; set; }
        public string Grade_Detail_Code { get; set; }
        public string Grade_Detail_Name { get; set; }
        public string Pallet_No { get; set; }
        public int In_Qty { get; set; }
        public DateTime Closed_Time { get; set; }
        public string WorkOrderNo { get; set; }
    }
}
