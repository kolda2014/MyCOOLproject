using Avalonia.Markup.Xaml.Templates;
using MyCOOLproject.Models;
using ReactiveUI;
using System.Collections.ObjectModel;

namespace MyCOOLproject.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<ClassForHistory>? projectHistoryCollection;
        public MainWindowViewModel()
        {
            XMLLoader xmlLoader = new XMLLoader();
            HistoryCollection = new ObservableCollection<ClassForHistory>(xmlLoader.LoadHistoryFile());
        }

        public ObservableCollection<ClassForHistory> HistoryCollection
        {
            get => projectHistoryCollection;
            set => this.RaiseAndSetIfChanged(ref projectHistoryCollection, value);
        }

        public void SaveInHistory(string path)
        {
            XMLSaver xmlSaver = new XMLSaver();
            HistoryCollection.Add(new ClassForHistory
            {
                PathProject = path,
                Name = System.IO.Path.GetFileNameWithoutExtension(path),
            });
            xmlSaver.SaveNewFIleInHistory(HistoryCollection, HistoryCollection[HistoryCollection.Count - 1]);
        }
    }
}