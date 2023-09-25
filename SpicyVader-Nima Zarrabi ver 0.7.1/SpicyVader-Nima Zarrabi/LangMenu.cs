using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class LangMenu
    {

        public const string LANGSELECT = "your selected language: ";

        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static int langSelectLength = 0;
        public static bool Enter = false;
        public static int PosY = 0;                                                                // Positionement horizontal du curseur
        public static int PosX = 0;                                                                // Positionement vertical du curseur
        public static int LongestLanguage = 0;
        public static int LongestLanguageMinusCurrent = 0;
        public static int CurrentLanguageLength = 0;
        public static string selectedLanguage = "Français";

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        const byte NUMBERLANGUAGE = 5;                                                   // Longeur du menu des langues
        const string ARROW = "  <-";                                                     // Design de la flèche de séléction pour menus

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        public static string[] Languages = new string[NUMBERLANGUAGE];

        public void WriteLangMenu()
        {
            LongestLanguage = 0;
            String LongestLanguageString = Languages.OrderByDescending(x => x.Length).First();
            Enum.TryParse(ColorMenu.Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            foreach (char c in LongestLanguageString)
            {
                LongestLanguage++;
            }

            LongestLanguageMinusCurrent = LongestLanguage;



            // LANGUAGE MENU
            PosY = 0;
            PosX = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY);
            for (int i = 0; i < NUMBERLANGUAGE; i++)
            {
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY);
                Console.WriteLine(Languages[i]);
                PosY++;
            }
            SetNewLang();
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
                    if (Languages[PosY] != Program.BACK)
                    {
                        selectedLanguage = Languages[PosY];
                    }
                }

                //When up arrow
                if (ConsoleKey.UpArrow == Key1)
                {
                    GetLongestLangMinusCurrent();
                    if (PosY <= 0)
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        PosY = (PosY + NUMBERLANGUAGE - 1);
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
                    if (PosY >= NUMBERLANGUAGE - 1)
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        PosY = PosY - NUMBERLANGUAGE + 1;
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
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY);
            //Remove red background
            for (int j = 0; j < NUMBERLANGUAGE; j++)
            {
                for (int z = 0; z <= LongestLanguage; z++)
                {
                    //Remove langages
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY);
                    Console.Write(" ");
                    PosX++;
                }
                //Remove arrows
                foreach (char e in ARROW)
                {
                    Console.Write(" ");
                    PosX++;
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY);
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
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY);
            Console.Write(Languages[PosY]);
            //Move to space between text and arrow
            for (int i = 0; i < Languages[PosY].Length; i++)
            {
                CurrentLanguageLength++;
            }
            //Remove red background
            for (int i = 0; i <= LongestLanguageMinusCurrent; i++)
            {
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX + CurrentLanguageLength, Program.DISTANCEMENUUP + PosY);
                Console.Write(" ");
                PosX++;
            }
            //Remove arrow
            for (int i = 0; i < ARROW.Length; i++)
            {
                Console.Write(" ");
                PosX++;
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + CurrentLanguageLength + PosX, Program.DISTANCEMENUUP + PosY);
            }
            PosX = 0;
            CurrentLanguageLength = 0;
        }

        public void WriteNewLang()
        {
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY);
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
                Languages[4] = Program.BACK;
            }
            catch
            {

            }
        }
        public void LeaveLangMenu()
        {
            if (Languages[PosY] == "Français")
            {
                RemoveCurrentLang();
                SetNewLang();
                WriteLangMenu();
            }
            else if (Languages[PosY] == "English")
            {
                RemoveCurrentLang();
                SetNewLang();
                WriteLangMenu();
            }
            else if (Languages[PosY] == "Deutche")
            {
                RemoveCurrentLang();
                SetNewLang();
                WriteLangMenu();
            }
            else if (Languages[PosY] == "Italianish")
            {
                RemoveCurrentLang();
                SetNewLang();
                WriteLangMenu();
            }
            else if (Languages[PosY] == Program.BACK)
            {
                RemoveLangMenu();
                RemoveNewLang1();
                RemoveNewLang2();
                new MainMenu().WriteMainMenu();
            }
        }

        public void SetNewLang()
        {
            RemoveNewLang1();
            Console.Write(LANGSELECT);
            RemoveNewLang2();
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + langSelectLength + PosX, Program.DISTANCEMENUUP + PosY + NUMBERLANGUAGE);
            Console.Write(selectedLanguage);
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY + NUMBERLANGUAGE);
        }

        public void RemoveNewLang1()
        {
            PosX = 0;
            PosY = 0;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY + NUMBERLANGUAGE);
            PosY++;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY + NUMBERLANGUAGE);
            foreach (char d in LANGSELECT)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + PosX, Program.DISTANCEMENUUP + PosY + NUMBERLANGUAGE);
        }
        public void RemoveNewLang2()
        {

            for (int x = 0; x <= LongestLanguage; x++)
            {
                Console.Write(" ");
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + langSelectLength + PosX, Program.DISTANCEMENUUP + PosY + NUMBERLANGUAGE);
                PosX++;
            }
            PosX = 0;
        }

    }
}
