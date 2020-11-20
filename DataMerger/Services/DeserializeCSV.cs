using DataMerger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMerger.Services
{
    public class DeserializeCSV
    {
        public List<CsvUser> UniqueCsvUsers { get; private set; }
        public List<CsvUser> DateEmpty { get; private set; }
        public List<CsvUser> IncorrectEmail { get; private set; }
        public List<CsvUser> DateOutOfRange { get; private set; }
        public void DeserializeUsersFromCSV(string mainDirectory)
        {
            string csvDirectory = Path.Combine(mainDirectory, "Files", "users.csv");
            List<string> usersCsv = File.ReadLines(csvDirectory).ToList();
            usersCsv.RemoveAt(0);

            List<CsvUser> csvUsers = new List<CsvUser>();

            foreach (var u in usersCsv)
            {
                var temp = u.Replace(@"""", "");
                csvUsers.Add(new CsvUser(temp.Split(',')));
            }

            RemoveCorruptedData(csvUsers);
        }
        public void RemoveCorruptedData(List<CsvUser> csvUsers)
        {
            //as required - exclude users that have and_date < 01.01.2019
            DateTime minDate = Convert.ToDateTime("01.01.2019", System.Globalization.CultureInfo
                .GetCultureInfo("hi-IN").DateTimeFormat);

            DateTime startDate = Convert.ToDateTime("01.01.0001", System.Globalization.CultureInfo
                .GetCultureInfo("hi-IN").DateTimeFormat);

            IncorrectEmail = csvUsers.Where(n => (n.Email == "")
                &&(n.EndDate.Date > minDate.Date))
                .ToList();

            DateEmpty = csvUsers.Where(n => (n.EndDate.Date == startDate.Date)
                && (n.Email != ""))
                .ToList();

            DateOutOfRange = csvUsers.Where(n => n.EndDate.Date < minDate.Date)
                .ToList();

            UniqueCsvUsers = csvUsers.Where(n => (n.Email != "")&&
            (n.EndDate.Date > minDate.Date))
                .ToList();

        }
    }
}
