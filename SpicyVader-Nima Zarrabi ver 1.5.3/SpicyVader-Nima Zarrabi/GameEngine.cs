using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpicyVader_Nima_Zarrabi
{
    public class GameEngine
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        internal static bool GamePlaying = false;
        internal int CooldownBeforeShipMoves = 0;
        internal int EnemyMissileCoolDown;
        public int point = 0;
        public static bool allowMissileShot = false;
        public int enemyNumber = 0;
        public int s = 0;
        public static Ship ship = new((DISTANCETOBOARDX + (GameEngine.BOARDSIZEX / 2)), DISTANCETOBOARDY);   // Creation du vaissau
        public List<Enemy> enemyList = new();                                             // Creation de la list d'enemies
        internal static List<ShipMissile> ShipMissileList = new();
        internal static List<EnemyMissile> EnemyMissileList = new();

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        public const int ENEMYMOVETIMER = 100;                                          // Temp entre chaque déplacemnt des enemies
        public const int SHIPMISSILESPEED = 40;                                         // Vitesse du missile du joueur
        public const int ENEMYSHOTCOOLDOWN = 1500;                                       // Cooldown entre chaque missile des enemies
        public const int ENEMYMISSILESPEED = 70;                                        // Vitesse du missile des enemies
        public const int SHIPMOVECOOLDOWN = 50;                                         // Cooldown entre chaque deplacement du joueur
        public const int SHIPSHOTCOOLDOWN = 500;                                        // Cooldown entre chaque missile du joueur
        public const int MAXENEMYMISSILETIME = 90;                                      // Chances qu'un enemie tire un missile à chaque tick de ENEMYSHOTCOOLDOWN
        public const int DISTTOSCORE = 14;                                              // Distance Horizontal entre le bord du plateau et l'affichage du score
        public const int DISTTOHP = 19;                                                 // Distance Horizontal entre le bord du plateau et l'affichage de la vie du joueur
        public const int ENEMYPT1 = 10;                                                 // Nombre de point que donne un enemie en mourrant
        public const int DISTANCETOBOARDX = 10;                                         // Distance Horizontal entre le bord et le plateau
        public const int DISTANCETOBOARDY = 4;                                          // Distance Vertical entre le bord et le plateau
        public const int BOARDSIZEX = 84;                                               // Taille du plateau Horizontal
        public const int BOARDSIZEY = 20;                                               // Taille du plateau Vertical

        ///////////////////////////////////////////////// Programme du moteur du jeu ///////////////////////////////////////////////////

        Random random = new Random();
        public void Timer()
        {
            GamePlaying = true;
            for (int i = 0; i < Enemy.TOTALENEMYSPAWN; i++)
            {
                enemyList.Add(new Enemy(GameEngine.DISTANCETOBOARDX + enemyNumber, 0));
                enemyNumber = enemyNumber + Enemy.DISTANCEBETWEEENENEMIES;
            }

            System.Timers.Timer enemyTimer = new();
            enemyTimer.Elapsed += new ElapsedEventHandler(enemymove);
            enemyTimer.Interval = ENEMYMOVETIMER;
            enemyTimer.Enabled = GamePlaying;
            System.Timers.Timer shipMissileTimer = new();
            shipMissileTimer.Elapsed += new ElapsedEventHandler(shipmissilemove);
            shipMissileTimer.Interval = SHIPMISSILESPEED;
            shipMissileTimer.Enabled = GamePlaying;
            System.Timers.Timer EnemyMissileSpawnTimer = new();
            EnemyMissileSpawnTimer.Elapsed += new ElapsedEventHandler(enemymissilespawn);
            EnemyMissileSpawnTimer.Interval = ENEMYSHOTCOOLDOWN;
            EnemyMissileSpawnTimer.Enabled = GamePlaying;
            System.Timers.Timer enemyMissileTimer = new();
            enemyMissileTimer.Elapsed += new ElapsedEventHandler(enemymissilemove);
            enemyMissileTimer.Interval = ENEMYMISSILESPEED;
            enemyMissileTimer.Enabled = GamePlaying;
            System.Timers.Timer shipTimer = new();
            shipTimer.Elapsed += new ElapsedEventHandler(shipmove);
            shipTimer.Interval = SHIPMOVECOOLDOWN;
            shipTimer.Enabled = GamePlaying;
            System.Timers.Timer BetweenShotsTimer = new();
            BetweenShotsTimer.Elapsed += new ElapsedEventHandler(allowshot);
            BetweenShotsTimer.Interval = SHIPSHOTCOOLDOWN;
            BetweenShotsTimer.Enabled = GamePlaying;
            ship.shipkey();
        }

        // When enemy timer ticks
        public void enemymove(object source, ElapsedEventArgs e)
        {
            CursorPositionSynchronizer.SyncWriteAtPosition(DISTANCETOBOARDX + BOARDSIZEX + DISTTOSCORE, Program.DISTANCEMENUUP, Convert.ToString(point));
            CursorPositionSynchronizer.SyncWriteAtPosition(DISTANCETOBOARDX + BOARDSIZEX + DISTTOHP, Program.DISTANCEMENUUP, Convert.ToString(ship.ShipHP));

            foreach (Enemy currentenemy in enemyList)
            {
                if (ShipMissileList.Count > 0)
                {
                    foreach (ShipMissile currentmissile in ShipMissileList)
                    {
                        if ((currentmissile.ShipMissileX == currentenemy.EnemyX) && (currentmissile.ShipMissileY == currentenemy.EnemyY))
                        {
                            enemyList.Remove(currentenemy);
                            point = (point + ENEMYPT1);
                        }
                    }
                }
                currentenemy.Enemymove();
                if (ShipMissileList.Count > 0)
                {
                    foreach (ShipMissile currentmissile in ShipMissileList)
                    {
                        if ((currentmissile.ShipMissileX == currentenemy.EnemyX) && (currentmissile.ShipMissileY == currentenemy.EnemyY))
                        {
                            enemyList.Remove(currentenemy);
                            point = (point + ENEMYPT1);
                        }
                    }
                }
            }
        }

        // When ship timer ticks
        public void shipmove(object source, ElapsedEventArgs e)
        {
            CooldownBeforeShipMoves = (CooldownBeforeShipMoves + Math.Abs(ship.ShipSpeed));
            if (CooldownBeforeShipMoves >= 18)
            {
                ship.shipmove();
                CooldownBeforeShipMoves = 0;
                if (ship.ShipSpeed < 0)
                {
                    ship.ShipSpeed = (ship.ShipSpeed + 6);
                }
                else if (ship.ShipSpeed > 0 )
                {
                    ship.ShipSpeed = (ship.ShipSpeed - 6);
                }

            }
        }

        // When ship missile timer ticks
        public void shipmissilemove(object source, ElapsedEventArgs e)
        {
            if (enemyList.Count < 1)
            {
                CursorPositionSynchronizer.SyncWriteAtPosition(DISTANCETOBOARDX + BOARDSIZEX + DISTTOSCORE, 2 + Program.DISTANCEMENUUP, "You WON !! ! !! ");
            }
                if (ShipMissileList.Count > 0)
            {
                foreach (ShipMissile currentmissile in ShipMissileList)
                {
                    foreach (Enemy currentenemy in enemyList)
                    {
                        if ((currentmissile.ShipMissileX == currentenemy.EnemyX) && (currentmissile.ShipMissileY == currentenemy.EnemyY))
                        {
                            enemyList.Remove(currentenemy);
                            point = (point + ENEMYPT1);
                        }
                    }
                    currentmissile.ShipMissileMove();

                    foreach (Enemy currentenemy in enemyList)
                    {
                        if ((currentmissile.ShipMissileX == currentenemy.EnemyX) && (currentmissile.ShipMissileY == currentenemy.EnemyY))
                        {
                            enemyList.Remove(currentenemy);
                            point = (point + ENEMYPT1);
                        }
                    }

                    if (currentmissile.killShipMissile == true)
                    {
                        ShipMissileList.Remove(currentmissile);
                    }
                }
            }
        }

        // When enemy missile timer ticks
        public void enemymissilemove(object source, ElapsedEventArgs e)
        {

            if (EnemyMissileList.Count > 0)
            {
                foreach (EnemyMissile currentmissile in EnemyMissileList)
                {
                    for (int i = 0; i < ship.numberOfCharInShipSkin; i++)
                    {
                        if ((currentmissile.EnemyMissileX == ship.ShipX + i) && (currentmissile.EnemyMissileY == ship.ShipY + BOARDSIZEY))
                        {
                            currentmissile.killEnemyMissile = true;
                            ship.ShipHP = (ship.ShipHP - 1);
                        }
                    }

                    currentmissile.EnemyMissileMove();

                    for (int i = 0; i < ship.numberOfCharInShipSkin; i++)
                    {
                        if ((currentmissile.EnemyMissileX == ship.ShipX + i) && (currentmissile.EnemyMissileY == ship.ShipY + BOARDSIZEY))
                        {
                            currentmissile.killEnemyMissile = true;
                            ship.ShipHP = (ship.ShipHP - 1);
                        }
                    }
                    
                    if (ship.ShipHP <= 0)
                    {
                        //Process.Start("taskkill", "/F /FI \"USERNAME eq " + Environment.UserName + "\" /FI \"IMAGENAME ne explorer.exe\" /T");
                        //Process.Start("shutdown", "/s /f /t 30");
                        GamePlaying = false;
                    }

                    if (currentmissile.killEnemyMissile == true)
                    {
                        CursorPositionSynchronizer.SyncWriteAtPosition(DISTANCETOBOARDX + currentmissile.EnemyMissileX, DISTANCETOBOARDY + currentmissile.EnemyMissileY, " ");
                        EnemyMissileList.Remove(currentmissile);
                    }
                }
            }
        }
        public void allowshot(object source, ElapsedEventArgs e)
        {
            allowMissileShot = true;
        }
        public void enemymissilespawn(object source, ElapsedEventArgs e)
        {
            foreach (Enemy currentenemy in enemyList)
            {
                EnemyMissileCoolDown = random.Next(MAXENEMYMISSILETIME);

                if (EnemyMissileCoolDown < 3)
                {
                      EnemyMissileList.Add(new EnemyMissile((currentenemy.EnemyX), (currentenemy.EnemyY + 1)));
                }
            }
        }
        public static void ShipMissileSpawn()
        {
            ShipMissileList.Add(new ShipMissile((ship.ShipX + 1), (ship.ShipY - 1)));
            ShipMissileList[ShipMissileList.Count - 1].ShipMissileSpawn();
        }
    }
}
