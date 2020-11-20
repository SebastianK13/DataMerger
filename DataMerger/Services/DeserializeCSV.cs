using DataMerger.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMerger.Services
{
    public static class DeserializeCSV
    {
        public static List<CsvUser> DeserializeUsersFromCSV(string mainDirectory)
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

            return csvUsers;
        }
    }
}
