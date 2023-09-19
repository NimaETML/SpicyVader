/*

Programme                  : Spicyvader.cs

Auteur                     : Nima Zarrabi

Date creation              : 4/9/2023

Date dernière modificaion  : 12.9.2023

Version                    : 0.6

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
        const string VERSION = "0.6";

        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static bool Enter = false;
        public static int PosY = 0;                                                                // Positionement horizontal du curseur
        public static int PosX = 0;                                                                // Positionement vertical du curseur

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        const int DISTANCEMENULEFT = 0;                                                  // Distance du plateau de jeu depuis la gauche
        const int DISTANCEMENUUP = 6;                                                    // Distance du plateau de jeu depuis le haut

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        public static void Main(string[] args)
        {
            new ColorMenu().Color();
            new LangMenu().AvailableLanguages();
            LangMenu.selectedLanguage = LangMenu.Languages[0];
            new LangMenu().AvailableLanguages();
            new MainMenu().MainButtons();
            Enum.TryParse(ColorMenu.Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            Console.CursorVisible = false;

            Console.Clear();

            new Program().Title();

            new MainMenu().WriteMainMenu();

        }
        public void Title()
        {
            Enum.TryParse(new ColorMenu().Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ColorMenu.consoleColor;
            Console.WriteLine("SPICYVADER");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("ver:" + VERSION);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);

        }
    }
}

