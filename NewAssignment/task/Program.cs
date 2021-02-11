using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalC = 0;

            XmlDocument xmlDoc = new XmlDocument();
            string XMLpath = Directory.GetCurrentDirectory() + @"\testData.xml";
            xmlDoc.Load(XMLpath);

            XmlNodeList CList = xmlDoc.GetElementsByTagName("Weight");
            totalC = CList.Count;
            for (int i = 0; i < CList.Count; i++)
            {
                Console.WriteLine(CList[i].InnerText.ToString());
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(totalC.ToString() + "entries in the sheet");
            Console.ReadLine();
        }
    }
}
