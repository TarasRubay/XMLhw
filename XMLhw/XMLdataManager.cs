using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLhw
{
    class XMLdataManager
    {
        public string Path { get; private set; } = "";
        public string Namespace { get; private set; } = "";
        public XMLdataManager(string path, string ns)
        {
            Path = path;
            Namespace = ns;
        }
        public void SaveData(List<Worker> workers)
        {
            XmlWriterSettings xmlWriter = new XmlWriterSettings { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(Path,xmlWriter))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Workers", Namespace);
                foreach (Worker item in workers)
                {
                  writer.WriteStartElement("Worker", Namespace);
                    writer.WriteElementString("ID", Namespace, item.ID);
                    writer.WriteElementString("Name", Namespace, item.Name);
                    writer.WriteElementString("Surname", Namespace, item.Surname);
                    writer.WriteElementString("PhoneNumber", Namespace, item.PhoneNumber);
                    writer.WriteElementString("Appointment", Namespace, item.Appointment.ToString());
                  writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        public List<Worker> LoadData()
        {
            List<Worker> workers = new List<Worker>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreProcessingInstructions = true;
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;
            using (XmlReader reader = XmlReader.Create(Path, settings))
            {
                reader.MoveToContent();
                while (reader.Read() && reader.NodeType == XmlNodeType.Element && reader.Name == "Worker")
                {
                    reader.Read();
                    workers.Add(new Worker(
                        reader.ReadElementContentAsString("ID", Namespace),
                        reader.ReadElementContentAsString("Name", Namespace),
                        reader.ReadElementContentAsString("Surname", Namespace),
                        reader.ReadElementContentAsString("PhoneNumber", Namespace),
                        (Appointment)Enum.Parse(typeof(Appointment), reader.ReadElementContentAsString("Appointment", Namespace))
                        ));
                }
            }
            return workers;
        }
    }
}
