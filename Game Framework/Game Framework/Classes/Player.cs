using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Framework.Classes
{
    public class Player : IPlayer
    {
        Image Bullet;
        int StartWidth;
        int StartHeight;
        Point FormWidth;
        Game game;
        public Player(Image Bullet, int StartWidth, int StartHeight, Point FormWidth, Form form)
        {
            this.Bullet = Bullet;
            this.StartWidth = StartWidth;
            this.StartHeight = StartHeight;
            this.FormWidth = FormWidth;
            game = Game.GetValidInstance(form);
        }
        public void Fire()
        {   
            //IMovement BulletMovement = new HorizontalMovement(10, new System.Drawing.Point(StartWidth,StartHeight), Direction.Right, FormWidth);
            //game.AddGameObject(Bullet,StartWidth,StartHeight, BulletMovement, ObjectType.Bullet);
            //GameObject objectT = GameObject.GetObjectInstance(Bullet, StartWidth, StartHeight, BulletMovement, ObjectType.Bullet);
            //game.AddObject(objectT);
            List<GameObject> bullets = Game.GetBullets();
            foreach (GameObject b in bullets)
            {
               b.update(new Point(StartWidth,StartHeight));
            }
        }
    }
}
