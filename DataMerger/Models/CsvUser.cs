using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataMerger.Models
{
    public class CsvUser
    {

        public CsvUser(string[] users)
        {
            for(int i = 0; i < users.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        Employee_type = users[i];
                        break;
                    case 1:
                        Id = users[i];
                        break;
                    case 2:
                        First_name = users[i];
                        break;
                    case 3:
                        Last_name = users[i];
                        break;
                    case 4:
                        Email = users[i];
                        break;
                    case 5:
                        Gender = users[i];
                        break;
                    case 6:
                        EndDate = ConvertToDate(users[i]);
                        break;
                    case 7:
                        Ext1 = users[i];
                        break;
                }
            }
        }
        //Check email format
        private string EmailValidation(string email)
        {
            bool isCorrect = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+
                (?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])
                ?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            if (!isCorrect)
                email = "";

            return email;
        }
        private DateTime ConvertToDate(string date)
        {
            DateTime formatedDate = new DateTime();
            if (!String.IsNullOrEmpty(date))
            {
                formatedDate = Convert.ToDateTime(date, System.Globalization.CultureInfo
                        .GetCultureInfo("hi-IN").DateTimeFormat);
            }

            return formatedDate;
        }


        public string Employee_type { get; set; }
        public string Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime EndDate { get; set; }
        public string Ext1 { get; set; }
    }
}
