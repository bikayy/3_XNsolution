using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_VO;
using Team5_XN_DAC;

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
            string sql = @"insert into User_Master(User_ID, User_Name, User_PW, Customer_Code, DefaultLanguage, 
                                              User_Type, Price_Visible_YN, IP_Security_YN, PW_Reset_Count, Default_Screen_Code, 
                                              Default_Major_Process_Code, Monitoring_YN, Use_YN)
                    values(@User_ID, @User_Name, @User_PW, NULL, NULL, @User_Type, @Price_Visible_YN, @IP_Security_YN, 0, NULL, NULL, NULL, @Use_YN)";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@User_ID", user.User_ID);
                cmd.Parameters.AddWithValue("@User_Name", user.User_Name);
                cmd.Parameters.AddWithValue("@User_PW", user.User_PW);
                cmd.Parameters.AddWithValue("@User_Type", '1');
                cmd.Parameters.AddWithValue("@Price_Visible_YN", 'Y');
                cmd.Parameters.AddWithValue("@IP_Security_YN", 'Y');
                cmd.Parameters.AddWithValue("@Use_YN", 'Y');
                return 0 < cmd.ExecuteNonQuery();
            }
        }
        public bool UpdateID(UserVO user) // 업데이트
        {
            string sql = @"Update User_Master SET User_PW=@User_PW , Up_Date = GETDATE()
                            WHERE User_ID=@User_ID";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@User_PW", user.User_PW);
                return 0 < cmd.ExecuteNonQuery();
            }
        }
        public UserVO GetCustomerInfo(string id)
        {
            string sql = @"SELECT User_ID, User_PW, User_Name
                            FROM User_Master WHERE User_ID = @User_ID";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@User_ID", id);

                var temp = Helper.DataReaderMapToList<UserVO>(cmd.ExecuteReader());
                return temp[0];
            }


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
        public void Dispose()
        {
            conn.Close();
        }
    }
}
