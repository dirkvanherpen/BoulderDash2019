using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    class HardenedMud : Moveable
    {
        public HardenedMud(int life, bool collision)
        {
            this.life = life;
            this.collision = collision;
        }
        public override char tile
        {
            get
            {
                return (char)9618;
            }
        }
    }
}
