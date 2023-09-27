using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpicyVader_Nima_Zarrabi
{
    internal class GameEngine
    {
        public int enemyNumber = 0;
        List<Enemy> enemyList = new List<Enemy>();
        //public static int[] EnemyX = new int[Enemy.TOTALENEMYSPAWN];
        //public static int[] EnemyY = new int[Enemy.TOTALENEMYSPAWN];

        //public Enemy enemy1 = new Enemy((Enemy.DISTANCEBETWEEENENEMIES), 0); 

        public void Timer()
        {
            for (int i = 0; i < Enemy.TOTALENEMYSPAWN; i++)
            {
                enemyList.Add(new Enemy(enemyNumber, 0));
                enemyNumber = enemyNumber + Enemy.DISTANCEBETWEEENENEMIES;
            }
            System.Timers.Timer enemyTimer = new System.Timers.Timer();
            enemyTimer.Elapsed += new ElapsedEventHandler(enemymove);
            enemyTimer.Interval = 200;
            enemyTimer.Enabled = true;
            System.Timers.Timer shipTimer = new System.Timers.Timer();
            shipTimer.Elapsed += new ElapsedEventHandler(shipmove);
            shipTimer.Interval = 100;
            shipTimer.Enabled = false;
            Console.ReadKey();
        }
        // When enemy timer ticks
        internal void enemymove(object source, ElapsedEventArgs e)
        {
            foreach (Enemy currentenemy in enemyList)
            {
                currentenemy.enemymove();
            }
        }

        // When ship timer ticks
        private static void shipmove(object source, ElapsedEventArgs e)
        {
            Program.PosY++;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            Console.WriteLine("Hello World!");
        }
    }
}
