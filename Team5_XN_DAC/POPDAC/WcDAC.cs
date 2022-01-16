using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Team5_XN_VO;
using System.Diagnostics;

namespace Team5_XN_DAC
{
    public class WcDAC : IDisposable
    {
        SqlConnection conn;

        public WcDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }

        public void Dispose()
        {
            conn.Close();
        }

        public DataTable SelectWc()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SP_Select_WorkCenter", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);

            return dt;
        }

        public DataTable SelectOr(string wcCode)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SP_Select_POP_OrderList", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Wc_Code", wcCode);
            da.Fill(dt);

            return dt;
        }

        public bool Start(string woNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Siyu_Start";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", woNo);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool End(string woNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Siyu_End";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", woNo);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool CreatePalette(CreatePaletteVO createPalette)
        {  //WorkOrderNo, Start_Hour, Prd_Qty, Pallet_No, Unit, Grade_Code
            //Grade_Detail_Code, Grade_Detail_Name, Ins_Emp
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Palette_Create";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", createPalette.WorkOrderNo);
            cmd.Parameters.AddWithValue("@Start_Hour", createPalette.Start_Hour);
            cmd.Parameters.AddWithValue("@Prd_Qty", createPalette.Prd_Qty);
            cmd.Parameters.AddWithValue("@Pallet_No", createPalette.Pallet_No);
            cmd.Parameters.AddWithValue("@Unit", createPalette.Unit);
            cmd.Parameters.AddWithValue("@Grade_Code", createPalette.Grade_Code);
            cmd.Parameters.AddWithValue("@Grade_Detail_Code", createPalette.Grade_Detail_Code);
            cmd.Parameters.AddWithValue("@Grade_Detail_Name", createPalette.Grade_Detail_Name);
            cmd.Parameters.AddWithValue("@Ins_Emp", createPalette.Ins_Emp);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool RegPerSiyu(RegSiyuVO regPerSiyu)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Per_Siyu_Create";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", regPerSiyu.WorkOrderNo);
            cmd.Parameters.AddWithValue("@Start_Hour", regPerSiyu.Start_Hour);
            cmd.Parameters.AddWithValue("@Prd_Qty", regPerSiyu.Prd_Qty);
            cmd.Parameters.AddWithValue("@Unit", regPerSiyu.Unit);
            cmd.Parameters.AddWithValue("@Ins_Emp", regPerSiyu.Ins_Emp);
            cmd.Parameters.AddWithValue("@Wc_Code", regPerSiyu.Wc_Code);

            return cmd.ExecuteNonQuery() > 0;
        }

        public DataTable SelectPaleeteList(string pNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SP_Palette_List_Select", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@WorkOrderNo", pNo);
            da.Fill(dt);

            return dt;
        }

        public DataTable SelectGrade()
        {
            string sql = @"select DetailCode, DetailName
from CommonCodeSystem
where Code = 'BOX_GRADE'";
            
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                da.Fill(dt);

                return dt;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public DataTable SelectGradeDetail(string code)
        {
            string sql = @"select Grade_Detail_Code DetailCode, 
Grade_Detail_Name DetailName
from BoxingGrade_Detail_Master
where Boxing_Grade_Code = @Boxing_Grade_Code";

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@Boxing_Grade_Code", code);

                da.Fill(dt);

                return dt;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public DataTable SelectPerSiyu(string woNo, string wcCode)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SP_Per_Of_Siyu_Select", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@WorkOrderNo", woNo);
            da.SelectCommand.Parameters.AddWithValue("@Wc_Code", wcCode);
            da.Fill(dt);

            return dt;
        }

        public bool DeletePerSiyu(DeletePerSiyuVO deletePerSiyu)
        {  //WorkOrderNo, Prd_Qty, Reg_DateTime, Del_Emp
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Per_Siyu_Delete";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@WorkOrderNo", deletePerSiyu.WorkOrderNo);
            cmd.Parameters.AddWithValue("@Prd_Qty", deletePerSiyu.Prd_Qty);
            cmd.Parameters.AddWithValue("@Reg_DateTime", deletePerSiyu.Reg_DateTime);
            cmd.Parameters.AddWithValue("@Del_Emp", deletePerSiyu.Del_Emp);

            return cmd.ExecuteNonQuery() > 0;
        }

    }
}
