using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    class Test
    {
        static void Main(string[] args)
        {
            //TestFactura fac = new TestFactura();
            //fac.Timbra33Test();
            //fac.Timbra40Test();

            CompPagos comPago = new CompPagos();
            comPago.TestPagos();            
        }
    }
}
