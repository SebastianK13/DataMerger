using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataMerger.Models
{
    [XmlRoot("Objects")]
    public class ObjectList
    {
        [XmlElement("Object")]
        public List<SingleObject> SingleObjects { get; set; }
        public void DeserializeXML(string mainPath)
        {
            string xmlDirectory = Path.Combine(mainPath, "Files", "phone.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(ObjectList));
            StreamReader reader = new StreamReader(xmlDirectory);
            ObjectList result = (ObjectList)serializer.Deserialize(reader);
            reader.Close();
        }
    }
    public class SingleObject
    { 
        [XmlElement("Property")]
        public List<Property> Properties { get; set; }
        public string Id
        {
            get
            {
                return Properties.Where(i => i.Name == "id").FirstOrDefault().Value;
            }
        }
        public string Username
        {
            get
            {
                return Properties.Where(i => i.Name == "username").FirstOrDefault().Value;
            }
        }
        public string PhoneType
        {
            get
            {
                return Properties.Where(i => i.Name == "phoneType").FirstOrDefault().Value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return Properties.Where(i => i.Name == "value").FirstOrDefault().Value;
            }
        }

    }
    public class Property
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
    
}
