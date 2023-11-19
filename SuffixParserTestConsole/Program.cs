using ElectricalSuffixParser.Models;
using ElectricalSuffixParser.Parsers;

namespace SuffixParserTestConsole;

internal class Program
{
   static void Main(string[] args)
   {
      string[] inputCases =
      {
         "1",
         "10",
         "10000",
         "10K",
         "0.1u",
         "42.2k",
         "42.2K",
         "100mR",
         "blah",
      };

      double?[] outputCases =
      {
         null,
         0,
         0.000000000000001,
         0.1,
         4.2,
         0.0042,
         1000000000,
         42000000,
         10000,
         100
      };

      SuffixModel model = new();
      SuffixParser parser = new(model);

      Console.WriteLine("\nInput Cases:");
      foreach (var test in inputCases)
      {
         Console.WriteLine($"IN: {test} OUT: {parser.ParseInput(test)}");
      }

      Console.WriteLine("\nOutput Cases");
      foreach (var test in outputCases)
      {
         Console.WriteLine($"IN: {test} OUT: {parser.Convert(test)}");
      }

      Console.WriteLine("\nDone...");
   }
}