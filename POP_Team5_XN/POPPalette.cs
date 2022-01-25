using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN_VO;
using Team5_XN;

namespace POP_Team5_XN
{
    public partial class POPPalette : Form
    {
        private WoInfoVO woInfo_p = new WoInfoVO();
        public WoInfoVO WoInfo_p { get { return woInfo_p; } set { woInfo_p = value; } }

        ucPaletteList ctrlPalette = null;
        WcService wcServ = new WcService();

        private string gradeCode = string.Empty;
        private string detailCode = string.Empty;

        public POPPalette()
        {
            InitializeComponent();
        }

        

        private void POPPalette_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(woInfo_p.Wc_Name);
            lblWoNo.Text = woInfo_p.WorkOrderNo;
            lblItemName.Text = woInfo_p.Item_Name;
            lblWcName.Text = woInfo_p.Wc_Name;
            lblDate.Text = woInfo_p.Plan_Date;
            lblQty.Text = woInfo_p.Prd_Qty.ToString();
            lblTitle.Text = $"팔레트 생성 : {woInfo_p.Wc_Name}";

            LoadPalette();
        }


        private void LoadPalette()
        {
            DataTable dt = new DataTable();
            dt = wcServ.SelectPaletteList(lblWoNo.Text);
            int idx = 0;

            pnlList.Controls.Clear();
            lblGrade.Text = "";
            lblGradeDetail.Text = "";
            lblBoxQty.Text = "";

            ctrlPalette = new ucPaletteList();
            ctrlPalette.Location = new Point(4, 6);
            ctrlPalette.Size = new Size(713, 61);
            ctrlPalette.Tag = 0;
            pnlList.Controls.Add(ctrlPalette);

            for (int i = dt.Rows.Count; i > 0; i--)
            {
                if (idx > dt.Rows.Count) break;
                //MessageBox.Show("ss");
                ctrlPalette = new ucPaletteList();
                ctrlPalette.Location = new Point(4, 8 + (i * 63));
                ctrlPalette.Size = new Size(713, 61);
                ctrlPalette.SendPList = new PaletteListVO
                {  //Pallet_No, Grade(DetailName), g.Grade_Detail_Name, In_Qty
                    Pallet_No = dt.Rows[idx]["Pallet_No"].ToString(),
                    Grade = dt.Rows[idx]["Grade"].ToString(),
                    Grade_Detail_Name = dt.Rows[idx]["Grade_Detail_Name"].ToString(),
                    In_Qty = Convert.ToInt32(dt.Rows[idx]["In_Qty"])
                };
                ctrlPalette.Tag = idx + 1;
                //ctrlPalette.eventBtnCheck += OnBtn;
                pnlList.Controls.Add(ctrlPalette);
                idx++;
            }
            string no = (idx + 1).ToString().PadLeft(3, '0');
            lblPalette.Text = no;
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            PopupBoxingGrade frm = new PopupBoxingGrade();
            frm.Mode = 'G';
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                lblGrade.Text = frm.Name;
                gradeCode = frm.Code;
            }
        }

        private void btnGradeDetail_Click(object sender, EventArgs e)
        {
            PopupBoxingGrade frm = new PopupBoxingGrade();
            frm.Mode = 'D';
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                lblGradeDetail.Text = frm.Name;
                detailCode = frm.Code;
            }
        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
        {
            PopupKeyboard frm = new PopupKeyboard();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                lblBoxQty.Text = frm.SendQty.ToString();
            }
        }

        private void btnPalette_Click(object sender, EventArgs e)
        {
            Label[] labels = { lblPalette, lblGrade, lblGradeDetail, lblBoxQty };
            Label[] labelsTitle = { lblTPalette, lblTGrade, lblTGradeDetail, lblTBoxQty };
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < labels.Length; i++)
            {
                bool isChecked = string.IsNullOrWhiteSpace(labels[i].Text.Trim());
                if (isChecked)
                {
                    MessageBox.Show($"{labelsTitle[i].Text}을(를) 입력하여주십시오.");
                    return;
                }
                else
                {
                    sb.AppendLine($"{labelsTitle[i].Text} : {labels[i].Text}");
                }
            }
            sb.AppendLine("위의 정보로 팔레트를 등록하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "팔레트등록", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            { //WorkOrderNo, Start_Hour, Prd_Qty, Pallet_No, Unit, Grade_Code
              //Grade_Detail_Code, Grade_Detail_Name, Ins_Emp

                CreatePaletteVO createPalette = new CreatePaletteVO
                {
                    WorkOrderNo = lblWoNo.Text,
                    Start_Hour = Convert.ToInt32(DateTime.Now.ToString("HH")),
                    Prd_Qty = Convert.ToInt32(lblBoxQty.Text),
                    Pallet_No = lblPalette.Text,
                    Unit = lblUnit.Text,
                    Grade_Code = gradeCode,
                    Grade_Detail_Code = detailCode,
                    Grade_Detail_Name = lblGradeDetail.Text,
                    Ins_Emp = "홍길동"
                };

                bool crResult = wcServ.CreatePalette(createPalette);

                if (crResult)
                {
                    MessageBox.Show("팔레트가 등록되었습니다.");
                    lblQty.Text = (Convert.ToInt32(lblQty.Text) + Convert.ToInt32(lblBoxQty.Text)).ToString();
                    LoadPalette();
                }
                else MessageBox.Show("작업지시 생성에 실패하였습니다.\n다시 확인하여주십시오.");
            }
        }
    }
}
