using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Framework.Classes
{
    public class CollissionDetector
    {
       
        public static string PlayerVSEnemy(ObjectType PType,ObjectType EType,Actions actions)
        {
            List<GameObject> Players = Game.GetPlayers();
            List<GameObject> Enemy = Game.GetEnemies();
            foreach (GameObject Player in Players)
            {
                foreach (GameObject EnemyPlayer in Enemy)
                {
                    if(Player.Pb.Bounds.IntersectsWith(EnemyPlayer.Pb.Bounds))
                    {   if(actions == Actions.PlayerHealthReduction)
                        {
                            Player.SetHealth(Player.GetHealth() - 10f);
                            return Player.GetHealth().ToString();
                        }
                        if(actions == Actions.PlayerScoreIncrement)
                        {
                            Player.SetScore(Player.GetScore() + 10);
                            return Player.GetScore().ToString();
                        }
                        if(actions == Actions.EnemyDead)
                        {
                            Enemy.Remove(Player);
                            EnemyPlayer.Pb.Visible = false;
                            return Actions.EnemyDead.ToString();
                        }
                        else if(actions == Actions.PlayerDead)
                        {
                            Players.Remove(Player);
                            Player.Pb.Visible = false;
                            return Actions.PlayerDead.ToString();
                        }
                        
                    }
                }
            }
            return null;
        }
        public static string EnemyVSPlayerBullet(ObjectType EType, ObjectType BType, Actions action)
        {
            List<GameObject> Enemy = Game.GetEnemies();
            List<GameObject> Bullets = Game.GetBullets();
            foreach(GameObject enemy in Enemy)
            {
                foreach(GameObject bullet in Bullets)
                {
                    if(bullet.Pb.Bounds.IntersectsWith(enemy.Pb.Bounds))
                    {
                        if(action == Actions.PlayerScoreIncrement)
                        {
                            bullet.SetScore(bullet.GetScore() + 10);
                            return bullet.GetScore().ToString();
                        }
                        else if(action == Actions.EnemyDead)
                        {
                            Game.RemoveObject(enemy);
                            return Actions.EnemyDead.ToString();
                        }
                    }
                }
            }
            return null;
        }
    }
}
