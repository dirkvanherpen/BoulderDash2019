using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    class Mud : Moveable
    {
        public override char tile
        {
            get
            {
                return (char)9617;
            }
        }
        public Mud(int life, bool collision)
        {
            this.life = life;
            this.collision = collision;
        }
    }
}
