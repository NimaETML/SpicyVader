using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class Ship
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        internal bool allowMove = false;
        internal int ShipX = 0;
        internal int ShipY = 0;
        internal int enemySkin1Legth = 0;
        internal int enemySkin2Legth = 0;
        internal int enemySkin3Legth = 0;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        internal const int TOTALENEMYSPAWN = 10;
        internal const string SHIPSKIN1 = "[|]";                                                    // Design for ship1 skin
        internal const string ENEMYSKIN2 = "#";                                                     // Design for enemy2 skin
        internal const string ENEMYSKIN3 = "{|}";                                                   // Design for enemy3 skin

        //////////////////////////////////////////////////// Programme du Vaisseau ////////////////////////////////////////////////////

        public Ship(int posX, int posY)
        {
            ShipX = posX;
            ShipY = posY;
        }

        internal void shipmove()
        
        {
            //ShipX += (GameEngine.BOARDSIZEX / 10); 
            CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipX, Program.DISTANCEMENUUP + ShipY + (GameEngine.BOARDSIZEY - 1), SHIPSKIN1);
            do
            {
                ConsoleKeyInfo pressKeyInfo = Console.ReadKey(true);
                ConsoleKey Key1 = pressKeyInfo.Key; 

                if (ConsoleKey.Spacebar == Key1)
                {
                    if (GameEngine.allowMissileShot == true)
                    {
                         GameEngine.MissileSpawn();
                    }
                }

                //When up arrow
                if ((ConsoleKey.LeftArrow == Key1) && (allowMove == true))
                {
                    foreach (char c in SHIPSKIN1)
                    {
                        CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipX, Program.DISTANCEMENUUP + ShipY + (GameEngine.BOARDSIZEY - 1), " ");
                        ShipX++;
                    }
                    foreach (char c in SHIPSKIN1)
                    {
                        ShipX--;
                    }

                    if (ShipX > GameEngine.DISTANCETOBOARDX + 0)
                    {
                        ShipX--;
                    }
                    else
                    {

                    }
                    CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipX, Program.DISTANCEMENUUP + ShipY + (GameEngine.BOARDSIZEY - 1), SHIPSKIN1);
                    allowMove = false;
                }

                //When down arrow
                if ((ConsoleKey.RightArrow == Key1) && (allowMove == true))
                {
                    foreach (char c in SHIPSKIN1)
                    {
                        CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipX, Program.DISTANCEMENUUP + ShipY + (GameEngine.BOARDSIZEY - 1), " ");
                        ShipX++;
                    }
                    foreach (char c in SHIPSKIN1)
                    {
                        ShipX--;
                    }
                    if (ShipX <= GameEngine.DISTANCETOBOARDX + GameEngine.BOARDSIZEX)
                    {
                        ShipX++;
                    }
                    else
                    {

                    }
                    CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipX, Program.DISTANCEMENUUP + ShipY + (GameEngine.BOARDSIZEY - 1), SHIPSKIN1);
                    allowMove = false;
                }
            }
            while (true);
        }
    }
}
