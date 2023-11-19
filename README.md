# Electrical Suffix Parser

Parse suffixes used by electrical engineers. such as "K" or "m" as their associated exponent. The list of suffixes can be editted using the settings that can be loaded through JSON.

## Console Usage

```cs
string input = "100n";
SuffixModel model = new();
SuffixParser parser = new(model);
double value = parser.ParseInput(input);
Console.WriteLine(value);

double output = 0.1;
Console.WriteLine(parser.Convert(output, "F"));
```

## WPF Usage
NEED TO FIX

--------------------------------------

App.xaml.cs file:
```cs
public partial class App : Application
{
    public static SuffixModelManager SuffixManager;

    protected override void OnStartup(StartupEventArgs e)
    {
        try
        {
            SuffixManager.OnStartup(nameof(<Project Namespace>));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"unable to load Suffix data: {ex.Message}");
        }
        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        try
        {
            SuffixManager.OnExit(nameof(<Project Namespace>));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"unable to save Suffix data: {ex.Message}");
        }
        base.OnExit(e);
    }
}
```

Value Converter:
```cs
public class SuffixConverter : IValueConverter
{
    private static SuffixParser { get; set; } = new(App.SuffixManager.SuffixModel);

    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string input)
        {
            return parser.ParseInput(input);
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double output)
        {
            return parser.Convert(output);
        }
        return null;
    }
}
```

XAML:

```cs
<Window
    
<Window.Resources>
    <
</Window.Resources>

<TextBox Text="{Binding Path=Resisitor, Converter={StaticResource }}"
```