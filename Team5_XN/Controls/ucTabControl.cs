﻿using System;
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
    public partial class ucTabControl : TabControl
    {
        //닫기 이미지를 그리기 위한 사용자지정컨트롤
        //DrawMode 속성을 변경하고,
        //DrawItem 이벤트를 구현해야 합니다.
        public ucTabControl()
        {
            InitializeComponent();

            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);

            try
            {
                Rectangle r = e.Bounds;
                r = this.GetTabRect(e.Index);
                r.Offset(2, 2);

                
                //else
                //{
                //    e.Graphics.FillRectangle(new SolidBrush(Color.FromName("ControlLight")), e.Bounds);
                //}
                //탭의 글씨
                SolidBrush titleBrush = new SolidBrush(Color.DimGray);
                string title = this.TabPages[e.Index].Text;
                Font f = new Font("맑은 고딕", 10, FontStyle.Bold);
                
                //선택된 탭의 백그라운드색상은 d(나머지 탭은 기본값)
                if (this.SelectedIndex == e.Index)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(230, 240, 240)), e.Bounds);
                    titleBrush = new SolidBrush(Color.Black);
                    f = new Font("맑은 고딕", 10, FontStyle.Bold);
                }
                e.Graphics.DrawString(title, f, titleBrush, new Point(r.X, r.Y));
                //탭의 닫기 이미지
                //선택된 탭은 빨간색이미지, 선택이 안된 탭은 검정색이미지
                Image img;
                if (this.SelectedIndex == e.Index)
                    img = Properties.Resources.icon_close_red;
                else
                    img = Properties.Resources.icon_close_black;

                Point imgLocation = new Point(18, 2);

                e.Graphics.DrawImage( img, r.X + this.GetTabRect(e.Index).Width - imgLocation.X, imgLocation.Y+6, 10, 10);

                img.Dispose();
                img = null;
            }
            catch
            {

            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
