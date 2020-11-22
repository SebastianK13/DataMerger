using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                var number = Properties.Where(i => i.Name == "value").FirstOrDefault().Value;
                return FormatPhoneNumber(number);               
            }
        }
        public string FormatPhoneNumber(string number)
        {
            string formatedPhNumber = number;
            number = Regex.Replace(number, @"[^0-9]+", "");

            if (!String.IsNullOrEmpty(number) && number.Length == 10)
            {
                formatedPhNumber = number.Substring(0, 3) + " " + number.Substring(3, 3) + " " + number.Substring(6, 4);
            }
            return formatedPhNumber;
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
