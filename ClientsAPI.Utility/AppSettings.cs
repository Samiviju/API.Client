using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsAPI.Utility
{
    public class AppSettings
    {
        public static string GetConnectionString()
        {
            var configuration = new Configuration();
            return configuration.AppSettings["ConnectionString"];
        }
    }
}
