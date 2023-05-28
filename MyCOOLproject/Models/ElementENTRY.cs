using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.Models
{
    public class ElementENTRY: ObjectInShem
    {
        int EntryPoint = 0;
        public int NullorOne
        {
            get => EntryPoint;
            set
            {
                SetAndRaise(ref EntryPoint, value);
                ExitValue = EntryPoint;
            }
        }
    }
}
