using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Framework.Classes
{
    public class Game
    {
        public List<GameObject> gameObjectList;
        public Form container;
        private static Game Instance;
        private static List<GameObject> EnemyObjects;
        private static List<GameObject> PlayerObjects;
        private static List<GameObject> Bullets;
        private Game(Form container)
        {
            gameObjectList = new List<GameObject>();
            EnemyObjects = new List<GameObject>();
            PlayerObjects = new List<GameObject>();
            Bullets = new List<GameObject>();
            this.container = container;
        }
        public static Game GetValidInstance(Form Container)
        {
            if(Instance == null)
            {
                Instance = new Game(Container);
            }
            return Instance;
        }
        public void AddGameObject(Image img, int left, int top, IMovement controller,ObjectType Type)
        {   
            GameObject gameObject = GameObject.GetObjectInstance(img, left, top, controller,Type);
           
            if (Type == ObjectType.Enemy)
            {
                EnemyObjects.Add(gameObject);
            }
            else if (Type == ObjectType.Player)
            {
                PlayerObjects.Add(gameObject);
            }
            else if (Type == ObjectType.Bullet)
            {
                Bullets.Add(gameObject);
            }
            gameObjectList.Add(gameObject);
            container.Controls.Add(gameObject.Pb);
        }

        public void Update()
        {
            foreach (GameObject go in gameObjectList)
            {
                go.update(go.GetPosition());
                //CollissionDetector.PlayerVSEnemy(ObjectType.Player, ObjectType.Enemy);
         
            }
        }
        public static List<GameObject> GetPlayers()
        {
            return PlayerObjects;
        }
        public static List<GameObject> GetEnemies()
        {
            return EnemyObjects;
        }
        public static List<GameObject> GetBullets()
        {
            return Bullets;
        }
       
    }


}
