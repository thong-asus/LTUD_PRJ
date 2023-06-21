using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COOPFOOD
{
    class Check
    {
         //kiểm tra chuỗi, nếu tồn tại kí tự != digit trả về false
        public static bool CheckDigit(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
