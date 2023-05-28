using Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.Models
{
    public class ClassForLine : ObjectInShem
    {
        private Point startPoint;
        private Point endPoint;
        private ObjectInShem firstElement;
        private ObjectInShem secondElement;

        public Point StartPoint
        {
            get => startPoint;
            set => SetAndRaise(ref startPoint, value);
        }

        public string NameString1
        {
            get;
            set;
        }

        public string NameString2
        {
            get;
            set;
        }

        public Point EndPoint
        {
            get => endPoint;
            set => SetAndRaise(ref endPoint, value);
        }

        public ObjectInShem FirstElement
        {
            get => firstElement;
            set
            {
                if (firstElement != null)
                {
                    firstElement.NewStartPoint -= OnFirstRectanglePositionChanged;
                }

                firstElement = value;

                if (firstElement != null)
                {
                    firstElement.NewStartPoint += OnFirstRectanglePositionChanged;
                    firstElement.NewStatus += CheckSmenaSignal;
                }
            }
        }
        public ObjectInShem SecondElement
        {
            get => secondElement;
            set
            {
                if (secondElement != null)
                {
                    secondElement.NewStartPoint -= OnSecondRectanglePositionChanged;
                }

                secondElement = value;

                if (secondElement != null)
                {
                    secondElement.NewStartPoint += OnSecondRectanglePositionChanged;
                }
            }
        }

        private void OnFirstRectanglePositionChanged(object? sender, CheckLine e)
        {
            StartPoint += e.NewStartPoint - e.OldStartPoint;
        }

        private void OnSecondRectanglePositionChanged(object? sender, CheckLine e)
        {
            EndPoint += e.NewStartPoint - e.OldStartPoint;
        }

        public void Dispose()
        {
            if (FirstElement != null)
            {
                firstElement.NewStartPoint -= OnFirstRectanglePositionChanged;
                firstElement.NewStatus -= CheckSmenaSignal;
            }

            if (SecondElement != null)
            {
                secondElement.NewStartPoint -= OnSecondRectanglePositionChanged;
            }
        }

        private void CheckSmenaSignal(object? sender, CheackStatus e)
        {
            if (SecondElement is ElementAnd elementAnd)
            {
                if (NameString2.Equals("AndIn1") == true)
                {
                    elementAnd.GetValueIN1 = e.Status;
                }
                else if (NameString2.Equals("AndIn2") == true)
                {
                    elementAnd.GetValueIN2 = e.Status;
                }
            }
            else if (SecondElement is ElementOUT elementOUT)
            {
                if (NameString2.Equals("OUTIn") == true)
                {
                    elementOUT.NullorOne = e.Status;
                }
            }
            else if (SecondElement is ElementOR elementOR)
            {
                if (NameString2.Equals("ORIn1") == true)
                {
                    elementOR.GetValueIN1 = e.Status;
                }
                else if (NameString2.Equals("ORIn2") == true)
                {
                    elementOR.GetValueIN2 = e.Status;
                }
            }
            else if (SecondElement is ElementNO elementNO)
            {
                if (NameString2.Equals("NOIn1") == true)
                {
                    elementNO.GetValueIN1 = e.Status;
                }
            }
            else if (SecondElement is ElementISCOR elementISCOR)
            {
                if (NameString2.Equals("ORIn1") == true)
                {
                    elementISCOR.GetValueIN1 = e.Status;
                }
                else if (NameString2.Equals("ORIn2") == true)
                {
                    elementISCOR.GetValueIN2 = e.Status;
                }
            }
            else if (SecondElement is ElementMUX elementMUX)
            {
                if (NameString2.Equals("MUXIn1") == true)
                {
                    elementMUX.GetValueIN1 = e.Status;
                }
                else if (NameString2.Equals("MUXIn2") == true)
                {
                    elementMUX.GetValueIN2 = e.Status;
                }
                else if (NameString2.Equals("MUXIn3") == true)
                {
                    elementMUX.GetValueIN3 = e.Status;
                }
                else if (NameString2.Equals("MUXIn4") == true)
                {
                    elementMUX.GetValueIN4 = e.Status;
                }
            }

        }
        public string Name1
        {
            get;
            set;
        }
        public string Name2
        {
            get;
            set;
        }
        public void CheckLineAndBlock(ObservableCollection<ObjectInShem> currentcollection)
        {
            for (int i = currentcollection.Count - 1; i >= 0; i--)
            {
                if (currentcollection[i] is ClassForLine currentLine)
                {
                    int findConection = 0;
                    for (int j = 0; j < currentcollection.Count; j++)
                    {
                        if (j == i) continue;
                        if (currentcollection[j] is ObjectInShem currentClass)
                        {
                            if (currentClass.Name == currentLine.Name1)
                            {
                                currentLine.FirstElement = currentClass;
                                findConection++;
                            }
                            if (currentClass.Name == currentLine.Name2)
                            {
                                currentLine.SecondElement = currentClass;
                                findConection++;
                            }
                        }
                        if (findConection == 2) break;
                    }
                }
            }
        }
    }

}
