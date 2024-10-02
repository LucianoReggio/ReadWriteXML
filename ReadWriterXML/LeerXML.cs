using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadWriterXML
{
    internal class LeerXML
    {
        static void Main(string[] args)
        {
            string xml = leerXML();
            Console.Write(xml);
            Console.ReadLine();
        }
        public static string leerXML()
        {
            string resultado = "";
            string path = Directory.GetCurrentDirectory();
            path = path.Replace("bin\\Debug", "");
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path+ "miXMLEmpleados.xml");
                XmlNodeList empleados = xDoc.GetElementsByTagName("empleados");
                XmlNodeList listado = xDoc.GetElementsByTagName("listado");
                XmlNodeList lista = ((XmlElement)listado[0]).GetElementsByTagName("empleado");

                foreach (XmlElement nodo in lista)
                {
                    // Leer ID, Nombre Completo, y CUIL
                    string id = nodo.GetElementsByTagName("id")[0].InnerText;
                    string nombreCompleto = nodo.GetElementsByTagName("nombreCompleto")[0].InnerText;
                    string cuil = nodo.GetElementsByTagName("cuil")[0].InnerText;

                    // Leer sector
                    XmlElement sector = (XmlElement)nodo.GetElementsByTagName("sector")[0];
                    string sectorDenominacion = sector.GetAttribute("denominacion");
                    string sectorID = sector.GetAttribute("id");
                    string colorSemaforo = sector.GetAttribute("colorSemaforo");
                    string valorSemaforo = sector.GetAttribute("valorSemaforo");

                   
                    string cupoAsignado = nodo.GetElementsByTagName("cupoAsignado")[0].InnerText;
                    string cupoConsumido = nodo.GetElementsByTagName("cupoConsumido")[0].InnerText;

                    
                    resultado += $"Empleado ID: {id}\n";
                    resultado += $"Nombre Completo: {nombreCompleto}\n";
                    resultado += $"CUIL: {cuil}\n";
                    resultado += $"Sector: {sectorDenominacion} (ID: {sectorID}) - Color Semáforo: {colorSemaforo}- Valor Semáforo {valorSemaforo}\n";
                    resultado += $"Cupo Asignado: {cupoAsignado}, Cupo Consumido: {cupoConsumido}\n";
                    resultado += "-----------------------------------\n";
                }
                XmlNodeList subsectores = xDoc.GetElementsByTagName("subSectores");
                if (subsectores.Count > 0)
                {
                    resultado += $"Cantidad de Subsectores: {subsectores[0].InnerText}\n";
                }

                XmlNodeList totalCupoAsignado = xDoc.GetElementsByTagName("totalCuposAsignadoSector");
                if (totalCupoAsignado.Count > 0)
                {
                    resultado += $"Total Cupo Asignado del Sector: {totalCupoAsignado[0].InnerText}\n";
                }

                XmlNodeList totalCupoConsumido = xDoc.GetElementsByTagName("totalCuposConsumidosSector");
                if (totalCupoConsumido.Count > 0)
                {
                    resultado += $"Total Cupo Consumido del Sector: {totalCupoConsumido[0].InnerText}\n";
                }

                XmlNodeList valorDial = xDoc.GetElementsByTagName("valorDial");
                if (valorDial.Count > 0)
                {
                    resultado += $"Valor Dial: {valorDial[0].InnerText}\n";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return resultado;

        }
        }
    }

