using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
namespace Game_Framework.Classes
{
    public class KeyBoardMovement : IMovement
    {
        int Speed;
        System.Drawing.Point Position;
        System.Drawing.Point ContainerCoordinates;
        IPlayer player;
        public KeyBoardMovement(int Speed,System.Drawing.Point Location,System.Drawing.Point FormLocation,IPlayer Player)
        {
            this.Speed = Speed;
            this.Position = Location;
            this.ContainerCoordinates = FormLocation;
            this.player = Player;
        }

       
        public System.Drawing.Point Move(System.Drawing.Point Location)
        {
            if(Keyboard.IsKeyPressed(Key.RightArrow))
            {
                Location.X += Speed;
                if(Location.X-30 >= ContainerCoordinates.X)
                {
                    Location.X = 0;
                }
            }
            else if(Keyboard.IsKeyPressed(Key.LeftArrow)) 
            { Location.X -= Speed;
                if(Location.X-30 <= 0)
                {
                    Location.X = 0;
                }
                
            }
            else if(Keyboard.IsKeyPressed(Key.DownArrow))
            {
                Location.Y += Speed;
                if(Location.Y-30 >= ContainerCoordinates.Y)
                {
                    Location.Y = 0;
                }
            }
            else if(Keyboard.IsKeyPressed (Key.UpArrow))
            {
                Location.Y -= Speed;
                if(Location.Y+30 <= 0)
                {
                    Location.Y = 0;
                }
            }
            
          
            return Location;
        }
        
    }
}
