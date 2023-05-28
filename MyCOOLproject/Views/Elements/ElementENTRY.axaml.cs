using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace MyCOOLproject.Views.Elements
{
    public class ElementENTRY : TemplatedControl
    {
        public static readonly StyledProperty<string> PowerProperty =
        AvaloniaProperty.Register<ElementENTRY, string>("Power");

        public string Power
        {
            get => GetValue(PowerProperty);
            set => SetValue(PowerProperty, value);
        }
    }
}
