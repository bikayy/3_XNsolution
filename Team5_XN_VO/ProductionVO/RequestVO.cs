using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{
    public class RequestVO
    {
        /*
            생산요청번호 Prd_Req_No
            요청일자 Req_Date
            요청순번 Req_Seq
            품목코드 Item_Code
            품목명 Item_Name
            요청수량 Req_Qty
            거래처 Customer_Name
            프로젝트명 Project_Nm
            영업담당자명 Sale_Prsn_Nm
            납기일자 Delivery_Date
            생산반영수량 Plan_Qty
            생산진행상태 Prd_Progress_Status
        */

        public string Prd_Req_No { get; set; }
        public string Req_Date { get; set; }
        public string Req_Seq { get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public int Req_Qty { get; set; }
        public string Customer_Name { get; set; }
        public string Project_Nm { get; set; }
        public string Sale_Prsn_Nm { get; set; }
        public string Delivery_Date { get; set; }
        public int Plan_Qty { get; set; }
        public string Prd_Progress_Status { get; set; }

    }
}
