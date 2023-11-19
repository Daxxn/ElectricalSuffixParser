using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ElectricalSuffixParser.Models;

namespace ElectricalSuffixParser.Parsers
{
   /// <summary>
   /// Object containing the logic for parsing the number suffixes.
   /// </summary>
   public class SuffixParser
   {
      #region Local Props
      /// <summary>
      /// Suffix data to use during conversion.
      /// </summary>
      public SuffixModel SuffixModel { get; set; }
      #endregion

      #region Constructors
      /// <summary>
      /// Default constructor using the default <see cref="SuffixModel"/>.
      /// </summary>
      public SuffixParser() => SuffixModel = new();
      /// <summary>
      /// Constructor using a custom <see cref="SuffixModel"/>.
      /// </summary>
      /// <param name="model">Custom suffix model.</param>
      public SuffixParser(SuffixModel model) => SuffixModel = model;
      #endregion

      #region Methods
      /// <summary>
      /// Parse an incoming number with a suffix and convert it to a floating point value.
      /// </summary>
      /// <param name="input">Incoming number string.</param>
      /// <returns>The converted floating point number</returns>
      public double? ParseInput(string? input)
      {
         if (string.IsNullOrEmpty(input)) return null;

         double temp;
         if (input.Length == 1)
         {
            if (double.TryParse(input, out temp)) return temp;
         }
         if (char.IsLetter(input[^1]))
         {
            if (SuffixModel.InputExponentSuffixes.ContainsKey(input[^1]))
            {
               if (double.TryParse(input[0..^1], out temp))
               {
                  return temp * (double)Math.Pow(10, SuffixModel.InputExponentSuffixes[input[^1]]);
               }
            }
            if (SuffixModel.UnitsWhitelist.Contains(input[^1]))
            {
               return ParseInput(input[0..^1]);
            }
            if (double.TryParse(input[0..^1], out temp)) return temp;
         }
         else
         {
            if (double.TryParse(input, out temp)) return temp;
         }
         return null;
      }

      /// <summary>
      /// Match a floating point value with the closest matching suffix and create a string with that value.
      /// </summary>
      /// <param name="input">Double floating point value to convert.</param>
      /// <param name="unitSuffix">Optional unit suffix.</param>
      /// <returns>String of the converted value.</returns>
      public string? Convert(double? input, string? unitSuffix = null)
      {
         if (input is null) return null;
         if (input == 0) return $"0{unitSuffix}";

         double value = (double)input;
         double abs = Math.Abs(value);
         int exponent = MathHelper.GetExponent(abs);

         if (exponent > SuffixModel.InputMaxExponent)
         {
            return $"{MathHelper.ToExponent(value, SuffixModel.InputMaxExponent):F}{SuffixModel.ExponentSuffixes[SuffixModel.InputMaxExponent]}{unitSuffix}";
         }
         if (exponent < SuffixModel.InputMinExponent)
         {
            return $"{MathHelper.ToExponent(value, SuffixModel.InputMinExponent):F}{SuffixModel.ExponentSuffixes[SuffixModel.InputMinExponent]}{unitSuffix}";
         }
         return $"{Math.Round(MathHelper.ToExponent(value, SuffixModel.InputExponentConvert[exponent]), 2):F}{SuffixModel.ExponentSuffixes[exponent]}{unitSuffix}";
      }
      #endregion

      #region Full Props

      #endregion
   }
}
