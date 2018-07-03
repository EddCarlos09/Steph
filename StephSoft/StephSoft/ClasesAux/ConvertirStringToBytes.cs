using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StephSoft.ClasesAux
{
    public class ConvertirStringToBytes
    {
        public static byte[] StringToBytes(string cadena)
        {
            return Convert.FromBase64String(cadena);
        }

        public static String getString(byte[] text)
        {
            return Convert.ToBase64String(text);
        }
    }
}
