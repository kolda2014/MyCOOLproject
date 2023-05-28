using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace MyCOOLproject.Views.Elements
{
    public class ElementOUT : TemplatedControl
    {
        public static readonly StyledProperty<string> PowerProperty =
       AvaloniaProperty.Register<ElementOUT, string>("Power");

        public string Power
        {
            get => GetValue(PowerProperty);
            set => SetValue(PowerProperty, value);
        }
    }
}
