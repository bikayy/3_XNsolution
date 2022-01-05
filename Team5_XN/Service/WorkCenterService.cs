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
    }
}
