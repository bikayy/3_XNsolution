using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_DAC;
using Team5_XN_VO;

namespace Team5_XN
{
    class RequestService
    {
        public List<RequestVO> GetRequestList()
        {
            RequestDAC db = new RequestDAC();
            List<RequestVO> list = db.GetRequestList();
            db.Dispose();

            return list;
        }

        public bool ProductionRequest(RequestVO cr)
        {
            RequestDAC db = new RequestDAC();
            bool result = db.ProductionRequest(cr);
            db.Dispose();

            return result;
        }

        public bool UpdateRequest(RequestVO ur)
        {
            RequestDAC db = new RequestDAC();
            bool result = db.UpdateRequest(ur);
            db.Dispose();

            return result;
        }

        public bool DeleteRequest(string id)
        {
            RequestDAC db = new RequestDAC();
            bool result = db.DeleteRequest(id);
            db.Dispose();

            return result;
        }
    }
}
