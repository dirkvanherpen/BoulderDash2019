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
        public List<Slideable> slideables = new List<Slideable>();

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
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new Player();
                            rockford = (Player)tile.moveable;
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'M':
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new Mud(1, false);
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'B':
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new Boulder(1, true);
                            slideables.Add((Slideable)tile.moveable);
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'D':
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new Diamond(1, false);
                            slideables.Add((Slideable)tile.moveable);
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'W':
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new Wall(1, true);
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'S':
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new Steelwall(true);
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'F':
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new Firefly(1);
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'H':
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new HardenedMud(3, true);
                            tile.moveable.moveableOnTile = tile;
                            break;
                        case 'T':
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new TNT(1, false);
                            slideables.Add((Slideable)tile.moveable);
                            tile.moveable.moveableOnTile = tile;
                            break;
                        default:
                            tile = new EmptyTile(x, y, this);
                            tile.moveable = new BlankTile();
                            tile.moveable.moveableOnTile = tile;
                            break;
                    }

                    tiles.Add(tile);
                }
            }

            ConnectTiles();
        }

        private void ConnectTiles()
        {
            foreach (var tile in tiles)
            {
                tile.tileToTop = tiles.Find(t => t.x == tile.x && t.y == tile.y - 1);
                tile.tileToRight = tiles.Find(t => t.x == tile.x + 1 && t.y == tile.y);
                tile.tileToBottom = tiles.Find(t => t.x == tile.x && t.y == tile.y + 1);
                tile.tileToLeft = tiles.Find(t => t.x == tile.x - 1 && t.y == tile.y);
            }
        }
    }
}
