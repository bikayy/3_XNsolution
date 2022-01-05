using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    public class CommonUtil
    {


        public static void ComboBinding(ComboBox cbo, string code, DataTable dt, bool blankItem = true, string blankText = "전체")
        {
            if (blankItem)
            {
                DataRow dr = dt.NewRow();
                dr["Code"] = code;
                dr["DetailCode"] = "";
                dr["Name"] = "";
                dr["DetailName"] = blankText;
                dt.Rows.InsertAt(dr, 0);
                //dt.AcceptChanges();
            }

            DataView dv = new DataView(dt);
            dv.RowFilter = "Code = '" + code + "'";
            cbo.DisplayMember = "DetailName";
            cbo.ValueMember = "Name";
            cbo.Text = "DetailCode";
            cbo.DataSource = dv;

        }

        public static void ComboBinding_DetailCode(ComboBox cbo, string code, DataTable dt, bool blankItem = true, string blankText = "전체")
        {

            if (blankItem)
            {
                DataRow dr = dt.NewRow();
                dr["Code"] = code;
                dr["DetailCode"] = blankText;
                dr["Name"] = "";
                dr["DetailName"] = "";
                dt.Rows.InsertAt(dr, 0);
                //dt.AcceptChanges();
            }

            DataView dv = new DataView(dt);
            dv.RowFilter = "Code = '" + code + "'";
            cbo.DisplayMember = "DetailCode";
            cbo.ValueMember = "Name";
            cbo.Text = "DetailName";
            cbo.DataSource = dv;

        }
    }


}
