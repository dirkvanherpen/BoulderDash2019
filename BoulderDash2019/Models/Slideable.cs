using BoulderDash2019.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public abstract class Slideable : Moveable
    {
        public void Move()
        {
            // Only code for falling down
            var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == moveableOnTile.x && tile.y == moveableOnTile.y + 1);

            if (nextTile.moveable.letCrush())//nextTile.moveable.GetType() == typeof(BlankTile))
            {
                if (moveableOnTile.moveable.Crush())
                {
                    
                    // If nextTile == player { Die }
                }
                nextTile.moveable = this;
                moveableOnTile.moveable = new BlankTile();
                moveableOnTile = nextTile;
            }
            else if (nextTile.moveable.letSlide())
            {
               if (moveableOnTile.tileToLeft.moveable.letCrush() && moveableOnTile.tileToLeft.tileToBottom.moveable.letCrush())
                {
                    moveableOnTile.tileToLeft.moveable = this;
                    moveableOnTile.moveable = new BlankTile();
                    moveableOnTile = moveableOnTile.tileToLeft;
                }
                else if (moveableOnTile.tileToRight.moveable.letCrush() && moveableOnTile.tileToRight.tileToBottom.moveable.letCrush())
                {
                    moveableOnTile.tileToRight.moveable = this;
                    moveableOnTile.moveable = new BlankTile();
                    moveableOnTile = moveableOnTile.tileToRight;
                }
            }
        }
        public void checkMove(List<Moveable> Moveable)
        {
            var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == moveableOnTile.x && tile.y == moveableOnTile.y + 1);

            if (nextTile.moveable.letCrush())
            {
                Moveable.Add(moveableOnTile.moveable);                
            }
            else if (nextTile.moveable.letSlide())
            {
                Moveable.Add(moveableOnTile.moveable);
            }
        }
    }
}
