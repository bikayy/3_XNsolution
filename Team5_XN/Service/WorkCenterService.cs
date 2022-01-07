using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN
{
    class WorkCenterService
    {
        public DataTable GetWorkCenter()
        {
            WorkCenterDAC db = new WorkCenterDAC();
            DataTable dt = db.GetWorkCenter();
            db.Dispose();

            return dt;
        }

        public int SaveWorkCenter(DataTable dt, int check)
        {
            WorkCenterDAC db = new WorkCenterDAC();
            int result = db.SaveWorkCenter(dt, check);
            db.Dispose();

            return result;
        }

        public bool DeleteProcess(String wcCode)
        {
            WorkCenterDAC db = new WorkCenterDAC();
            bool result = db.DeleteWorkCenter(wcCode);
            db.Dispose();

            return result;
        }

    }
}
