using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN 
{ 
    class DayProductionService
    {

        public DataTable GetDayProduction(DateTime from, DateTime to)
        {
            DayProductionDAC db = new DayProductionDAC();
            DataTable dt = db.GetDayProduction(from, to);
            db.Dispose();

            return dt;
        }

        public DataTable GetDayDefect(DateTime from, DateTime to, string process_code, string Wc_Name, string WorkOrderNo)
        {
            DayProductionDAC db = new DayProductionDAC();
            DataTable dt = db.GetDayDefect(from, to, process_code, Wc_Name, WorkOrderNo);
            db.Dispose();

            return dt;
        }
        
        public DataTable GetDayDefect_Chart(DateTime from, DateTime to)
        {
            DayProductionDAC db = new DayProductionDAC();
            DataTable dt = db.GetDayDefect_Chart(from, to);
            db.Dispose();

            return dt;
        }
    }
}
