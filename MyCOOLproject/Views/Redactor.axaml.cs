using Avalonia.Controls;
using Avalonia.Interactivity;
using MyCOOLproject.ViewModels;
using MyCOOLproject.Models;
using Avalonia.Input;
using Avalonia.VisualTree;
using System.Linq;
using JetBrains.Annotations;
using Avalonia.Controls.Shapes;
using Avalonia;
using System.ComponentModel;
using System.Xml.Linq;

namespace MyCOOLproject.Views
{
    public partial class Redactor : Window
    {
        private int elementAnd = 0, elementEntry = 0, elementMUX = 0, elementOR = 0,  elementNO = 0, elementISCOR = 0, elementOUT = 0;
        private Avalonia.Point Cursor;
        private Avalonia.Point CursorOnElement;
        private MainWindow insaidWindow;
        private ObjectInShem LastPushElement;
        public Redactor()
        {
            InitializeComponent();
        }
        public Redactor(MainWindow mainWindow)
        {
            InitializeComponent();
            this.KeyUp += DelElement;
            DataContext = new RedactorViewModel();
            insaidWindow = mainWindow;
        }
        public void CloseWindow(object sender, RoutedEventArgs eventArgs)
        { this.Close(); insaidWindow.Close(); }

        public void ClickElement(object sender, RoutedEventArgs eventArgs)
        {
            if (this.DataContext is RedactorViewModel dataContext)
            {
                if (sender is Button button)
                {
                    dataContext.ViborNameButton(button.Name);
                }
            }
        }

        public void AddOnHolstElement(object sender, PointerPressedEventArgs pointerPressed)
        {
            if (this.DataContext is RedactorViewModel dataContext)
            {
                Cursor = pointerPressed
                .GetPosition(
                this.GetVisualDescendants()
                .OfType<Canvas>()
                .FirstOrDefault());
                if (dataContext.GetorSetNameButton == 1)
                {
                    dataContext.objectCollection.Add(new ElementAnd { StartPointObject = new Avalonia.Point(Cursor.X, Cursor.Y),
                        Name = $"elementAnd {elementAnd}",
                    });
                    elementAnd += 1;
                }
                else if (dataContext.GetorSetNameButton == 2)
                {
                    dataContext.objectCollection.Add(new ElementOR { StartPointObject = new Avalonia.Point(Cursor.X, Cursor.Y),
                        Name = $"elementOR{elementOR}",
                    });
                    elementOR += 1;
                }
                else if (dataContext.GetorSetNameButton == 3)
                {
                    dataContext.objectCollection.Add(new ElementNO { StartPointObject = new Avalonia.Point(Cursor.X, Cursor.Y),
                        Name = $"elementNO {elementNO}",
                    });
                    elementNO += 1;
                }
                else if (dataContext.GetorSetNameButton == 4)
                {
                    dataContext.objectCollection.Add(new ElementISCOR { StartPointObject = new Avalonia.Point(Cursor.X, Cursor.Y),
                        Name = $"elementISCOR {elementISCOR}",
                    });
                    elementISCOR += 1;
                }
                else if (dataContext.GetorSetNameButton == 5)
                {
                    dataContext.objectCollection.Add(new ElementMUX { StartPointObject = new Avalonia.Point(Cursor.X, Cursor.Y),
                        Name = $"elementMUX {elementMUX}",
                    });
                    elementMUX += 1;
                }
                else if (dataContext.GetorSetNameButton == 6)
                {
                    dataContext.objectCollection.Add(new ElementENTRY { StartPointObject = new Avalonia.Point(Cursor.X, Cursor.Y),
                        Name = $"elementEntry {elementEntry}",
                    });
                    elementEntry += 1;
                }
                else if (dataContext.GetorSetNameButton == 7)
                {
                    dataContext.objectCollection.Add(new ElementOUT { StartPointObject = new Avalonia.Point(Cursor.X, Cursor.Y),
                        Name = $"elementOUT {elementOUT}",
                    });
                    elementOUT += 1;
                }
                else if (dataContext.GetorSetNameButton == 0)
                {
                    if (pointerPressed.Source is Path path)
                    {
                        if (path.DataContext is ObjectInShem objectIn)
                        {
                            LastPushElement = objectIn;
                        }
                        CursorOnElement = pointerPressed.GetPosition(path);
                        this.PointerMoved += PointerMoveDragShape;
                        this.PointerReleased += PointerReleasDragShape;
                    }
                    else if (pointerPressed.Source is Rectangle rectangle)
                    {
                        if (rectangle.DataContext is ObjectInShem objectIn)
                        {
                            LastPushElement = objectIn;
                        }
                        CursorOnElement = pointerPressed.GetPosition(rectangle);
                        this.PointerMoved += PointerMoveDragShape;
                        this.PointerReleased += PointerReleasDragShape;
                    }
                    else if (pointerPressed.Source is Ellipse ellipse)
                    {
                        if (ellipse.Name.Contains("In") == true)
                        {
                            if (ellipse.DataContext is ObjectInShem objectInShem)
                            {
                                dataContext.objectCollection.Add(new ClassForLine
                                {
                                    StartPoint = Cursor,
                                    EndPoint = Cursor,
                                    SecondElement = objectInShem,
                                    NameString2 = ellipse.Name,
                                    Name2 = objectInShem.Name,
                                }) ;
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
                        }
                        else if (ellipse.Name.Contains("Exit") == true)
                        {
                            if (ellipse.DataContext is ObjectInShem objectInShem)
                            {
                                dataContext.objectCollection.Add(new ClassForLine
                                {
                                    StartPoint = Cursor,
                                    EndPoint = Cursor,
                                    FirstElement = objectInShem,
                                    NameString1 = ellipse.Name,
                                    Name1 = objectInShem.Name,
                                });
                                this.PointerMoved += PointerMoveDrawLine;
                                this.PointerReleased += PointerPressedReleasedDrawLine;
                            }
                        }
                        else if (ellipse.DataContext is ObjectInShem objectIn)
                        {
                            LastPushElement = objectIn;

                            CursorOnElement = pointerPressed.GetPosition(ellipse);
                            this.PointerMoved += PointerMoveDragShape;
                            this.PointerReleased += PointerReleasDragShape;
                        }
                    }
                    else if(pointerPressed.Source is Line line)
                    {
                        if (line.DataContext is ClassForLine objectInShem)
                        {
                            LastPushElement = objectInShem;
                        }    
                    }
                }
            }
        }
        public void PointerMoveDragShape(object? sender, PointerEventArgs pointerEventArgs)
        {
            Avalonia.Point curentPosition = pointerEventArgs
                    .GetPosition(
                    this.GetVisualDescendants()
                    .OfType<Canvas>()
                    .FirstOrDefault());
            if (pointerEventArgs.Source is Path path)
            {
                if (path.DataContext is ObjectInShem objectIn)
                {
                    objectIn.StartPointObject = new Avalonia.Point(curentPosition.X - CursorOnElement.X, curentPosition.Y - CursorOnElement.Y);
                }
            }
            else if (pointerEventArgs.Source is Rectangle rectangle)
            {
                if (rectangle.DataContext is ObjectInShem objectIn)
                {
                    objectIn.StartPointObject = new Avalonia.Point(curentPosition.X - CursorOnElement.X, curentPosition.Y - CursorOnElement.Y);
                }
            }
            else if (pointerEventArgs.Source is Ellipse ellipse)
            {
                if (ellipse.DataContext is ObjectInShem objectIn)
                {
                    objectIn.StartPointObject = new Avalonia.Point(curentPosition.X - CursorOnElement.X, curentPosition.Y - CursorOnElement.Y);
                }
            }
        }
        public void PointerReleasDragShape(object? sender, PointerReleasedEventArgs pREA)
        {
            this.PointerMoved -= PointerMoveDragShape;
            this.PointerReleased -= PointerReleasDragShape;
        }
        public void DelElement(object? sender, KeyEventArgs e)
        {
            if (this.DataContext is RedactorViewModel datacontext)
            {
                if (e.Key == Key.Delete)
                {
                    if (LastPushElement != null)
                    {
                        datacontext.objectCollection.Remove(LastPushElement);
                    }
                }
            }
        }
        private void PointerMoveDrawLine(object? sender, PointerEventArgs pointerEventArgs)
        {
            if (DataContext is RedactorViewModel viewModel)
            {
                ClassForLine connector = viewModel.Project.CollectionVkladok[viewModel.SelectedVkladka].Elements[viewModel.Project.CollectionVkladok[viewModel.SelectedVkladka].Elements.Count - 1] as ClassForLine;
                Point currentPointerPosition = pointerEventArgs.GetPosition(this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault());

                connector.EndPoint = new Point(
                        currentPointerPosition.X - 1,
                        currentPointerPosition.Y - 1);
            }
        }
        private void PointerPressedReleasedDrawLine(object? sender, PointerReleasedEventArgs pointerReleasedEventArgs)
        {
            this.PointerMoved -= PointerMoveDrawLine;
            this.PointerReleased -= PointerPressedReleasedDrawLine;

            var canvas = this.GetVisualDescendants().OfType<Canvas>().FirstOrDefault(canvas => string.IsNullOrEmpty(canvas.Name) == false && canvas.Name.Equals("Holst"));
            var coords = pointerReleasedEventArgs.GetPosition(canvas);
            var shape = canvas.InputHitTest(coords);
            if(DataContext is RedactorViewModel viewModel)
            {
                if (shape is Ellipse ellipse)
                {
                    if (ellipse.DataContext is ObjectInShem objectIn)
                    {
                        ClassForLine line = viewModel.objectCollection[viewModel.objectCollection.Count - 1] as ClassForLine;
                        if (ellipse.Name.Contains("In") == true)
                        {
                            if (line.SecondElement == null)
                            {
                                line.NameString2 = ellipse.Name;
                                line.SecondElement = objectIn;
                                line.Name2 = objectIn.Name;
                                return;
                            }
                        }
                        else if (ellipse.Name.Contains("Exit") == true)
                        {
                            if (line.FirstElement == null)
                            {
                                line.NameString1 = ellipse.Name;
                                line.FirstElement = objectIn;
                                line.Name1 = objectIn.Name;
                                return;
                            }
                            
                        }
                    }
                }
                viewModel.objectCollection.RemoveAt(viewModel.objectCollection.Count - 1);
            }
        }
        private void DoubleTapOnCanvas(object sender, RoutedEventArgs e)
        {
            if (DataContext is RedactorViewModel viewModel)
            {
                var src = e.Source;
                if (src == null) return;

                if (src is Rectangle rect)
                {
                    if (rect.DataContext is ElementENTRY element)
                    {
                        element.NullorOne = (element.NullorOne == 0)?1:0;
                    }
                }
            }
        }
        public void AddShem(object sender, RoutedEventArgs eventArgs)
        {
            if (DataContext is RedactorViewModel datacontext)
            {
                datacontext.DrawVkladkaList.Add(new MyShemVkladka());
            }
        }

        public void DelShem(object sender, RoutedEventArgs eventArgs)
        {
            if (DataContext is RedactorViewModel datacontext)
            {
                if (datacontext.DrawVkladkaList.Count > 1) datacontext.DrawVkladkaList.RemoveAt(datacontext.SelectedVkladka);
            }
        }
        public async void DoubleTapForRename(object? sender, RoutedEventArgs e)
        {
            if (DataContext is RedactorViewModel viewModel)
            {
                if (e.Source is TextBlock textBlock)
                {
                    if (textBlock.DataContext is MyShemVkladka vkladka)
                    {
                        MyShemVkladka? vkladkaTemp = vkladka;
                        RenameWindow? changeNameWindow = new RenameWindow(vkladkaTemp);
                        changeNameWindow.ShowDialog(this);
                    }
                    else if (textBlock.DataContext is ClassForProject project)
                    {
                        ClassForProject? projectTemp = project;
                        RenameWindow? changeNameWindow = new RenameWindow(projectTemp);
                        changeNameWindow.ShowDialog(this);
                    }
                    else if (textBlock.DataContext is RedactorViewModel redactor)
                    {
                        ClassForProject? projectTemp = redactor.Project;
                        RenameWindow? changeNameWindow = new RenameWindow(projectTemp);
                        await changeNameWindow.ShowDialog(this);
                        viewModel.DrawProjectName = projectTemp.NameProject;
                    }
                }
            }
        }
        public async void SaveFile(object sender, RoutedEventArgs args)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filters.Add(new FileDialogFilter
            {
                Name = "Я люблю ВАС сильно",
                Extensions = new string[] { "xml" }.ToList()
            });
            string? path = await saveFileDialog.ShowAsync(this);

            if (path != null)
            {
                if (this.DataContext is RedactorViewModel programmWindowViewModel)
                {
                    var xmlCollectionSaver = new XMLSaver();
                    xmlCollectionSaver.Save(programmWindowViewModel.Project, path);
                    if(insaidWindow.DataContext is MainWindowViewModel mainWindowViewModel)
                    {
                        mainWindowViewModel.SaveInHistory(path);
                    }
                }
            }
        }
        public async void LoadFile(object sender, RoutedEventArgs eventArgs)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filters.Add(new FileDialogFilter
            {
                Name = "Я люблю ВАС сильно",
                Extensions = new string[] { "xml" }.ToList()
            });

            string[]? path = await openFileDialog.ShowAsync(this);
            if (path != null)
            {
                if (this.DataContext is RedactorViewModel programmWindowViewModel)
                {
                    var xmlCollectionLoader = new XMLLoader();
                    programmWindowViewModel.Project = xmlCollectionLoader.Load(path[0]);
                    if (insaidWindow.DataContext is MainWindowViewModel mainWindowViewModel)
                    {
                        mainWindowViewModel.SaveInHistory(path[0]);
                    }
                }
            }
        }

        public void LoadNewFile(string path)
        {
            if (path != null)
            {
                if (this.DataContext is RedactorViewModel programmWindowViewModel)
                {
                    var xmlCollectionLoader = new XMLLoader();
                    programmWindowViewModel.Project = xmlCollectionLoader.Load(path);
                }
            }
        }

        public void CreateProject(object sender, RoutedEventArgs eventArgs)
        {
            if (DataContext is RedactorViewModel redactorViewModel)
            {
                redactorViewModel.Project = new ClassForProject();
                redactorViewModel.SelectedVkladka = 0;
            }
        }
    }
}
