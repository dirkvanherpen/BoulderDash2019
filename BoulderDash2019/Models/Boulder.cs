using BoulderDash2019.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public class Boulder : Moveable
    {
        public override char tile
        {
            get
            {
                return (char)8709;
            }
        }

        public void Move(Movement movement)
        {

            int newx = moveableOnTile.x;
            int newy = moveableOnTile.y;

            if (movement == Movement.Down)
            {
                newy++;
            }

            // Only code for boulders falling down
            var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == newx && tile.y == newy);

            if (nextTile.life == 0)
            {
                nextTile.moveable = this;
                moveableOnTile.moveable = null;
                moveableOnTile = nextTile;
            }



            //if (nextTile.moveable != null && nextTile.moveable.GetType() == typeof(EmptyTile))


            //foreach (var tilechar in level.tiles)
            //{
            //    int newy = tilechar.y + 1;

            //    // Only code for boulders falling down
            //    var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == moveableOnTile.x && tile.y == newy);

            //    if (tilechar.moveable != null && tilechar.moveable.GetType() == typeof(Boulder) && nextTile.moveable != null && nextTile.moveable.GetType() == typeof(EmptyTile))
            //    {
            //        nextTile.moveable = this;
            //        moveableOnTile.moveable = null;
            //        moveableOnTile = nextTile;
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
        }
    }
}
