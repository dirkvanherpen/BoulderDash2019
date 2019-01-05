using BoulderDash2019.Enum;
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

        public void loadInfo() { 
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

        private Level currentLevel;

        public void loadLevel(int levelNumber)
        {
            switch (levelNumber)
            {
                case 1:
                    currentLevel = new Level(LevelData.Level1);
                    break;
                case 2:
                    currentLevel = new Level(LevelData.Level2);
                    break;
                case 3:
                    currentLevel = new Level(LevelData.Level3);
                    break;
                default:
                    break;
            }

            while (currentLevel.isFinished != true)
            {
                renderLevel(currentLevel);

                var key = Console.ReadKey();
                if (key != null)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            currentLevel.rockford.Move(Movement.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            currentLevel.rockford.Move(Movement.Right);
                            break;
                        case ConsoleKey.UpArrow:
                            currentLevel.rockford.Move(Movement.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            currentLevel.rockford.Move(Movement.Down);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void renderLevel(Level currentLevel)
        {
            Console.Clear();
            int y = 0;

            foreach (var tilechar in currentLevel.tiles)
            {
                if (y != tilechar.y)
                {
                    Console.WriteLine();
                    y++;
                }
                Console.Write(tilechar.tile);
            }
        }
    }
}
