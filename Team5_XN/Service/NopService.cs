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
    class NopService
    {
        public DataTable GetNopMaster()
        {
            NopDAC db = new NopDAC();
            DataTable result = db.GetNopMaster();
            db.Dispose();

            return result;
        }
        public DataTable GetNopDetail(string code)
        {
            NopDAC db = new NopDAC();
            DataTable result = db.GetNopDetail(code);
            db.Dispose();

            return result;
        }
        public List<NopVO> GetNopList()
        {
            NopDAC db = new NopDAC();
            List<NopVO> list = db.GetNopList();
            db.Dispose();

            return list;
        }
        public int SaveNopCode(DataTable dt, int check)
        {
            NopDAC db = new NopDAC();
            int result = db.SaveNopCode(dt, check);
            db.Dispose();

            return result;
        }
        public bool DeleteNopDetail(String code)
        {
            NopDAC db = new NopDAC();
            bool result = db.DeleteNopDetail(code);
            db.Dispose();

            return result;
        }
        
    }
}
