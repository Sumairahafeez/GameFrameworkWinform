using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework.Classes
{
    public class VerticalMovement : IMovement
    {   public int Speed;
        public Point Boundary;
        Direction direction;
        public VerticalMovement(int speed, System.Drawing.Point Boundary,Direction Direction)
        {
            this.Speed = speed;
            this.Boundary = Boundary;
            this.direction = Direction;
        }
        Point IMovement.Move(Point Location)
        {
           if(direction == Direction.Up)
            Location.Y -= 50;
           else if(direction == Direction.Down)
                Location.Y += 50;
            return Location;
        }
    }
}
