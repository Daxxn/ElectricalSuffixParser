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