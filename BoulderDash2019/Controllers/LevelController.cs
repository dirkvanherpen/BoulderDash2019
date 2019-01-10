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
        private int score { get; set; }
        private bool result { get; set; }

        public void loadInfo() { 
            while (!exit)
            {
                Console.Clear();
                GameView.startInfo();

                if (retry) { Console.WriteLine("Vul een geldige input in!"); }
                var input = Console.ReadLine().ToLower();

                switch (input)
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

            if (result)
            {
                EndView.EndScreenVictory(score);
            }
            else
            {
                EndView.EndScreenDefeat();
            }
            Console.ReadLine();
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
            List<Slideable> canSlide = new List<Slideable> { };
            int moves = 0;
            string allTiles = "";
            while (currentLevel.isFinished != true)
            {                
                checkMove(canMove, canSlide);
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
                        case ConsoleKey.S:
                            Console.ReadKey();
                            loadInfo();
                            break;
                        default:
                            break;
                    }

                    moves++;

                    if (moves == 3)
                    {
                        currentLevel.levelTimer--;
                        moves = 0;
                    }
                    if (currentLevel.rockford.removeTileX != -1 && currentLevel.rockford.removeTileY != -1)
                    {
                        var itemToRemove = currentLevel.slideables.Single(r => r.moveableOnTile.x == currentLevel.rockford.removeTileX && r.moveableOnTile.y == currentLevel.rockford.removeTileY);
                        currentLevel.slideables.Remove(itemToRemove);
                    }

                    moveBoulder(canMove, canSlide);
                    canMove.Clear();
                    canSlide.Clear();

                    /*
                     *  -	Maak firefly met behaviour (eerst links vannuit de richting waar hij heen gaat)
                     */
                     
                    foreach (var tilechar in currentLevel.tiles)
                    {
                        allTiles += tilechar.tile;
                    }
                    if (!allTiles.ToLower().Contains('r'))
                    {
                        currentLevel.isFinished = true;
                        result = false;
                    }
                    allTiles = "";

                    if (currentLevel.diamonds.Count() <= currentLevel.rockford.diamonds && currentLevel.rockford.exit == true)
                    {
                        currentLevel.isFinished = true;
                        result = true;
                    }

                    renderLevel(currentLevel);
                }
            }
        }
        public void checkMove(List<Slideable> canMove, List<Slideable> canSlide)
        {
            currentLevel.slideables.ForEach(slideable => slideable.checkMove(canMove, canSlide));
        }

        public void moveBoulder(List<Slideable> canMove, List<Slideable> canSlide)
        {            
            canMove.ForEach(slideable => slideable.Move());
            canSlide.ForEach(slideable => slideable.Slide());
        }
    }
}
