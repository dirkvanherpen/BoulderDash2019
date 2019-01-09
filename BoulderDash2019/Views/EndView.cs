using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Views
{
    class EndView
    {
        public static void EndScreen(int score, bool win)
        {
            Console.Clear();
            Console.WriteLine("┌───────────────────────────────┐");
            Console.WriteLine(" U heeft " + win + "!            ");
            Console.WriteLine("                                ");
            Console.WriteLine(" U heeft " + score + " punten behaald");
            Console.WriteLine("└─────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine("s = stop");
        }
    }
}
