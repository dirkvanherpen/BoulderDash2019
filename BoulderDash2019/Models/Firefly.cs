using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    class Firefly : Moveable
    {
        public override char tile
        {
            get
            {
                return 'F';
            }
        }
        public Firefly(int life, string direction)
        {
            this.life = life;
            this.direction = direction;
        }
        public override bool canExplode()
        {
            return true;
        }
        public override bool letCrush()
        {
            return true;
        }
    }
}
