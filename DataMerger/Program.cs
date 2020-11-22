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
            Console.WriteLine("Please insert path to folder where you store data files:");
            string filesLocation = Console.ReadLine();


            if (File.Exists(filesLocation+"\\phone.xml") && File.Exists(filesLocation+"\\users.csv"))
            {
                DeserializeJSON deserializeJSON = new DeserializeJSON();
                deserializeJSON.DeserializeUsersFromXML(mainPath);
                DeserializeCSV deserializeCSV = new DeserializeCSV();
                deserializeCSV.DeserializeUsersFromCSV(mainPath);
                UserMergedData userMergedData = new UserMergedData();

                userMergedData.MergeContractorUsers(deserializeJSON.UniqueXmlUsers,
                    deserializeCSV.UniqueCsvUsers);

                userMergedData.MergeFulltimeUsers(deserializeJSON.UniqueXmlUsers,
                    deserializeCSV.UniqueCsvUsers);

                ReportGenerator reportGenerator = new ReportGenerator(userMergedData, deserializeJSON, deserializeCSV);
                reportGenerator.GenerateOutputs(mainPath);

                Console.WriteLine("Operation success");
            }
            else
            {
                Console.WriteLine("Operation failed, wrong path, file or files doesn't exist in the directory which was pointed");
            }

            //Implement in DeserializeXML
            //ObjectList objectList = new ObjectList();
            //objectList.DeserializeXML(mainPath);

            Console.ReadKey();
        }
    }
}
