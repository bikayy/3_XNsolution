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

        public List<WCSearchVO> GetWCList()
        {
            SearchDAC db = new SearchDAC();
            List<WCSearchVO> list = db.GetWCList();
            db.Dispose();

            return list;
        }
        public List<UGSearchVO> GetUGList()
        {
            SearchDAC db = new SearchDAC();
            List<UGSearchVO> list = db.GetUGList();
            db.Dispose();

            return list;
        }
    }
}
