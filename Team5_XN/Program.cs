using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Main());
            //Application.Run(new POPWorkCenter());
            //Application.Run(new frmWorkOrder());
            //Application.Run(new frmWorkOrder2());
            //Application.Run(new frmWorkPlan());
            //Application.Run(new frmWorkRequest());
            //Application.Run(new POPWorkOrderStatus());
            //Application.Run(new POPPalette());
            Application.Run(new frmInputList());
        }
    }
}
