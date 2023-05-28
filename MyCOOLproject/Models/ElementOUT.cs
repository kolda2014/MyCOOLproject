using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.Models
{
    public class ElementOUT: ObjectInShem
    {
        int OutPoint = 0;
        public int NullorOne
        {
            get => OutPoint;
            set => SetAndRaise(ref OutPoint, value);
        }
        public int In1;
        public int GetValueIN1
        {
            get => In1;
            set => SetAndRaise(ref In1, value);
        }
    }
}
