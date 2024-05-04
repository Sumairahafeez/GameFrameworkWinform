using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework.Classes
{
    public class HorizontalMovement : IMovement
    {
        public int Speed;
        public Point Boundary;
        Direction direction;
        System.Drawing.Point ContainerCoordinates;
        public HorizontalMovement(int speed, Point boundary, Direction direction, Point containerCoordinates)
        {
            Speed = speed;
            Boundary = boundary;
            this.direction = direction;
            ContainerCoordinates = containerCoordinates;
        }

        Point IMovement.Move(Point Location)
        {   if (direction == Direction.Right) 
            Location.X += 10;   
                else if(direction == Direction.Left)
                Location.X -= 10;
            if (Location.X-30 <= 0)
                Location.X = ContainerCoordinates.X;
            else if(Location.X-30 >= ContainerCoordinates.X)
                Location.X = 0;
            
            return Location;
        }
    }
}
