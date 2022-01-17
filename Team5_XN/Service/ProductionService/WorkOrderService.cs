using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_VO;
using Team5_XN_DAC;

namespace Team5_XN
{
    class WorkOrderService
    {
        public List<WOSelectVO> WOSelect(string planFrom, string planTo, string prCode, string wcCode)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            List<WOSelectVO> list = dac.WOSelect(planFrom, planTo, prCode, wcCode);
            dac.Dispose();

            return list;
        }

        public bool WOInsert(WOUpsertVO woInsert)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.WOInsert(woInsert);
            dac.Dispose();

            return result;
        }

        public bool WOUpdate(WOUpsertVO woInsert)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.WOUpdate(woInsert);
            dac.Dispose();

            return result;
        }

        public bool WODelete(string woNo)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.WODelete(woNo);
            dac.Dispose();

            return result;
        }

        public bool WOEnd(string woNo)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.WOEnd(woNo);
            dac.Dispose();

            return result;
        }

        public bool WOEndCancle(string woNo)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            bool result = dac.WOEndCancle(woNo);
            dac.Dispose();

            return result;
        }
    }
}
