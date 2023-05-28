using MyCOOLproject.Models;
using MyCOOLproject.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCOOLproject.ViewModels
{
    public class RenameViewModelcs: ViewModelBase
    {
        private string nameVkladka = string.Empty;
        private MyShemVkladka? circuit;
        private ClassForProject? project;
        private RenameWindow renameWindow;

        public RenameViewModelcs()
        {
            circuit = null;
            project = null;
        }

        public RenameViewModelcs(MyShemVkladka changeElement, RenameWindow tempWindow)
        {
            circuit = changeElement;
            project = null;
            renameWindow = tempWindow;
        }

        public RenameViewModelcs(ClassForProject changeElement,RenameWindow tempWindow)
        {
            circuit = null;
            project = changeElement;
            renameWindow = tempWindow;
        }

        public string NameVkladka
        {
            get => nameVkladka;
            set => this.RaiseAndSetIfChanged(ref nameVkladka, value);
        }

        public void ButtonSave()
        {
            if (circuit != null)
            {
                if (string.IsNullOrWhiteSpace(NameVkladka) == false)
                {
                    circuit.CreateNameVkladka = NameVkladka;
                    renameWindow.Close();
                }
            }
            else if (project != null)
            {
                if (string.IsNullOrWhiteSpace(NameVkladka) == false)
                {
                    project.NameProject = NameVkladka;
                    renameWindow.Close();
                }
            }
        }

        public void ButtonClear()
        {
            NameVkladka = string.Empty;
        }
    }
}
