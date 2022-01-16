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
}
