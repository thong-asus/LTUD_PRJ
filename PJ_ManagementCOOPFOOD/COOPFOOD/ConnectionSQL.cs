using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOPFOOD
{
    class ConnectionSQL
    {
        public static string getConnectSQL()
        {
            //return "Data Source =.; Initial Catalog = QUANLYSTCOOPFOOD; Integrated Security = True";
            return "Data Source=THONGJ4" + KiTu() + "SQLEXPRESS;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True";

            //SqlConnection con = new SqlConnection("Data Source=THONGJ4" + KiTu() + "SQLEXPRESS;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");
        }
        public static string KiTu()
        {
            char c = (char)92;
            string s = c.ToString();
            return s;
        }
    }
}
