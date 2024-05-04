using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;
using System.Windows.Forms;
using System.Drawing;
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
            else if(Keyboard.IsKeyPressed(Key.LeftArrow)) { Location.X -= Speed;}
           
            return Location;
        }
        public void PlayerFire(Image Bullet, int StartWidth, int StartHeight, System.Drawing.Point FormWidth, Game game)
        {
            player.Fire(Bullet, StartWidth, StartHeight,FormWidth, game);
        }
       
    }
}
