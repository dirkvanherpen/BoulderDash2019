using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Views
{
    class EndView
    {
        public static void EndScreenVictory(int score)
        {
            Console.Clear();
            Console.WriteLine("┌─────────────────────────────────┐");
            Console.WriteLine(" U heeft gewonnen!            ");
            Console.WriteLine("                                ");
            Console.WriteLine(" U heeft " + score + " punten behaald");
            Console.WriteLine("                                ");
            Console.WriteLine(" Druk op een toets om terug te keren");
            Console.WriteLine("└─────────────────────────────────┘");
            Console.WriteLine();
        }

        public static void EndScreenDefeat()
        {
            Console.Clear();
            Console.WriteLine("┌─────────────────────────────────┐");
            Console.WriteLine(" U heeft verloren! :(            ");
            Console.WriteLine(" Druk op een toets om terug te keren");
            Console.WriteLine("└─────────────────────────────────┘");
            Console.WriteLine();
        }
    }
}
