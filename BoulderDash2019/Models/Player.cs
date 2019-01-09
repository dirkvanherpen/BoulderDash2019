using BoulderDash2019.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public class Player : Crushable
    {
        public int diamonds = 0;
        public bool exit = false;

        public int removeTileX = -1;
        public int removeTileY = -1;

        public override char tile
        {
            get
            {
                return 'R';
            }
        }

        public void Move(Movement movement)
        {
            int newx = moveableOnTile.x;
            int newy = moveableOnTile.y;

            if (movement == Movement.Up)
            {
                newy--;
            }
            else if (movement == Movement.Down)
            {
                newy++;
            }
            else if (movement == Movement.Left)
            {
                newx--;
            }
            else if (movement == Movement.Right)
            {
                newx++;
            }

            var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == newx && tile.y == newy);

            if (nextTile.moveable.GetType() == typeof(HardenedMud))
            {
                if (nextTile.moveable.life == 1)
                {

                }
                else
                {
                    nextTile.moveable.life--;
                    return;
                }
            }
            else if (nextTile.moveable.GetType() == typeof(Diamond))
            {
                this.diamonds++;
            }
            else if (nextTile.moveable.willCollide())
            {
                return;
            }
            else if (nextTile.moveable.GetType() == typeof(Exit))
            {
                this.exit = true;
            }

            if (nextTile.moveable.GetType() == typeof(Diamond) || nextTile.moveable.GetType() == typeof(TNT))
            {
                removeTileX = nextTile.x;
                removeTileY = nextTile.y;
            }
            else
            {
                removeTileX = -1;
                removeTileY = -1;
            }
            
            nextTile.moveable = this;
            moveableOnTile.moveable = new BlankTile();
            moveableOnTile = nextTile;
        }
        public override bool letCrush()
        {
            return true;
        }
        public override bool canExplode()
        {
            return true;
        }
    }
}
