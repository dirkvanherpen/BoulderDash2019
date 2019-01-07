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
        protected bool collision;
        public virtual bool letSlide()
        {
            return false;
        }

        public abstract char tile { get; }

        public bool willCollide()
        {
            return collision;
        }
    }
}
