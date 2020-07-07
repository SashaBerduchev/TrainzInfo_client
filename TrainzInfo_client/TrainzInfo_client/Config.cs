using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainzInfo_client
{
    class Config
    {
        private static string connstring;
        public static bool DEBUG_MODE = true;
        public static string GetString()
        {
            if (DEBUG_MODE == true)
            {
                connstring = "https://localhost:44321/";
            }
            else
            {
              connstring = "http://trainzinfo.somee.com/";
            }
            return connstring;
        }
    }
}
