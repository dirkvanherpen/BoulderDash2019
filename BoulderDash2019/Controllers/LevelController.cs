using BoulderDash2019.Models;
using BoulderDash2019.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Controllers
{
    class LevelController
    {
        private static Level _level;

        public static Level level
        {
            get { return _level; }
            set { _level = value; }
        }

        GameView view = new GameView();
        private static bool exit = false;
        private static bool retry = false;

        public static void loadInfo() { 
            while (!exit)
            {
                Console.Clear();
                GameView.startInfo();

                if (retry) { Console.WriteLine("Vul een geldige input in!"); }
                 var result = Console.ReadLine().ToLower();

                switch (result)
                {
                    case "s":
                        Environment.Exit(0);
                        break;
                    case "1":
                        loadLevel(1);
                        break;
                    case "2":
                        loadLevel(2);
                        break;
                    case "3":
                        loadLevel(3);
                        break;
                    default:
                        retry = true;
                        break;
                }
            }
        }

        static void loadLevel(int levelNumber)
        {
            Console.WriteLine("Laad level: " + levelNumber);
            var result = Console.ReadLine().ToLower();
        }
    }
}
