using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN_VO
{
    public class ProcessVO
    {

        /// <summary>
        /// 공정코드 Process_Code
        /// 공정명   Process_Name
        /// 공정그룹 Process_Group
        /// 비고     Remark
        /// 사용유무 Use_YN
        /// </summary>
        /// 
        public string Process_Code { get; set; }
        public string Process_Name { get; set; }
        public string Process_Group { get; set; }
        public string Remark { get; set; }
        public string Use_YN { get; set; }

        public DateTime Up_Date { get; set; }
        public string Up_Emp { get; set; }
        public DateTime Ins_Date { get; set; }
        public string Ins_Emp { get; set; }
    }
}
