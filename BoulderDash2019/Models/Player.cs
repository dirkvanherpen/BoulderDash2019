using BoulderDash2019.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public class Player : Moveable
    {

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

            /*if (GetType(nextTile) == Steelwall)
            {
                return;
            }*/

            nextTile.moveable = this;
            moveableOnTile.moveable = null;
            moveableOnTile = nextTile;
        }
    }
}
