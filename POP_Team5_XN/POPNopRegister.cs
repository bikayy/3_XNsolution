using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN;
using Team5_XN_VO;

namespace POP_Team5_XN
{
    public partial class POPNopRegister : Form
    {
        NopService nopServ = new NopService();
        ucNopRegist nopList = null;

        DataTable dt = null;

        private WoInfoVO woInfo = new WoInfoVO();
        public WoInfoVO WoInfo
        {
            get { return woInfo; }
            set { woInfo = value; }
        }

        private NopInfoVO nopInfo = new NopInfoVO();
        public NopInfoVO NopInfo
        {
            get { return nopInfo; }
            set { nopInfo = value; }
        }

        private NopHistoryVO nopHistory = new NopHistoryVO();
        public NopHistoryVO NopHistory
        {
            get { return nopHistory; }
            set { nopHistory = value; }
        }

        NopHistoryVO SendNopHistory;

        int lastday;
        int check = 0;

        public POPNopRegister(/*WoInfoVO woInfo*/)
        {
            InitializeComponent();

            //this.woInfo = woInfo;
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
            ucNopRegist a = new ucNopRegist();

            button_Click_NowDate(this, null);

            lblWcName.Text = woInfo.Wc_Name;
            LoadData();

        }

        private void LoadData()
        {
            pnl_Register.Visible = false;
            pnl_Register.SendToBack();


            Nop_History();
        }


        private void Nop_History()
        {
            pnl_MainHistory.Controls.Clear();

            ucNopHistory_Top nopHisTop = new ucNopHistory_Top();
            nopHisTop.Dock = DockStyle.Top;
            pnl_MainHistory.Controls.Add(nopHisTop);
            nopHisTop.BringToFront();

            dt = nopServ.GetNopHistory(WoInfo.Wc_Code);
            if (dt.Rows.Count < 1) return;

            //비가동시간 이력이 없으면? => 현재 비가동 중이다.
            if (dt.Rows[0]["Nop_Time"] == DBNull.Value || dt.Rows[0]["Nop_Time"].ToString().Length < 1)
            {
                btnStop.Enabled = false; //비가동등록 비활성화
                btnStart.Enabled = true; //비가동해제 활성화
            }
            else
            {
                btnStop.Enabled = true;   //비가동등록
                btnStart.Enabled = false; //비가동해제
            }




            //foreach (Control nh in pnl_MainHistory.Controls)
            //{
            //    if (nh.Name.Contains("uc"))
            //    {
            //        pnl_MainHistory.Controls.Remove(nh);
            //        pnl_MainHistory.Update();
            //        pnl_MainHistory.Refresh();
            //    }
            //}
            //int cnt = pnl_MainHistory.Controls.Count;

            //for (int i = 0; i < cnt; i++)
            //{
            //    if (pnl_MainHistory.Controls[i].Name.Contains("uc"))
            //    {
            //        Control con = (Control)pnl_MainHistory.Controls[i];
            //        pnl_MainHistory.Controls.Remove(con);
            //        //con.Dispose();
            //    }      
            //}
            //pnl_MainHistory.Update();
            //pnl_MainHistory.Refresh();




            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ucNopHistory nopHis = new ucNopHistory();
                //pnlTableSubject.Dock = DockStyle.Top;
                //pnlTableSubject.SendToBack();

                nopHis.Location = new Point(0, 100 + (i * 100));

                SendNopHistory = new NopHistoryVO
                {
                    Wc_Code = dt.Rows[i]["Wc_Code"].ToString(),
                    Wc_Name = dt.Rows[i]["Wc_Name"].ToString(),
                    Nop_Ma_Name = dt.Rows[i]["Nop_Ma_Name"].ToString(),
                    Nop_Mi_Name = dt.Rows[i]["Nop_Mi_Name"].ToString(),
                    Nop_DateTime_Start = Convert.ToDateTime(dt.Rows[i]["Nop_HappenTime"])
                };
                if (dt.Rows[i]["Nop_CancelTime"] != DBNull.Value)
                    SendNopHistory.Nop_DateTime_End = Convert.ToDateTime(dt.Rows[i]["Nop_CancelTime"]);
                if (dt.Rows[i]["Nop_Time"] != DBNull.Value)
                    SendNopHistory.Nop_Time = (dt.Rows[i]["Nop_Time"]).ToString();

                nopHis.SendnopList = SendNopHistory;

                nopHis.Nop_History += Nop_History_Click;
                nopHis.Dock = DockStyle.Top;
                pnl_MainHistory.Controls.Add(nopHis);
                nopHis.BringToFront();

            }

        }

        /// <summary>
        /// 비가동이력 유저컨트롤 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nop_History_Click(object sender, EventArgs e)
        {
            NopInfoVO nopHistoryCLick = new NopInfoVO();
            //nopInfo = new NopInfoVO();
            foreach (Control con in pnl_MainHistory.Controls)
            {
                con.BackColor = Color.White;
            }
            ucNopHistory ctrl = (ucNopHistory)sender;
            ctrl.BackColor = Color.Yellow;

            NopHistory = ctrl.SendnopList;


            //if (NopHistory.Nop_Time == null)
            //{
            //    btnStart.Enabled = true;
            //}
            //else
            //{
            //    btnStart.Enabled = false;
            //}

            //NopInfo.Wc_Name = dt.Rows[i]["Nop_Mi_Code"].ToString(),
            //Nop_Name = dt.Rows[i]["Nop_Mi_Name"].ToString()

            //NopInfo.Wc_Code = woInfo.Wc_Code;
            //NopInfo.Wc_Name = woInfo.Wc_Name;
        }

        // 비가동등록 버튼 클릭
        private void btnStop_Click(object sender, EventArgs e)
        {
            pnl_Register.Visible = true;
            pnl_Register.BringToFront();
            button_Click_NowDate(this, null);

            Nop_Wc_Insert();
            Nop_Ma_Insert();
            Nop_Mi_Insert_Empty();

        }

        /// <summary>
        /// 비가동등록 - 작업장 Nop_Wc 유저컨트롤 동적 생성
        /// </summary>
        private void Nop_Wc_Insert()
        {
            pnlWc.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                nopList = new ucNopRegist();
                nopList.Location = new Point(0, 0 + (i * 65));

                if (i > 0)
                {
                    nopList.SendnopList = new NopVO
                    {
                        Nop_Code = "",
                        Nop_Name = ""
                    };
                }
                else
                {
                    nopList.SendnopList = new NopVO
                    {
                        Nop_Code = woInfo.Wc_Code,
                        Nop_Name = woInfo.Wc_Name
                    };
                    nopList.BackColor = Color.Yellow;
                    NopInfo.Wc_Code = woInfo.Wc_Code;
                    NopInfo.Wc_Name = woInfo.Wc_Name;
                }
                nopList.Tag = "Wc";
                nopList.Dock = DockStyle.Top;
                pnlWc.Controls.Add(nopList);
                nopList.BringToFront();
            }
        }
        /// <summary>
        /// 비가동등록 - 비가동대분류 Nop_Ma 유저컨트롤 동적 생성
        /// </summary>
        private void Nop_Ma_Insert()
        {
            pnlNopMa.Controls.Clear();
            NopInfo.Nop_Ma_Code = NopInfo.Nop_Ma_Name = NopInfo.Nop_Mi_Code = NopInfo.Nop_Mi_Name = null;

            DataTable dt = nopServ.GetNopRegist_Ma(WoInfo.Wc_Code);

            int cnt = dt.Rows.Count;
            if (dt.Rows.Count < 5) cnt = 5;

            for (int i = 0; i < cnt; i++)
            {
                nopList = new ucNopRegist();
                nopList.Location = new Point(0, 0 + (i * 65));

                if (i >= dt.Rows.Count)
                {
                    nopList.SendnopList = new NopVO
                    {
                        Nop_Code = "",
                        Nop_Name = ""
                    };
                }
                else
                {
                    nopList.SendnopList = new NopVO
                    {
                        Nop_Code = dt.Rows[i]["Nop_Ma_Code"].ToString(),
                        Nop_Name = dt.Rows[i]["Nop_Ma_Name"].ToString()
                    };

                }
                nopList.Nop_Mi_Insert += NopList_Nop_Ma_Click;
                nopList.Tag = "Ma";
                nopList.Dock = DockStyle.Top;
                pnlNopMa.Controls.Add(nopList);
                nopList.BringToFront();
            }
        }

        /// <summary>
        /// 비가동 등록 - 비가동상세분류 Nop_Mi 유저컨트롤 공백으로 동적 생성 
        /// </summary>
        private void Nop_Mi_Insert_Empty()
        {
            pnlNopMi.Controls.Clear();

            for (int i = 0; i < 5; i++)
            {
                nopList = new ucNopRegist();
                nopList.Location = new Point(0, 0 + (i * 65));

                nopList.SendnopList = new NopVO
                {
                    Nop_Code = "",
                    Nop_Name = ""
                };

                nopList.Tag = "Mi";
                nopList.Dock = DockStyle.Top;
                pnlNopMi.Controls.Add(nopList);
                nopList.BringToFront();
            }
        }


        /// <summary>
        /// 비가동등록 - 비가동대분류 Nop_Ma 컨트롤 클릭시, 
        /// 1. 비가동대분류 Nop_Ma 컬러 추가
        /// 2. 비가동상세분류 Nop_Mi 유저컨트롤 동적 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NopList_Nop_Ma_Click(object sender, EventArgs e)
        {
            foreach (Control con in pnlNopMa.Controls)
            {
                con.BackColor = Color.White;
            }
            ucNopRegist ctrl = (ucNopRegist)sender;
            ctrl.BackColor = Color.Yellow;
            NopVO item = ctrl.SendnopList;

            Nop_Mi_Insert(item.Nop_Code);
            NopInfo.Nop_Ma_Code = ctrl.SendnopList.Nop_Code;
            NopInfo.Nop_Ma_Name = ctrl.SendnopList.Nop_Name;
        }

        /// <summary>
        /// 비가동등록 - 비가동상세분류 Nop_Mi 유저컨트롤 동적 생성
        /// </summary>
        /// <param name="wcCode"></param>
        public void Nop_Mi_Insert(string wcCode)
        {
            pnlNopMi.Controls.Clear();

            
            DataTable dt = nopServ.GetNopRegist_Mi(wcCode);

            int cnt = dt.Rows.Count;
            if (dt.Rows.Count < 5) cnt = 5;

            for (int i = 0; i < cnt; i++)
            {
                nopList = new ucNopRegist();
                nopList.Location = new Point(0, 0 + (i * 65));

                if (i >= dt.Rows.Count)
                {
                    nopList.SendnopList = new NopVO
                    {
                        Nop_Code = "",
                        Nop_Name = ""
                    };
                }
                else
                {
                    nopList.SendnopList = new NopVO
                    {
                        Nop_Code = dt.Rows[i]["Nop_Mi_Code"].ToString(),
                        Nop_Name = dt.Rows[i]["Nop_Mi_Name"].ToString()
                    };
                }
                nopList.Nop_Mi_Color += Nop_Mi_Click;
                nopList.Dock = DockStyle.Top;
                pnlNopMi.Controls.Add(nopList);
                nopList.BringToFront();
            }
        }
        /// <summary>
        /// 비가동등록 - 비가동상세분류 Nop_Mi 유저컨트롤 클릭시 컬러추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nop_Mi_Click(object sender, EventArgs e)
        {
            foreach (Control con in pnlNopMi.Controls)
            {
                con.BackColor = Color.White;
            }
            ucNopRegist ctrl = (ucNopRegist)sender;
            ctrl.BackColor = Color.Yellow;

            NopInfo.Nop_Mi_Code = ctrl.SendnopList.Nop_Code;
            NopInfo.Nop_Mi_Name = ctrl.SendnopList.Nop_Name;
        }


        //비가동 등록 - [등록]버튼 클릭(OK)
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (woInfo.Wc_Code == null || woInfo.Wc_Name == null)
            {
                MessageBox.Show("선택된 작업장이 없습니다. 다시 확인하세요.");
                return;
            }
            else if (NopInfo.Nop_Mi_Name == null)
            {
                MessageBox.Show("비가동분류를 선택하세요.");
                return;
            }

            if (check == 0) //
            {
                string nopDateTime = $"{mskYear.Text}-{mskMonth.Text}-{mskDay.Text} {mskHour.Text}:{mskMinute.Text}:{mskSecond.Text}";

                NopInfo.Nop_DateTime_Start = Convert.ToDateTime(nopDateTime);
                if (MessageBox.Show($"- 작업장 : {woInfo.Wc_Name} \n- 비가동대분류 : {NopInfo.Nop_Ma_Name} \n- 비가동상세분류 : {NopInfo.Nop_Mi_Name} \n- 등록일시:{NopInfo.Nop_DateTime_Start} \n→ 비가동을 등록하시겠습니까?", "비가동등록", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                {
                    bool result = nopServ.NopRegist_Stop(NopInfo);
                    if (result)
                    {
                        MessageBox.Show("비가동 등록이 완료되었습니다.");
                        pnl_Register.Visible = false;
                        pnl_Register.SendToBack();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("비가동 등록에 실패하였습니다.");
                    }

                }
            }
            else if (check == 1) //수정
            {
                if (MessageBox.Show($"- 작업장 : {woInfo.Wc_Name} \n- 비가동대분류 : {NopInfo.Nop_Ma_Name} \n- 비가동상세분류 : {NopInfo.Nop_Mi_Name} \n→ 비가동을 수정하시겠습니까?", "비가동수정", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    NopInfo.Nop_DateTime_Start = NopHistory.Nop_DateTime_Start;

                    bool result = nopServ.NopRegist_Update(NopInfo);
                    if (result)
                    {
                        MessageBox.Show("비가동 수정이 완료되었습니다.");
                        pnl_Register.Visible = false;
                        pnl_Register.SendToBack();
                        LoadData();
                        ChangeCheck(0);
                    }
                    else
                    {
                        MessageBox.Show("비가동 수정에 실패하였습니다.");
                    }

                }


            }


        }

        //비가동 등록 - [취소]버튼 클릭 (cancel)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnl_Register.Visible = false;
            pnl_Register.SendToBack();
            ChangeCheck(0);
        }












        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            //if (numericUpDown4.Value < 10)
            //{
            //    numericUpDown4.Value = Convert.ToDecimal("0" + numericUpDown4.Value);
            //}
        }

        /// <summary>
        /// msk-text 날짜,시간 UP/DOWN 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


            else if (((Button)sender).Name.Contains("Day"))///
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

            else if (((Button)sender).Name.Contains("Hour"))///
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

            else if (((Button)sender).Name.Contains("Minute"))///
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

        /// <summary>
        /// [현재시간입력] 버튼 이벤트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click_NowDate(object sender, EventArgs e)
        {
            mskYear.Text = DateTime.Now.Year.ToString().PadLeft(4, '0');
            mskMonth.Text = DateTime.Now.Month.ToString().PadLeft(2, '0');
            mskDay.Text = DateTime.Now.Day.ToString().PadLeft(2, '0');
            mskHour.Text = DateTime.Now.Hour.ToString().PadLeft(2, '0');
            mskMinute.Text = DateTime.Now.Minute.ToString().PadLeft(2, '0');
            mskSecond.Text = DateTime.Now.Second.ToString().PadLeft(2, '0');
        }

        /// <summary>
        /// 각 컨트롤별 범위초과 값 입력시 정정 이벤트 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        //비가동 등록 - [비가동해제] 버튼 클릭
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("비가동을 해제할 수 있는 상태가 아닙니다. 다시 확인하세요.");
                return;
            }
            //비가동해제가능
            if (dt.Rows[0]["Wc_Code"] == DBNull.Value)
            {
                MessageBox.Show("작업장이 선택되지 않았습니다. 다시 시도하세요.");
                return;
            }
            else if (dt.Rows[0]["Nop_Time"] == DBNull.Value || dt.Rows[0]["Nop_Time"].ToString().Length < 1)
            {
                if (MessageBox.Show($"비가동을 해제하시겠습니까?", "비가동해제", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    NopHistoryVO nopStart = new NopHistoryVO()
                    {
                        Nop_DateTime_Start = Convert.ToDateTime(dt.Rows[0]["Nop_HappenTime"]),
                        Wc_Code = dt.Rows[0]["Wc_Code"].ToString()
                    };

                    bool result = nopServ.NopRegist_Start(nopStart);
                    if (result)
                    {
                        MessageBox.Show("비가동을 해제하였습니다.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("비가동 해제에 실패하였습니다.");
                    }
                }

            }


        }

        //[비가동 사유변경] 버튼 클릭
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (NopHistory.Wc_Code == null)
            {
                MessageBox.Show("변경할 비가동 이력을 선택하세요.");
                return;
            }

            ChangeCheck(1);
            pnl_Register.Visible = true;
            pnl_Register.BringToFront();
            button_Click_NowDate(this, null);

            Nop_Wc_Insert();
            Nop_Ma_Insert();
            Nop_Mi_Insert_Empty();

            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (NopHistory.Wc_Code == null)
            {
                MessageBox.Show("삭제할 비가동 이력을 선택하세요.");
                return;
            }

            if (MessageBox.Show("선택한 비가동 이력을 삭제하시겠습니까?", "비가동삭제", MessageBoxButtons.YesNo)
== DialogResult.Yes)
            {

                bool result = nopServ.NopRegist_Delete(NopHistory);
                if (result)
                {
                    MessageBox.Show("비가동 삭제가 완료되었습니다.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("비가동 삭제에 실패하였습니다.");
                }

            }

            
        }

        private void ChangeCheck(int check)
        {
            this.check = check;

            if (this.check == 0)
            {
                pnlDatetime.Enabled = true;
            }
            else
            {
                pnlDatetime.Enabled = false;
            }
        }
    }
}
