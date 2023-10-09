using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpicyVader_Nima_Zarrabi
{
    internal class GameEngine
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        internal static bool allowMissileShot = false;
        public int enemyNumber = 0;
        public int s = 0;
        //public static Missile missile = new(GameEngine.DISTANCETOBOARDX, Program.DISTANCEMENUUP+ (GameEngine.BOARDSIZEY));
        public static Ship ship = new((DISTANCETOBOARDX + (GameEngine.BOARDSIZEX / 2)), DISTANCETOBOARDY);   // Creation du vaissau
        public List<Enemy> enemyList = new();                                             // Creation de la list d'enemies
        internal static List<Missile> missileList = new();

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        internal const int DISTANCETOBOARDX = 10;                                         // Distance Horizontal entre le bord et le plateau
        internal const int DISTANCETOBOARDY = 4;                                          // Distance Vertical entre le bord et le plateau
        internal const int BOARDSIZEX = 64;                                               // Taille du plateau Horizontal
        internal const int BOARDSIZEY = 20;                                               // Taille du plateau Vertical

        ///////////////////////////////////////////////// Programme du moteur du jeu ///////////////////////////////////////////////////

        public void Timer()
        {
            for (int i = 0; i < Enemy.TOTALENEMYSPAWN; i++)
            {
                enemyList.Add(new Enemy(GameEngine.DISTANCETOBOARDX + enemyNumber, 0));
                enemyNumber = enemyNumber + Enemy.DISTANCEBETWEEENENEMIES;
            }

            System.Timers.Timer enemyTimer = new();
            enemyTimer.Elapsed += new ElapsedEventHandler(enemymove);
            enemyTimer.Interval = 100;
            enemyTimer.Enabled = true;
            System.Timers.Timer missileTimer = new();
            missileTimer.Elapsed += new ElapsedEventHandler(missilemove);
            missileTimer.Interval = 100;
            missileTimer.Enabled = true;
            System.Timers.Timer shipTimer = new();
            shipTimer.Elapsed += new ElapsedEventHandler(shipmove);
            shipTimer.Interval = 30;
            shipTimer.Enabled = true;
            System.Timers.Timer BetweenShotsTimer = new();
            BetweenShotsTimer.Elapsed += new ElapsedEventHandler(allowshot);
            BetweenShotsTimer.Interval = 800;
            BetweenShotsTimer.Enabled = true;
            ship.shipmove();
        }

        // When enemy timer ticks
        internal void enemymove(object source, ElapsedEventArgs e)
        {
            foreach (Enemy currentenemy in enemyList)
            {
                currentenemy.Enemymove();
            }
        }

        // When ship timer ticks
        internal static void shipmove(object source, ElapsedEventArgs e)
        {
            ship.allowMove = true;
        }

        // When missile timer ticks
        internal void missilemove(object source, ElapsedEventArgs e)
        {
            if (missileList.Count > 0)
            {
                foreach (Missile currentmissile in missileList.ToList())
                {
                    currentmissile.Missilemove();
                    if (currentmissile.killMissile == true)
                    {
                        missileList.Remove(currentmissile);
                    }
                }
            }

        }
        internal void allowshot(object source, ElapsedEventArgs e)
        {
            allowMissileShot = true;
        }
        internal static void MissileSpawn()
        {
            missileList.Add(new Missile((ship.ShipY - 1), (ship.ShipX + 1)));
            missileList[missileList.Count - 1].Missilespawn();
        }
    }
}
