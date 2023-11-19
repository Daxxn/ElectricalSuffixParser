# Electrical Suffix Parser

Parse suffixes used by electrical engineers. such as "K" or "m" as their associated metric exponent. The list of suffixes can be editted using the settings that can be loaded through JSON.

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

### Value Converter:

It would be nice to have this in the library, but that requires more magic than I can muster. Its a Microsoft thing.

Create a class file and throw this in there. Its usually a good idea to separate value converters into its own namespace. It makes things easier to find on the XAML side.

```cs
using System;
using System.Globalization;
using System.Windows.Data;

using ElectricalSuffixParser.Models;
using ElectricalSuffixParser.Parsers;

namespace ProjectNamespace.Converters;

public class SuffixConverter : IValueConverter
{
    // Un-Comment this line and delete the next line, when a custom suffix model is needed:
    //private static SuffixParser parser { get; set; } = new(App.SuffixManager.Suffixes);

    // Otherwise, this line creates the default suffix model:
    private static SuffixParser parser { get; set; } = new(new());

    public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is double output)
        {
            return parser.Convert(output, (string?)parameter);
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string input)
        {
            return parser.ParseInput(input);
        }
        return null;
    }
}
```

### XAML:

```cs
<Window
    xmlns:conv="<path-to-namespace>"
<Window.Resources>
    <conv:SuffixConverter x:Key="SuffixConverter"/>
</Window.Resources>

<TextBox Text="{Binding Path=Value, Converter={StaticResource SuffixConverter}, ConverterParameter=R}"/>
```

### App.xaml.cs file:

This section is for adding or modifying the suffix model. This saves the suffix model to a JSON file in the app data folder. can be ommited if desired.

#### Default settings file path:
```
C:\Users\<user>\AppData\Local\<AppName>\Suffixes\Settings.json
```

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