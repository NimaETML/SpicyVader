/*

Programme                  : Spicyvader.cs

Auteur                     : Nima Zarrabi

Date creation              : 4/9/2023

Date dernière modificaion  : 25.9.2023

Version                    : 0.7

*/

/*

Description du programme :

Jeu similair à "Space invader", en console.

*/

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpicyVader_Nima_Zarrabi
{
    internal class Program
    {

        //Version:
        public const string VERSION = "0.7";
        public const string BACK = "[ Exit ]";

        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static bool Enter = false;
        public static int PosY = 0;                                                                // Positionement horizontal du curseur
        public static int PosX = 0;                                                                // Positionement vertical du curseur

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        public const int DISTANCEMENULEFT = 0;                                                  // Distance du plateau de jeu depuis la gauche
        public const int DISTANCEMENUUP = 4;                                                    // Distance du plateau de jeu depuis le haut

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        public static void Main(string[] args)
        {
            new GameEngine().Timer();
        }
        public void Title()
        {
            Enum.TryParse(ColorMenu.Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(DISTANCEMENULEFT, 0);
            Console.ForegroundColor = ColorMenu.consoleColor;
            Console.Write("SPICYVADER");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(DISTANCEMENULEFT, 1);
            Console.Write("ver:" + VERSION);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);

        }
    }
}

