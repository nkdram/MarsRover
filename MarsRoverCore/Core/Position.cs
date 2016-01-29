using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCore.Core
{
    class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public Direction direction { get; set; }
        public enum Direction { N = 0, E = 1, S = 2, W = 3 };

        public Position(int _x, int _y, Direction _direction)
        {
            this.x = _x;
            this.y = _y;
            this.direction = (MarsRoverCore.Core.Position.Direction)Enum.Parse(typeof(MarsRoverCore.Core.Position.Direction), _direction.ToString(), true); ;
        }

        public Position setPosition(int _x, int _y, Direction _direction)
        {
            this.x = _x;
            this.y = _y;
            this.direction = direction;
            return this;
        }
    }
}
