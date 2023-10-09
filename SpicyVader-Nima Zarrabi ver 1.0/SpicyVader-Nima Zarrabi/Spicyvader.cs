/*

Programme                  : Spicyvader.cs

Auteur                     : Nima Zarrabi

Date creation              : 4/9/2023

Date dernière modificaion  : 9.10.2023

Version                    : 1.0

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
        
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        internal int currentDistanceBetweenEnemies = 0;                                   // Distance entre enemies en ce moment
        public static bool Enter = false;                                                 // variable pour savoir si la touch Espace à été pressé
        public static int PosY = 0;                                                       // Positionement horizontal du curseur
        public static int PosX = 0;                                                       // Positionement vertical du curseur

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        public const string VERSION = "1.0";                                              // Version du programme (s'affiche dans le menu principal)
        public const string BACK = "[ Exit ]";                                            // texte par default pour le bouton "Exit"
        public const int DISTANCEMENULEFT = 0;                                            // Distance du plateau de jeu depuis la gauche
        public const int DISTANCEMENUUP = 4;                                              // Distance du plateau de jeu depuis le haut
        internal const string ARROW = "  <-";                                             // Design de la flèche de séléction pour menus

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        public static void Main(string[] args)
        {
            // Calcule la longeur du text par default du language séléctionné en ce moment
            foreach (char c in LangMenu.LANGSELECT)
            {
                LangMenu.langSelectLength++;
            }

            // Calcule la longeur du text par default de la couleur séléctionné en ce moment
            foreach (char c in ColorMenu.COLORSELECT)
            {
                ColorMenu.colorSelectLength++;
            }
            LangMenu.selectedLanguage = BACK;

            // Appel la méthode "Color" (donne leurs valeur à chaque couleur)
            new ColorMenu().Color();

            // Appel la méthode "Color" (donne leurs valeur à chaque language)
            new LangMenu().AvailableLanguages();

            // Séléctionne le language par défault
            LangMenu.selectedLanguage = LangMenu.Languages[0];

            // Appel la méthode "MainButtons" (donne leurs valeur à chaque Boutons dans le Menu principal)
            new MainMenu().MainButtons();

            // Donne la valeur séléctionné dans "Color" à la classe "ConsoleColor"
            Enum.TryParse(ColorMenu.Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            Console.CursorVisible = false;

            Console.Clear();

            new Missile(0, 0).Missilespawn();

            new Program().Title();

            new MainMenu().WriteMainMenu();
        }
        // Ecriture du Titre
        public void Title()
        {
            // Change la couleur de fond en noir et celle de text à la couleur séléctionné
            Enum.TryParse(ColorMenu.Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(DISTANCEMENULEFT, 0);
            Console.ForegroundColor = ColorMenu.consoleColor;

            // Ecriture du Titre
            Console.Write("SPICYVADER");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(DISTANCEMENULEFT, 1);

            // Ecriture de la version
            Console.Write("ver:" + VERSION);
            Console.WriteLine();

            // Change la couleur de text en blac
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
        }
    }
}

