using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{
    class WcVO
    {
    }

    public class SelectWcVO
    {  //Wc_Name, Wc_Group, Wo_Status
        public string Wc_Code { get; set; }
        public string Wc_Name { get; set; }
        public string Wc_Group { get; set; }
        public string Wo_Status { get; set; }
    }

    public class SelectOrderVO
    {  //Wo_Status, Plan_Date, Prd_Date, WorkOrderNo, Project_Nm, Item_Name, Item_Name_Eng,
        //Plan_Qty_Box, Prd_Qty, Prd_StartTime, Prd_EndTime, w.Remark
        public string Wo_Status { get; set; }
        public string Plan_Date { get; set; }
        public string Prd_Date { get; set; }
        public string WorkOrderNo { get; set; }
        public string Project_Nm { get; set; }
        public string Item_Name { get; set; }
        public string Item_Name_Eng { get; set; }
        public int Plan_Qty_Box { get; set; }
        public int Prd_Qty { get; set; }
        public string Prd_StartTime { get; set; }
        public string Prd_EndTime { get; set; }
        public string Remark { get; set; }
        public string Remark_YN { get; set; }
    }

    public class WoInfoVO
    {
        public string Item_Name { get; set; }
        public string Plan_Date { get; set; }
        public int Plan_Qty_Box { get; set; }
        public int Prd_Qty { get; set; }
        public string WorkOrderNo { get; set; }
        public string Wc_Code { get; set; }
        public string Wc_Name { get; set; }
    }

    public class PaletteListVO
    {  //Pallet_No, Grade(DetailName), g.Grade_Detail_Name, In_Qty
        public string Pallet_No { get; set; }
        public string Grade { get; set; }
        public string Grade_Detail_Name { get; set; }
        public int In_Qty { get; set; }
    }

    public class GradeVO
    {  //DetailCode, DetailName
        public string DetailCode { get; set; }
        public string DetailName { get; set; }
    }

    public class CreatePaletteVO
    {  //WorkOrderNo, Start_Hour, Prd_Qty, Pallet_No, Unit, Grade_Code
        //Grade_Detail_Code, Grade_Detail_Name, Ins_Emp

        public string WorkOrderNo { get; set; }
        public int Start_Hour { get; set; }
        public int Prd_Qty { get; set; }
        public string Pallet_No { get; set; }
        public string Unit { get; set; }
        public string Grade_Code { get; set; }
        public string Grade_Detail_Code { get; set; }
        public string Grade_Detail_Name { get; set; }
        public string Ins_Emp { get; set; }
    }

    public class RegSiyuVO
    {  //WorkOrderNo, Start_Hour, Prd_Qty, Pallet_No, Unit, Grade_Code
        //Grade_Detail_Code, Grade_Detail_Name, Ins_Emp

        public string WorkOrderNo { get; set; }
        public int Start_Hour { get; set; }
        public int Prd_Qty { get; set; }
        public string Unit { get; set; }
        public string Ins_Emp { get; set; }
        public string Wc_Code { get; set; }
    }

    public class SelectPerSiyuVO
    {  //WorkOrderNo, Reg_Datetime, Prd_Qty
        public string WorkOrderNo { get; set; }
        public DateTime Reg_Datetime { get; set; }
        public int Prd_Qty { get; set; }
    }

    public class DeletePerSiyuVO
    {  //WorkOrderNo, Prd_Qty, Reg_DateTime, Del_Emp
        public string WorkOrderNo { get; set; }
        public int Prd_Qty { get; set; }
        public DateTime Reg_DateTime { get; set; }
        public string Del_Emp { get; set; }
    }
}
