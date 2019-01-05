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

        public abstract char tile { get; }
    }
}
