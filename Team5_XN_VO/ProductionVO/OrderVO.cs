using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{
	/*
    @Wo_Status nvarchar(20), -- 작업지시상태
	-- @WorkOrderNo nvarchar(20), -- 작업지시번호
	@Plan_Date date, -- 계획일자
	@Plan_Qty_Box int, -- 계획수량
	@Item_Code nvarchar(20), 
	@Wc_Code nvarchar(20),
	@Prd_Date date, -- 생산일자
	@Prd_Qty int, --생산수량
	@Plan_StartTime datetime, -- 계획시작시간
	@Plan_EndTime datetime, --계획종료시간
	-- @Prd_StartTime datetime, -- 작업시작시간
	-- @Prd_EndTime datetime, -- 작업종료시간
	-- @Worker_CloseTime datetime, -- 현장마감시간
	-- @Manager_CloseTime datetime, -- 관리자마감시간
	-- @Close_CancelTime datetime, -- 마감취소시간
	@Remark nvarchar(100), 
	@Prd_Plan_No nvarchar(20), 
	@Ins_Date datetime, 
	@Ins_Emp nvarchar(20), 
	--@Up_Date datetime, 
	--@Up_Emp nvarchar(20)
    */

	public class OrderVO
    {
        public string Wo_Status { get; set; }
		public string Plan_Date { get; set; }
		public int Plan_Qty_Box { get; set; }
		public string Item_Code { get; set; }
		public string Wc_Code { get; set; }
		public string Prd_Date { get; set; }
		public int Prd_Qty { get; set; }
		public string Plan_StartTime { get; set; }
		public string Plan_EndTime { get; set; }
		public string Remark { get; set; }
		public string Prd_Plan_No { get; set; }
		public DateTime Ins_Date { get; set; }
		public string Ins_Emp { get; set; }



		public string Item_Name { get; set; }
		public string Wc_Name { get; set; }
		public string WorkOrderNo { get; set; }
		public string Prd_StartTime { get; set; }
		public string Prd_EndTime { get; set; }
		public string Worker_CloseTime { get; set; }
		public string Manager_CloseTime { get; set; }
		public string Close_CancelTime { get; set; }
		public DateTime Up_Date { get; set; }
		public string Up_Emp { get; set; }
	}
}
