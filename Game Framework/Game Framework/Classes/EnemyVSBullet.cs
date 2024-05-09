using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework.Classes
{
    public class EnemyVSBullet : ICollision
    {
        public string DetectCollision(Actions action)
        {
            List<GameObject> Enemy = Game.GetEnemies();
            List<GameObject> Bullets = Game.GetBullets();
            foreach (GameObject enemy in Enemy)
            {
                foreach (GameObject bullet in Bullets)
                {
                    if (bullet.Pb.Bounds.IntersectsWith(enemy.Pb.Bounds))
                    {
                        if (action == Actions.PlayerScoreIncrement)
                        {
                            bullet.SetScore(bullet.GetScore() + 10);
                            return bullet.GetScore().ToString();
                        }
                        else if (action == Actions.EnemyDead)
                        {
                            Game.RemoveObject(enemy);
                            //FactoryPattern.SetMaxEnemy(FactoryPattern.GetMaxEnemies() - 1);
                            return Actions.EnemyDead.ToString();
                        }
                    }
                }
            }
            return null;
        }
    }
}
