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
            var usersCsv = DeserializeCSV.DeserializeUsersFromCSV(mainPath);

            Console.ReadKey();
        }
    }
}
