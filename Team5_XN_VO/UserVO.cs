using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{
    public class UserVO
    {
        public string User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_PW { get; set; }
        public string UserGroup_Code { get; set; }
        public string UserGroup_Name { get; set; }
        public string IP_Security_YN { get; set; }
        
        public string Default_Major_Process_Code { get; set; }
        public string Process_Name { get; set; }
        public string Use_YN { get; set; }
        public DateTime Up_Date { get; set; }
        public string Up_Emp { get; set; }
        public DateTime Ins_Date { get; set; }
        public string Ins_Emp { get; set; }
    }
}
