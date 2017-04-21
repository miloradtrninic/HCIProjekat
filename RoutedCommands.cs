using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCIProjekat
{
    public static class RoutedCommands
    {
        

        public static readonly RoutedUICommand NewEtiketa = new RoutedUICommand(
            "Nova Etiketa",
            "NewEtiketa",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
               new KeyGesture(Key.E, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand NewTip = new RoutedUICommand(
            "Novi Tip",
            "NewTip",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand NewSpomenikCmd = new RoutedUICommand(
            "Nova Etiketa",
            "NewEtiketa",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
               new KeyGesture(Key.S, ModifierKeys.Alt | ModifierKeys.Control)
            }
            );

         public static readonly RoutedUICommand SaveState = new RoutedUICommand(
            "Snimi podatke",
             "Save",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
               new KeyGesture(Key.S,  ModifierKeys.Control)
            }
            );
         public static readonly RoutedUICommand OpenState = new RoutedUICommand(
            "Učitaj podatke",
             "Load",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
               new KeyGesture(Key.O,  ModifierKeys.Control)
            }
            );
         public static readonly RoutedUICommand Accept = new RoutedUICommand(
             "Potvrdi",
              "Accept",
             typeof(RoutedCommands),
             new InputGestureCollection()
            {
               new KeyGesture(Key.Enter)
            }
            );
         public static readonly RoutedUICommand Escape = new RoutedUICommand(
              "Odustane",
               "Escape",
              typeof(RoutedCommands),
              new InputGestureCollection()
            {
               new KeyGesture(Key.Escape)
            }
             );
        
    }
}
