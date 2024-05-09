using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework.Classes
{
    public class EnemyVSPlayerCollision : ICollision
    {
        string ICollision.DetectCollision(Actions actions)
        {
            List<GameObject> Players = Game.GetPlayers();
            List<GameObject> Enemy = Game.GetEnemies();
            foreach (GameObject Player in Players)
            {
                foreach (GameObject EnemyPlayer in Enemy)
                {
                    if (Player.Pb.Bounds.IntersectsWith(EnemyPlayer.Pb.Bounds))
                    {
                        if (actions == Actions.PlayerHealthReduction)
                        {
                            Player.SetHealth(Player.GetHealth() - 10f);
                            return Player.GetHealth().ToString();
                        }
                        if (actions == Actions.PlayerScoreIncrement)
                        {
                            Player.SetScore(Player.GetScore() + 10);
                            return Player.GetScore().ToString();
                        }
                        if (actions == Actions.EnemyDead)
                        {
                            Enemy.Remove(Player);
                            EnemyPlayer.Pb.Visible = false;
                            return Actions.EnemyDead.ToString();
                        }
                        else if (actions == Actions.PlayerDead)
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
    }
}
