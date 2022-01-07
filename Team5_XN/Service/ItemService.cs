using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN
{
    class ItemService
    {
        public DataTable GetItem()
        {
            ItemDAC db = new ItemDAC();
            DataTable dt = db.GetItem();
            db.Dispose();

            return dt;
        }

        public int SaveItem(DataTable dt, int check)
        {
            ItemDAC db = new ItemDAC();
            int result = db.SaveItem(dt, check);
            db.Dispose();

            return result;
        }

        public bool DeleteItem(String itemCode)
        {
            ItemDAC db = new ItemDAC();
            bool result = db.DeleteItem(itemCode);
            db.Dispose();

            return result;
        }
    }
}
