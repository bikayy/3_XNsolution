using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_VO;
using Team5_XN_DAC;

namespace Team5_XN
{
    class InputListService
    {
        public List<SelectInputVO> SelectInput(InputVO input)
        {
            InputListDAC dac = new InputListDAC();
            List<SelectInputVO> list = dac.SelectInputList(input);
            dac.Dispose();

            return list;
        }

    }
}
