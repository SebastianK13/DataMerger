using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataMerger.Models
{
    public class XmlUser
    {
        private Phone phone;
        public XmlUser() { }
        public XmlUser(List<XElement> accountAttributes)
        {
            InsertUserToRepo(accountAttributes);
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public List<Phone> Phones { get; set; }

        public void InsertUserToRepo(List<XElement> accountAttributes)
        {
            phone = new Phone();
            foreach (var a in accountAttributes)
            {
                switch (a.FirstAttribute.Value)
                {
                    case "id":
                        Id = a.Value;
                        break;
                    case "username":
                        Username = a.Value;
                        break;
                    case "phoneType":
                        phone.Type = a.Value;
                        break;
                    case "value":
                        phone.PhoneNumber = FormatPhoneNumber(a.Value);
                        break;
                }
            }
            Phones = new List<Phone>();
            Phones.Add(phone);
        }
        public string FormatPhoneNumber(string number)
        {
            string formatedPhNumber = "";           
            number = Regex.Replace(number, @"[^0-9]+", "");

            if (!String.IsNullOrEmpty(number) && number.Length == 10)
            {
                formatedPhNumber = number.Substring(0, 3) + " " + number.Substring(3, 3) + " " + number.Substring(6, 4);
            }
            return formatedPhNumber;
        }
            
    }
    //if user has more than one phone number in .xml
    public class Phone
    {
        public string Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}
