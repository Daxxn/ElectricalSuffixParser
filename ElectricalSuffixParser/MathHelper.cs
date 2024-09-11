using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalSuffixParser
{
   internal static class MathHelper
   {
      public static decimal Pow10(int exp)
      {
         return (decimal)Math.Pow(10, exp);
      }

      public static decimal ToExponent(decimal value, int ex)
      {
         return value * Pow10(-ex);
      }

      public static double ToExponent(double value, int ex)
      {
         return value * Math.Pow(10, -ex);
      }

      public static int GetExponent(double value)
      {
         return (int)Math.Floor(Math.Log10(value));
      }

      public static int GetExponent(decimal value)
      {
         return (int)Math.Floor(Math.Log10((double)value));
      }
   }
}
