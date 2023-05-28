using Avalonia.Controls;
using MyCOOLproject.Models;
using MyCOOLproject.ViewModels;

namespace MyCOOLproject.Views
{
    public partial class RenameWindow : Window
    {

        public RenameWindow()
        {
            InitializeComponent();
            DataContext = new RenameViewModelcs();
        }

        public RenameWindow(MyShemVkladka changeElement)
        {
            InitializeComponent();
            DataContext = new RenameViewModelcs(changeElement,this);
        }

        public RenameWindow(ClassForProject changeElement)
        {
            InitializeComponent();
            DataContext = new RenameViewModelcs(changeElement,this);
        }
    }
}
