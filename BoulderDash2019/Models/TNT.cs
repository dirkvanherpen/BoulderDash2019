using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    class TNT : Slideable
    {
        public override char tile
        {
            get
            {
                return 'T';
            }
        }
        public TNT(int life, bool collision)
        {
            this.life = life;
            this.collision = collision;
        }
        public override bool letSlide()
        {
            return true;
        }
        public override bool canExplode()
        {
            return true;
        }
    }
}
