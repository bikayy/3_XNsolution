using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    public partial class POPNopRegister : Form
    {
        int lastday;
        public POPNopRegister()
        {
            InitializeComponent();
        }

        /// <summary>
        /// numericUpDown 숫자 00, 01, 02~...  (안씀)
        /// </summary>
        public class MyNumericUpDown : NumericUpDown
        {
            protected override void UpdateEditText()
            {
                this.Text = this.Value.ToString().PadLeft(2, '0');
            }

        }

        private void POPNopRegister_Load(object sender, EventArgs e)
        {
            pnlRegister.Visible = false;


            button1_Click_1(this, null);
            //mskYear.Text = DateTime.Now.Year.ToString().PadLeft(2, '0');
            //mskMonth.Text = DateTime.Now.Month.ToString().PadLeft(2, '0');
            //mskDay.Text = DateTime.Now.Day.ToString().PadLeft(2, '0');
            //mskHour.Text = DateTime.Now.Hour.ToString().PadLeft(2, '0');
            //mskMinute.Text = DateTime.Now.Minute.ToString().PadLeft(2, '0');
            //mskSecond.Text = DateTime.Now.Second.ToString().PadLeft(2, '0');



        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            pnlRegister.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            pnlRegister.Visible = false;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            pnlRegister.Visible = false;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            //if (numericUpDown4.Value < 10)
            //{
            //    numericUpDown4.Value = Convert.ToDecimal("0" + numericUpDown4.Value);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lastday = DateTime.DaysInMonth(Convert.ToInt32(mskYear.Text), Convert.ToInt32(mskMonth.Text));

            if (((Button)sender).Name.Contains("Year"))///
            {
                if (((Button)sender).Name.Contains("Up"))
                {
                    if (Convert.ToInt32(mskYear.Text) >= 1900 && Convert.ToInt32(mskYear.Text) < 2999)
                        mskYear.Text = (Convert.ToInt32(mskYear.Text) + 1).ToString();
                    else if (Convert.ToInt32(mskYear.Text) == 2999)
                        mskYear.Text = "1900";
                }
                else if (((Button)sender).Name.Contains("Down"))
                {
                    if (Convert.ToInt32(mskYear.Text) > 1900 && Convert.ToInt32(mskYear.Text) <= 2999)
                        mskYear.Text = (Convert.ToInt32(mskYear.Text) - 1).ToString();
                    else if (Convert.ToInt32(mskYear.Text) == 1900)
                        mskYear.Text = "2999";
                }
            }

            else if (((Button)sender).Name.Contains("Month"))///
            {
                
                if (((Button)sender).Name.Contains("Up"))
                {
                    if (Convert.ToInt32(mskMonth.Text) >= 1 && Convert.ToInt32(mskMonth.Text) < 12)
                        mskMonth.Text = (Convert.ToInt32(mskMonth.Text) + 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskMonth.Text) == 12)
                        mskMonth.Text = "01";
                }
                else if (((Button)sender).Name.Contains("Down"))
                {
                    if (Convert.ToInt32(mskMonth.Text) > 1 && Convert.ToInt32(mskMonth.Text) <= 12)
                        mskMonth.Text = (Convert.ToInt32(mskMonth.Text) - 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskMonth.Text) == 01)
                        mskMonth.Text = "12";
                }

                
            }
            

            else if(((Button)sender).Name.Contains("Day"))///
            {
                
                if (((Button)sender).Name.Contains("Up"))
                {
                    if (Convert.ToInt32(mskDay.Text) >= 1 && Convert.ToInt32(mskDay.Text) < lastday)
                        mskDay.Text = (Convert.ToInt32(mskDay.Text) + 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskDay.Text) == lastday)
                        mskDay.Text = "01";
                }
                else if (((Button)sender).Name.Contains("Down"))
                {
                    if (Convert.ToInt32(mskDay.Text) > 1 && Convert.ToInt32(mskDay.Text) <= lastday)
                        mskDay.Text = (Convert.ToInt32(mskDay.Text) - 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskDay.Text) == 01)
                        mskDay.Text = lastday.ToString();
                }
            }

            else if(((Button)sender).Name.Contains("Hour"))///
            {
                if (((Button)sender).Name.Contains("Up"))
                {
                    if (Convert.ToInt32(mskHour.Text) >= 0 && Convert.ToInt32(mskHour.Text) < 23)
                        mskHour.Text = (Convert.ToInt32(mskHour.Text) + 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskHour.Text) == 23)
                        mskHour.Text = "00";
                }
                else if (((Button)sender).Name.Contains("Down"))
                {
                    if (Convert.ToInt32(mskHour.Text) > 0 && Convert.ToInt32(mskHour.Text) <= 23)
                        mskHour.Text = (Convert.ToInt32(mskHour.Text) - 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskHour.Text) == 00)
                        mskHour.Text = "23";
                }
            }

            else if(((Button)sender).Name.Contains("Minute"))///
            {
                if (((Button)sender).Name.Contains("Up"))
                {
                    if (Convert.ToInt32(mskMinute.Text) >= 0 && Convert.ToInt32(mskMinute.Text) < 59)
                        mskMinute.Text = (Convert.ToInt32(mskMinute.Text) + 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskMinute.Text) == 59)
                        mskMinute.Text = "00";
                }
                else if (((Button)sender).Name.Contains("Down"))
                {
                    if (Convert.ToInt32(mskMinute.Text) > 0 && Convert.ToInt32(mskMinute.Text) <= 59)
                        mskMinute.Text = (Convert.ToInt32(mskMinute.Text) - 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskMinute.Text) == 00)
                        mskMinute.Text = "59";
                }
            }

            else if (((Button)sender).Name.Contains("Second"))///
            {
                if (((Button)sender).Name.Contains("Up"))
                {
                    if (Convert.ToInt32(mskSecond.Text) >= 0 && Convert.ToInt32(mskSecond.Text) < 59)
                        mskSecond.Text = (Convert.ToInt32(mskSecond.Text) + 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskSecond.Text) == 59)
                        mskSecond.Text = "00";
                }
                else if (((Button)sender).Name.Contains("Down"))
                {
                    if (Convert.ToInt32(mskSecond.Text) > 0 && Convert.ToInt32(mskSecond.Text) <= 59)
                        mskSecond.Text = (Convert.ToInt32(mskSecond.Text) - 1).ToString().PadLeft(2, '0');
                    else if (Convert.ToInt32(mskSecond.Text) == 00)
                        mskSecond.Text = "59";
                }

            }           

            if (lastday < Convert.ToInt32(mskDay.Text))
            {
                mskDay.Text = lastday.ToString();
            }


        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            mskYear.Text = DateTime.Now.Year.ToString().PadLeft(4, '0');
            mskMonth.Text = DateTime.Now.Month.ToString().PadLeft(2, '0');
            mskDay.Text = DateTime.Now.Day.ToString().PadLeft(2, '0');
            mskHour.Text = DateTime.Now.Hour.ToString().PadLeft(2, '0');
            mskMinute.Text = DateTime.Now.Minute.ToString().PadLeft(2, '0');
            mskSecond.Text = DateTime.Now.Second.ToString().PadLeft(2, '0');
        }

        private void mskMonth_Validating(object sender, CancelEventArgs e)
        {
            
            if (((Control)sender).Name.Equals("mskYear"))
            {
                Convert.ToInt32(mskYear.Text).ToString().PadLeft(4, '0');

                if (Convert.ToInt32(mskYear.Text) < 1900)
                    mskYear.Text = "1900";
                else if (Convert.ToInt32(mskYear.Text) > 2999)
                    mskYear.Text = "2999";
                return;
            }

            

            else if (((Control)sender).Name.Equals("mskMonth"))
            {
                if (Convert.ToInt32(mskMonth.Text) < 1)
                    mskMonth.Text = "01";
                else if (Convert.ToInt32(mskMonth.Text) > 12)
                    mskMonth.Text = "12";
            }

            
            else if (((Control)sender).Name.Equals("mskDay"))
            {
                lastday = DateTime.DaysInMonth(Convert.ToInt32(mskYear.Text), Convert.ToInt32(mskMonth.Text));

                if (Convert.ToInt32(mskDay.Text) < 1)
                    mskDay.Text = "01";
                else if (Convert.ToInt32(mskDay.Text) > lastday)
                    mskDay.Text = lastday.ToString();
            }

            else if (((Control)sender).Name.Equals("mskHour"))
            {
                if (Convert.ToInt32(mskHour.Text) > 23)
                    mskHour.Text = "23";
            }

            else if (((Control)sender).Name.Equals("mskMinute"))
            {
                if (Convert.ToInt32(mskMinute.Text) > 59)
                    mskMinute.Text = "59";
            }

            else if (((Control)sender).Name.Equals("mskSecond"))
            {
                if (Convert.ToInt32(mskSecond.Text) > 59)
                    mskSecond.Text = "59";
            }

            ((Control)sender).Text = ((Control)sender).Text.ToString().PadLeft(2, '0');
        }
    }
}
