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
        public void Move(Movement movement)
        {

            int newx = moveableOnTile.x;
            int newy = moveableOnTile.y;

            if (movement == Movement.Down)
            {
                newy++;
            }

            // Only code for falling down
            var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == newx && tile.y == newy);

            if (nextTile.moveable.GetType() == typeof(BlankTile))
            {
                nextTile.moveable = this;
                moveableOnTile.moveable = new BlankTile();
                moveableOnTile = nextTile;
            }
            else if (nextTile.moveable.letSlide())
            {
                // Beweeg naar links of rechts
                // is het vakje link of recht inclief linkks of rechtonder ook vrij

                if (moveableOnTile.tileToLeft.moveable.GetType() == typeof(BlankTile) && moveableOnTile.tileToLeft.tileToBottom.moveable.GetType() == typeof(BlankTile))
                {
                    moveableOnTile.tileToLeft.moveable = this;
                    moveableOnTile.moveable = new BlankTile();
                    moveableOnTile = moveableOnTile.tileToLeft;
                }
                else if (moveableOnTile.tileToRight.moveable.GetType() == typeof(BlankTile) && moveableOnTile.tileToRight.tileToBottom.moveable.GetType() == typeof(BlankTile))
                {
                    moveableOnTile.tileToRight.moveable = this;
                    moveableOnTile.moveable = new BlankTile();
                    moveableOnTile = moveableOnTile.tileToRight;
                }
            }
        }
    }
}
