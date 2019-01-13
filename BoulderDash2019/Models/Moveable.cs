using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public abstract class Moveable
    {
        public Tile moveableOnTile;
        public int life;
        public string direction;
        protected bool collision;
        public virtual bool letSlide()
        {
            return false;
        }
        public virtual bool letCrush()
        {
            return false;
        }
        public virtual bool canCrush()
        {
            return false;
        }
        public virtual bool canExplode()
        {
            return false;
        }
        public abstract char tile { get; }

        public void MoveFlies()
        {
            switch (moveableOnTile.moveable.direction)
            {
                    case "up":
                        if (moveableOnTile.tileToLeft.moveable.letCrush()) { MoveLeft(); }
                        else if (moveableOnTile.tileToTop.moveable.letCrush()) { MoveUp(); }
                        else if (moveableOnTile.tileToRight.moveable.letCrush()) { MoveRight(); }
                        else if (moveableOnTile.tileToBottom.moveable.letCrush())  { MoveDown(); }
                        break;
                    case "left":
                        if (moveableOnTile.tileToBottom.moveable.letCrush()) { MoveDown(); }
                        else if (moveableOnTile.tileToLeft.moveable.letCrush()) { MoveLeft(); }
                        else if (moveableOnTile.tileToTop.moveable.letCrush()) { MoveUp(); }
                        else if (moveableOnTile.tileToRight.moveable.letCrush()) { MoveRight(); }
                        break;
                    case "right":
                        if (moveableOnTile.tileToTop.moveable.letCrush()) { MoveUp(); }
                        else if (moveableOnTile.tileToRight.moveable.letCrush()) { MoveRight(); }
                        else if (moveableOnTile.tileToBottom.moveable.letCrush()) { MoveDown(); }
                        else if(moveableOnTile.tileToLeft.moveable.letCrush())  { MoveLeft(); }
                        break;
                    case "down":
                        if (moveableOnTile.tileToRight.moveable.letCrush()) { MoveRight(); }
                        else if (moveableOnTile.tileToBottom.moveable.letCrush()) { MoveDown(); }
                        else if (moveableOnTile.tileToLeft.moveable.letCrush()) { MoveLeft(); }
                        else if (moveableOnTile.tileToTop.moveable.letCrush()) { MoveUp(); }
                        break;
                    default:
                        break;
            }
        }

        public void MoveLeft() {
            moveableOnTile.tileToLeft.moveable = this;
            moveableOnTile.moveable = new BlankTile();
            moveableOnTile = moveableOnTile.tileToLeft;
            moveableOnTile.moveable.direction = "left";
        }
        public void MoveUp() {
            moveableOnTile.tileToTop.moveable = this;
            moveableOnTile.moveable = new BlankTile();
            moveableOnTile = moveableOnTile.tileToTop;
            moveableOnTile.moveable.direction = "up";
        }
        public void MoveRight() {
            moveableOnTile.tileToRight.moveable = this;
            moveableOnTile.moveable = new BlankTile();
            moveableOnTile = moveableOnTile.tileToRight;
            moveableOnTile.moveable.direction = "right";
        }
        public void MoveDown() {
            moveableOnTile.tileToBottom.moveable = this;
            moveableOnTile.moveable = new BlankTile();
            moveableOnTile = moveableOnTile.tileToBottom;
            moveableOnTile.moveable.direction = "down";
        }

        public bool willCollide()
        {
            return collision;
        }
    }
}
