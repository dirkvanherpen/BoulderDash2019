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
            if (moveableOnTile.moveable.life<=0) { }
            else if (nextTile.moveable.letCrush())
            {
                if (moveableOnTile.moveable.canCrush())
                {
                    if (nextTile.moveable.GetType() == typeof(Player))
                    {
                        Console.Clear();
                        Console.WriteLine("death");
                        Console.ReadLine();
                    }
                    nextTile.moveable = this;
                    moveableOnTile.moveable = new BlankTile();
                    moveableOnTile = nextTile;
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
                    if (moveableOnTile.moveable.canCrush())
                    {
                        if (moveableOnTile.tileToLeft.moveable.GetType() == typeof(Player))
                        {
                            Console.Clear();
                            Console.WriteLine("death");
                            Console.ReadLine();
                        }
                        moveableOnTile.tileToLeft.moveable = this;
                        moveableOnTile.moveable = new BlankTile();
                        moveableOnTile = moveableOnTile.tileToLeft;
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
                    if (moveableOnTile.moveable.canCrush())
                    {
                        if (moveableOnTile.tileToRight.moveable.GetType() == typeof(Player))
                        {
                            Console.Clear();
                            Console.WriteLine("death");
                            Console.ReadLine();
                        }
                        moveableOnTile.tileToRight.moveable = this;
                        moveableOnTile.moveable = new BlankTile();
                        moveableOnTile = moveableOnTile.tileToRight;
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
            animateTnt();
            var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == moveableOnTile.x && tile.y == moveableOnTile.y + 1);

            if (moveableOnTile.moveable.life <=0)
            {
                
            }
            else if (nextTile.moveable.letCrush())
            {
                if(!moveableOnTile.moveable.canCrush() && nextTile.moveable.GetType() == typeof(Player))
                {
                    // Als de moveable geen boulder (Crush) is en het volgende vakje de player voegt hij hem niet toe anders wel
                    
                } else
                {
                    slideable.Add(this);
                }     
            }
            else if ((nextTile.moveable.letSlide() && moveableOnTile.tileToLeft.moveable.letCrush() && moveableOnTile.tileToLeft.tileToBottom.moveable.letCrush()) || (nextTile.moveable.letSlide() && moveableOnTile.tileToRight.moveable.letCrush() && moveableOnTile.tileToRight.tileToBottom.moveable.letCrush()))
            {
                if((moveableOnTile.moveable.canCrush() == false) && (moveableOnTile.tileToLeft.moveable.GetType() == typeof(Player) || moveableOnTile.tileToRight.moveable.GetType() == typeof(Player)))
                {

                }
                else
                {
                    slideable.Add(this);
                }
            }
        }
        public void animateTnt()
        {
            if (moveableOnTile.moveable.GetType() == typeof(TNT))
            {
                moveableOnTile.moveable.life--;
                if (moveableOnTile.moveable.life <= 0)
                {
                    // doo big boom
                    for (int x = -1; x < 2; x++)
                    {
                        for (int y = -1; y < 2; y++)
                        {
                            var explosion = moveableOnTile.level.tiles.Find(tile => tile.x == moveableOnTile.x + x && tile.y == moveableOnTile.y + y);
                            if (explosion.moveable.canExplode())
                            {
                                explosion.moveable = new BlankTile();
                            }
                        }
                    }
                }
            }
        }
    }
}
