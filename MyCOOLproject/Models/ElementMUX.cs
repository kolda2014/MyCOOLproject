using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.Models
{
    public class ElementMUX: ObjectInShem
    {
        public int In1, In2, In3, In4;

        public int GetValueIN1
        {
            get => In1;
            set
            {
                SetAndRaise(ref In1, value);
                LogikaMUX();
            }
        }

        public int GetValueIN2
        {
            get => In2;
            set
            {
                SetAndRaise(ref In2, value);
                LogikaMUX();
            }
        }
        public int GetValueIN3
        {
            get => In3;
            set
            {
                SetAndRaise(ref In3, value);
                LogikaMUX();
            }
        }

        public int GetValueIN4
        {
            get => In4;
            set
            {
                SetAndRaise(ref In4, value);
                LogikaMUX();
            }
        }

        public void LogikaMUX()
        {
            if (GetValueIN1 == 0 && GetValueIN2 == 0 && GetValueIN3 == 0)
            {
                ExitValue = 0;
                ExitValue2 = 0;
            }
            else if (GetValueIN1 == 0 && GetValueIN2 == 0 && GetValueIN3 == 1)
            {
                ExitValue = 1;
                ExitValue2 = 0;
            }
            else if (GetValueIN1 == 0 && GetValueIN2 == 1 && GetValueIN3 == 0)
            {
                ExitValue = 0;
                ExitValue2 = 1;
            }
            else if (GetValueIN1 == 0 && GetValueIN2 == 1 && GetValueIN3 == 1)
            {
                ExitValue = 1;
                ExitValue2 = 1;
            }
            else if (GetValueIN1 == 1 && GetValueIN2 == 0 && GetValueIN3 == 0)
            {
                ExitValue = 1;
                ExitValue2 = 1;
            }
            else if (GetValueIN1 == 1 && GetValueIN2 == 0 && GetValueIN3 == 1)
            {
                ExitValue = 1;
                ExitValue2 = 1;
            }
            else if (GetValueIN1 == 1 && GetValueIN2 == 1 && GetValueIN3 == 0)
            {
                ExitValue = 1;
                ExitValue2 = 1;
            }
            else if (GetValueIN1 == 1 && GetValueIN2 == 1 && GetValueIN3 == 1)
            {
                ExitValue = 1;
                ExitValue2 = 1;
            }
        }
    }
}
