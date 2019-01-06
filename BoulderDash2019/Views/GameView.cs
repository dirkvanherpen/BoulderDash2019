using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Views
{
    class GameView
    {
        public static void startInfo()
        {
            Console.Clear();
            Console.WriteLine("┌──────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom bij BoulderDash                               |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("| Besturing:                                           |");
            Console.WriteLine("| Pijltjes : Het besturen van Rockford                 |");
            Console.WriteLine("| Spatie : Wacht een zet af                            |");
            Console.WriteLine("|                                                      |");
            Console.WriteLine("| Betekenis van de symbolen:                           |");
            Console.WriteLine("| S : Stalenmuur                                       |");
            Console.WriteLine("| R : Rockford (Onze held)                             |");
            Console.WriteLine("| M : Modder                                           |");
            Console.WriteLine("| B : Boulder                                          |");
            Console.WriteLine("| D : Diamand                                          |");
            Console.WriteLine("| W : Wall (muur)                                      |");
            Console.WriteLine("| F : FireFily (vuurvliegje)                           |");
            Console.WriteLine("| T : TNT,                                             |");
            Console.WriteLine("|    gaat na 30sec automatisch af                      |");
            Console.WriteLine("| H : Harde modder,                                    |");
            Console.WriteLine("|    Rockford moet 3x graven om hier doorheen te komen |");
            Console.WriteLine("| E : Exit (de uitgang),                               |");
            Console.WriteLine("|    Alleen zichtbaar als alle diamandjes gehaald zijn |");
            Console.WriteLine("└──────────────────────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine("Kies een level (1-3), s = stop");
        }
    }
}
