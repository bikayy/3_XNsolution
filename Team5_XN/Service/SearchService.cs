using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_DAC;
using Team5_XN_VO;

namespace Team5_XN
{
    class SearchService
    {
        public List<SearchVO> GetItemList()
        {
            SearchDAC db = new SearchDAC();
            List<SearchVO> list = db.GetItemList();
            db.Dispose();

            return list;
        }
    }
}
