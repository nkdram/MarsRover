using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCore.Core
{
    class Landscape
    {
        public int maxX { get; set; }
        public int maxY { get; set; }

        public Landscape(int x, int y)
        {
            this.maxX = x;
            this.maxY = y;
        }        
    }
}
