using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Interactivity;
using MyCOOLproject.Models;
using MyCOOLproject.ViewModels;

namespace MyCOOLproject.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        public void CloseWindow(object sender, RoutedEventArgs eventArgs) 
        {this.Close();}

        public void Create(object sender, RoutedEventArgs eventArgs)
        {
            Redactor redactor = new Redactor(this);
            this.Hide();
            redactor.Show();
        }
        public void Open(object sender, RoutedEventArgs eventArgs)
        {
            Redactor redactor = new Redactor(this);
            this.Hide();
            redactor.Show();
            redactor.LoadFile(null,null);
        }

        public async void DoubleTapForOpen(object? sender, RoutedEventArgs e)
        {
            if(DataContext is MainWindowViewModel mainWindowViewModel)
            {
                if(e.Source is ContentPresenter content)
                {
                    if(content.DataContext is ClassForHistory classHistory)
                    {
                        Redactor redactor = new Redactor(this);
                        this.Hide();
                        redactor.Show();
                        redactor.LoadNewFile(classHistory.PathProject);
                        mainWindowViewModel.SaveInHistory(classHistory.PathProject);
                    }
                }
                else if(e.Source is TextBlock textBlock)
                {
                    if(textBlock.DataContext is ClassForHistory classHistoryy)
                    {
                        Redactor redactor = new Redactor(this);
                        this.Hide();
                        redactor.Show();
                        redactor.LoadNewFile(classHistoryy.PathProject);
                        mainWindowViewModel.SaveInHistory(classHistoryy.PathProject);
                    }
                }
            }
        }
    }
}