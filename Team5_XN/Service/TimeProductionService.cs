using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN
{
    class TimeProductionService
    {

        public DataTable GetTimeProduction(DateTime from, DateTime to)
        {
            TimeProductionDAC db = new TimeProductionDAC();
            DataTable dt = db.GetTimeProduction(from, to);
            db.Dispose();

            return dt;
        }

        public DataTable GetTimeProduction_Chart(string workOrderNo)
        {
            TimeProductionDAC db = new TimeProductionDAC();
            DataTable dt = db.GetTimeProduction_Chart(workOrderNo);
            db.Dispose();

            return dt;
        }

    }
}
