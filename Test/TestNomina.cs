using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimbradoCepdi.V33;

namespace Test
{
    public class Nominas
    {
        public void TestNomina()
        {

            /*************************************************************************************************************************************************/
            /*************************************************************************************************************************************************/
            /******************************************************Inicia llenado de datos del complemento Nomina**********************************************/
            /*************************************************************************************************************************************************/
            /*************************************************************************************************************************************************/

            var complementoNomina = new TimbradoCepdi.Models.Nomina();

            complementoNomina.Version = "1.2";
            complementoNomina.TipoNomina = "O";
            complementoNomina.FechaPago = DateTime.Parse("2019-01-01");
            complementoNomina.FechaInicialPago = DateTime.Parse("2018-12-31");
            complementoNomina.FechaFinalPago = DateTime.Parse("2019-01-08");
            complementoNomina.NumDiasPagados = 9.000M;
            complementoNomina.TotalPercepciones = 12669.91M;
            complementoNomina.TotalPercepcionesSpecified = true;
            complementoNomina.TotalDeducciones = 2571.70M;
            complementoNomina.TotalDeduccionesSpecified = true;
            //complementoNomina.TotalOtrosPagos = 0.0M;
            //complementoNomina.TotalOtrosPagosSpecified = true;
            complementoNomina.Emisor = new TimbradoCepdi.Models.NominaEmisor();
            complementoNomina.Emisor.RegistroPatronal = "Y5446719105";
            TimbradoCepdi.Models.NominaReceptor Receptor = new TimbradoCepdi.Models.NominaReceptor();
            Receptor.Antigüedad = "P397W";
            Receptor.ClaveEntFed = "NLE";
            Receptor.Curp = "HEVJ860606HNLRLS05";
            Receptor.Departamento = "MERCHANDIS";
            Receptor.FechaInicioRelLaboral = DateTime.Parse("2011-05-30");
            Receptor.FechaInicioRelLaboralSpecified = true;
            Receptor.NumEmpleado = "32004256";
            Receptor.NumSeguridadSocial = "43048691109";
            Receptor.PeriodicidadPago = "03";
            Receptor.RiesgoPuesto = "2";
            Receptor.RiesgoPuestoSpecified = true;
            Receptor.SalarioBaseCotApor = 465.07M;
            Receptor.SalarioBaseCotAporSpecified = true;
            Receptor.SalarioDiarioIntegrado = 465.07M;
            Receptor.SalarioDiarioIntegradoSpecified = true;
            Receptor.TipoContrato = "01";
            Receptor.TipoJornada = "01";
            Receptor.TipoJornadaSpecified = true;
            Receptor.TipoRegimen = "02";

            complementoNomina.Receptor = Receptor;
            complementoNomina.Percepciones = new TimbradoCepdi.Models.NominaPercepciones();
            complementoNomina.Percepciones.TotalExento = 626.51M;
            complementoNomina.Percepciones.TotalGravado = 12043.40M;
            complementoNomina.Percepciones.TotalSueldos = 12669.91M;
            complementoNomina.Percepciones.TotalSueldosSpecified = true;
            List<TimbradoCepdi.Models.NominaPercepcionesPercepcion> percepciones = new List<TimbradoCepdi.Models.NominaPercepcionesPercepcion>()
            {
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "1102",
                    Concepto = "Accrued salary",
                    ImporteExento = 0.00M,
                    ImporteGravado = 1769.25M,
                    TipoPercepcion = "001"
                },
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "1103",
                    Concepto = "Salary to be accrued",
                    ImporteExento = 0.00M,
                    ImporteGravado = 505.53M,
                    TipoPercepcion = "001"
                },
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "5005",
                    Concepto = "T Vacation days",
                    ImporteExento = 0.00M,
                    ImporteGravado = 5709.62M,
                    TipoPercepcion = "001"
                },
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "4203",
                    Concepto = "Christmas Bonus exempt",
                    ImporteExento = 83.10M,
                    ImporteGravado = 0.00M,
                    TipoPercepcion = "002"
                },
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "4202",
                    Concepto = "Vacation Premium exempt",
                    ImporteExento = 543.41M,
                    ImporteGravado = 0.00M,
                    TipoPercepcion = "021"
                },
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "5006",
                    Concepto = "Food Vouchers Taxable",
                    ImporteExento = 0.00M,
                    ImporteGravado = 159.00M,
                    TipoPercepcion = "029"
                },
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "3000",
                    Concepto = "Incentives",
                    ImporteExento = 0.00M,
                    ImporteGravado = 3900.00M,
                    TipoPercepcion = "038"
                }
            };

            complementoNomina.Percepciones.Percepcion = percepciones.ToArray();
            complementoNomina.Deducciones = new TimbradoCepdi.Models.NominaDeducciones();
            complementoNomina.Deducciones.TotalImpuestosRetenidos = 1996.04M;
            complementoNomina.Deducciones.TotalImpuestosRetenidosSpecified = true;
            complementoNomina.Deducciones.TotalOtrasDeducciones = 575.66M;
            complementoNomina.Deducciones.TotalOtrasDeduccionesSpecified = true;
            List<TimbradoCepdi.Models.NominaDeduccionesDeduccion> deducciones = new List<TimbradoCepdi.Models.NominaDeduccionesDeduccion>()
            {
                new TimbradoCepdi.Models.NominaDeduccionesDeduccion()
                {
                    Clave = "_391",
                    Concepto = "Employee IMSS contr",
                    Importe= 107.99M,
                    TipoDeduccion = "001"
                },
                new TimbradoCepdi.Models.NominaDeduccionesDeduccion()
                {
                    Clave = "_440",
                    Concepto = "Regular tax",
                    Importe= 1996.04M,
                    TipoDeduccion = "002"
                },
                new TimbradoCepdi.Models.NominaDeduccionesDeduccion()
                {
                    Clave = "_381",
                    Concepto = "INFONAVIT credit contr",
                    Importe= 452.67M,
                    TipoDeduccion = "010"
                },
                new TimbradoCepdi.Models.NominaDeduccionesDeduccion()
                {
                    Clave = "_387",
                    Concepto = "INFONAVIT household ins",
                    Importe= 15.00M,
                    TipoDeduccion = "010"
                },
            };
            complementoNomina.Percepciones.Percepcion = percepciones.ToArray();
            complementoNomina.Deducciones.Deduccion = deducciones.ToArray();
            complementoNomina.OtrosPagos = null;
            complementoNomina.Incapacidades = null;
            /**
             Segunda Nomina
             */
            var complementoNomina2 = new TimbradoCepdi.Models.Nomina();

            complementoNomina2.Version = "1.2";
            complementoNomina2.FechaFinalPago = DateTime.Parse("2019-01-08");
            complementoNomina2.FechaInicialPago = DateTime.Parse("2018-12-31");
            complementoNomina2.FechaPago = DateTime.Parse("2019-01-01");
            complementoNomina2.NumDiasPagados = 1.000M;
            complementoNomina2.TipoNomina = "E";

            complementoNomina2.TotalPercepciones = 100672.90M;
            complementoNomina2.TotalPercepcionesSpecified = true;
            complementoNomina2.TotalDeducciones = 3257.76M;
            complementoNomina2.TotalDeduccionesSpecified = true;
            //complementoNomina.TotalOtrosPagos = 0.0M;
            //complementoNomina.TotalOtrosPagosSpecified = true;
            complementoNomina2.Emisor = null;
            TimbradoCepdi.Models.NominaReceptor Receptor2 = new TimbradoCepdi.Models.NominaReceptor();
            Receptor2.ClaveEntFed = "NLE";
            Receptor2.Curp = "HEVJ860606HNLRLS05";
            Receptor2.Departamento = "MERCHANDIS";
            Receptor2.NumEmpleado = "32004256";
            Receptor2.PeriodicidadPago = "99";
            Receptor2.SalarioBaseCotApor = 465.07M;
            Receptor2.SalarioBaseCotAporSpecified = true;
            Receptor2.TipoContrato = "99";
            Receptor2.TipoJornada = "01";
            Receptor2.TipoJornadaSpecified = true;
            Receptor2.TipoRegimen = "13";



            complementoNomina2.Receptor = Receptor2;
            complementoNomina2.Percepciones = new TimbradoCepdi.Models.NominaPercepciones();
            complementoNomina2.Percepciones.TotalExento = 58032.00M;
            complementoNomina2.Percepciones.TotalGravado = 42640.90M;
            complementoNomina2.Percepciones.TotalSeparacionIndemnizacion = 100672.90M;
            complementoNomina2.Percepciones.TotalSeparacionIndemnizacionSpecified = true;
            List<TimbradoCepdi.Models.NominaPercepcionesPercepcion> percepciones2 = new List<TimbradoCepdi.Models.NominaPercepcionesPercepcion>()
            {
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "5000",
                    Concepto = "Seniority payment",
                    ImporteExento = 16145.92M,
                    ImporteGravado = 0.00M,
                    TipoPercepcion = "022"
                },
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "5003",
                    Concepto = "Severance",
                    ImporteExento = 31400.10M,
                    ImporteGravado = 0.00M,
                    TipoPercepcion = "023"
                },
                new TimbradoCepdi.Models.NominaPercepcionesPercepcion()
                {
                    Clave = "5004",
                    Concepto = "Relocation",
                    ImporteExento = 10485.98M,
                    ImporteGravado = 42640.90M,
                    TipoPercepcion = "023"
                }
            };
            complementoNomina2.Percepciones.SeparacionIndemnizacion = new TimbradoCepdi.Models.NominaPercepcionesSeparacionIndemnizacion();
            complementoNomina2.Percepciones.SeparacionIndemnizacion.IngresoAcumulable = 7582.50M;
            complementoNomina2.Percepciones.SeparacionIndemnizacion.IngresoNoAcumulable = 35058.40M;
            complementoNomina2.Percepciones.SeparacionIndemnizacion.NumAñosServicio = 08;
            complementoNomina2.Percepciones.SeparacionIndemnizacion.TotalPagado = 100672.90M;
            complementoNomina2.Percepciones.SeparacionIndemnizacion.UltimoSueldoMensOrd = 7582.50M;
            complementoNomina2.Percepciones.Percepcion = percepciones2.ToArray();
            complementoNomina2.Deducciones = new TimbradoCepdi.Models.NominaDeducciones();
            complementoNomina2.Deducciones.TotalImpuestosRetenidos = 3257.76M;
            complementoNomina2.Deducciones.TotalImpuestosRetenidosSpecified = true;
            List<TimbradoCepdi.Models.NominaDeduccionesDeduccion> deducciones2 = new List<TimbradoCepdi.Models.NominaDeduccionesDeduccion>()
            {
                new TimbradoCepdi.Models.NominaDeduccionesDeduccion()
                {
                    Clave = "_445",
                    Concepto = "Severanc payment amount",
                    Importe= 3257.76M,
                    TipoDeduccion = "002"
                }
            };
            complementoNomina2.Percepciones.Percepcion = percepciones2.ToArray();
            complementoNomina2.Deducciones.Deduccion = deducciones2.ToArray();
            complementoNomina2.OtrosPagos = null;
            complementoNomina2.Incapacidades = null;
            /*************************************************************************************************************************************************/
            /*************************************************************************************************************************************************/
            /******************************************************Inicia llenado de datos del complemento Nomina**********************************************/
            /*************************************************************************************************************************************************/
            /*************************************************************************************************************************************************/

            //se cre objeto Comprobante
            var comprobante = new TimbradoCepdi.Comprobante40.Comprobante();
            //Todo comprobate tiene un emisor, del cual obtenemos sus datos principales
            comprobante.Emisor = new TimbradoCepdi.Comprobante40.ComprobanteEmisor()
            {
                //estos son los atributos que se colocan al comprobante
                Nombre = "Unilever Servicios de Promotoria, S. de R.L. de C.V.",
                Rfc = "AAA010101AAA",
                RegimenFiscal = "601"

            };
            //Todo comprobante tiene un receptor (Cliente), del cual se pbtienen sus datos
            comprobante.Receptor = new TimbradoCepdi.Comprobante40.ComprobanteReceptor()
            {
                //atributos o datos principales del cliente()
                Nombre = "JESUS ISABEL HERNANDEZ VILLA",
                Rfc = "HEVJ860606AW3",
                UsoCFDI = "CN01",
                DomicilioFiscalReceptor = "65000",
                RegimenFiscalReceptor = "605"
            };

            //Aqui obtenemos elementos escenciales en un comprobante
            comprobante.Descuento = 5829.46M;
            comprobante.Exportacion = "01";
            comprobante.DescuentoSpecified = true;
            comprobante.Fecha = DateTime.Now.ToString("s");//Atributo requerido para la expresión de la fecha y hora de expedición del Comprobante Fiscal Digital por Internet. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora local donde se expide el comprobante
            comprobante.Folio = "320042560043700001";//Atributo opcional para control interno del contribuyente que expresa el folio del documento que ampara la retención e información de pagos. Permite números y/o letras. 
            comprobante.FormaPago = "99";//Atributo condicional para expresar la clave de la forma de pago de los bienes o servicios amparados por el comprobante. Si no se conoce la forma de pago este atributo se debe omitir.
            comprobante.FormaPagoSpecified = true;
            comprobante.LugarExpedicion = "05120";//Atributo requerido para incorporar el código postal del lugar de expedición del comprobante (domicilio de la matriz o de la sucursal). 
            comprobante.MetodoPago = "PUE";//Atributo condicional para precisar la clave del método de pago que aplica para este comprobante fiscal digital por Internet, conforme al Artículo 29-A fracción VII incisos a y b del CFF        
            comprobante.MetodoPagoSpecified = true; // Atributo boleano que se debe poner en true si se manda metodo de pago, false si no se manda.
            comprobante.Moneda = "MXN";//tipo de moneda con el que se paga
            comprobante.Serie = "32004256";//Atributo opcional para precisar la serie para control interno del contribuyente. Este atributo acepta una cadena de caracteres
            comprobante.SubTotal = 113342.81m; //Atributo requerido para representar la suma de los importes de los conceptos antes de descuentos e impuesto. No se permiten valores negativos
            comprobante.TipoDeComprobante = "N";//Atributo requerido para expresar la clave del efecto del comprobante fiscal para el contribuyente emisor. 
            comprobante.Total = 107513.35m; //Atributo requerido para representar la suma del subtotal, menos los descuentos aplicables, más las contribuciones recibidas (impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos. Si el valor es superior al límite que establezca el SAT en la Resolución Miscelánea Fiscal vigente, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. No se permiten valores negativos.                                                                                    
           // comprobante.TipoCambio = 1m; //Atributo condicional para representar el tipo de cambio conforme con la moneda usada. Es requerido cuando la clave de moneda es distinta de MXN y de XXX. El valor debe reflejar el número de pesos mexicanos que equivalen a una unidad de la divisa señalada en el atributo moneda. Si el valor está fuera del porcentaje aplicable a la moneda tomado del catálogo c_Moneda, el emisor debe obtener del PAC que vaya a timbrar el CFDI, de manera no automática, una clave de confirmación para ratificar que el valor es correcto e integrar dicha clave en el atributo Confirmacion. 
            comprobante.Sello = "Sello";//Atributo requerido para contener el sello digital del documento de retención e información de pagos. El sello deberá ser expresado como una cadena de texto en formato base 64. 
            comprobante.NoCertificado = "numerocertificado";//Atributo requerido para expresar el número de serie del certificado del SAT usado para generar el sello digital del Timbre Fiscal Digital. 
            comprobante.Certificado = "certificadoBase64";//Atributo requerido que sirve para incorporar el certificado de sello digital que ampara al comprobante, como texto en formato base 64. 

            //objeto con el cual se obtienen la lista de los productos cubiertos por el comprobante
            var concepto = new TimbradoCepdi.Comprobante40.ComprobanteConcepto()
            {
                //Se obtienen los atributos respectivos para cada uno de los productos o servicios
                Cantidad = 1.00M,//Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por el presente concepto.
                ClaveProdServ = "84111505",//Atributo requerido para expresar la clave del producto o del servicio amparado por el presente concepto. Es requerido y deben utilizar las claves del catálogo de productos y servicios, cuando los conceptos que registren por sus actividades correspondan con dichos conceptos.  
                ClaveUnidad = "ACT",//Atributo requerido para precisar la clave de unidad de medida estandarizada aplicable para la cantidad expresada en el concepto. La unidad debe corresponder con la descripción del concepto.
                Descuento = 5829.46M,
                DescuentoSpecified = true,
                Descripcion = "Pago de nómina",//Atributo requerido para precisar la descripción del bien o servicio cubierto por la presente parte. 
                Importe = 113342.81M, //Atributo requerido para precisar el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto. No se permiten valores negativos.
                //NoIdentificacion = "AC008",//Atributo opcional para expresar el número de serie, número de parte del bien o identificador del producto o del servicio amparado por la presente parte. Opcionalmente se puede utilizar claves del estándar GTIN
                //Unidad = "PIEZA",//Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en la parte. La unidad debe corresponder con la descripción de la parte. 
                ValorUnitario = 113342.81M, //Atributo opcional para precisar el valor o precio unitario del bien o servicio cubierto por la presente parte. No se permiten valores negativos. 
                //objeto ComplementoConcepto el cual se captira la totalidad Descuento los impuestos totales de un producto o servicio.
                ObjetoImp = "01"
            };

            //se crea un objeto de tipo lista para obtener los datos relevantes con cada uno de los productos o servicios que cubre el comprobante
            var conceptos = new List<TimbradoCepdi.Comprobante40.ComprobanteConcepto>();
            //se impementa el objeto anterior 
            conceptos.Add(concepto);
            //se asigna la totalidad de productos o servicios al comprobante
            comprobante.Conceptos = conceptos.ToArray();


            ComplementoSat nomina = new ComplementoSat();
            nomina.Prefix = "nomina12";
            nomina.NameSpace = "http://www.sat.gob.mx/nomina12";
            nomina.Complemento = complementoNomina;
            comprobante.ListaComplementos = new List<ComplementoSat>();
            comprobante.ListaComplementos.Add(nomina);



            //*************Llenado de datos extra**********************//

            var datos_Extra = new TimbradoCepdi.WS.datosExtra();
            datos_Extra.Email = "";
            //************Termina Datos Adicionales********************//

            TimbradoCepdi.V33.XmlUtils timbra = new TimbradoCepdi.V33.XmlUtils();
            var xml = timbra.GetXmlFromComprobante40(comprobante);

            var res = timbra.Timbrar40(comprobante, "demo1@mail.com", "demo123#", datos_Extra, "D");

            if (!res.Exitoso)
            {
                Console.WriteLine(res.MensajeError + "\n" + res.CodigoError);
            }
            else
            {
                Console.WriteLine(res.XMLTimbrado);
            }

            Console.ReadKey();
        }
    }
}
