using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    class Destination: Floor
    {

        public override void Show()
        {
            if (this.MoveableObject != null)
            {
                MoveableObject.Show();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("x");
                Console.ResetColor();
            }
            
        }
    }
}
