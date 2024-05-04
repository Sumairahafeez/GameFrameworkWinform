using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework.Classes
{
    public class Player : GameObject, IPlayer
    {
        GameObject ObjectInstance;
        public new GameObject GetObjectInstance()
        {
            if ((FactoryPattern.GetMaxObstacles() <= 15) && (FactoryPattern.GetMaxPlayers() <= 5) && (FactoryPattern.GetMaxEnemies() <= 10) && (FactoryPattern.GetMaxBullets() <= 1000))
            {
                ObjectInstance = GetGameObject();
            }
            else
            {
                throw new Exception("More than capacity production");
            }
            return ObjectInstance;
        }
        public void Fire(Image Bullet,int StartWidth,int StartHeight,Point FormWidth,Game game)
        {   
            IMovement BulletMovement = new HorizontalMovement(10, new System.Drawing.Point(StartWidth,StartHeight), Direction.Right, FormWidth);
            game.AddGameObject(Bullet,StartWidth,StartHeight, BulletMovement, ObjectType.Bullet);

        }
    }
}
