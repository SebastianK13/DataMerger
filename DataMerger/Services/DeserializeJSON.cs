using DataMerger.Models;
using DataMerger.Services.Errors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DataMerger.Services
{
    public class DeserializeJSON
    {
        public List<XmlUser> UniqueXmlUsers { get; private set; }
        public List<XmlUser> IncorrectData { get; private set; }
        public void DeserializeUsersFromXML(string mainDirectory)
        {
            string xmlDirectory = Path.Combine(mainDirectory, "Files", "phone.xml");
            XDocument usersXml = XDocument.Load(new StreamReader(xmlDirectory));
            var users = usersXml.Root.Elements();

            List<XmlUser> xmlUsers = new List<XmlUser>();

            foreach(var u in users)
            {
                xmlUsers.Add(new XmlUser(u.Elements().ToList()));
            }

            //for testing only
            //ErrorsChecker.CheckErrors(xmlUsers);
           
            RemoveDuplicatesAndEmpties(xmlUsers);
        }
        public void RemoveDuplicatesAndEmpties(List<XmlUser> xmlUsers)
        {
            List<XmlUser> uniqueUsers = new List<XmlUser>();
            foreach(var u in xmlUsers)
            {
                var duplicates = xmlUsers.Where(n => (n.Username == u.Username) &&
                (!uniqueUsers.Any(e=>e.Username == u.Username))&&
                (n.Phones.Any(p=>p.PhoneNumber != "")))
                    .ToList();

                IncorrectData = xmlUsers
                    .Where(p => p.Phones
                    .Any(n => n.PhoneNumber == ""))
                    .ToList();

                if(duplicates.Count() > 0)
                {
                    XmlUser uniqueUser = new XmlUser();
                    uniqueUser.Id = duplicates[0].Id;
                    uniqueUser.Username = duplicates[0].Username;
                    uniqueUser.Phones = new List<Phone>();

                    foreach (var d in duplicates)
                    {
                        Phone phone = d.Phones[0];
                        uniqueUser.Phones.Add(phone);
                    }

                    uniqueUsers.Add(uniqueUser);
                }
            }

            UniqueXmlUsers = uniqueUsers;
        }
    }
}
