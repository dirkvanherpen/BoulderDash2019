using BoulderDash2019.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public class Boulder : Slideable
    {
        public override char tile
        {
            get
            {
                return (char)8709;
            }
        }
        public Boulder(int life, bool collision)
        {
            this.life = life;
            this.collision = collision;
        }
        public override bool letSlide()
        {
            return true;
        }
        public override bool Crush()
        {
            return true;
        }
    }
}
