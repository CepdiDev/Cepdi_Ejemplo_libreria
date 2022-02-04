using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimbradoCepdi.V33;
using TimbradoCepdi.WS;

namespace Test
{
    public class TestFactura
    {
        public string Timbra33Test()
        {
            var comprobante = new Comprobante();
            comprobante.Emisor = new ComprobanteEmisor()
            {
                Nombre = "Demo S.A. DE C.V.",
                Rfc = "XIA190128J61",
                RegimenFiscal = "601"

            };
            comprobante.Receptor = new ComprobanteReceptor()
            {
                Nombre = "CLIENTE DEL EXTERIOR MQ",
                Rfc = "XEXX010101000",
                UsoCFDI = "G01",
            };
            comprobante.Moneda = "USD";
            comprobante.MetodoPago = "PUE";
            comprobante.MetodoPagoSpecified = true; // Para que pinte el dato
            comprobante.CondicionesDePago = "CONTADO : Efectivo";
            comprobante.Fecha = DateTime.Now.ToString("s");
            comprobante.Total = 803.88M;
            comprobante.SubTotal = 693.00M;
            comprobante.TipoDeComprobante = "I";
            comprobante.Folio = "21230";
            comprobante.Serie = "A";
            comprobante.FormaPago = "01";
            comprobante.FormaPagoSpecified = true;
            comprobante.LugarExpedicion = "54050";
            comprobante.TipoCambio = 19.90M;
            comprobante.TipoCambioSpecified = true;
            comprobante.NoCertificado = "30001000000300023708";
            var concepto = new ComprobanteConcepto()
            {
                Cantidad = 7.00M,
                ClaveProdServ = "60122202",
                ClaveUnidad = "H87",
                Descripcion = "Semilla de Girasol",
                Importe = 693.00M,
                NoIdentificacion = "AC008",
                Unidad = "PIEZA",
                ValorUnitario = 99.00M,
                Impuestos = new ComprobanteConceptoImpuestos
                {
                    Traslados = new ComprobanteConceptoImpuestosTraslado[]
                    {
                        new ComprobanteConceptoImpuestosTraslado {
                            Base = 693.00M,
                           Importe =110.88M,
                           ImporteSpecified = true,
                           Impuesto = "002",
                           TasaOCuota = 0.160000M,TasaOCuotaSpecified= true,
                           TipoFactor = "Tasa"
                    } }

                }
            };
            var conceptos = new List<ComprobanteConcepto>();
            conceptos.Add(concepto);
            comprobante.Conceptos = conceptos.ToArray();
            comprobante.Impuestos = new ComprobanteImpuestos
            {
                TotalImpuestosTrasladados = "110.88"
                    ,
                TotalImpuestosTrasladadosSpecified = true
                    ,
                Traslados = new ComprobanteImpuestosTraslado[]
                    {
                        new ComprobanteImpuestosTraslado
                        {
                            Impuesto = "002", Importe = "110.88", TipoFactor = "Tasa", TasaOCuota = "0.160000"
                        }
                    }
            };
            var datos_Extra = new TimbradoCepdi.WS.datosExtra();
            datos_Extra.Email = "";
            //************Termina Datos Adicionales********************//

            TimbradoCepdi.V33.XmlUtils timbra = new TimbradoCepdi.V33.XmlUtils();

            var res = timbra.Timbrar(comprobante, "demotim@mail.com", "9feijB30Hy", datos_Extra, "D");

            if (!res.Exitoso)
            {
                Console.WriteLine(res.MensajeError + "\n" + res.CodigoError);
            }
            else
            {
                Console.WriteLine(res.XMLTimbrado);
            }

            Console.ReadKey();
            return "";

        }

        public string Timbra40Test()
        {
            var comprobante = new TimbradoCepdi.Comprobante40.Comprobante();
            comprobante.Emisor = new TimbradoCepdi.Comprobante40.ComprobanteEmisor()
            {
                Nombre = "Demo S.A. DE C.V.",
                Rfc = "XIA190128J61",
                RegimenFiscal = "601"

            };
            comprobante.Receptor = new TimbradoCepdi.Comprobante40.ComprobanteReceptor()
            {
                Nombre = "CLIENTE DEL EXTERIOR MQ",
                Rfc = "XEXX010101000",
                UsoCFDI = "G01",
            };
            comprobante.Moneda = "USD";
            comprobante.MetodoPago = "PUE";
            comprobante.MetodoPagoSpecified = true; // Para que pinte el dato
            comprobante.CondicionesDePago = "CONTADO : Efectivo";
            comprobante.Fecha = DateTime.Now.ToString("s");
            comprobante.Total = 803.88M;
            comprobante.SubTotal = 693.00M;
            comprobante.TipoDeComprobante = "I";
            comprobante.Folio = "21230";
            comprobante.Serie = "A";
            comprobante.FormaPago = "01";
            comprobante.FormaPagoSpecified = true;
            comprobante.LugarExpedicion = "54050";
            comprobante.TipoCambio = 19.90M;
            comprobante.TipoCambioSpecified = true;
            comprobante.NoCertificado = "30001000000300023708";
            var concepto = new TimbradoCepdi.Comprobante40.ComprobanteConcepto()
            {
                Cantidad = 7.00M,
                ClaveProdServ = "60122202",
                ClaveUnidad = "H87",
                Descripcion = "Semilla de Girasol",
                Importe = 693.00M,
                NoIdentificacion = "AC008",
                Unidad = "PIEZA",
                ValorUnitario = 99.00M,
                Impuestos = new TimbradoCepdi.Comprobante40.ComprobanteConceptoImpuestos
                {
                    Traslados = new TimbradoCepdi.Comprobante40.ComprobanteConceptoImpuestosTraslado[]
                    {
                        new TimbradoCepdi.Comprobante40.ComprobanteConceptoImpuestosTraslado {
                            Base = 693.00M,
                           Importe =110.88M,
                           ImporteSpecified = true,
                           Impuesto = "002",
                           TasaOCuota = 0.160000M,TasaOCuotaSpecified= true,
                           TipoFactor = "Tasa"
                    } }

                }
            };
            var conceptos = new List<TimbradoCepdi.Comprobante40.ComprobanteConcepto>();
            conceptos.Add(concepto);
            comprobante.Conceptos = conceptos.ToArray();
            comprobante.Impuestos = new TimbradoCepdi.Comprobante40.ComprobanteImpuestos
            {
                TotalImpuestosTrasladados = 110.88M
                    ,
                TotalImpuestosTrasladadosSpecified = true
                    ,
                Traslados = new TimbradoCepdi.Comprobante40.ComprobanteImpuestosTraslado[]
                    {
                        new TimbradoCepdi.Comprobante40.ComprobanteImpuestosTraslado
                        {
                            Impuesto = "002", Importe = 110.88M, TipoFactor = "Tasa", TasaOCuota = 0.160000M
                        }
                    }
            };
            var datos_Extra = new TimbradoCepdi.WS.datosExtra();
            datos_Extra.Email = "";
            //************Termina Datos Adicionales********************//

            TimbradoCepdi.V33.XmlUtils timbra = new TimbradoCepdi.V33.XmlUtils();

            var res = timbra.Timbrar40(comprobante, "demotim@mail.com", "9feijB30Hy", datos_Extra, "D");

            if (!res.Exitoso)
            {
                Console.WriteLine(res.MensajeError + "\n" + res.CodigoError);
            }
            else
            {
                Console.WriteLine(res.XMLTimbrado);
            }

            Console.ReadKey();
            return "";

        }

        public string CancelaCFDITest()
        {
            XmlUtils cancel = new XmlUtils();

            respuestaCancelacion respuesta = cancel.CancelaCFDI("Usuario", "Pass", "Emisor", "Receptor", "Total", "UUID", 0, "UUIDRelacionado", "D");
            if (respuesta.CancelacionExitosa)
                return respuesta.AcuseCancelacion;
            else
                return null;

        }

        public byte[] ObtenerPDFTest()
        {
            XmlUtils pdf = new XmlUtils();

            respuestaPDF respuesta = pdf.ObtenerPDF("Usuario", "Pass", "UUID", "D");
            if (respuesta.Exitoso)
                return respuesta.PDF;
            else
                return null;

        }

    }
}
