using BoulderDash2019.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public class BlankTile : Crushable
    {
        public override char tile
        {
            get
            {
                return (char)'\0';
            }
        }
        public override bool letCrush()
        {
            return true;
        }
        public override bool canExplode()
        {
            return true;
        }
    }
}
