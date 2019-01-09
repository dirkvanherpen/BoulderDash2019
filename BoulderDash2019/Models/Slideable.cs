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
            var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == moveableOnTile.x && tile.y == moveableOnTile.y + 1);

            if (nextTile.moveable.letCrush())
            {
                if (moveableOnTile.moveable.Crush())
                {
                    // If nextTile == player { Die }
                }
                else
                {
                    // Voor alles behalve boulders
                    if(nextTile.moveable.GetType() != typeof(Player))
                    {
                        nextTile.moveable = this;
                        moveableOnTile.moveable = new BlankTile();
                        moveableOnTile = nextTile;
                    }
                }
            }
            else if (nextTile.moveable.letSlide())
            {
               if (moveableOnTile.tileToLeft.moveable.letCrush() && moveableOnTile.tileToLeft.tileToBottom.moveable.letCrush())
                {
                    if (moveableOnTile.moveable.Crush())
                    {

                    }
                    else
                    {
                        // Voor alles behalve boulders
                        moveableOnTile.tileToLeft.moveable = this;
                        moveableOnTile.moveable = new BlankTile();
                        moveableOnTile = moveableOnTile.tileToLeft;

                    }
                }
                else if (moveableOnTile.tileToRight.moveable.letCrush() && moveableOnTile.tileToRight.tileToBottom.moveable.letCrush())
                {
                    if (moveableOnTile.moveable.Crush())
                    {

                    }
                    else
                    {
                        // Voor alles behalve boulders
                        moveableOnTile.tileToRight.moveable = this;
                        moveableOnTile.moveable = new BlankTile();
                        moveableOnTile = moveableOnTile.tileToRight;
                    }
                }
            }
        }
        public void checkMove(List<Slideable> slideable)
        {
            var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == moveableOnTile.x && tile.y == moveableOnTile.y + 1);

            if (nextTile.moveable.letCrush())
            {
                if(!moveableOnTile.moveable.Crush() && nextTile.moveable.GetType() == typeof(Player))
                {
                    // Als de moveable geen boulder (Crush) is en het volgende vakje de player voegt hij hem niet toe anders wel
                    
                } else
                {
                    slideable.Add(this);
                }     
            }
            else if ((nextTile.moveable.letSlide() && moveableOnTile.tileToLeft.moveable.letCrush() && moveableOnTile.tileToLeft.tileToBottom.moveable.letCrush()) || (nextTile.moveable.letSlide() && moveableOnTile.tileToRight.moveable.letCrush() && moveableOnTile.tileToRight.tileToBottom.moveable.letCrush()))
            {
                slideable.Add(this);
            }
        }
    }
}
