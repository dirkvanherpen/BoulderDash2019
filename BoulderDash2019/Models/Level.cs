using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public class Level
    {
        public List<Tile> tiles = new List<Tile>();
        public bool isFinished { get; set; }
        public Player rockford;
        public int levelTimer;
        public Boulder boulder;

        public Level(char[,] level, int levelTimer)
        {
            this.levelTimer = levelTimer;
            for (int y = 0; y < LevelData.Level_height; y++)
            {
                for (int x = 0; x < LevelData.Level_width; x++)
                {
                    var tilechar = level[y, x];
                    Tile tile;

                    switch (tilechar)
                    {
                        case 'R':
                            tile = new EmptyTile(x, y, this, 0);
                            tile.moveable = new Player();
                            rockford = (Player)tile.moveable;
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'M':
                            tile = new EmptyTile(x, y, this, 1);
                            tile.moveable = new Mud();
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'B':
                            tile = new EmptyTile(x, y, this, 1);
                            tile.moveable = new Boulder();
                            boulder = (Boulder)tile.moveable;
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'D':
                            tile = new EmptyTile(x, y, this, 1);
                            tile.moveable = new Diamond();
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'W':
                            tile = new EmptyTile(x, y, this, 1);
                            tile.moveable = new Wall();
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'S':
                            tile = new EmptyTile(x, y, this, 99);
                            tile.moveable = new Steelwall();
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'F':
                            tile = new EmptyTile(x, y, this, 1);
                            tile.moveable = new Firefly();
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'H':
                            tile = new EmptyTile(x, y, this, 3);
                            tile.moveable = new HardenedMud(3);
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'T':
                            tile = new EmptyTile(x, y, this, 1);
                            tile.moveable = new TNT();
                            tile.moveable.moveableOnTile = tile;
                            break;
                        default:
                            tile = new EmptyTile(x, y, this, 0);
                            break;
                    }

                    tiles.Add(tile);
                }
            }
        }
    }
}
