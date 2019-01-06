using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    class Diamond : Moveable
    {
        public override char tile
        {
            get
            {
                return (char)9532;
            }
        }
    }
}
