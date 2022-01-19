using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_VO;

namespace Team5_XN
{
    public class NopService
    {
        public DataTable GetNopRegist_Ma(string wcCode)
        {
            NopRegistDAC db = new NopRegistDAC();
            DataTable dt = db.GetNopRegist_Ma(wcCode);
            db.Dispose();

            return dt;
        }

        public DataTable GetNopRegist_Mi(string nopMaCode)
        {
            NopRegistDAC db = new NopRegistDAC();
            DataTable dt = db.GetNopRegist_Mi(nopMaCode);
            db.Dispose();

            return dt;
        }

        public bool NopRegist_Stop(string wcCode, string nopMaCode, string nopMiCode, DateTime nopTime)
        {
            NopRegistDAC db = new NopRegistDAC();
            bool result = db.NopRegist_Stop(wcCode, nopMaCode, nopMiCode, nopTime);
            db.Dispose();

            return result;
        }
        public bool NopRegist_Stop(NopInfoVO NopInfo)
        {
            NopRegistDAC db = new NopRegistDAC();
            bool result = db.NopRegist_Stop(NopInfo);
            db.Dispose();

            return result;
        }

        public DataTable GetNopHistory(string wcCode)
        {
            NopRegistDAC db = new NopRegistDAC();
            DataTable dt = db.GetNopHistory(wcCode);
            db.Dispose();

            return dt;
        }

        public DataTable GetNopHistoryAll(DateTime dateFrom, DateTime dateTo)
        {
            NopRegistDAC db = new NopRegistDAC();
            DataTable dt = db.GetNopHistoryAll(dateFrom, dateTo);
            db.Dispose();

            return dt;
        }

        public bool NopRegist_Start(NopHistoryVO nopHistory)
        {
            NopRegistDAC db = new NopRegistDAC();
            bool result = db.NopRegist_Start(nopHistory);
            db.Dispose();

            return result;
        }

        
        public bool NopRegist_Update(NopInfoVO nopInfo)
        {
            NopRegistDAC db = new NopRegistDAC();
            bool result = db.NopRegist_Update(nopInfo);
            db.Dispose();

            return result;
        }

        
        public bool NopRegist_Delete(NopHistoryVO nopHistory)
        {
            NopRegistDAC db = new NopRegistDAC();
            bool result = db.NopRegist_Delete(nopHistory);
            db.Dispose();

            return result;
        }

        
        public int NopRegistAll_Update(DataTable dt)
        {
            NopRegistDAC db = new NopRegistDAC();
            int result = db.NopRegistAll_Update(dt);
            db.Dispose();

            return result;
        }

        public bool NopRegistAll_Delete(int seq)
        {
            NopRegistDAC db = new NopRegistDAC();
            bool result = db.NopRegistAll_Delete(seq);
            db.Dispose();

            return result;
        }
    }
}
