using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument studentDoc = new XmlDocument();
            studentDoc.Load(@"C:\Users\HP\Documents\Visual Studio 2017\Projects\HomeworkXML\Task2\Students.xml");
            XmlElement root = studentDoc.DocumentElement;

            XmlElement studentElem = studentDoc.CreateElement("student");

            XmlElement nameElem = studentDoc.CreateElement("name");
            XmlElement groupElem = studentDoc.CreateElement("group");
            XmlElement gpaElem = studentDoc.CreateElement("gpa");

            XmlText nameText = studentDoc.CreateTextNode("Semyon Semyonych");
            XmlText groupText = studentDoc.CreateTextNode("123");
            XmlText gpaText = studentDoc.CreateTextNode("4.0");

            nameElem.AppendChild(nameText);
            groupElem.AppendChild(groupText);
            gpaElem.AppendChild(gpaText);

            studentElem.AppendChild(nameElem);
            studentElem.AppendChild(groupElem);
            studentElem.AppendChild(gpaElem);

            root.AppendChild(studentElem);

            studentDoc.Save(@"C:\Users\HP\Documents\Visual Studio 2017\Projects\HomeworkXML\Task2\Students.xml");

            Student student = new Student();
            student.Name = studentElem["name"].InnerText;
            student.Group = studentElem["group"].InnerText;
            student.GPA = studentElem["gpa"].InnerText;

            Console.WriteLine("Name: {0}\nGroup: {1}\nGPA: {2}", student.Name, student.Group, student.GPA);
            Console.ReadLine();
        }
    }
}
