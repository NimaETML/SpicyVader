using Org.BouncyCastle.Asn1.Kisa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpicyVader_Nima_Zarrabi
{
    internal class EnemyMissile
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        internal bool killEnemyMissile = false;
        internal int EnemyMissileX;
        internal int EnemyMissileY;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        internal const string ENEMYMISSILESKIN1 = "'";                                              // Design for enemy1 skin
        internal const string ENEMYSKIN2 = "#";                                                     // Design for enemy2 skin
        internal const string ENEMYSKIN3 = "{|}";                                                   // Design for enemy3 skin

        //////////////////////////////////////////////////// Programme de l'Enemie ////////////////////////////////////////////////////

        public EnemyMissile(int posX, int posY)
        {
            EnemyMissileX = posX;
            EnemyMissileY = posY;
        }

        // Fair l'ennemie avancer de 1 (s'execute chaque tick)
        internal void EnemyMissileMove()
        {
            foreach (char c in ENEMYMISSILESKIN1)
            {
                CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + EnemyMissileX, GameEngine.DISTANCETOBOARDY + EnemyMissileY, " ");
                EnemyMissileY++;
            }
            foreach (char c in ENEMYMISSILESKIN1)
            {
                EnemyMissileY--;
            }

            // Tant que le Missile est dans le plateau en Y
            if (EnemyMissileY < GameEngine.DISTANCETOBOARDY + GameEngine.BOARDSIZEY)
            {
                EnemyMissileY++;
                CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + EnemyMissileX, GameEngine.DISTANCETOBOARDY + EnemyMissileY, ENEMYMISSILESKIN1);
            }
            // Sinon, Si le missile de l'ennemie ne dépace pas la taille de plateau en Y en possitive, le missile cesse d'exister
            else
            {
                foreach (char c in ENEMYMISSILESKIN1)
                {
                    EnemyMissileY++;
                    CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + EnemyMissileX, GameEngine.DISTANCETOBOARDY + EnemyMissileY, " ");
                }
                killEnemyMissile = true;
            }
            /*
            if (killEnemyMissile == true)
            {
                EnemyMissileY++;
                CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + EnemyMissileX, GameEngine.DISTANCETOBOARDY + EnemyMissileY, " ");
            }*/
        }

        internal void IsEnemyMissileAllowed()
        {

        }
    }
}
