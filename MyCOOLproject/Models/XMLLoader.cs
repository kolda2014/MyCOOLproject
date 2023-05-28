using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyCOOLproject.Models
{
    public class XMLLoader
    {
        public ClassForProject Load(string path)
        {
            XDocument xDocument = XDocument.Load(path);
            XElement? collection = xDocument.Element("project");
            if (collection is not null)
            {
                var name = collection.Attribute("name");
                ObservableCollection<MyShemVkladka> loadVkladka = new ObservableCollection<MyShemVkladka>();
                foreach (XElement xcollection in collection.Elements("collection"))
                {
                    var nameVkladka = xcollection.Attribute("name");
                    ObservableCollection<ObjectInShem> loadCollection = new ObservableCollection<ObjectInShem>();
                    foreach (XElement classElement in xcollection.Elements("ElementAnd"))
                    {

                        var point = classElement.Element("Start");
                        var nameElement = classElement.Element("name");
                        var OUTPUT = classElement.Element("OUT");

                        ElementAnd elementAnd = new ElementAnd
                        {
                            StartPointObject = Avalonia.Point.Parse(point.Value),
                            Name = nameElement.Value,
                            ExitValue = int.Parse(OUTPUT.Value),
                        };
                        loadCollection.Add(elementAnd);
                    }
                    foreach (XElement classElement in xcollection.Elements("ElementENTRY"))
                    {

                        var point = classElement.Element("Start");
                        var nameElement = classElement.Element("name");
                        var OUTPUT = classElement.Element("OUT");

                        ElementENTRY elementENTRY = new ElementENTRY
                        {
                            StartPointObject = Avalonia.Point.Parse(point.Value),
                            Name = nameElement.Value,
                            NullorOne = int.Parse(OUTPUT.Value),
                            ExitValue = int.Parse(OUTPUT.Value),
                        };
                        loadCollection.Add(elementENTRY);
                    }
                    foreach (XElement classElement in xcollection.Elements("ElementMUX"))
                    {

                        var point = classElement.Element("Start");
                        var nameElement = classElement.Element("name");
                        var OUTPUT = classElement.Element("OUT");

                        ElementMUX elementMUX = new ElementMUX
                        {
                            StartPointObject = Avalonia.Point.Parse(point.Value),
                            Name = nameElement.Value,
                            ExitValue = int.Parse(OUTPUT.Value),
                        };
                        loadCollection.Add(elementMUX);
                    }
                    foreach (XElement classElement in xcollection.Elements("elementOR"))
                    {

                        var point = classElement.Element("Start");
                        var nameElement = classElement.Element("name");
                        var OUTPUT = classElement.Element("OUT");

                        ElementOR elementOR = new ElementOR
                        {
                            StartPointObject = Avalonia.Point.Parse(point.Value),
                            Name = nameElement.Value,
                            ExitValue = int.Parse(OUTPUT.Value),
                        };
                        loadCollection.Add(elementOR);
                    }
                    foreach (XElement classElement in xcollection.Elements("elementISCOR"))
                    {

                        var point = classElement.Element("Start");
                        var nameElement = classElement.Element("name");
                        var OUTPUT = classElement.Element("OUT");

                        ElementISCOR elementISCOR = new ElementISCOR
                        {
                            StartPointObject = Avalonia.Point.Parse(point.Value),
                            Name = nameElement.Value,
                            ExitValue = int.Parse(OUTPUT.Value),
                        };
                        loadCollection.Add(elementISCOR);
                    }
                    foreach (XElement classElement in xcollection.Elements("elementNO"))
                    {

                        var point = classElement.Element("Start");
                        var nameElement = classElement.Element("name");
                        var OUTPUT = classElement.Element("OUT");

                        ElementNO elementNO = new ElementNO
                        {
                            StartPointObject = Avalonia.Point.Parse(point.Value),
                            Name = nameElement.Value,
                            ExitValue = int.Parse(OUTPUT.Value),
                        };
                        loadCollection.Add(elementNO);
                    }
                    foreach (XElement classElement in xcollection.Elements("elementOUT"))
                    {

                        var point = classElement.Element("Start");
                        var nameElement = classElement.Element("name");
                        var OUTPUT = classElement.Element("OUT");

                        ElementOUT elementOUT = new ElementOUT
                        {
                            StartPointObject = Avalonia.Point.Parse(point.Value),
                            Name = nameElement.Value,
                            NullorOne = int.Parse(OUTPUT.Value),
                            ExitValue = int.Parse(OUTPUT.Value),
                        };
                        loadCollection.Add(elementOUT);
                    }

                    foreach (XElement lineElement in xcollection.Elements("ElementLine"))
                    {

                        var lineStart = lineElement.Element("Start");
                        var lineEnd = lineElement.Element("End");
                        var firstElementName = lineElement.Element("firstElement");
                        var secondElementName = lineElement.Element("secondElement");
                        var name1 = lineElement.Element("name1");
                        var name2 = lineElement.Element("name2");

                        ClassForLine lineElementCollection = new ClassForLine();

                        lineElementCollection.StartPoint = Avalonia.Point.Parse(lineStart.Value);
                        lineElementCollection.EndPoint = Avalonia.Point.Parse(lineEnd.Value);
                        lineElementCollection.Name1 = firstElementName.Value;
                        lineElementCollection.Name2 = secondElementName.Value;
                        lineElementCollection.NameString1 = name1.Value;
                        lineElementCollection.NameString2 = name2.Value;

                        loadCollection.Add(lineElementCollection);
                    }
                    MyShemVkladka shema = new MyShemVkladka
                    {
                        CreateNameVkladka = nameVkladka.Value,
                        Elements = loadCollection,
                    };
                    loadVkladka.Add(shema);
                }
                ClassForProject classForProject = new ClassForProject
                {
                    CollectionVkladok = loadVkladka,
                    NameProject = name.Value,
                };
                if (classForProject != null)
                {
                    return classForProject;
                }
                
                else return new ClassForProject();
            }
            return new ClassForProject();
        }

        public IEnumerable<ClassForHistory> LoadHistoryFile()
        {
            string historyPath = "../../../history.xml";
            XDocument xDocument = XDocument.Load(historyPath);
            XElement? xColection = xDocument.Element("historyColection");
            if (xColection is not null)
            {
                ObservableCollection<ClassForHistory> historyColection = new ObservableCollection<ClassForHistory>();
                foreach (XElement projectElement in xColection.Elements("project"))
                {
                    var projectName = projectElement.Attribute("name");
                    var projectPath = projectElement.Element("path");
                    ClassForHistory projectHistory = new ClassForHistory
                    {
                        Name = projectName.Value,
                        PathProject = projectPath.Value,
                    };
                    historyColection.Add(projectHistory);
                }
                if (historyColection != null)
                {
                    return historyColection;
                }
                else return new List<ClassForHistory>();
            }
            else return new List<ClassForHistory>();
        }
    }
}
