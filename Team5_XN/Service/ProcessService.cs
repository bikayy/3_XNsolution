using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN
{
    class ProcessService
    {
        public DataTable GetProcess()
        {
            ProcessDAC db = new ProcessDAC();
            DataTable dt = db.GetProcess();
            db.Dispose();

            return dt;
        }

        public int SaveProcess(DataTable dt, int check)
        {
            ProcessDAC db = new ProcessDAC();
            int result = db.SaveProcess(dt, check);
            db.Dispose();

            return result;
        }

        public bool DeleteProcess(String processCode)
        {
            ProcessDAC db = new ProcessDAC();
            bool result = db.DeleteProcess(processCode);
            db.Dispose();

            return result;
        }

        public DataTable SearchProcess()
        {
            ProcessDAC db = new ProcessDAC();
            DataTable result = db.SearchProcess();
            db.Dispose();

            return result;
        }
    }
}
