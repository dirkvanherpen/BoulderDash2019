using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    class EmptyTile : Tile
    {
        public EmptyTile(int x, int y, Level level) : base(x, y, level)
        {
        }

        public override char tile
        {
            get
            {
                if (moveable != null)
                {
                    return moveable.tile;
                }

                return ' ';
            }
        }
    }
}
