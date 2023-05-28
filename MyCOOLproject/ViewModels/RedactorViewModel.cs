using MyCOOLproject.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.ViewModels
{
    public class RedactorViewModel : ViewModelBase
    {
        protected ObservableCollection<ObjectInShem> objectInShems;
        private int selectedVkladka;
        private ClassForProject project;
        public ObservableCollection<MyShemVkladka> SpisokVkladok;
        public RedactorViewModel()
        {
            //objectInShems = new ObservableCollection<ObjectInShem>();
            //objectCollection = objectInShems;
            project = new ClassForProject();
            Project = project;
            SelectedVkladka = 0;
        }
        public ObservableCollection<ObjectInShem> objectCollection
        {
            get => objectInShems;
            set => this.RaiseAndSetIfChanged(ref objectInShems, value);
        }
        protected int NamePushButton = 0;

        public int GetorSetNameButton
        {
            get => NamePushButton;
            set => this.RaiseAndSetIfChanged(ref NamePushButton, value);
        }

        public void ViborNameButton(string NameButton)
        {
           
           if(NameButton == "A"){ 
                int temp = 1; 
                if(temp != GetorSetNameButton) GetorSetNameButton = 1; 
                else GetorSetNameButton = 0;
            }
           else if (NameButton == "O") {
                int temp = 2;
                if (temp != GetorSetNameButton) GetorSetNameButton = 2;
                else GetorSetNameButton = 0;
            }
           else if (NameButton == "NO") {
                int temp = 3;
                if (temp != GetorSetNameButton) GetorSetNameButton = 3;
                else GetorSetNameButton = 0;
            }
           else if (NameButton == "I") {
                int temp = 4;
                if (temp != GetorSetNameButton) GetorSetNameButton = 4;
                else GetorSetNameButton = 0;
            }
           else if (NameButton == "M") {
                int temp = 5;
                if (temp != GetorSetNameButton) GetorSetNameButton = 5;
                else GetorSetNameButton = 0;
            }
           else if (NameButton == "E") {
                int temp = 6;
                if (temp != GetorSetNameButton) GetorSetNameButton = 6;
                else GetorSetNameButton = 0;
            }
           else if (NameButton == "OUT") {
                int temp = 7;
                if (temp != GetorSetNameButton) GetorSetNameButton = 7;
                else GetorSetNameButton = 0;
            }
        }

        public int SelectedVkladka
        {
            get => selectedVkladka;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedVkladka, value);

                if (SelectedVkladka < 0)
                {
                    SelectedVkladka = 0;
                }

                if (Project.CollectionVkladok.Count == 0)
                {
                    objectCollection = null;
                }
                else
                {
                    objectCollection = Project.CollectionVkladok[SelectedVkladka].Elements;
                    ClassForLine templine = new ClassForLine();
                    templine.CheckLineAndBlock(objectCollection);
                }
            }
        }

        public ClassForProject Project
        {
            get => project;
            set
            {
                this.RaiseAndSetIfChanged(ref project, value);
                DrawProjectName = Project.NameProject;
                DrawVkladkaList = Project.CollectionVkladok;
            }
        }

        public ObservableCollection<MyShemVkladka> DrawVkladkaList
        {
            get => SpisokVkladok;
            set => this.RaiseAndSetIfChanged(ref SpisokVkladok, value);
            
        }
        public string ProjectName; //вытащить из класса имя проекта
        public string DrawProjectName
        {
            get => ProjectName;
            set=> this.RaiseAndSetIfChanged(ref ProjectName, value);
        }

    }
}
