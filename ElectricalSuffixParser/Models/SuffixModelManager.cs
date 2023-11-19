using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SettingsLibrary;

namespace ElectricalSuffixParser.Models
{
   /// <summary>
   /// Manager for the suffix model used by a WPF application.
   /// <para/>
   /// This should be used as a static property in the App.xaml.cs class file.
   /// </summary>
   public class SuffixModelManager
   {
      /// <summary>
      /// The local suffix model used by the application.
      /// </summary>
      public SuffixModel Suffixes { get; set; } = new();
      /// <summary>
      /// Triggered during startup.
      /// </summary>
      /// <param name="parentAppName"></param>
      public void OnStartup(string parentAppName)
      {
         Suffixes = SettingsManager.OnStartup<SuffixModel>(Path.Combine(parentAppName, "Suffixes"));
      }

      /// <summary>
      /// Triggered during exit.
      /// </summary>
      /// <param name="parentAppName"></param>
      public void OnExit(string parentAppName)
      {
         SettingsManager.OnExit(Suffixes, Path.Combine(parentAppName, "Suffixes"));
      }
   }
}
