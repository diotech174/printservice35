using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace printservice35
{
    public class Etiqueta
    {
        public void print(String Impressora, String codigo)
        {

            if (Impressora == null)
            {
                throw new ArgumentNullException("Impressora");
            }
            StringBuilder etiquetacod = new StringBuilder();
            etiquetacod.AppendLine(codigo);
            RawPrinterHelper.SendStringToPrinter(Impressora, etiquetacod.ToString());
        }
    }
}
