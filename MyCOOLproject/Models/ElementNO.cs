using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.Models
{
    public class ElementNO : ObjectInShem
    {
        public int In1;

        public int GetValueIN1
        {
            get => In1;
            set
            { 
                SetAndRaise(ref In1, value);
                LogikaNO();
            }
        }
        public void LogikaNO()
        {
            if (GetValueIN1 == 1)
            { 
                ExitValue = 0; 
            }
            else if (GetValueIN1 == 0)
            {
                ExitValue = 1;
            }
        } 
    }
}
