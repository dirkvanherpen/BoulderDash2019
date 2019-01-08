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
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────┐");
            Console.WriteLine(" Welkom bij BoulderDash                                 ");
            Console.WriteLine("                                                        ");
            Console.WriteLine(" Besturing:                                             ");
            Console.WriteLine(" Pijltjes : Het besturen van Rockford                   ");
            Console.WriteLine(" Spatie : Wacht een zet af                              ");
            Console.WriteLine(" S : Stoppen met het level                              ");
            Console.WriteLine("     En terugkeren naar startscherm                     ");
            Console.WriteLine("                                                        ");
            Console.WriteLine(" Betekenis van de symbolen:                             ");
            Console.WriteLine(" " + (char)9608 + " : Stalenmuur                        ");
            Console.WriteLine(" R : Rockford (Onze held)                               ");
            Console.WriteLine(" " + (char)9617 + " : Modder                            ");
            Console.WriteLine(" " + (char)8709 + " : Boulder                           ");
            Console.WriteLine(" " + (char)9532 + " : Diamand                           ");
            Console.WriteLine(" " + (char)9619 + " : Wall (muur)                       ");
            Console.WriteLine(" F : FireFily (vuurvliegje)                             ");
            Console.WriteLine(" T : TNT, gaat na 30sec automatisch af");
            Console.WriteLine(" " + (char)9618 + " : Harde modder, Rockford moet 3x graven om hier doorheen te komen");
            Console.WriteLine(" E : Exit (de uitgang), alleen zichtbaar als alle diamandjes gehaald zijn");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine("Kies een level (1-3), s = stop");
        }
    }
}
