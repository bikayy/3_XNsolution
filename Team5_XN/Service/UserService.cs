using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team5_XN_DAC;
using Team5_XN_VO;

namespace Team5_XN.Service
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
        public UserVO GetCustomerInfo(string id)
        {
            UserDAC db = new UserDAC();
            var result = db.GetCustomerInfo(id);
            db.Dispose();

            return result;
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
    }
}
