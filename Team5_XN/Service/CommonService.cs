﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_XN
{
    class CommonService
    {
        public DataTable GetCommonCodeSys(string[] codes)
        {
            CommonDAC db = new CommonDAC();
            DataTable result = db.GetCommonCodeSys(codes);
            db.Dispose();

            return result;
        }

        public DataTable GetCommonCodeUser(string[] codes)
        {
            CommonDAC db = new CommonDAC();
            DataTable result = db.GetCommonCodeUser(codes);
            db.Dispose();

            return result;
        }
        public DataTable GetSystemCodeMaster()
        {
            CommonDAC db = new CommonDAC();
            DataTable result = db.GetSystemCodeMaster();
            db.Dispose();

            return result;
        }


        public DataTable GetSystemCodeDetail(string name)
        {
            CommonDAC db = new CommonDAC();
            DataTable result = db.GetSystemCodeDetail(name);
            db.Dispose();

            return result;
        }


    }
}
