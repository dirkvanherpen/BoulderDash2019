using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public abstract class Tile
    {
        public Moveable moveable;
        public abstract char tile { get; }

        public int x;
        public int y;
        public Level level;

        public Tile(int x, int y, Level level)
        {
            this.x = x;
            this.y = y;
            this.level = level;
        }
    }
}
