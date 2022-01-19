using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{

    public class NopVO
    {
        public string Nop_Code { get; set; }
        public string Nop_Name { get; set; }
    }
    public class NopMaVO
    {
        public string Nop_Ma_Code { get; set; }
        public string Nop_Ma_Name { get; set; }
    }

    public class NopMiVO
    {
        public string Nop_Mi_Code { get; set; }
        public string Nop_Mi_Name { get; set; }
    }

    public class NopInfoVO
    {
        public string Wc_Code { get; set; }
        public string Wc_Name { get; set; }

        public string Nop_Ma_Code { get; set; }
        public string Nop_Ma_Name { get; set; }
        public string Nop_Mi_Code { get; set; }
        public string Nop_Mi_Name { get; set; }
        public DateTime Nop_DateTime_Start { get; set; }

        public DateTime Nop_DateTime_End { get; set; }
        public string Nop_Time { get; set; }
    }


    public class NopHistoryVO
    {
        public string Wc_Code { get; set; }
        public string Wc_Name { get; set; }

        public string Nop_Ma_Code { get; set; }
        public string Nop_Ma_Name { get; set; }
        public string Nop_Mi_Code { get; set; }
        public string Nop_Mi_Name { get; set; }
        public DateTime Nop_DateTime_Start { get; set; }

        public DateTime Nop_DateTime_End { get; set; }
        public string Nop_Time { get; set; }
    }
}
