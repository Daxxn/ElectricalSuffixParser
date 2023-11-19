using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SettingsLibrary.Models;

namespace ElectricalSuffixParser.Models
{
   /// <summary>
   /// Suffix model used during parsing by the <see cref="Parsers.SuffixParser"/>
   /// </summary>
   public class SuffixModel : ISettingsModel
   {
      /// <summary>
      /// --NOT USED--
      /// </summary>
      public string SavePath { get; set; } = null!;
      /// <summary>
      /// --NOT USED--
      /// </summary>
      public string LastSavePath { get; set; } = null!;

      /// <summary>
      /// Exponent to suffix conversion dictionary.
      /// </summary>
      public Dictionary<int, string> ExponentSuffixes { get; set; } = new()
      {
         { 6, "M" },
         { 5, "K" },
         { 4, "K" },
         { 3, "K" },
         { 2, "" },
         { 1, "" },
         { 0, "" },
         { -1, "m" },
         { -2, "m" },
         { -3, "m" },
         { -4, "μ" },
         { -5, "μ" },
         { -6, "μ" },
         { -7, "n" },
         { -8, "n" },
         { -9, "n" },
         { -10, "p" },
         { -11, "p" },
         { -12, "p" },
      };

      /// <summary>
      /// Suffix to exponent conversion dictionary.
      /// </summary>
      public Dictionary<char, int> InputExponentSuffixes { get; set; } = new()
      {
         { 'M', 6 },
         { 'K', 3 },
         { 'k', 3 },
         { 'm', -3 },
         { 'u', -6 },
         { 'U', -6 },
         { 'n', -9 },
         { 'N', -9 },
         { 'p', -12 },
         { 'P', -12 },
      };

      /// <summary>
      /// Exponent readability rounding conversion dictionary.
      /// <para>
      ///   <para>Example:</para>  
      ///   Converts 0.1 or 1d (deca) to 100m (milli)
      /// </para>
      /// </summary>
      public Dictionary<int, int> InputExponentConvert { get; set; } = new()
      {
         { 6, 6 },
         { 5, 3 },
         { 4, 3 },
         { 3, 3 },
         { 2, 0 },
         { 1, 0 },
         { 0, 0 },
         { -1, -3 },
         { -2, -3 },
         { -3, -3 },
         { -4, -6 },
         { -5, -6 },
         { -6, -6 },
         { -7, -9 },
         { -8, -9 },
         { -9, -9 },
         { -10, -12 },
         { -11, -12 },
         { -12, -12 },
      };

      /// <summary>
      /// Highest exponent provided in the <see cref="InputExponentConvert"/> dictionary.
      /// </summary>
      public int InputMaxExponent => InputExponentConvert.Keys.Max(x => x);

      /// <summary>
      /// Lowest exponent provided in the <see cref="InputExponentConvert"/> dictionary.
      /// </summary>
      public int InputMinExponent => InputExponentConvert.Keys.Min(x => x);

      /// <summary>
      /// Special characters for converting units into the special unicode character instead of a basic letter.
      /// <para>
      ///   <para>Example:</para>
      ///   Use "μ" instead of "u"
      /// </para>
      /// </summary>
      public Dictionary<string, string> SpecialChars = new()
      {
         { "micro", "μ" },
         { "ohm", "Ω" },
         { "celc", "℃" },
         { "degree", "°" },
         { "pi", "π" },
         { "faren", "℉" },
         { "plusminus", "±" },
      };

      /// <summary>
      /// Expandable list of units that the parser will step over when parsing.
      /// <para/>
      /// Characters not included here will cause the parser to output null.
      /// </summary>
      public List<char> UnitsWhitelist = new()
      {
         'F',
         'R',
         'H',
         'Z',
         'Ω',
         'μ'
      };
   }
}
