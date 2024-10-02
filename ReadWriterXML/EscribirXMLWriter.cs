using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace ReadWriterXML
{
    internal class EscribirXMLWriter
    {
        public static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Replace("bin\\Debug", "");
            escribirXML(path);
        }
        public static void escribirXML(string path)
    {
        XmlTextWriter myXmlTextWriter = new XmlTextWriter(path + "EmpleadosWriter.xml", null);
            myXmlTextWriter.Formatting = Formatting.Indented;
            myXmlTextWriter.WriteStartDocument(false);
            myXmlTextWriter.WriteComment("Lista Empleados");

            myXmlTextWriter.WriteStartElement("empleados", null);

            myXmlTextWriter.WriteStartElement("listado", null);

            myXmlTextWriter.WriteStartElement("empleado", null);
            myXmlTextWriter.WriteElementString("id", null, "4884");
            myXmlTextWriter.WriteElementString("nombreCompleto", null, "Rodriguez, Victor");
            myXmlTextWriter.WriteElementString("cuil", null, "20103180326");

            myXmlTextWriter.WriteStartElement("sector", null);
            myXmlTextWriter.WriteAttributeString("denominacion", "Gerencia Recursos Humanos");
            myXmlTextWriter.WriteAttributeString("id", "137");
            myXmlTextWriter.WriteAttributeString("valorSemaforo", "130.13");
            myXmlTextWriter.WriteAttributeString("colorSemaforo", "VERDE");
            myXmlTextWriter.WriteEndElement();

            myXmlTextWriter.WriteElementString("cupoAsignado", null, "1837.15");
            myXmlTextWriter.WriteElementString("cupoConsumido", null, "658.02");
            myXmlTextWriter.WriteEndElement(); // empleado

            myXmlTextWriter.WriteStartElement("empleado", null);
            myXmlTextWriter.WriteElementString("id", null, "1225");
            myXmlTextWriter.WriteElementString("nombreCompleto", null, "Sanchez, Juan Ignacio");
            myXmlTextWriter.WriteElementString("cuil", null, "20271265817");

            myXmlTextWriter.WriteStartElement("sector", null);
            myXmlTextWriter.WriteAttributeString("denominacion", "Gerencia Operativa");
            myXmlTextWriter.WriteAttributeString("id", "44");
            myXmlTextWriter.WriteAttributeString("valorSemaforo", "130.13");
            myXmlTextWriter.WriteAttributeString("colorSemaforo", "ROjo");
            myXmlTextWriter.WriteEndElement();

            myXmlTextWriter.WriteElementString("cupoAsignado", null, "750.15");
            myXmlTextWriter.WriteElementString("cupoConsumido", null, "625.02");
            myXmlTextWriter.WriteEndElement(); // empleado

            myXmlTextWriter.WriteEndElement(); // listado

            myXmlTextWriter.WriteElementString("subSectores", null, "5");
            myXmlTextWriter.WriteElementString("totalCuposAsignadoSector", null, "4217.21");
            myXmlTextWriter.WriteElementString("totalCuposConsumidosSector", null, "1405.88");
            myXmlTextWriter.WriteElementString("valorDial", null, "33.34");

            myXmlTextWriter.WriteEndElement(); // empleados

            myXmlTextWriter.Flush();


        }
    }
    }


