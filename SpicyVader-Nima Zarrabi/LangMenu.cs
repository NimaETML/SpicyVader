using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class LangMenu
    {

        //Version:
        const string VERSION = "0.6";

        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static bool Enter = false;
        public int PosY = 0;                                                                // Positionement horizontal du curseur
        public int PosX = 0;                                                                // Positionement vertical du curseur
        public int LongestLanguage = 0;
        public int LongestLanguageMinusCurrent = 0;
        public int CurrentLanguageLength = 0;
        public string selectedLanguage = "Français";

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        const int DISTANCEMENULEFT = 0;                                                  // Distance du plateau de jeu depuis la gauche
        const int DISTANCEMENUUP = 6;                                                    // Distance du plateau de jeu depuis le haut
        public const byte NUMBERLANGUAGES = 5;                                                   // Longeur du menu des langues
        const string ARROW = "  <-";                                                     // Design de la flèche de séléction pour menus

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        public string[] Languages = new string[NUMBERLANGUAGES];

        public void WriteLangMenu()
        {
            LongestLanguage = 0;
            String LongestLanguageString = Languages.OrderByDescending(x => x.Length).First();
            Enum.TryParse(new ColorMenu().Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            foreach (char c in LongestLanguageString)
            {
                LongestLanguage++;
            }

            LongestLanguageMinusCurrent = LongestLanguage;



            // LANGUAGE MENU
            new MainMenu().RemoveMainMenu();
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            for (int i = 0; i < NUMBERLANGUAGES; i++)
            {
                Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
                Console.WriteLine(Languages[i]);
                PosY++;
            }
            PosY = -1;
            Console.WriteLine();
            Console.Write("\nyour selected language: ");
            Console.Write(selectedLanguage);
            PosY = 0;
            PosX = 0;
            WriteNewLang();

            do
            {
                ConsoleKeyInfo pressKeyInfo = Console.ReadKey(true);
                ConsoleKey Key1 = pressKeyInfo.Key;

                //When enter
                if (ConsoleKey.Enter == Key1)
                {
                    Enter = true;
                    selectedLanguage = Languages[PosY];
                }

                //When up arrow
                if (ConsoleKey.UpArrow == Key1)
                {
                    GetLongestLangMinusCurrent();
                    if (PosY <= 0)
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        PosY = (PosY + NUMBERLANGUAGES - 1);
                        WriteNewLang();
                    }
                    else
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        PosY--;
                        WriteNewLang();
                    }
                }
                //When down arrow
                if (ConsoleKey.DownArrow == Key1)
                {
                    GetLongestLangMinusCurrent();
                    if (PosY >= NUMBERLANGUAGES - 1)
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        PosY = PosY - NUMBERLANGUAGES + 1;
                        WriteNewLang();
                    }
                    else
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        PosY++;
                        WriteNewLang();
                    }
                }
            }
            while (!Enter);
            Enter = false;
            CurrentLanguageLength = 0;
            LeaveLangMenu();
        }
        public void RemoveLangMenu()
        {
            PosX = 0;
            PosY = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Erase language
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            //Remove red background
            for (int j = 0; j < NUMBERLANGUAGES; j++)
            {
                for (int z = 0; z <= LongestLanguage; z++)
                {
                    //Remove langages
                    Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
                    Console.Write(" ");
                    PosX++;
                    //Remove arrows
                    foreach (char e in ARROW)
                    {
                        Console.Write(" ");
                        PosX++;
                        Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
                    }
                }
                PosY++;
                PosX = 0;
            }
            PosY = 0;
            PosX = 0;
        }
        public void RemoveCurrentLang()
        {
            PosX = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Write Language in black and white
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            Console.Write(Languages[PosY]);
            //Move to space between text and arrow
            for (int i = 0; i < Languages[PosY].Length;i++)
            {
                CurrentLanguageLength++;
            }
            //Remove red background
            for (int i = 0; i <= LongestLanguageMinusCurrent; i++)
            {
                Console.SetCursorPosition(DISTANCEMENULEFT + PosX + CurrentLanguageLength, DISTANCEMENUUP + PosY);
                Console.Write(" ");
                PosX++;
            }
            //Remove arrow
            for (int i = 0; i < ARROW.Length; i++)
            {
                Console.Write(" ");
                PosX++;
                Console.SetCursorPosition(DISTANCEMENULEFT + CurrentLanguageLength + PosX, DISTANCEMENUUP + PosY);
            }
            PosX = 0;
            CurrentLanguageLength = 0;
        }

        public void WriteNewLang()
        {
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            //Write selected language
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ColorMenu.consoleColor;
            Console.Write(Languages[PosY]);
            //Add Red between language and arrow
            LongestLanguageMinusCurrent = LongestLanguage;
            for (int i = 0; i < Languages[PosY].Length; i++)
            {
                LongestLanguageMinusCurrent--;
            }
            //Write arrow
            for (int i = 0; i <= LongestLanguageMinusCurrent; i++)
            {
                Console.Write(" ");
            }
            Console.Write(ARROW);
        }
        public void GetLongestLangMinusCurrent()
        {
            LongestLanguageMinusCurrent = LongestLanguage;
            for (int i = 0; i < Languages[PosY].Length; i++)
            {
                LongestLanguageMinusCurrent--;
            }
        }
        public void AvailableLanguages()
        {
            Languages[0] = "Français";
            Languages[1] = "English";
            Languages[2] = "Deutche";
            Languages[3] = "Italianish";
            try
            {
                Languages[4] = "Retour arrière";
            }
            catch
            {

            }
        }
        public void LeaveLangMenu()
        {
            if (Languages[PosY] == "Français")
            {
                new LangMenu().WriteLangMenu();
            }
            else if (Languages[PosY] == "English")
            {
                new LangMenu().WriteLangMenu();
            }
            else if (Languages[PosY] == "Deutche")
            {
                new LangMenu().WriteLangMenu();
            }
            else if (Languages[PosY] == "Italianish")
            {
                new LangMenu().WriteLangMenu();
            }
            else if (Languages[PosY] == "Retour arrière")
            {
                RemoveLangMenu();
                new MainMenu().WriteMainMenu();
            }
        }

        public void SetNewLang()
        {
            selectedLanguage = Languages[PosY];
            Console.WriteLine();
            Console.WriteLine("\nyour selected language:");
            Console.WriteLine(selectedLanguage);
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
        }
    }
}
