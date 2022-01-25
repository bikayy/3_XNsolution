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
        public int SaveBoxing(DataTable dt, int check)
        {
            BoxingGradeDAC db = new BoxingGradeDAC();
            int result = db.SaveBoxing(dt, check);
            db.Dispose();

            return result;
        }
        public bool DeleteBoxDetail(String code)
        {
            BoxingGradeDAC db = new BoxingGradeDAC();
            bool result = db.DeleteBoxDetail(code);
            db.Dispose();

            return result;
        }

        public List<BoxingGradeVO> GetBoxingGradeList()
        {
            BoxingGradeDAC db = new BoxingGradeDAC();
            List<BoxingGradeVO> result = db.GetBoxingGradeList();
            db.Dispose();

            return result;
        }
    }
}
