using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Framework.Classes
{
    public class FactoryPattern
    {
        private static int MaxPlayers;
        private static int MaxEnemies;
        private static int MaxBullets;
        private static int MaxObstacles;
        public static int GetMaxPlayers()
        {
            return MaxPlayers;
        }
        public static int GetMaxEnemies()
        {
            return MaxEnemies;
        }
        public static int GetMaxBullets()
        {
            return MaxBullets;
        }
        public static int GetMaxObstacles()
        {
            return MaxObstacles;
        }
        public static void SetMaxPlayers(int maxPlayers)
        {
            MaxPlayers = maxPlayers;
        }
        public static void SetMaxEnemy(int maxEnemy)
        {
            MaxEnemies = maxEnemy;
        }
        public static void SetMaxBullets(int maxBullets)
        {
            MaxBullets = maxBullets;
        }
        public static void SetMaxObstacles(int maxObstacles)
        {
            MaxObstacles = maxObstacles;
        }
    }
}
