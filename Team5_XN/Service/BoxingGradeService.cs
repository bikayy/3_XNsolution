using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_DAC;
using Team5_XN_VO;

namespace Team5_XN
{
    class BoxingGradeService
    {
        public DataTable GetBoxingGradeMaster()
        {
            BoxingGradeDAC db = new BoxingGradeDAC();
            DataTable result = db.GetBoxingGradeMaster();
            db.Dispose();

            return result;
        }
        public DataTable GetBoxingGradeDetail(string code)
        {
            BoxingGradeDAC db = new BoxingGradeDAC();
            DataTable result = db.GetBoxingGradeDetail(code);
            db.Dispose();

            return result;
        }
    }
}
