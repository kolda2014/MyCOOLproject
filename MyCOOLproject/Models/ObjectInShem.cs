using Avalonia;
using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.Models
{
    public class ObjectInShem: AbstractNotifyPropertyChanged
    {
        protected Avalonia.Point StartPoint;
        public event EventHandler<CheckLine> NewStartPoint;
        public event EventHandler<CheackStatus> NewStatus;
        public Avalonia.Point StartPointObject
        {
            get => StartPoint;
            set
            {
                Point oldPoint = StartPointObject;
                SetAndRaise(ref StartPoint, value);
                if (NewStartPoint != null)
                {
                    CheckLine args = new CheckLine
                    {
                        OldStartPoint = oldPoint,
                        NewStartPoint = StartPointObject,
                    };
                    NewStartPoint(this, args);
                }

            }
        }

        public int OutValueElement;
        public int ExitValue
        {
            get => OutValueElement;
            set
            {
                SetAndRaise(ref OutValueElement, value);
                if (NewStatus != null)
                {
                    CheackStatus args = new CheackStatus
                    {
                        Status = ExitValue
                    };
                    NewStatus(this, args);
                }
            }
        }

        public int ExitValue2
        {
            get => OutValueElement;
            set
            {
                SetAndRaise(ref OutValueElement, value);
                if (NewStatus != null)
                {
                    CheackStatus args = new CheackStatus
                    {
                        Status = ExitValue2
                    };
                    NewStatus(this, args);
                }
            }
        }

        public string Name
        {
            get;
            set;
        }
    }
}
