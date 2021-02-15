using System;
using System.Xml;
using System.IO;
using System.Globalization;
namespace task
{
    class Program
    {
        /* Note: new class added, to handle incoming data from various sources
         e.g. array of data coming in from new xml file/sql dbo 

         static List<Department> allDepartments =
             new List<Department> {
                 new Department { name = "Dep1" },
                 new Department { name = "Dep2" }
             };
         */
        static void Main(string[] args)
        {
            int parcelData = 0;

            XmlDocument xmlDoc = new XmlDocument();
            string XMLpath = Directory.GetCurrentDirectory() + @"\testData.xml";
            xmlDoc.Load(XMLpath);

            XmlNodeList parcelList = xmlDoc.GetElementsByTagName("Parcel");
            parcelData = parcelList.Count;
            for (int i = 0; i < parcelList.Count; i++)
            {

                var weightData = parcelList[i].SelectSingleNode("Weight").InnerText;
                var priceData = parcelList[i].SelectSingleNode("Value").InnerText;

                double weight;
                double.TryParse(weightData, NumberStyles.Any, CultureInfo.InvariantCulture, out weight);
                double price;
                double.TryParse(priceData, NumberStyles.Any, CultureInfo.InvariantCulture, out price);

                if (price > 1000)
                {
                    Console.WriteLine("package needs to be first checked by Insurance department");
                    /* Note: extra code can be added later, to check the weight before sending data to final source */
                }
                if (weight < 1)
                {
                    Console.WriteLine("Mail department");
                }
                else if (weight < 10)
                {
                    Console.WriteLine("Regular department");
                }
                else
                {
                    Console.WriteLine("Heavy department");
                }
            }
        }
    }
}
