using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{
    public class SearchVO
    {
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
    }

    public class WCSearchVO
    {  //Wc_Code, Wc_Name, Wc_Group, Process_Code
        public string Wc_Code { get; set; }
        public string Wc_Name { get; set; }
        public string Wc_Group { get; set; }
        public string Process_Name { get; set; }

    }

    public class ReqSearchVO
    {
        public string Tag { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string ItemCode { get; set; }
    }

    public class PlanSearchVO
    {
        public string PlanMonth { get; set; }
        public string ItemCode { get; set; }
        public string WCCode { get; set; }
    }
    public class UGSearchVO
    {
        //UserGroup_Code, UserGroup_Name
        public string UserGroup_Code { get; set; }
        public string UserGroup_Name { get; set; }
    }
}
