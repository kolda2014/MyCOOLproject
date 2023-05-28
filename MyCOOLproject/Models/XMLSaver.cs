using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyCOOLproject.Models
{
    internal class XMLSaver
    {
        public void Save(ClassForProject project, string path)
        {
            XDocument xDocument = new XDocument();
            XElement xElementproject = new XElement("project");
            XAttribute xAttributename = new XAttribute("name", project.NameProject);
            xElementproject.Add(xAttributename);
            foreach (MyShemVkladka collection in project.CollectionVkladok)
            {

                XElement xElementColection = new XElement("collection");
                XAttribute xAttributenamee = new XAttribute("name", collection.CreateNameVkladka);
                xElementColection.Add(xAttributenamee);
                foreach (ObjectInShem element in collection.Elements)
                {
                    if (element is ElementAnd elementAND)
                    {
                        XElement xElementClass = new XElement("ElementAnd");
                        XElement xElementStart = new XElement("Start", elementAND.StartPointObject);
                        XElement xElementName = new XElement("name", elementAND.Name);
                        XElement xElementOUTPUT = new XElement("OUT", elementAND.ExitValue);

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementOUTPUT);
                        xElementClass.Add(xElementName);
                        xElementColection.Add(xElementClass);
                    }
                    else if (element is ElementENTRY elementENTRY)
                    {
                        XElement xElementClass = new XElement("ElementENTRY");
                        XElement xElementStart = new XElement("Start", elementENTRY.StartPointObject);
                        XElement xElementName = new XElement("name", elementENTRY.Name);
                        XElement xElementOUTPUT = new XElement("OUT", elementENTRY.ExitValue);

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementOUTPUT);
                        xElementClass.Add(xElementName);
                        xElementColection.Add(xElementClass);
                    }
                    else if (element is ElementMUX elementMUX)
                    {
                        XElement xElementClass = new XElement("ElementMUX");
                        XElement xElementStart = new XElement("Start", elementMUX.StartPointObject);
                        XElement xElementName = new XElement("name", elementMUX.Name);
                        XElement xElementOUTPUT = new XElement("OUT", elementMUX.ExitValue);

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementOUTPUT);
                        xElementClass.Add(xElementName);
                        xElementColection.Add(xElementClass);
                    }
                    else if (element is ElementOR elementOR)
                    {
                        XElement xElementClass = new XElement("elementOR");
                        XElement xElementStart = new XElement("Start", elementOR.StartPointObject);
                        XElement xElementName = new XElement("name", elementOR.Name);
                        XElement xElementOUTPUT = new XElement("OUT", elementOR.ExitValue);

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementOUTPUT);
                        xElementClass.Add(xElementName);
                        xElementColection.Add(xElementClass);
                    }
                    else if (element is ElementISCOR elementISCOR)
                    {
                        XElement xElementClass = new XElement("elementISCOR");
                        XElement xElementStart = new XElement("Start", elementISCOR.StartPointObject);
                        XElement xElementName = new XElement("name", elementISCOR.Name);
                        XElement xElementOUTPUT = new XElement("OUT", elementISCOR.ExitValue);

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementOUTPUT);
                        xElementClass.Add(xElementName);
                        xElementColection.Add(xElementClass);
                    }
                    else if (element is ElementNO elementNO)
                    {
                        XElement xElementClass = new XElement("elementNO");
                        XElement xElementStart = new XElement("Start", elementNO.StartPointObject);
                        XElement xElementName = new XElement("name", elementNO.Name);
                        XElement xElementOUTPUT = new XElement("OUT", elementNO.ExitValue);

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementOUTPUT);
                        xElementClass.Add(xElementName);
                        xElementColection.Add(xElementClass);
                    }
                    else if (element is ElementOUT elementOUT)
                    {
                        XElement xElementClass = new XElement("elementOUT");
                        XElement xElementStart = new XElement("Start", elementOUT.StartPointObject);
                        XElement xElementName = new XElement("name", elementOUT.Name);
                        XElement xElementOUTPUT = new XElement("OUT", elementOUT.GetValueIN1);

                        xElementClass.Add(xElementStart);
                        xElementClass.Add(xElementName);
                        xElementClass.Add(xElementOUTPUT);
                        xElementColection.Add(xElementClass);
                    }
                    else if (element is ClassForLine elementLine)
                    {
                        XElement xElementLine = new XElement("ElementLine");
                        XElement xElementStart = new XElement("Start", elementLine.StartPoint);
                        XElement xElementEnd = new XElement("End", elementLine.EndPoint);
                        XElement xElement1 = new XElement("firstElement", elementLine.FirstElement.Name);
                        XElement xElement2 = new XElement("secondElement", elementLine.SecondElement.Name);
                        XElement xElement1_Name = new XElement("name1", elementLine.NameString1);
                        XElement xElement2_Name = new XElement("name2", elementLine.NameString2);

                        xElementLine.Add(xElementStart);
                        xElementLine.Add(xElementEnd);
                        xElementLine.Add(xElement1);
                        xElementLine.Add(xElement2);
                        xElementLine.Add(xElement1_Name);
                        xElementLine.Add(xElement2_Name);
                        xElementColection.Add(xElementLine);
                    }
                }
                xElementproject.Add(xElementColection);
            }
            xDocument.Add(xElementproject);
            xDocument.Save(path);
        }

        public void SaveHistory(ObservableCollection<ClassForHistory> tempColection)
        {
            string historyPath = "../../../history.xml";
            XDocument xDocument = new XDocument();
            XElement xElementColection = new XElement("historyColection");
            for (int i = 0; i < tempColection.Count && i < 10; i++)
            {
                if (tempColection[i] is ClassForHistory element)
                {
                    XElement xElement = new XElement("project");
                    XAttribute xElementName = new XAttribute("name", element.Name);
                    XElement xElementPAth = new XElement("path", element.PathProject);
                    xElement.Add(xElementName);
                    xElement.Add(xElementPAth);
                    xElementColection.Add(xElement);
                }
            }
            xDocument.Add(xElementColection);
            xDocument.Save(historyPath);
        }

        public void SaveNewFIleInHistory(ObservableCollection<ClassForHistory> tempColection, ClassForHistory newElement)
        {
            string historyPath = "../../../history.xml";
            XDocument xDocument = new XDocument();
            XElement xElementColection = new XElement("historyColection");
            XElement xLastElement = new XElement("project");
            XAttribute xLastName = new XAttribute("name", newElement.Name);
            XElement xLastPAth = new XElement("path", newElement.PathProject);
            xLastElement.Add(xLastName);
            xLastElement.Add(xLastPAth);
            xElementColection.Add(xLastElement);
            for (int i = 0; i < tempColection.Count && i < 10; i++)
            {
                if (tempColection[i] is ClassForHistory element)
                {
                    if (element.PathProject != newElement.PathProject)
                    {
                        XElement xElement = new XElement("project");
                        XAttribute xElementName = new XAttribute("name", element.Name);
                        XElement xElementPAth = new XElement("path", element.PathProject);
                        xElement.Add(xElementName);
                        xElement.Add(xElementPAth);
                        xElementColection.Add(xElement);
                    }
                }
            }
            xDocument.Add(xElementColection);
            xDocument.Save(historyPath);
        }
    }
}