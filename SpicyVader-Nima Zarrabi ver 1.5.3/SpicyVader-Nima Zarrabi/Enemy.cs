using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpicyVader_Nima_Zarrabi
{
    public class Enemy
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public int x { get; set; }
        public int y { get; set; }
        internal bool goingRight = true;
        internal int EnemyX = 0;
        internal int EnemyY = 0;
        internal int enemySkin1Legth = 0;
        internal int enemySkin2Legth = 0;
        internal int enemySkin3Legth = 0;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        internal const int DISTANCEBETWEEENENEMIES = 3;
        internal const int TOTALENEMYSPAWN = 30;
        internal const string ENEMYSKIN1 = "X";                                                     // Design for enemy1 skin
        internal const string ENEMYSKIN2 = "#";                                                     // Design for enemy2 skin
        internal const string ENEMYSKIN3 = "{|}";                                                   // Design for enemy3 skin

        //////////////////////////////////////////////////// Programme de l'Enemie ////////////////////////////////////////////////////
        public Enemy(int posX, int posY)
        {
            EnemyX = posX;
            EnemyY = posY;
        }

        // Fair l'ennemie avancer de 1 (s'execute chaque tick)
        internal void Enemymove()
        {
            foreach (char c in Enemy.ENEMYSKIN1)
            {
                CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + EnemyX, GameEngine.DISTANCETOBOARDY + EnemyY, " ");
                EnemyX++;
            }
            foreach (char c in Enemy.ENEMYSKIN1)
            {
                EnemyX--;
            }

            // Si l'ennemie avance vers la droite
            if (goingRight == true) 
            {
                // Si l'ennemie ne dépace pas la taille de plateau en X en positive
                if (EnemyX < GameEngine.DISTANCETOBOARDX + GameEngine.BOARDSIZEX)
                {
                    EnemyX++;
                }
                // Sinion, l'ennemie vas de 1 vers le bas et change de direction
                else
                {
                    EnemyY++;
                    goingRight = false;
                }
            }
            // Si l'ennemie n'avance pas vers la droite
            else
            {
                //Si l'ennemie dépace la taille de plateau en X en négative
                if (EnemyX > GameEngine.DISTANCETOBOARDX + 0)
                {
                    EnemyX--;
                }
                // Sinion, l'ennemie vas de 1 vers le bas et change de direction
                else
                {
                    EnemyY++;
                    goingRight = true;
                }
            }
            CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + EnemyX, GameEngine.DISTANCETOBOARDY + EnemyY, ENEMYSKIN1);
            /*foreach (char c in Enemy.ENEMYSKIN1)
            {
                EnemyX--;
            }*/
        }
    }
}
