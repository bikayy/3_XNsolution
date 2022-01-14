using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_DAC;
using Team5_XN_VO;

namespace Team5_XN
{
    class UserService
    {
        public bool IDCheck(string id) // 아이디가 있으면 True 아이디가 없으면 False
        {
            UserDAC db = new UserDAC();
            bool result = db.IDCheck(id);
            db.Dispose();

            return result;
        }

        public bool AddID(UserVO user)
        {
            UserDAC db = new UserDAC();
            bool result = db.AddID(user);
            db.Dispose();

            return result;
        }

        public bool UpdateID(UserVO user)
        {
            UserDAC db = new UserDAC();
            bool result = db.UpdateID(user);
            db.Dispose();

            return result;
        }
        public DataTable GetUserInfo()
        {
            UserDAC db = new UserDAC();
            DataTable dt = db.GetUserInfo();
            db.Dispose();

            return dt;
        }
        public List<string> GetUserName(string uname)
        {
            UserDAC db = new UserDAC();
            var result = db.GetUserName(uname);
            db.Dispose();

            return result;
        }
        public DataTable GetUserGroupMaster()
        {
            UserDAC db = new UserDAC();
            DataTable dt = db.GetUserGroupMaster();
            db.Dispose();

            return dt;
        }
        
        public bool LoginCheck(UserVO user, bool IsUser)
        {
            UserDAC db = new UserDAC();
            var result = db.LoginCheck(user, IsUser);
            db.Dispose();

            return result;
        }
        public string GetMemberName(string id)
        {
            UserDAC db = new UserDAC();
            var result = db.GetMemberName(id);
            db.Dispose();

            return result;
        }
        public int SaveUser(DataTable dt, int check)
        {
            UserDAC db = new UserDAC();
            int result = db.SaveUser(dt, check);
            db.Dispose();

            return result;
        }
        public bool DeleteUser(String user)
        {
            UserDAC db = new UserDAC();
            bool result = db.DeleteUser(user);
            db.Dispose();

            return result;
        }
        public int SaveUserGroup(DataTable dt, int check)
        {
            UserDAC db = new UserDAC();
            int result = db.SaveUserGroup(dt, check);
            db.Dispose();

            return result;
        }
        public bool DeleteUserGroup(String user)
        {
            UserDAC db = new UserDAC();
            bool result = db.DeleteUserGroup(user);
            db.Dispose();

            return result;
        }
        
    }
}
