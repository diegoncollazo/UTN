using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * int.Parse(string):int
 * int.Parse(string, out int):bool
 * */

namespace Clase_14
{
    public static class ParseadorDeEnteros
    {
        //Si la case es static todos los metodos debes ser static

        public static bool TryParce(string s, out int i)
        {
            bool parseo = false;
            i = 0;

            try
            {
                i = Int32.Parse(s);
                parseo = true;
            }

            catch (Exception)
            {
               parseo = false;
            }

            return parseo;
        }


        //PARSE
        public static int Parse(string s)
        {

            try
            {
                return Int32.Parse(s);
            }

            catch(OverflowException e)
            {
                throw new ErrorParserException("... por tamaño del dato", e);
            }

            catch(FormatException e)
            {
                throw new ErrorParserException("... por error de formato", e);
            }
        }
    }
}
