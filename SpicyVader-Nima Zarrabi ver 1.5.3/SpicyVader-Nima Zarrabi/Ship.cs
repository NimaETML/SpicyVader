using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpicyVader_Nima_Zarrabi
{
    public class Ship
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////
        
        public bool IsDown { get; }
        public int numberOfCharInShipSkin;
        public int ShipSpeed = 0;
        public int ShipHP = 3;
        public bool allowMove = false;
        public int ShipX = 0;
        public int ShipY = 0;
        public int enemySkin1Legth = 0;
        public int enemySkin2Legth = 0;
        public int enemySkin3Legth = 0;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        public const int TOTALENEMYSPAWN = 10;
        public const string SHIPSKIN1 = "_[|]_";                                                    // Design for ship1 skin
        public const string SHIPSKIN2 = "-+I+-";                                                    // Design for enemy2 skin
        public const string SHIPSKIN3 = "_{M}_";                                                    // Design for enemy3 skin

        //////////////////////////////////////////////////// Programme du Vaisseau ////////////////////////////////////////////////////

        public Ship(int posX, int posY)
        {
            ShipX = posX;
            ShipY = posY;

            foreach (char _ in SHIPSKIN1)
            {
                numberOfCharInShipSkin++;
            }
        }

        internal void shipkey()
        {
            CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipX, Program.DISTANCEMENUUP + ShipY + (GameEngine.BOARDSIZEY - 1), SHIPSKIN1);
            ConsoleKeyInfo PressedKey = new ConsoleKeyInfo();
            do
            {
                ConsoleKeyInfo pressKeyInfo = Console.ReadKey(true);
                ConsoleKey Key1 = pressKeyInfo.Key;

                if (ConsoleKey.Spacebar == Key1)
                {
                    if (GameEngine.allowMissileShot)
                    {
                        GameEngine.ShipMissileSpawn();
                    }
                }

                //When left arrow
                if ((ConsoleKey.LeftArrow == Key1 || ConsoleKey.A == Key1) && ShipSpeed <= 18)
                {
                    if (ShipSpeed < -6)
                    {
                        ShipSpeed = (ShipSpeed + 12);
                    }
                    else
                    {
                        ShipSpeed = (ShipSpeed + 6);
                    }
                }
                PressedKey = Console.ReadKey(true);
                //When right arrow
                if ((ConsoleKey.RightArrow == Key1 || ConsoleKey.D == Key1) && ShipSpeed >= -18)
                {
                    if (ShipSpeed > 6)
                    {
                        ShipSpeed = (ShipSpeed - 12);
                    }
                    else
                    {
                        ShipSpeed = (ShipSpeed - 6);
                    }
                }
            }
            while (GameEngine.GamePlaying == true);
        }

        internal void shipmove()

        {
            if (ShipSpeed > 0)
            {
                foreach (char _ in SHIPSKIN1)
                {
                    CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipX, Program.DISTANCEMENUUP + ShipY + (GameEngine.BOARDSIZEY - 1), " ");
                    ShipX++;
                }
                foreach (char _ in SHIPSKIN1)
                {
                    ShipX--;
                }

                if (ShipX > GameEngine.DISTANCETOBOARDX + 0)
                {
                    ShipX--;
                }
                CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipX, Program.DISTANCEMENUUP + ShipY + (GameEngine.BOARDSIZEY - 1), SHIPSKIN1);
            }
            else if (ShipSpeed < 0)
            {
                foreach (char _ in SHIPSKIN1)
                {
                    CursorPositionSynchronizer.SyncWriteAtPosition(GameEngine.DISTANCETOBOARDX + ShipX, Program.DISTANCEMENUUP + ShipY + (GameEngine.BOARDSIZEY - 1), " ");
                    ShipX++;
                }
                foreach (char _ in SHIPSKIN1)
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
            }
            else
            {

            }

        }
    }

}
