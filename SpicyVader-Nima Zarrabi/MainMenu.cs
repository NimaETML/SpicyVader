using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class MainMenu
    {
        //Version:
        const string VERSION = "0.6";

        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static bool Enter = false;
        public static int PosY = 0;                                                                // Positionement horizontal du curseur
        public static int PosX = 0;                                                                // Positionement vertical du curseur
        public static int LongestMainButton = 0;
        public static int LongestMainButtonMinusCurrent = 0;
        public static int CurrentMainButtonLength = 0;
        public static string? selectedMainOption;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        const int DISTANCEMENULEFT = 0;                                                  // Distance du plateau de jeu depuis la gauche
        const int DISTANCEMENUUP = 6;                                                    // Distance du plateau de jeu depuis le haut
        const byte NUMBERMAINMENU = 5;                                                   // Nombre de bouton dans le menu principal
        const string ARROW = "  <-";                                                     // Design de la flèche de séléction pour menus


        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        public string[] MainMenuButton = new string[NUMBERMAINMENU];
        public void WriteMainMenu()
        {
            LongestMainButton = 0;
            String LongestMainButtonString = MainMenuButton.OrderByDescending(x => x.Length).First();
            Enum.TryParse(ColorMenu.Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            foreach (char c in LongestMainButtonString)
            {
                LongestMainButton++;
            }
            LongestMainButtonMinusCurrent = LongestMainButton;
            for (int i = 0; i < NUMBERMAINMENU; i++)
            {
                Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
                Console.WriteLine(MainMenuButton[i]);
                PosY++;
            }
            PosY = 0;
            PosX = 0;
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            WriteNewMainButton();
            do
            {
                ConsoleKeyInfo pressKeyInfo = Console.ReadKey(true);
                ConsoleKey Key1 = pressKeyInfo.Key;

                //When enter
                if (ConsoleKey.Enter == Key1)
                {
                    Enter = true;
                    selectedMainOption = MainMenuButton[PosY];
                }
                //When up arrow
                if (ConsoleKey.UpArrow == Key1)
                {
                    GetLongestMainButtonMinusCurrent();
                    if (PosY <= 0)
                    {
                        RemoveCurrentMain();
                        //Change selected language
                        PosY = (PosY + NUMBERMAINMENU - 1);
                        WriteNewMainButton();
                    }
                    else
                    {
                        RemoveCurrentMain();
                        //Change selected language
                        PosY--;
                        WriteNewMainButton();
                    }
                }
                //When down arrow
                if (ConsoleKey.DownArrow == Key1)
                {
                    GetLongestMainButtonMinusCurrent();
                    if (PosY >= NUMBERMAINMENU - 1)
                    {
                        RemoveCurrentMain();
                        //Change selected language
                        PosY = PosY - NUMBERMAINMENU + 1;
                        WriteNewMainButton();
                    }
                    else
                    {
                        RemoveCurrentMain();
                        //Change selected language
                        PosY++;
                        WriteNewMainButton();
                    }
                }
            } while (!Enter);
            Enter = false;
            CurrentMainButtonLength = 0;
            LeaveMainMenu();
        }
        public void RemoveMainMenu()
        {
            PosX = 0;
            PosY = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Erase language
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            //Remove red background
            for (int j = 0; j < NUMBERMAINMENU; j++)
            {
                for (int z = 0; z <= LongestMainButton; z++)
                {
                    //Remove langages
                    Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
                    Console.Write(" ");
                    PosX++;
                    //Remove arrows
                }
                foreach (char e in ARROW)
                {
                    Console.Write(" ");
                    PosX++;
                    Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
                }
                PosY++;
                PosX = 0;
            }
            PosY = 0;
            PosX = 0;
        }

        public void RemoveCurrentMain()
        {
            CurrentMainButtonLength = 0;
            PosX = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Write Language in black and white
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            Console.Write(MainMenuButton[PosY]);
            //Move to space between text and arrow
            for (int i = 0; i < MainMenuButton[PosY].Length; i++)
            {
                CurrentMainButtonLength++;
            }
            //Remove red background
            for (int i = 0; i <= LongestMainButtonMinusCurrent; i++)
            {
                Console.SetCursorPosition(DISTANCEMENULEFT + PosX + CurrentMainButtonLength, DISTANCEMENUUP + PosY);
                Console.Write(" ");
                PosX++;
            }
            //Remove arrow
            for (int i = 0; i < ARROW.Length; i++)
            {
                Console.Write(" ");
                PosX++;
                Console.SetCursorPosition(DISTANCEMENULEFT + CurrentMainButtonLength + PosX, DISTANCEMENUUP + PosY);
            }
            PosX = 0;
            CurrentMainButtonLength = 0;
        }
        public void WriteNewMainButton()
        {
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            //Write selected language
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ColorMenu.consoleColor;
            Console.Write(MainMenuButton[PosY]);
            //Add Red between language and arrow
            LongestMainButtonMinusCurrent = LongestMainButton;
            for (int i = 0; i < MainMenuButton[PosY].Length; i++)
            {
                LongestMainButtonMinusCurrent--;
            }
            //Write arrow
            for (int i = 0; i <= LongestMainButtonMinusCurrent; i++)
            {
                Console.Write(" ");
            }
            Console.Write(ARROW);
        }

        public void GetLongestMainButtonMinusCurrent()
        {
            LongestMainButtonMinusCurrent = LongestMainButton;
            for (int i = 0; i < MainMenuButton[PosY].Length; i++)
            {
                LongestMainButtonMinusCurrent--;
            }
        }
        public void MainButtons()
        {
            MainMenuButton[0] = "Play";
            MainMenuButton[1] = "Skins";
            MainMenuButton[2] = "Languages";
            MainMenuButton[3] = "Themes";
            MainMenuButton[4] = "Exit";
        }
        public void LeaveMainMenu()
        {

            if (MainMenuButton[PosY] == "Play")
            {
                PosY = 0;
                PosX = 0;
                new LangMenu().WriteLangMenu();
            }
            else if (MainMenuButton[PosY] == "Skins")
            {
                PosY = 0;
                PosX = 0;
                new LangMenu().WriteLangMenu();
            }
            else if (MainMenuButton[PosY] == "Languages")
            {
                PosY = 0;
                PosX = 0;
                new LangMenu().WriteLangMenu();
            }
            else if (MainMenuButton[PosY] == "Themes")
            {
                PosY = 0;
                PosX = 0;
                new ColorMenu().WriteColorMenu();
            }
            else if (MainMenuButton[PosY] == "Exit")
            {
                PosY = 0;
                PosX = 0;
                new LangMenu().WriteLangMenu();
            }
        }
    }
}
