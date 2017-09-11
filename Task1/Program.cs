using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> habrItems = new List<Item>();

            XmlDocument habrXml = new XmlDocument();
            habrXml.Load("https://habrahabr.ru/rss/interesting/");
            XmlNode habrRoot = habrXml.DocumentElement;
            XmlNode chanel = habrRoot.FirstChild;

            foreach(XmlElement item in chanel)
            {
                if (item.Name == "item")
                {
                    Item habrItem = new Item();
                    habrItem.Title = item["title"].InnerText;
                    habrItem.Link = item["link"].InnerText;
                    habrItem.Description = item["description"].InnerText;
                    habrItem.PubDate = DateTime.Parse(item["pubDate"].InnerText);
                    
                    habrItems.Add(habrItem);
                }
            }
            
            for (int i = 0; i < habrItems.Count; i++)
            {
                Console.WriteLine("Title: ");
                Console.WriteLine(habrItems[i].Title);
                Console.WriteLine();
                Console.WriteLine("Link: ");
                Console.WriteLine(habrItems[i].Link);
                Console.WriteLine();
                Console.WriteLine("Description: ");
                Console.WriteLine(habrItems[i].Description);
                Console.WriteLine();
                Console.WriteLine("PubDate: ");
                Console.WriteLine(habrItems[i].PubDate);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
