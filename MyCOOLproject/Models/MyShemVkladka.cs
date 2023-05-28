using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.Models
{
    public class MyShemVkladka:AbstractNotifyPropertyChanged
    {
        private string nameVklda;
        private ObservableCollection<ObjectInShem> elements;

        public MyShemVkladka()
        {
            CreateNameVkladka = "NoName";
            Elements = new ObservableCollection<ObjectInShem>();
        }

        public string CreateNameVkladka
        {
            get => nameVklda;
            set => SetAndRaise(ref nameVklda, value);
        }

        public ObservableCollection<ObjectInShem> Elements
        {
            get => elements;
            set => SetAndRaise(ref elements, value);
        }
    }
}
