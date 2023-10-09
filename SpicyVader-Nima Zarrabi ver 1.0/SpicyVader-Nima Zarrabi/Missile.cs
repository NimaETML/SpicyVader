using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpicyVader_Nima_Zarrabi
{
    internal class Missile
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        internal bool killMissile = false;
        internal int MissileX;
        internal int MissileY;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        internal const string MISSILESKIN1 = "|";                                                   // Design for enemy1 skin
        internal const string ENEMYSKIN2 = "#";                                                     // Design for enemy2 skin
        internal const string ENEMYSKIN3 = "{|}";                                                   // Design for enemy3 skin

        //////////////////////////////////////////////////// Programme de l'Enemie ////////////////////////////////////////////////////

        public Missile(int posX, int posY)
        {
            MissileX = posX;
            MissileY = posY;
        }

        internal void Missilespawn()
        {
            MissileX = (GameEngine.ship.ShipX + 1);
            MissileY = (GameEngine.ship.ShipY - 2);
            GameEngine.allowMissileShot = false;
        }

        // Fair l'ennemie avancer de 1 (s'execute chaque tick)
        internal void Missilemove()
        {

                foreach (char c in MISSILESKIN1)
                {
                CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + MissileX, Program.DISTANCEMENUUP + MissileY + (GameEngine.BOARDSIZEY), " ");
                    MissileY--;
                }
                foreach (char c in MISSILESKIN1)
                {
                    MissileY++;
                }

                // Si l'ennemie ne dépace pas la taille de plateau en Y en negative
                if (MissileY + Program.DISTANCEMENUUP + (GameEngine.BOARDSIZEY) > GameEngine.DISTANCETOBOARDY)
                {
                    MissileY--;
                }
                // Sinon, le missile cesse d'exister
                else
                {
                    foreach (char c in MISSILESKIN1)
                    {
                        CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + MissileX, Program.DISTANCEMENUUP + MissileY + (GameEngine.BOARDSIZEY), " ");
                        MissileY--;
                    }
                    killMissile = true;
    }
                CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + MissileX, MissileY + Program.DISTANCEMENUUP + (GameEngine.BOARDSIZEY), MISSILESKIN1);

        }

        internal void IsMissileAllowed()
        {

        }
    }
}
