using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SettingsLibrary;

namespace ElectricalSuffixParser.Models
{
   public static class SuffixList
   {
      public static SuffixModel Suffixes { get; set; } = new();
      public static void OnStartup(string parentAppName)
      {
         Suffixes = SettingsManager.OnStartup<SuffixModel>(Path.Combine(parentAppName, "Suffixes"));
      }

      public static void OnExit(string parentAppName)
      {
         SettingsManager.OnExit(Suffixes, Path.Combine(parentAppName, "Suffixes"));
      }
   }
}
