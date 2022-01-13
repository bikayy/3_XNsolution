using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_VO;
using Team5_XN_DAC;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Team5_XN_DAC
{
    public class UserDAC
    {
        SqlConnection conn;
        public UserDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            conn.Open();
        }
        public bool IDCheck(string id) // 아이디가 있으면 True 아이디가 없으면 False
        {
            string sql = "SELECT Count(*) FROM User_Master WHERE User_ID=@User_ID;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@User_ID", id);
            int result = Convert.ToInt32(cmd.ExecuteScalar());

            return (result > 0);
        }
        public bool AddID(UserVO user) // 계정추가
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Register_Grouping";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@User_ID", user.User_ID);
            cmd.Parameters.AddWithValue("@User_Name", user.User_Name);
            cmd.Parameters.AddWithValue("@User_PW", user.User_PW);
            cmd.Parameters.AddWithValue("@User_Type", '1');
            cmd.Parameters.AddWithValue("@Price_Visible_YN", 'Y');
            cmd.Parameters.AddWithValue("@IP_Security_YN", 'Y');
            cmd.Parameters.AddWithValue("@Use_YN", 'Y');
            return 0 < cmd.ExecuteNonQuery();
        }
        public bool UpdateID(UserVO user) // 업데이트
        {
            string sql = @"Update User_Master SET User_PW=@User_PW , Up_Date = GETDATE()
                            WHERE User_ID=@User_ID";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@User_ID", user.User_ID);
                cmd.Parameters.AddWithValue("@User_PW", user.User_PW);
                return 0 < cmd.ExecuteNonQuery();
            }
        }
        public DataTable GetUserInfo()
        {
            string sql = @"SELECT 
	User_ID, User_Name, M.UserGroup_Code, M.UserGroup_Name, 
	U.Default_Major_Process_Code, P.Process_Name, PW_Reset_Count
	, (select DetailName from CommonCodeSystem where Code ='IP_Security_YN' and DetailCode=U.IP_Security_YN) IP_Security_YN
	, (select DetailName from CommonCodeSystem where Code='USE_YN' and DetailCode = U.Use_YN) Use_YN
	, U.Ins_Date, U.Ins_Emp, U.Up_Date, U.Up_Emp
FROM 
	User_Master U
	INNER JOIN UserGroup_Master M ON U.Customer_Code = M.UserGroup_Code
	LEFT OUTER JOIN Process_Master P ON U.Default_Major_Process_Code = P.Process_Code";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
        public List<string> GetUserName(string uname)
        {
            string sql = @"SELECT U.User_ID
FROM User_Master U JOIN UserGroup_Mapping M ON U.User_ID = M.User_ID
WHERE U.User_Name LIKE @UserName";

            uname = $"%{uname}%";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@UserName", uname);
            List<string> list = new List<string>();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }

            return list;


        }
        public DataTable GetUserGroupMaster()
        {
            string sql = @"  SELECT 
UserGroup_Code, UserGroup_Name, 
(select DetailName from CommonCodeSystem where Code ='Admin_YN' and DetailCode= Admin) Admin, 
(select DetailName from CommonCodeSystem where Code='USE_YN' and DetailCode = Use_YN) Use_YN,
Ins_Date, Ins_Emp, Up_Date, Up_Emp
FROM 
UserGroup_Master";
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;
        }
        public bool LoginCheck(UserVO user, bool IsUser) // 로그인
        {
            string sql = @"SELECT count(*) FROM User_Master WHERE User_ID=@User_ID AND User_PW=@User_PW AND Use_YN=@Use_YN";

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;

                cmd.Parameters.AddWithValue("@User_ID", user.User_ID);
                cmd.Parameters.AddWithValue("@User_PW", user.User_PW);
                cmd.Parameters.AddWithValue("@Use_YN", IsUser == true ? 'Y' : 'N');

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        public string GetMemberName(string id)
        {
            string sql = @"SELECT User_Name FROM User_Master WHERE User_ID = @User_ID";

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@User_ID", id);

                return cmd.ExecuteScalar().ToString();
            }

        }
        public int SaveUser(DataTable dt, int check)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UserInfo_Save", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserInfo_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "dbo.User_Master_Type",
                    Value = dt
                });
                cmd.Parameters.AddWithValue("@Check", check);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return -1;
            }
        }
        public bool DeleteUser(string user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_User_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_ID", user);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }
        }
        public int SaveUserGroup(DataTable dt, int check)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UserGroup_Save", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@UserGroup_Data", System.Data.SqlDbType.Structured)
                {
                    TypeName = "dbo.UserGroup_Master_Type",
                    Value = dt
                });
                cmd.Parameters.AddWithValue("@Check", check);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return -1;
            }
        }
        public bool DeleteUserGroup(string user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UserGroup_Delete", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserGroup_Code", user);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                MessageBox.Show(err.Message);
                return false;
            }
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}
