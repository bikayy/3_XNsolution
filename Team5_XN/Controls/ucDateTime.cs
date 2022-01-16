using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN.Controls
{
    public partial class ucDateTime : UserControl
    {
        public ucDateTime()
        {
            InitializeComponent();
        }

        private void ucDateTime_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH시 mm분 ss초");
            timer1.Start();
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime day = DateTime.Now;
            switch (day.DayOfWeek)
            {
                case DayOfWeek.Monday: lblDay.Text = "(월요일)"; break;
                case DayOfWeek.Tuesday: lblDay.Text = "(화요일)"; break;
                case DayOfWeek.Wednesday: lblDay.Text = "(수요일)"; break;
                case DayOfWeek.Thursday: lblDay.Text = "(목요일)"; break;
                case DayOfWeek.Friday: lblDay.Text = "(금요일)"; break;
                case DayOfWeek.Saturday: lblDay.Text = "(토요일)"; break;
                case DayOfWeek.Sunday: lblDay.Text = "(일요일)"; break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH시 mm분 ss초");
        }
    }
}
