using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TimbradoCepdi;
using TimbradoCepdi.V33;

namespace Test
{
    class CompPagos
    {
        public void TestPagos()
        {
            /*************************************************************************************************************************************************/
            /*************************************************************************************************************************************************/
            /******************************************************Inicia llenado de datos del complemento Pagos**********************************************/
            /*************************************************************************************************************************************************/
            /*************************************************************************************************************************************************/
            var complementoPago = new Pagos()
            {
                Version="1.0",//objeto ComplementoConcepto el cual se captira la totalidad Descuento los impuestos totales de un producto o servicio.
            };
            var listaDePagos = new List<PagosPago>();
            var pago = new PagosPago()
            {
                FechaPago = Convert.ToDateTime("2018/02/15"),//Atributo requerido para expresar la fecha y hora en la que el beneficiario recibe el pago. Se expresa en la forma aaaa-mm-ddThh:mm:ss, de acuerdo con la especificación ISO 8601.En caso de no contar con la hora se debe registrar 12:00:00.
                FormaDePagoP = "01",//Atributo requerido para expresar la clave de la forma en que se realiza el pago.
                MonedaP = "MXN",//Atributo requerido para identificar la clave de la moneda utilizada para realizar el pago, cuando se usa moneda nacional se registra MXN. El atributo Pagos:Pago:Monto y los atributos TotalImpuestosRetenidos, TotalImpuestosTrasladados, Traslados:Traslado:Importe y Retenciones:Retencion:Importe del nodo Pago:Impuestos deben ser expresados en esta moneda. Conforme con la especificación ISO 4217.
                TipoCambioP = 0.01m,//Atributo condicional para expresar el tipo de cambio de la moneda a la fecha en que se realizó el pago. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo MonedaP. Es requerido cuando el atributo MonedaP es diferente a MXN.
                Monto = 105.25m,//Atributo requerido para expresar el importe del pago.
                NumOperacion = "1025",//Atributo condicional para expresar el número de cheque, número de autorización, número de referencia, clave de rastreo en caso de ser SPEI, línea de captura o algún número de referencia análogo que identifique la operación que ampara el pago efectuado
                //No debe existir con Complemento Pago
                //RfcEmisorCtaOrd = "XEXX870502544",//Atributo condicional para expresar la clave RFC de la entidad emisora de la cuenta origen, es decir, la operadora, el banco, la institución financiera, emisor de monedero electrónico, etc., en caso de ser extranjero colocar XEXX010101000, considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.
                NomBancoOrdExt = "Mi banco personal",//Atributo condicional para expresar el nombre del banco ordenante, es requerido en caso de ser extranjero. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.
                //CtaOrdenante = "0000000000000",//Atributo condicional para incorporar el número de la cuenta con la que se realizó el pago. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago
                //No debe existir con complemento pago
                //RfcEmisorCtaBen = "mibanco551097jh",//Atributo condicional para expresar la clave RFC de la entidad operadora de la cuenta destino, es decir, la operadora, el banco, la institución financiera, emisor de monedero electrónico, etc. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.
                //No debe existir con complemento pago
                //CtaBeneficiario = "MIDL870502HS5",//Atributo condicional para incorporar el número de cuenta en donde se recibió el pago. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.
                TipoCadPago = "01",//Atributo condicional para identificar la clave del tipo de cadena de pago que genera la entidad receptora del pago. Considerar las reglas de obligatoriedad publicadas en la página del SAT para éste atributo de acuerdo con el catálogo catCFDI:c_FormaPago.
                //CertPago = "Certificado de Pago",//Atributo condicional que sirve para incorporar el certificado que ampara al pago, como una cadena de texto en formato base 64. Es requerido en caso de que el atributo TipoCadPago contenga información.
                //No debe existir con complemento pago
                //CadPago = "Cadena original del certificado de pago",//Atributo condicional para expresar la cadena original del comprobante de pago generado por la entidad emisora de la cuenta beneficiaria. Es requerido en caso de que el atributo TipoCadPago contenga información.
                //SelloPago = "cadena de sello",//Atributo condicional para integrar el sello digital que se asocie al pago. La entidad que emite el comprobante de pago, ingresa una cadena original y el sello digital en una sección de dicho comprobante, este sello digital es el que se debe registrar en este campo. Debe ser expresado como una cadena de texto en formato base 64. Es requerido en caso de que el atributo TipoCadPago contenga información.
            };            

            var listaDoctoRelacionado  = new List<PagosPagoDoctoRelacionado>();
            var docto = new PagosPagoDoctoRelacionado()
            {
                IdDocumento = "F980EF7C-26C1-4594-B8AE-BA5C24129EB0",//Atributo requerido para expresar el identificador del documento relacionado con el pago. Este dato puede ser un Folio Fiscal de la Factura Electrónica o bien el número de operación de un documento digital.
                Serie = "6546",//Atributo opcional para precisar la serie del comprobante para control interno del contribuyente, acepta una cadena de caracteres.
                Folio = "6646",//Atributo opcional para precisar el folio del comprobante para control interno del contribuyente, acepta una cadena de caracteres.
                MonedaDR = "MXN",//Atributo requerido para identificar la clave de la moneda utilizada en los importes del documento relacionado, cuando se usa moneda nacional o el documento relacionado no especifica la moneda se registra MXN. Los importes registrados en los atributos “ImpSaldoAnt”, “ImpPagado” e “ImpSaldoInsoluto” de éste nodo, deben corresponder a esta moneda. Conforme con la especificación ISO 4217.
                TipoCambioDR=0.015m,//Atributo condicional para expresar el tipo de cambio conforme con la moneda registrada en el documento relacionado. Es requerido cuando la moneda del documento relacionado es distinta de la moneda de pago. Se debe registrar el número de unidades de la moneda señalada en el documento relacionado que equivalen a una unidad de la moneda del pago. Por ejemplo: El documento relacionado se registra en USD El pago se realiza por 100 EUR. Este atributo se registra como 1.114700 USD/EUR. El importe pagado equivale a 100 EUR * 1.114700 USD/EUR = 111.47 USD.
                MetodoDePagoDR = "PUE",//Atributo requerido para expresar la clave del método de pago que se registró en el documento relacionado.
                NumParcialidad = "2",//Atributo condicional para expresar el número de parcialidad que corresponde al pago. Es requerido cuando MetodoDePagoDR contiene: “PPD” Pago en parcialidades o diferido.
                ImpSaldoAnt = 0,//Atributo condicional para expresar el monto del saldo insoluto de la parcialidad anterior. Es requerido cuando MetodoDePagoDR contiene: “PPD” Pago en parcialidades o diferido.En el caso de que sea la primer parcialidad este campo debe contener el importe total del documento relacionado.
                ImpPagado = 0,//Atributo condicional para expresar el importe pagado para el documento relacionado. Es obligatorio cuando exista más de un documento relacionado o cuando existe un documento relacionado y el TipoCambioDR tiene un valor.
                ImpSaldoInsoluto = 234234,//Atributo condicional para expresar la diferencia entre el importe del saldo anterior y el monto del pago. Es requerido cuando MetodoDePagoDR contiene: “PPD” Pago en parcialidades o diferido.
            };
            listaDoctoRelacionado.Add(docto);
            /*********************Los impuestos no se colocan Con el complemento pagos*****************/

            //var listaImpuestoPago=new List<PagosPagoImpuestos>();
            //var impuestoDePago = new PagosPagoImpuestos()
            //{
            //    TotalImpuestosRetenidos = 0,//Atributo condicional para expresar el total de los impuestos retenidos que se desprenden del pago. No se permiten valores negativos.
            //    TotalImpuestosTrasladados = 0,//Atributo condicional para expresar el total de los impuestos trasladados que se desprenden del pago. No se permiten valores negativos.
                
            //};
            //listaImpuestoPago.Add(impuestoDePago);

            //var listaImpuestoRetencionespago =new List<PagosPagoImpuestosRetencion>();
            //var Retenciones = new PagosPagoImpuestosRetencion()
            //{
            //    Importe = 0,//Atributo requerido para señalar el importe o monto del impuesto retenido. No se permiten valores negativos.
            //    Impuesto = c_Impuesto.Item001,//Atributo requerido para señalar la clave del tipo de impuesto retenido.
            //};
            //listaImpuestoRetencionespago.Add(Retenciones);
            //var listaImpuestoTrasladadosPago =new List<PagosPagoImpuestosTraslado>();
            //var Traslados = new PagosPagoImpuestosTraslado()
            //{
            //    Impuesto = c_Impuesto.Item001,//Atributo requerido para señalar la clave del tipo de impuesto trasladado.
            //    TipoFactor = c_TipoFactor.Tasa,//Atributo requerido para señalar la clave del tipo de factor que se aplica a la base del impuesto.
            //    TasaOCuota = 10,//Atributo requerido para señalar el valor de la tasa o cuota del impuesto que se traslada.
            //    Importe=0.5m,//Atributo requerido para señalar el importe del impuesto trasladado. No se permiten valores negativos.
                
            //};
            //listaImpuestoTrasladadosPago.Add(Traslados);
            //impuestoDePago.Traslados = listaImpuestoTrasladadosPago.ToArray();
            //impuestoDePago.Retenciones = listaImpuestoRetencionespago.ToArray();


            //pago.Impuestos = listaImpuestoPago.ToArray();
            


            pago.DoctoRelacionado = listaDoctoRelacionado.ToArray();
            listaDePagos.Add(pago);
            complementoPago.Pago = listaDePagos.ToArray();

            /*************************************************************************************************************************************************/
            /*************************************************************************************************************************************************/
            /******************************************************Termina llenado de datos del complemento Pagos*********************************************/
            /*************************************************************************************************************************************************/
            /*************************************************************************************************************************************************/

            //se cre objeto Comprobante
            var comprobante = new Comprobante();
            //Todo comprobate tiene un emisor, del cual obtenemos sus datos principales
            comprobante.Emisor = new ComprobanteEmisor()
            {
                //estos son los atributos que se colocan al comprobante
                Nombre = "DEMO S.A. DE C.V.",
                Rfc = "XIA190128J61",
                RegimenFiscal = "601"

            };
            //Todo comprobante tiene un receptor (Cliente), del cual se pbtienen sus datos
            comprobante.Receptor = new ComprobanteReceptor()
            {
                //atributos o datos principales del cliente()
                Nombre = "CLIENTE DEL EXTERIOR MQ",
                // NumRegIdTrib = "MSS091104LRA",
                Rfc = "EIN820415JEA",
                UsoCFDI = "P01",
                //  ResidenciaFiscal = "DEU",
                // ResidenciaFiscalSpecified = true
            };

            //Aqui obtenemos elementos escenciales en un comprobante
            comprobante.Moneda = "XXX";//tipo de moneda con el que se paga
            //MetodoPago no dedbe existir para el complemento pagos
            //comprobante.MetodoPago = "PUE";//Atributo condicional para precisar la clave del método de pago que aplica para este comprobante fiscal digital por Internet, conforme al Artículo 29-A fracción VII incisos a y b del CFF
            comprobante.MetodoPagoSpecified = true; // Atributo boleano que se debe poner en true si se manda metodo de pago, false si no se manda.
            //CondicionesDePago no dedbe existir para el complemento pagos
            //comprobante.CondicionesDePago = "CONTADO : Efectivo";//Atributo condicional para expresar las condiciones comerciales aplicables para el pago del comprobante fiscal digital por Internet. Este atributo puede ser condicionado mediante atributos o complementos.
            comprobante.Fecha = DateTime.Now.ToString("s");//Atributo requerido para la expresión de la fecha y hora de expedición del Comprobante Fiscal Digital por Internet. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora local donde se expide el comprobante
            comprobante.Total = 0m; //Atributo requerido para representar la suma del subtotal, menos los descuentos aplicables, más las contribuciones recibidas (impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos. Si el valor es superior al límite que establezca el SAT en la Resolución Miscelánea Fiscal vigente, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. No se permiten valores negativos.
            comprobante.SubTotal = 0m; //Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e impuesto. No se permiten valores negativos
            comprobante.TipoDeComprobante = "P";//Atributo requerido para expresar la clave del efecto del comprobante fiscal para el contribuyente emisor. 
            comprobante.Folio = "21230";//Atributo opcional para control interno del contribuyente que expresa el folio del documento que ampara la retención e información de pagos. Permite números y/o letras. 
            comprobante.Serie = "A";//Atributo opcional para precisar la serie para control interno del contribuyente. Este atributo acepta una cadena de caracteres
            //FormaPago no debe exitir para el complemento pagos
            //comprobante.FormaPago = "01";//Atributo condicional para expresar la clave de la forma de pago de los bienes o servicios amparados por el comprobante. Si no se conoce la forma de pago este atributo se debe omitir.
            comprobante.LugarExpedicion = "01000";//Atributo requerido para incorporar el código postal del lugar de expedición del comprobante (domicilio de la matriz o de la sucursal). 
            comprobante.TipoCambio = 1m; //Atributo condicional para representar el tipo de cambio conforme con la moneda usada. Es requerido cuando la clave de moneda es distinta de MXN y de XXX. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo moneda. Si el valor está fuera del porcentaje aplicable a la moneda tomado del catálogo c_Moneda, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. 
            comprobante.Sello = "Sello";//Atributo requerido para contener el sello digital del documento de retención e información de pagos. El sello deberá ser expresado como una cadena de texto en formato base 64. 
            comprobante.NoCertificado = "30001000000300023708";//Atributo requerido para expresar el número de serie del certificado del SAT usado para generar el sello digital del Timbre Fiscal Digital. 
            comprobante.Certificado = "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";//Atributo requerido que sirve para incorporar el certificado de sello digital que ampara al comprobante, como texto en formato base 64. 
            
            //No debe esxistir cuando los atributos TipoCambio y/o Total estan dentro del rango permitido.
            //comprobante.Confirmacion = " ECVH1";//Se debe registrar la clave de confirmación única e irrepetible que entregue el Proveedor de Certificación de CFDI o el SAT a los emisores (usuarios) para expedir el comprobante con importes o tipo de cambio fuera del rango establecido o en ambos casos. Cuando el valor equivalente en MXN del campo Monto del complemento exceda el límite publicado por el SAT, el emisor debe obtener de manera no automática una clave de confirmación para ratificar que el importe es correcto e integrarla en este campo al CFDI.

            //objeto con el cual se obtienen la lista de los productos cubiertos por el comprobante
            var concepto = new ComprobanteConcepto()
            {
                //Se obtienen los atributos respectivos para cada uno de los productos o servicios
                //CAntidad debe ser 1 cuando se usa complemento Pagos
                Cantidad = 1M,//Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por el presente concepto.
                ClaveProdServ = "84111506",//Atributo requerido para expresar la clave del producto o del servicio amparado por el presente concepto. Es requerido y deben utilizar las claves del catálogo de productos y servicios, cuando los conceptos que registren por sus actividades correspondan con dichos conceptos.  
                ClaveUnidad = "ACT",//Atributo requerido para precisar la clave de unidad de medida estandarizada aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                Descripcion = "Pago",//Atributo requerido para precisar la descripción del bien o servicio cubierto por la presente parte. 
                Importe = 0M, //Atributo requerido para precisar el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto. No se permiten valores negativos.
                //No debe estar con el complemto Pagos
                //NoIdentificacion = "AC008",//Atributo opcional para expresar el número de serie, número de parte del bien o identificador del producto o del servicio amparado por la presente parte. Opcionalmente se puede utilizar claves del estándar GTIN
                //No debe estar con el complemto Pagos
                //Unidad = "PIEZA",//Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en la parte. La unidad debe corresponder con la descripción de la parte. 
                ValorUnitario = 0m, //Atributo opcional para precisar el valor o precio unitario del bien o servicio cubierto por la presente parte. No se permiten valores negativos. Nota importante: El uso de esta clave estará vigente unicamente a partir de que el SAT publique en su Portal de Internet los procedimientos para generar la clave de confirmación y para parametrizar los montos y rangos máximos aplicables. 
                Descuento=0m,

                ///estos impuestos no van con el complemento Pagos////////////////////////
                //objeto ComplementoConcepto el cual se captira la totalidad Descuento los impuestos totales de un producto o servicio.
                //Impuestos = new ComprobanteConceptoImpuestos
                //{
                //    Traslados = new ComprobanteConceptoImpuestosTraslado[]
                //    {
                //        //Atributo condicional para expresar el total de los impuestos trasladados que se desprenden de los conceptos expresados en el comprobante fiscal digital por Internet. No se permiten valores negativos. Es requerido cuando en los conceptos se registren impuestos trasladados. 
                //        new ComprobanteConceptoImpuestosTraslado {
                //           Base = 1500, //Atributo requerido para señalar la base para el cálculo de la retención, la determinación de la base se realiza de acuerdo con las disposiciones fiscales vigentes. No se permiten valores negativos
                //           Importe =2400m, //Atributo requerido para señalar el importe del impuesto retenido que aplica al concepto. No se permiten valores negativos
                //           ImporteSpecified = true,//Atributo boleano que se debe poner en true si se manda importe, false si no se manda.
                //           Impuesto = "002", //Atributo requerido para señalar la clave del tipo de impuesto trasladado.
                //           TasaOCuota = 0.16m,//Atributo requerido para señalar el valor de la tasa o cuota del impuesto que se traslada por los conceptos amparados en el comprobante.
                //           TasaOCuotaSpecified= true,//Atributo boleano que se debe poner en true si se manda la tasa, false si no se manda.
                //           TipoFactor = "Tasa"//Atributo requerido para señalar la clave del tipo de factor que se aplica a la base del impuesto.
                //        } 
                //    }

                //}
            };

            //se crea un objeto de tipo lista para obtener los datos relevantes con cada uno de los productos o servicios que cubre el comprobante
            var conceptos = new List<ComprobanteConcepto>();
            //se impementa el objeto anterior 
            conceptos.Add(concepto);
            //se asigna la totalidad de productos o servicios al comprobante
            comprobante.Conceptos = conceptos.ToArray();
            
            //**************Esta parte de impuestos no debe estar para el complemento de Pagos********************************
            
            /*
            //se crea objeto para obtener la totalidad de los impuestos obtenidos 
            comprobante.Impuestos = new ComprobanteImpuestos
            {
                //Parametros de los impuestos
                TotalImpuestosTrasladados = "110.88"
                ,
                TotalImpuestosTrasladadosSpecified = true
                ,
                Traslados = new ComprobanteImpuestosTraslado[]
                    {
                        //se crea nuevo metodo para la totalidad de impuestos trasladados
                        new ComprobanteImpuestosTraslado
                        {
                            Impuesto = "002", Importe = "110.88", TipoFactor = "Tasa", TasaOCuota = "0.160000"
                        }
                    }
            };

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
            */
            
            ComplementoSat pagos = new ComplementoSat();
            pagos.Prefix = "pago10";
            pagos.NameSpace = "http://www.sat.gob.mx/Pagos";
            pagos.Complemento = complementoPago;
            comprobante.ListaComplementos = new List<ComplementoSat>();
            comprobante.ListaComplementos.Add(pagos);
            //*************Llenado de datos extra**********************//
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


            ////CANELACION de un UUID
            var res3 = timbra.CancelaCFDI("demo1@mail.com", "Demo123#", comprobante.Emisor.Rfc, comprobante.Receptor.Rfc, comprobante.Total.ToString(),"DC235262-F38E-4CA3-9A94-B2720A170BF2",1,"", "D");            
            if (res3.CancelacionExitosa)
            {
                Console.WriteLine("Cancelado exitosamente");
                Console.WriteLine(res3.AcuseCancelacion);
            }
            else
            {
                Console.WriteLine(res3.AcuseCancelacion);
            }
            Console.ReadKey();
        }
 

    }

}
