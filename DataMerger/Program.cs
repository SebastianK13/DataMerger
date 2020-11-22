using DataMerger.Models;
using DataMerger.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            string mainPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            DeserializeJSON deserializeJSON = new DeserializeJSON();
            deserializeJSON.DeserializeUsersFromXML(mainPath);
            DeserializeCSV deserializeCSV = new DeserializeCSV();
            deserializeCSV.DeserializeUsersFromCSV(mainPath);
            UserMergedData userMergedData = new UserMergedData();

            var temp = userMergedData.Encode("bdb294dc-bdec-4d01-96a0-261c6f17f4a5");

            userMergedData.MergeContractorUsers(deserializeJSON.UniqueXmlUsers,
                deserializeCSV.UniqueCsvUsers);

            userMergedData.MergeFulltimeUsers(deserializeJSON.UniqueXmlUsers,
                deserializeCSV.UniqueCsvUsers);

            Console.ReadKey();
        }
    }
}
