using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.Models
{
    public class ElementAnd: ObjectInShem
    {
       public int In1, In2;
       
       public int GetValueIN1
        {
           get => In1;
            set
            {
                SetAndRaise(ref In1, value);
                LogikaAND();
            }
        }

        public int GetValueIN2
        {
            get => In2;
            set
            {
                SetAndRaise(ref In2, value);
                LogikaAND();
            }
        }
        public void LogikaAND()
        {
            if (GetValueIN1 == 1 && GetValueIN2 == 1)
            {
                ExitValue = 1;
            }
            else if (GetValueIN1 == 0 && GetValueIN2 == 0)
            {
                ExitValue = 0;
            }
            else if (GetValueIN1 == 1 && GetValueIN2 == 0)
            {
                ExitValue = 0;
            }
            else if (GetValueIN1 == 0 && GetValueIN2 == 1)
            {
                ExitValue = 0;
            }
        }
    }

}
