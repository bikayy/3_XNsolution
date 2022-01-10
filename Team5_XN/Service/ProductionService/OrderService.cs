using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_DAC;
using Team5_XN_VO;

namespace Team5_XN
{
    class OrderService
    {
        public bool CreateOrder(OrderVO io)
        {
            OrderDAC db = new OrderDAC();
            bool result = db.CreateOrder(io);
            db.Dispose();

            return result;
        }

        public List<OrderVO> SelectOrder(PlanSearchVO ps)
        {
            OrderDAC db = new OrderDAC();
            List<OrderVO> list = db.SelectOrder(ps);
            db.Dispose();

            return list;
        }

        public bool EndOrder(string orderNo)
        {
            OrderDAC db = new OrderDAC();
            bool result = db.EndOrder(orderNo);
            db.Dispose();

            return result;
        }

        public bool EndCancleOrder(string orderNo)
        {
            OrderDAC db = new OrderDAC();
            bool result = db.EndCancleOrder(orderNo);
            db.Dispose();

            return result;
        }

        public bool UpdateOrder(OrderVO uo)
        {
            OrderDAC db = new OrderDAC();
            bool result = db.UpdateOrder(uo);
            db.Dispose();

            return result;
        }
    }
}
