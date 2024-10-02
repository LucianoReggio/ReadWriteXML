using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadWriterXML
{
    internal class LeerXMLReader
    {
        static void Main(string[] args) {
            string XML = LeerReader();
            Console.WriteLine(XML);
            Console.ReadLine();
        }
        private static string LeerReader() {

            string resultado = "";
            string path = Directory.GetCurrentDirectory();
            path = path.Replace("bin\\Debug", "");

            using (XmlReader reader = XmlReader.Create(path + "EmpleadosWriter.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "empleados":
                                resultado += "Inicio Empleados elementos" + "\n";
                                break;
                            case "listado":
                                resultado += "listado de Empleados" + "\n";
                                break;
                            case "empleado":
                                resultado += "Empleado";
                                break;
                            case "id":
                                if (reader.Read())
                                {
                                    resultado += "ID: " + reader.Value.Trim() + "\n";
                                }
                                break;
                            case "nombreCompleto":
                                if (reader.Read())
                                {
                                    resultado += "Nombre Completo: " + reader.Value.Trim() + "\n";
                                }
                                break;
                            case "cuil":
                                if (reader.Read())
                                {
                                    resultado += "Cuil: " + reader.Value.Trim() + "\n";
                                }
                                break;
                            case "sector":
                                // Leer atributos del sector
                                string sectorDenominacion = reader["denominacion"];
                                string sectorID = reader["id"];
                                string colorSemaforo = reader["colorSemaforo"];
                                string valorSemaforo = reader["valorSemaforo"];
                                resultado += $"  Sector: {sectorDenominacion} (ID: {sectorID}) - Color Semáforo: {colorSemaforo} - Valor Semaforo {valorSemaforo}\n";
                                break;
                            case "cupoAsignado":
                                if (reader.Read())
                                {
                                    resultado += "  Cupo Asignado: " + reader.Value.Trim() + "\n";
                                }
                                break;

                            case "cupoConsumido":
                                if (reader.Read())
                                {
                                    resultado += "  Cupo Consumido: " + reader.Value.Trim() + "\n";
                                }
                                break;

                            case "subSectores":
                                if (reader.Read())
                                {
                                    resultado += "Cantidad de Subsectores: " + reader.Value.Trim() + "\n";
                                }
                                break;

                            case "totalCuposAsignadoSector":
                                if (reader.Read())
                                {
                                    resultado += "Total Cupo Asignado del Sector: " + reader.Value.Trim() + "\n";
                                }
                                break;

                            case "totalCuposConsumidosSector":
                                if (reader.Read())
                                {
                                    resultado += "Total Cupo Consumido del Sector: " + reader.Value.Trim() + "\n";
                                }
                                break;

                            case "valorDial":
                                if (reader.Read())
                                {
                                    resultado += "Valor Dial: " + reader.Value.Trim() + "\n";
                                }
                                break;
                        }
                    }

                }
                return resultado;
            }
        }
    } 
}


