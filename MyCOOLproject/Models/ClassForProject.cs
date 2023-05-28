using DynamicData.Binding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.Models
{
    public class ClassForProject:AbstractNotifyPropertyChanged
    {
        private string nameProject;
        private ObservableCollection<MyShemVkladka> collectionVkladok;

        public ClassForProject()
        {
            NameProject = "NoName";
            CollectionVkladok = new ObservableCollection<MyShemVkladka>();
            CollectionVkladok.Add(new MyShemVkladka());
        }

        public string NameProject
        {
            get => nameProject;
            set => SetAndRaise(ref nameProject, value);
        }

        public ObservableCollection<MyShemVkladka> CollectionVkladok
        {
            get => collectionVkladok;
            set => SetAndRaise(ref collectionVkladok, value);
        }
    }
}
