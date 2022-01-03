using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{
    /*
1. Prd_Req_Plan_Allocation(생산요청별계획할당)
1) Prd_Req_No	 nvarchar(20) / 생산요청번호

2. Production_Plan_Detail(생산계획Detail)
Plan_Month	생산계획월	nvarchar(7)
Item_Code	품목코드	nvarchar(20)
Plan_Qty	생산계획수량	int
Prd_Plan_Status	생산계획상태	nvarchar(20)
Wc_Code	작업장코드	nvarchar(20)
Remark	비고	nvarchar(200)
Ins_Emp	최초입력자	nvarchar(20)

    pp.Prd_Plan_No,  pp.Wc_Code, Wc_Name, pp.Item_Code, Item_Name, 
pp.Plan_Qty, Customer_Name, Delivery_Date,
Prd_Plan_Status, pp.Remark
    */

    public class PlanVO
    {
        public string Prd_Req_No { get; set; }
        public string Plan_Month { get; set; }
        public string Item_Code { get; set; }
        public int Plan_Qty { get; set; }
        public string Wc_Code { get; set; }
        public string Remark { get; set; }
        public string Ins_Emp { get; set; }
    }

    public class GetPlanListVO
    {
        public string Item_Code { get; set; }
        public int Plan_Qty { get; set; }
        public string Prd_Plan_Status { get; set; }
        public string Plan_Month { get; set; }
        public string Wc_Code { get; set; }
        public string Remark { get; set; }
        public string Prd_Plan_No { get; set; }
        public string Wc_Name { get; set; }
        public string Item_Name { get; set; }
        public string Customer_Name { get; set; }
        public string Delivery_Date { get; set; }
        public string Ins_Emp { get; set; }
    }
}
