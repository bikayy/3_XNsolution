using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_DAC;
using Team5_XN_VO;

namespace Team5_XN
{
    class PlanService
    {
        public List<GetPlanListVO> GetPlanList()
        {
            PlanDAC db = new PlanDAC();
            List<GetPlanListVO> list = db.GetPlanList();
            db.Dispose();

            return list;
        }

        public bool CreatePlan(PlanVO cp)
        {
            PlanDAC db = new PlanDAC();
            bool result = db.CreatePlan(cp);
            db.Dispose();

            return result;
        }

        public bool AddPlan(PlanVO ap)
        {
            PlanDAC db = new PlanDAC();
            bool result = db.AddPlan(ap);
            db.Dispose();

            return result;
        }

        public bool UpdatePlan(GetPlanListVO up)
        {
            PlanDAC db = new PlanDAC();
            bool result = db.UpdatePlan(up);
            db.Dispose();

            return result;
        }

        public bool DeletePlan(string id)
        {
            PlanDAC db = new PlanDAC();
            bool result = db.DeletePlan(id);
            db.Dispose();

            return result;
        }
    }
}
