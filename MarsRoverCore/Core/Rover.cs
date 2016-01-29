
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCore.Core
{
    class Rover
    {
        public enum Command { L, R, M };

        public Position RoverPosition { get; set; }
        private Landscape RoverLandscape { get; set; }

        private void init(Landscape landscape, Position position)
        {
            this.RoverLandscape = landscape;
            this.RoverPosition = position;
        }

        //Default - Rover is placed in a 200 X 200 Landscape & Positioned 0,0 N
        public Rover()
        {
            init(new Landscape(200, 200), new Position(0, 0, Position.Direction.N));
        }

        public Rover(Landscape roverLandScape, Position roverPosition)
        {
            init(roverLandScape, roverPosition);
        }

        public Position Move(Command command)
        {

            var intDirection = command == Command.L ? -1 : (command == Command.R ? 1 : 0);

            if (intDirection != 0)
            {
                var currentDirection = ((int)this.RoverPosition.direction + intDirection);
                if (currentDirection < 0)
                    this.RoverPosition.direction = Position.Direction.W;
                else if (currentDirection > 3)
                    this.RoverPosition.direction = Position.Direction.N;
                else
                    this.RoverPosition.direction = (Position.Direction)Enum.ToObject(typeof(Position.Direction), currentDirection);
            }
            else
            {
                var incX = this.RoverPosition.direction == Position.Direction.W && this.RoverPosition.x != 0
                    ? -1 : (this.RoverPosition.direction == Position.Direction.E ? 1 : 0);
                var incY = this.RoverPosition.direction == Position.Direction.N ? 1 : (this.RoverPosition.direction == Position.Direction.S && this.RoverPosition.y != 0 ? -1 : 0);

                this.RoverPosition.x += incX;
                this.RoverPosition.y += incY;

                // Max X and Y are checked
                if (this.RoverPosition.x > this.RoverLandscape.maxX)
                    this.RoverPosition.x = this.RoverLandscape.maxX;
                if (this.RoverPosition.y > this.RoverLandscape.maxY)
                    this.RoverPosition.y = this.RoverLandscape.maxY;

            }
            return this.RoverPosition;
        }


    }
}
