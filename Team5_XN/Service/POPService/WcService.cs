using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Team5_XN_VO;
using Team5_XN_DAC;

namespace Team5_XN
{
    public class WcService
    {
        public DataTable SelectWc()
        {
            WcDAC dac = new WcDAC();
            DataTable dt = dac.SelectWc();
            dac.Dispose();

            return dt;
        }

        public DataTable SelectOr(string wcCode)
        {
            WcDAC dac = new WcDAC();
            DataTable dt = dac.SelectOr(wcCode);
            dac.Dispose();

            return dt;
        }

        public bool Start(string woNo)
        {
            WcDAC dac = new WcDAC();
            bool result = dac.Start(woNo);
            dac.Dispose();

            return result;
        }

        public bool CreatePalette(CreatePaletteVO createPalette)
        {
            WcDAC dac = new WcDAC();
            bool result = dac.CreatePalette(createPalette);
            dac.Dispose();

            return result;
        }

        public bool RegPerSiyu(RegSiyuVO regPerSiyu)
        {
            WcDAC dac = new WcDAC();
            bool result = dac.RegPerSiyu(regPerSiyu);
            dac.Dispose();

            return result;
        }


        public bool End(string woNo)
        {
            WcDAC dac = new WcDAC();
            bool result = dac.End(woNo);
            dac.Dispose();

            return result;
        }

        public DataTable SelectPaletteList(string pNo)
        {
            WcDAC dac = new WcDAC();
            DataTable dt = dac.SelectPaleeteList(pNo);
            dac.Dispose();

            return dt;
        }

        public DataTable SelectGrade()
        {
            WcDAC dac = new WcDAC();
            DataTable dt = dac.SelectGrade();
            dac.Dispose();

            return dt;
        }

        public DataTable SelectGradeDetail(string code)
        {
            WcDAC dac = new WcDAC();
            DataTable dt = dac.SelectGradeDetail(code);
            dac.Dispose();

            return dt;
        }

        public DataTable SelectPerSiyu(string woNo, string wcCode)
        {
            WcDAC dac = new WcDAC();
            DataTable dt = dac.SelectPerSiyu(woNo, wcCode);
            dac.Dispose();

            return dt;
        }

    }
}
