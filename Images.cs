using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach
{
    abstract class Images
    {
        static public Image CellToPicture(Cell c)
        {
            switch (c)
            {
                case Cell.none: return Properties.Resources.none;
                case Cell.wall: return Properties.Resources.wall;
                case Cell.abox: return Properties.Resources.abox;
                case Cell.here: return Properties.Resources.here;
                case Cell.done: return Properties.Resources.done;
                case Cell.user: return Properties.Resources.user1;
                default: return Properties.Resources.none;
            }
        }
    }
}
