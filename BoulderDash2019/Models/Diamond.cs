using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    class Diamond : Slideable
    {
        public override char tile
        {
            get
            {
                return (char)9532;
            }
        }
        public Diamond(int life, bool collision)
        {
            this.life = life;
            this.collision = collision;
        }
        public override bool letSlide()
        {
            return true;
        }
    }
}
