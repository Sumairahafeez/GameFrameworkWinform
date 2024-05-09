using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace Game_Framework.Classes
{
    public class GameObject
    {
        public PictureBox Pb;
        public IMovement controller;
        private System.Drawing.Point Position;
        private static GameObject ObjectInstance;
        private int Players = 0;
        private int Enemies = 0;
        private int Bullets = 0;
        private ObjectType Type;
        private int Score = 0;
        private float Health = 100;
        private GameObject(Image img, int left, int top, IMovement controller,ObjectType Type, bool isVisible)
        {
            Position = new System.Drawing.Point(left, top);
            Pb = new PictureBox();
            Pb.Image = img;
            Pb.Location = Position;
            Pb.Size = new Size(img.Width, img.Height);
            
                Pb.Size = new Size(img.Width/2,img.Height/2);
          
                Pb.Size = new Size((img.Width/2), (img.Height));
            Pb.SizeMode = PictureBoxSizeMode.StretchImage;
            Pb.BackColor = Color.Transparent;
            Pb.Visible = isVisible;
            this.controller = controller;
            SetObjectTypes(Type);
        }
        private GameObject() { }
        //protected GameObject GetGameObject() { return new GameObject(); }
        public static GameObject GetObjectInstance(Image img, int left, int top, IMovement controller, ObjectType Type,bool isVisble)
        {
            if((FactoryPattern.GetMaxObstacles() <= 15) && (FactoryPattern.GetMaxPlayers()<=5) && (FactoryPattern.GetMaxEnemies() <= 100) )
            {
                ObjectInstance = new GameObject(img, left, top, controller, Type,isVisble);
                return ObjectInstance;
            }
            else
            {
                throw new Exception("More than capacity production");
            }
            return null;
           
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
                FactoryPattern.SetMaxPlayers(FactoryPattern.GetMaxPlayers()+1);
               
            }
            else if(Type == ObjectType.Enemy)
            {
                FactoryPattern.SetMaxEnemy(FactoryPattern.GetMaxEnemies()+1);
            }
            else if(Type == ObjectType.Bullet)
            {
                FactoryPattern.SetMaxBullets(FactoryPattern.GetMaxBullets()+1);
            }
            this.Type = Type;
        }
        public ObjectType GetObjectType()
        {
            return Type;
        }
        public System.Drawing.Point GetPosition()
        {
            return Position;
        }
        public void update(System.Drawing.Point Location)
        {   if(Type  != ObjectType.Bullet)
            {
                Position = controller.Move(Location);

                Pb.Location = Position;
            }
           
            if (Type == ObjectType.Bullet)
            {
                if(Keyboard.IsKeyPressed(Key.Space))
                {
                    Pb.Visible = true;
                   

                }
                Position = controller.Move(Location);

                Pb.Location = Position;

            }
        }
        public void SetPosition(System.Drawing.Point Position )
        {
            this.Position = Position;
        }
        public void SetVisibility(bool Visible)
        {
            Pb.Visible = Visible;   
        }
      }
}
