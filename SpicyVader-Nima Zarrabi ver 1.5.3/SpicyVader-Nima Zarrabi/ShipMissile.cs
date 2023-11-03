using Org.BouncyCastle.Asn1.Kisa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpicyVader_Nima_Zarrabi
{
    public class ShipMissile
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public double GetShipMiddleLength;
        public int ShipMiddleLength = 0;
        public bool killShipMissile = false;
        public int ShipMissileX;
        public int ShipMissileY;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        internal const string SHIPMISSILESKIN1 = "|";                                                   // Design for enemy1 skin

        //////////////////////////////////////////////////// Programme de l'Enemie ////////////////////////////////////////////////////

        public ShipMissile(int posX, int posY)
        {
            ShipMissileX = posX;
            ShipMissileY = posY;
        }

        public void ShipMissileSpawn()
        {

            GetShipMiddleLength = (GameEngine.ship.numberOfCharInShipSkin/2);
            ShipMiddleLength = Convert.ToInt16(Math.Round(GetShipMiddleLength));
            ShipMissileX = (GameEngine.ship.ShipX + ShipMiddleLength);
            ShipMissileY = (GameEngine.ship.ShipY - 2) + GameEngine.BOARDSIZEY;
            GameEngine.allowMissileShot = false;
        }

        // Fair l'ennemie avancer de 1 (s'execute chaque tick)
        internal void ShipMissileMove()
        {
            foreach (char _ in SHIPMISSILESKIN1)
            {
                CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipMissileX, Program.DISTANCEMENUUP + ShipMissileY, " ");
                ShipMissileY--;
            }
            foreach (char _ in SHIPMISSILESKIN1)
            {
                ShipMissileY++;
            }

            // Tant que le Missile est dans le plateau en Y
            if (ShipMissileY + Program.DISTANCEMENUUP > GameEngine.DISTANCETOBOARDY)
            {
                ShipMissileY--;
            }
            // Sinon, Si l'ennemie ne dépace pas la taille de plateau en Y en negative, le missile cesse d'exister
            else
            {
                foreach (char c in SHIPMISSILESKIN1)
                {
                    CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipMissileX, Program.DISTANCEMENUUP + ShipMissileY, " ");
                }
                killShipMissile = true;
            }
            CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipMissileX, Program.DISTANCEMENUUP + ShipMissileY, SHIPMISSILESKIN1);
            if (killShipMissile == true)
            {
                CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipMissileX, ShipMissileY + Program.DISTANCEMENUUP, " ");
            }
        }

        internal void IsShipMissileAllowed()
        {

        }
    }
}
