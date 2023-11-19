using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSuffixParser.Models
{
   public class SuffixModel : SettingsLibrary.Models.ISettingsModel
   {
      public string SavePath { get; set; } = null!;
      public string LastSavePath { get; set; } = null!;

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

      public int InputMaxExponent => InputExponentConvert.Keys.Max(x => x);
      public int InputMinExponent => InputExponentConvert.Keys.Min(x => x);

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
   }
}
