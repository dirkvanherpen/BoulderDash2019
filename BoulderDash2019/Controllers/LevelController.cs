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
                    currentLevel = new Level(LevelData.Level1, LevelData.Level1_timer);
                    break;
                case 2:
                    currentLevel = new Level(LevelData.Level2, LevelData.Level2_timer);
                    break;
                case 3:
                    currentLevel = new Level(LevelData.Level3, LevelData.Level3_timer);
                    break;
                default:
                    break;
            }
            renderLevel(currentLevel);
            gameFlow();          
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
            Console.WriteLine();
            Console.WriteLine("Points left: " + currentLevel.levelTimer);
        }

        public void gameFlow()
        {
            List<Moveable> canMove = new List<Moveable> { };
            int moves = 0;
            while (currentLevel.isFinished != true)
            {                
                checkMove(canMove);
                var key = Console.ReadKey();
                if (key != null)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            currentLevel.rockford.Move(Movement.Left);
                            moves++;
                            moveBoulder(canMove);
                            canMove.Clear();
                            renderLevel(currentLevel);
                            break;
                        case ConsoleKey.RightArrow:
                            currentLevel.rockford.Move(Movement.Right);
                            moves++;
                            moveBoulder(canMove);
                            canMove.Clear();
                            renderLevel(currentLevel);
                            break;
                        case ConsoleKey.UpArrow:
                            currentLevel.rockford.Move(Movement.Up);
                            moves++;
                            moveBoulder(canMove);
                            canMove.Clear();
                            renderLevel(currentLevel);
                            break;
                        case ConsoleKey.DownArrow:
                            currentLevel.rockford.Move(Movement.Down);
                            moves++;
                            moveBoulder(canMove);
                            canMove.Clear();
                            renderLevel(currentLevel);
                            break;
                        case ConsoleKey.Spacebar:
                            moves++;
                            moveBoulder(canMove);
                            canMove.Clear();
                            renderLevel(currentLevel);
                            break;
                        case ConsoleKey.S:
                            Console.ReadKey();
                            loadInfo();
                            break;
                        default:
                            break;
                    }
                    if (moves == 3)
                    {
                        currentLevel.levelTimer--;
                        moves = 0;
                    }
                }
            }
        }
        public void checkMove(List<Moveable> canMove)
        {
            currentLevel.slideables.ForEach(slideable => slideable.checkMove(canMove));
        }

        public void moveBoulder(List<Moveable> canMove)
        {
            /*
                 
                Er moeteerst gechecked worden of de boulders kunnen bewegen, dan moet de speler bewegen, en daarna de boulders pas.
                De dubbele for each moet hier natuurlijk weggehaalt worden anders gebeurt het te vaak
                Naast dat moet voor elke moveable in canMove de functie: slideable.Move() uitgevoerd worden.
                Echter weet ik niet hoe dit moet.
                 
            */

            foreach (var y in canMove)
            {
                currentLevel.slideables.ForEach(slideable => slideable.Move());
            }
            //currentLevel.slideables.ForEach(slideable => slideable.Move());
        }
    }
}
