using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class LangMenu
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static int langSelectLength = 0;
        public static bool Enter = false;
        public static int LongestLanguage = 0;
        public static int LongestLanguageMinusCurrent = 0;
        public static int CurrentLanguageLength = 0;
        public static string selectedLanguage = "Français";

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////


        public const string LANGSELECT = "your selected language: ";
        const byte NUMBERLANGUAGE = 5;                                                   // Longeur du menu des langues

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
            Program.PosY = 0;
            Program.PosX = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            for (int i = 0; i < NUMBERLANGUAGE; i++)
            {
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                Console.WriteLine(Languages[i]);
                Program.PosY++;
            }
            SetNewLang();
            Program.PosY = 0;
            Program.PosX = 0;
            WriteNewLang();

            do
            {
                ConsoleKeyInfo pressKeyInfo = Console.ReadKey(true);
                ConsoleKey Key1 = pressKeyInfo.Key;

                //When enter
                if (ConsoleKey.Enter == Key1)
                {
                    Enter = true;
                    if (Languages[Program.PosY] != Program.BACK)
                    {
                        selectedLanguage = Languages[Program.PosY];
                    }
                }

                //When up arrow
                if (ConsoleKey.UpArrow == Key1)
                {
                    GetLongestLangMinusCurrent();
                    if (Program.PosY <= 0)
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        Program.PosY = (Program.PosY + NUMBERLANGUAGE - 1);
                        WriteNewLang();
                    }
                    else
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        Program.PosY--;
                        WriteNewLang();
                    }
                }
                //When down arrow
                if (ConsoleKey.DownArrow == Key1)
                {
                    GetLongestLangMinusCurrent();
                    if (Program.PosY >= NUMBERLANGUAGE - 1)
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        Program.PosY = Program.PosY - NUMBERLANGUAGE + 1;
                        WriteNewLang();
                    }
                    else
                    {
                        RemoveCurrentLang();
                        //Change selected language
                        Program.PosY++;
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
            Program.PosX = 0;
            Program.PosY = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Erase language
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            //Remove red background
            for (int j = 0; j < NUMBERLANGUAGE; j++)
            {
                for (int z = 0; z <= LongestLanguage; z++)
                {
                    //Remove langages
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                    Console.Write(" ");
                    Program.PosX++;
                }
                //Remove arrows
                foreach (char e in Program.ARROW)
                {
                    Console.Write(" ");
                    Program.PosX++;
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                }
                Program.PosY++;
                Program.PosX = 0;
            }
            Program.PosY = 0;
            Program.PosX = 0;
        }
        public void RemoveCurrentLang()
        {
            Program.PosX = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Write Language in black and white
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            Console.Write(Languages[Program.PosY]);
            //Move to space between text and arrow
            for (int i = 0; i < Languages[Program.PosY].Length; i++)
            {
                CurrentLanguageLength++;
            }
            //Remove red background
            for (int i = 0; i <= LongestLanguageMinusCurrent; i++)
            {
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX + CurrentLanguageLength, Program.DISTANCEMENUUP + Program.PosY);
                Console.Write(" ");
                Program.PosX++;
            }
            //Remove arrow
            for (int i = 0; i < Program.ARROW.Length; i++)
            {
                Console.Write(" ");
                Program.PosX++;
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + CurrentLanguageLength + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            }
            Program.PosX = 0;
            CurrentLanguageLength = 0;
        }

        public void WriteNewLang()
        {
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            //Write selected language
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ColorMenu.consoleColor;
            Console.Write(Languages[Program.PosY]);
            //Add Red between language and arrow
            LongestLanguageMinusCurrent = LongestLanguage;
            for (int i = 0; i < Languages[Program.  PosY].Length; i++)
            {
                LongestLanguageMinusCurrent--;
            }
            //Write arrow
            for (int i = 0; i <= LongestLanguageMinusCurrent; i++)
            {
                Console.Write(" ");
            }
            Console.Write(Program.ARROW);
        }
        public void GetLongestLangMinusCurrent()
        {
            LongestLanguageMinusCurrent = LongestLanguage;
            for (int i = 0; i < Languages[Program.PosY].Length; i++)
            {
                LongestLanguageMinusCurrent--;
            }
        }
        // Donne leurs valeur à chaque language
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
            if (Languages[Program.PosY] == "Français")
            {
                RemoveCurrentLang();
                SetNewLang();
                WriteLangMenu();
            }
            else if (Languages[Program.PosY] == "English")
            {
                RemoveCurrentLang();
                SetNewLang();
                WriteLangMenu();
            }
            else if (Languages[Program.PosY] == "Deutche")
            {
                RemoveCurrentLang();
                SetNewLang();
                WriteLangMenu();
            }
            else if (Languages[Program.PosY] == "Italianish")
            {
                RemoveCurrentLang();
                SetNewLang();
                WriteLangMenu();
            }
            else if (Languages[Program.PosY] == Program.BACK)
            {
                RemoveLangMenu();
                RemoveNewLang1();
                RemoveNewLang2();
                Program.PosY = 0;
                new MainMenu().WriteMainMenu();
            }
        }

        public void SetNewLang()
        {
            RemoveNewLang1();
            Console.Write(LANGSELECT);
            RemoveNewLang2();
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + langSelectLength + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERLANGUAGE);
            Console.Write(selectedLanguage);
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERLANGUAGE);
        }

        public void RemoveNewLang1()
        {
            Program.PosX = 0;
            Program.PosY = 0;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERLANGUAGE);
            Program.PosY++;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERLANGUAGE);
            foreach (char d in LANGSELECT)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERLANGUAGE);
        }
        public void RemoveNewLang2()
        {

            for (int x = 0; x <= LongestLanguage; x++)
            {
                Console.Write(" ");
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + langSelectLength + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERLANGUAGE);
                Program.PosX++;
            }
            Program.PosX = 0;
        }
    }
}
