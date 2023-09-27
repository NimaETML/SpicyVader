using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpicyVader_Nima_Zarrabi
{
    internal class Enemy
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        internal bool goingRight = true;
        internal int EnemyX = 0;
        internal int EnemyY = 0;
        internal int enemySkin1Legth = 0;
        internal int enemySkin2Legth = 0;
        internal int enemySkin3Legth = 0;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        internal const int DISTANCEBETWEEENENEMIES = 3;
        internal const int BOARDSIZEX = 45;
        internal const int BOARDSIZEY = 25;
        internal const int TOTALENEMYSPAWN = 10;
        internal const string ENEMYSKIN1 = "X";                                                     // Design for enemy1 skin
        internal const string ENEMYSKIN2 = "#";                                                     // Design for enemy2 skin
        internal const string ENEMYSKIN3 = "{|}";                                                   // Design for enemy3 skin

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////
        public Enemy(int posX, int posY)
        {
            EnemyX = posX;
            EnemyY = posY;
        }

        internal void enemyspawn()
        {



            /*foreach (char c in ENEMYSKIN2)
            {
                enemySkin2Legth++;
            }
            foreach (char c in ENEMYSKIN3)
            {
                enemySkin3Legth++;
            }
            for (int i = 0; i <= TOTALENEMYSPAWN; i++)
            {
                EnemyX = EnemyX + 2;
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + EnemyX, Program.DISTANCEMENUUP + EnemyY);
                Console.Write(ENEMYSKIN1);
            }*/
        }

        internal void enemymove()
        {

            Console.SetCursorPosition(Program.DISTANCEMENULEFT + EnemyX, Program.DISTANCEMENUUP + EnemyY);
            foreach (char c in ENEMYSKIN1)
            {
                Console.Write(" ");
            }
            if (goingRight == true) 
            {
                if (EnemyX < BOARDSIZEX)
                {
                    EnemyX++;
                }
                else
                {
                    EnemyY++;
                    goingRight = false;
                }
            }
            else
            {
                if (EnemyX > 0)
                {
                    EnemyX--;
                }
                else
                {
                    EnemyY++;
                    goingRight = true;
                }
            }
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + EnemyX, Program.DISTANCEMENUUP + EnemyY);
            Console.Write(ENEMYSKIN1);

        }
    }
}
