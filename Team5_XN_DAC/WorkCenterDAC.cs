using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Team5_XN_DAC
{
    public class WorkCenterDAC : IDisposable
    {
        SqlConnection conn;
        public WorkCenterDAC()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
