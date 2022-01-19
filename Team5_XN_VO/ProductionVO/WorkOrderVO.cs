using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{
    class WorkOrderVO
    {
    }

    public class WOSelectVO
    {
        /*
        w.Wo_Status, WorkOrderNo, convert(varchar(10), Plan_Date, 23) Plan_Date,
		Plan_Qty_Box, w.Item_Code, i.Item_Name,
		w.Wc_Code, wc.Wc_Name, wc.Process_Code, Process_Name,
		convert(varchar(10), Prd_Date, 23) Prd_Date, Prd_Qty, 
		Plan_StartTime,	Plan_EndTime, Prd_StartTime, Prd_EndTime,
		Worker_CloseTime, Manager_CloseTime, Close_CancelTime, 
		w.Remark, Prd_Plan_No
        */

        public string Wo_Status { get; set; }
        public string WorkOrderNo { get; set; }
        public string Plan_Date { get; set; }
        public int Plan_Qty_Box { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Wc_Code { get; set; }
        public string Wc_Name { get; set; }
        public string Prd_Date { get; set; }
        public int Prd_Qty { get; set; }
        public DateTime Plan_StartTime { get; set; }
        public DateTime Plan_EndTime { get; set; }
        public DateTime Prd_StartTime { get; set; }
        public DateTime Prd_EndTime { get; set; }
        public DateTime Worker_CloseTime { get; set; }
        public DateTime Manager_CloseTime { get; set; }
        public DateTime Close_CancelTime { get; set; }
        public string Remark { get; set; }
        public string Prd_Plan_No { get; set; }
        public string Process_Code { get; set; }
        public string Process_Name { get; set; }

    }

    public class WOUpsertVO
    {  //Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code, Process_Code,
        //Plan_StartTime, Plan_EndTime, Remark, Ins_Emp  / WorkOrderNo , Up_Emp
        public string WorkOrderNo { get; set; }
        public string Plan_Date { get; set; }
        public int Plan_Qty_Box { get; set; }
        public string Item_Code { get; set; }
        public string Wc_Code { get; set; }
        public string Process_Code { get; set; }
        public DateTime Plan_StartTime { get; set; }
        public DateTime Plan_EndTime { get; set; }
        public string Remark { get; set; }
        public string Ins_Emp { get; set; }
        public string Up_Emp { get; set; }
    }
}
