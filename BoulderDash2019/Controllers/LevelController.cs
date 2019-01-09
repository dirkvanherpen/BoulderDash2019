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
        private int score { get; set; }

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
            score = (currentLevel.levelTimer + (currentLevel.rockford.diamonds * 10));
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
            Console.WriteLine("Points left: " + score);
            Console.WriteLine("Diamonds: " + currentLevel.rockford.diamonds + "/" + currentLevel.diamonds.Count());
        }

        public void gameFlow()
        {
            List<Slideable> canMove = new List<Slideable> { };
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
                    if(currentLevel.rockford.removeTileX != -1 && currentLevel.rockford.removeTileY != -1)
                    {
                        var itemToRemove = currentLevel.slideables.Single(r => r.moveableOnTile.x == currentLevel.rockford.removeTileX && r.moveableOnTile.y == currentLevel.rockford.removeTileY);
                        currentLevel.slideables.Remove(itemToRemove);
                    }
                    if(currentLevel.diamonds.Count() <= currentLevel.rockford.diamonds)
                    {

                        /*
                         Laat de exit zien.
                         Probleem aanwezig is nogsteeds de volgorde van het vallen van boulders, tnt en diamonds waardoor je meer diamonds dan mogelijk kan halen
                         */
                    }
                    if(currentLevel.rockford.exit == true)
                    {
                        currentLevel.isFinished = true;
                    }
                }
            }
            EndView.EndScreen(score, true);

            /*
             implement:
             level congrats screen met score en keys waardoor je naar het menu kan gaan (druk op ... om terug naar het menu te gaan)
             */
        }
        public void checkMove(List<Slideable> canMove)
        {
            currentLevel.slideables.ForEach(slideable => slideable.checkMove(canMove));
        }

        public void moveBoulder(List<Slideable> canMove)
        {            
            canMove.ForEach(slideable => slideable.Move());
        }
    }
}
