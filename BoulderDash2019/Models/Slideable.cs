using BoulderDash2019.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash2019.Models
{
    public abstract class Slideable : Moveable
    {
        public void Move(Movement movement)
        {

            int newx = moveableOnTile.x;
            int newy = moveableOnTile.y;

            if (movement == Movement.Down)
            {
                newy++;
            }

            // Only code for falling down
            var nextTile = moveableOnTile.level.tiles.Find(tile => tile.x == newx && tile.y == newy);

            if (nextTile.moveable.letCrush())//nextTile.moveable.GetType() == typeof(BlankTile))
            {
                if (moveableOnTile.moveable.Crush())
                {
                    // Probleem: Boulders gaan nu eerst naar beneden en ook als het een player is. Daarna overschrijft de movment van de player de boulder omdat deze een: 
                    // new BlankTile() aanmaakt. Boulders moeten ook niet pas naar beneden vallen nadat de movement is gemaakt omdat je dan niet onder een Boulder kan graven,
                    // want dan plet deze je meteen.

                    // Oplossing: Bij het moment dat de player onder een boulder staan en hij niet van het vakje weggaat valt de boulder op de player. 
                    // Hiervoor moet elke boulder dus kunnen zien of de player wegbeweegt van het vakje onder hem , maar hier is dan weer een counter nodig die elke keer 
                    // gereset moet worden. Hoe kan dit op een betere manier opgelost worden?
                     
                    // If nextTile == player { Die }
                    Console.WriteLine("sssssssssssssssssss");
                    var key = Console.ReadKey();
                }
                nextTile.moveable = this;
                moveableOnTile.moveable = new BlankTile();
                moveableOnTile = nextTile;
            }
            else if (nextTile.moveable.letSlide())
            {
               if (moveableOnTile.tileToLeft.moveable.letCrush() && moveableOnTile.tileToLeft.tileToBottom.moveable.letCrush())
                {
                    moveableOnTile.tileToLeft.moveable = this;
                    moveableOnTile.moveable = new BlankTile();
                    moveableOnTile = moveableOnTile.tileToLeft;
                }
                else if (moveableOnTile.tileToRight.moveable.letCrush() && moveableOnTile.tileToRight.tileToBottom.moveable.letCrush())
                {
                    moveableOnTile.tileToRight.moveable = this;
                    moveableOnTile.moveable = new BlankTile();
                    moveableOnTile = moveableOnTile.tileToRight;
                }
            }
        }
    }
}
