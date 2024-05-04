using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Framework.Classes
{
    public class GameObject
    {
        public PictureBox Pb;
        public IMovement controller;
        private Point Position;
        private static GameObject ObjectInstance;
        private int Players = 0;
        private int Enemies = 0;
        private int Bullets = 0;
        private ObjectType Type;
        private int Score;
        private float Health = 1000;
        private GameObject(Image img, int left, int top, IMovement controller,ObjectType Type)
        {
            Position = new Point(left, top);
            Pb = new PictureBox();
            Pb.Image = img;
            Pb.Location = Position;
            if(Type == ObjectType.Player)
            Pb.Size = new Size(img.Width, img.Height);
            else if(Type == ObjectType.Enemy)
                Pb.Size = new Size(img.Width/2,img.Height/2);
            else if( Type == ObjectType.Bullet)
                Pb.Size = new Size((img.Width/2), (img.Height));
            Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            Pb.BackColor = Color.Transparent;
            this.controller = controller;
            SetObjectTypes(Type);
        }
        private GameObject() { }
        protected GameObject GetGameObject() { return new GameObject(); }
        public static GameObject GetObjectInstance(Image img, int left, int top, IMovement controller, ObjectType Type)
        {
            if((FactoryPattern.GetMaxObstacles() <= 15) && (FactoryPattern.GetMaxPlayers()<=5) && (FactoryPattern.GetMaxEnemies() <= 10) && (FactoryPattern.GetMaxBullets() <=1000))
            {
                ObjectInstance = new GameObject(img, left, top, controller, Type);
            }
            else
            {
                throw new Exception("More than capacity production");
            }
            return ObjectInstance;
        }
       
        public int GetScore()
        {
            return Score;
        }
        public void SetScore(int Score)
        {
            this.Score = Score;
        }
        public void SetHealth(float Health)
        {
            this.Health = Health;
        }
        public float GetHealth()
        {
            return Health;
        }
        public void SetObjectTypes(ObjectType Type)
        {
            if(Type == ObjectType.Player)
            {
                FactoryPattern.SetMaxPlayers(Players+=1);
               
            }
            else if(Type == ObjectType.Enemy)
            {
                FactoryPattern.SetMaxEnemy(Enemies+=1);
            }
            else if(Type == ObjectType.Bullet)
            {
                FactoryPattern.SetMaxBullets(Bullets++);
            }
            this.Type = Type;
        }
        public ObjectType GetObjectType()
        {
            return Type;
        }
        public Point GetPosition()
        {
            return Position;
        }
        public void update(Point Location)
        {   
            Position = controller.Move(Location);
            
            Pb.Location = Position;
        }
      }
}
