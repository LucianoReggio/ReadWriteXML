using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReadWriterXML
{
    internal class EscribirXML
    {
        static void Main(string[] args)
        {
            CrearArchivoXML();
        }
        public static void CrearArchivoXML() {

            try
            {

                XElement empleados = new XElement("empleados");

                XElement listado = new XElement("listado");

                XElement empleado1 = new XElement("empleado");
                XElement id = new XElement("id", "4884");
                XElement nombreCompleto = new XElement("nombreCompleto", "Rodriguez, Victor");
                XElement cuil = new XElement("cuil", "20103180326");
                XElement sector = new XElement("sector");
                XAttribute denominacion = new XAttribute("denominacion", "Gerencia Recursos Humanos");
                XAttribute idsector = new XAttribute("id", "137");
                XAttribute valorSemaforo = new XAttribute("valorSemaforo", "130.13");
                XAttribute colorSemaforo = new XAttribute("colorSemaforo", "VERDE");
                sector.Add(denominacion, idsector, valorSemaforo, colorSemaforo);
                XElement cupoAsignado = new XElement("cupoAsignado", "1837.15");
                XElement cupoConsumido = new XElement("cupoConsumido", "658.02");
                empleado1.Add(id, nombreCompleto, cuil, sector, cupoAsignado, cupoConsumido);

                XElement empleado2 = new XElement("empleado");
                id = new XElement("id", "1225");
                nombreCompleto = new XElement("nombreCompleto", "Sanchez, Juan Ignacio");
                cuil = new XElement("cuil", "20271265817");
                sector = new XElement("sector");
                denominacion = new XAttribute("denominacion", "Gerencia Operativa");
                idsector = new XAttribute("id", "44");
                valorSemaforo = new XAttribute("valorSemaforo", "130.13");
                colorSemaforo = new XAttribute("colorSemaforo", "ROjo");
                sector.Add(denominacion, idsector, valorSemaforo, colorSemaforo);
                cupoAsignado = new XElement("cupoAsignado", "750.15");
                cupoConsumido = new XElement("cupoConsumido", "625.02");
                empleado2.Add(id, nombreCompleto, cuil, sector, cupoAsignado, cupoConsumido);

                listado.Add(empleado1, empleado2);

                XElement subSector = new XElement("subSectores", "5");
                XElement totalCuposAsignasdos = new XElement("totalCuposAsignadoSector", "4217.21");
                XElement totalCuposConsumido = new XElement("totalCuposConsumidosSector", "1405.88");
                XElement valorDial = new XElement("valorDial", "33.34");

                empleados.Add(listado, subSector, totalCuposAsignasdos, totalCuposConsumido, valorDial);

                XDeclaration declaration = new XDeclaration("1.0", "utf-8", "yes");
                XComment comentario = new XComment("Lista de Emplados");
                XDocument miXML = new XDocument(declaration, comentario, empleados);

                string path = Directory.GetCurrentDirectory();
                path = path.Replace("bin\\Debug", "");
                string archivoXML = path + "miXMLEmpleados.xml";
                miXML.Save(@archivoXML);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
