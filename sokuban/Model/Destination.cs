using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sokuban.Model
{
    class Destination: Floor
    {
        public override bool MoveTo(MoveableObject moveableObject)
        {
            throw new NotImplementedException();
        }

        public override void Show()
        {
            Console.Write("0");
        }
    }
}
