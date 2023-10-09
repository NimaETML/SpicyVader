using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class MainMenu
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static bool Enter = false;
        public static int LongestMainButton = 0;
        public static int LongestMainButtonMinusCurrent = 0;
        public static int CurrentMainButtonLength = 0;
        public static string? selectedMainOption;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        const byte NUMBERMAINMENU = 5;                                                   // Nombre de bouton dans le menu principal

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        public static string[] MainMenuButton = new string[NUMBERMAINMENU];
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
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                Console.WriteLine(MainMenuButton[i]);
                Program.PosY++;
            }
            Program.PosY = 0;
            Program.PosX = 0;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            WriteNewMainButton();
            do
            {
                ConsoleKeyInfo pressKeyInfo = Console.ReadKey(true);
                ConsoleKey Key1 = pressKeyInfo.Key;

                //When enter
                if (ConsoleKey.Enter == Key1)
                {
                    Enter = true;
                    selectedMainOption = MainMenuButton[Program.PosY];
                }
                //When up arrow
                if (ConsoleKey.UpArrow == Key1)
                {
                    GetLongestMainButtonMinusCurrent();
                    if (Program.PosY <= 0)
                    {
                        RemoveCurrentMain();
                        //Change selected language
                        Program.PosY = (Program.PosY + NUMBERMAINMENU - 1);
                        WriteNewMainButton();
                    }
                    else
                    {
                        RemoveCurrentMain();
                        //Change selected language
                        Program.PosY--;
                        WriteNewMainButton();
                    }
                }
                //When down arrow
                if (ConsoleKey.DownArrow == Key1)
                {
                    GetLongestMainButtonMinusCurrent();
                    if (Program.PosY >= NUMBERMAINMENU - 1)
                    {
                        RemoveCurrentMain();
                        //Change selected language
                        Program.PosY = Program.PosY - NUMBERMAINMENU + 1;
                        WriteNewMainButton();
                    }
                    else
                    {
                        RemoveCurrentMain();
                        //Change selected language
                        Program.    PosY++;
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
            Program.PosX = 0;
            Program.PosY = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Erase language
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            //Remove red background
            for (int j = 0; j < NUMBERMAINMENU; j++)
            {
                for (int z = 0; z <= LongestMainButton; z++)
                {
                    //Remove langages
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP +  Program.PosY);
                    Console.Write(" ");
                    Program.PosX++;
                    //Remove arrows
                }
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

        public void RemoveCurrentMain()
        {
            CurrentMainButtonLength = 0;
            Program.PosX = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Write Language in black and white
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            Console.Write(MainMenuButton[Program.PosY]);
            //Move to space between text and arrow
            for (int i = 0; i < MainMenuButton[Program.PosY].Length; i++)
            {
                CurrentMainButtonLength++;
            }
            //Remove red background
            for (int i = 0; i <= LongestMainButtonMinusCurrent; i++)
            {
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX + CurrentMainButtonLength, Program.DISTANCEMENUUP +Program.PosY);
                Console.Write(" ");
                Program.PosX++;
            }
            //Remove arrow
            for (int i = 0; i < Program.ARROW.Length; i++)
            {
                Console.Write(" ");
                Program.PosX++;
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + CurrentMainButtonLength + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            }
            Program.PosX = 0;
            CurrentMainButtonLength = 0;
        }
        public void WriteNewMainButton()
        {
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            //Write selected language
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ColorMenu.consoleColor;
            Console.Write(MainMenuButton[Program.PosY]);
            //Add Red between language and arrow
            LongestMainButtonMinusCurrent = LongestMainButton;
            for (int i = 0; i < MainMenuButton[Program.PosY].Length; i++)
            {
                LongestMainButtonMinusCurrent--;
            }
            //Write arrow
            for (int i = 0; i <= LongestMainButtonMinusCurrent; i++)
            {
                Console.Write(" ");
            }
            Console.Write(Program.ARROW);
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        // Methode pour calculer la longeur du plus long string dans la table des boutons du menu principal, moins la taille du bouton séléctionné
        public void GetLongestMainButtonMinusCurrent()
        {
            LongestMainButtonMinusCurrent = LongestMainButton;
            for (int i = 0; i < MainMenuButton[Program.PosY].Length; i++)
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
            MainMenuButton[4] = Program.BACK;
        }
        public void LeaveMainMenu()
        {

            if (MainMenuButton[Program.PosY] == "Play")
            {
                Program.PosY = 0;
                Program.PosX = 0;
                RemoveMainMenu();
                new GameEngine().Timer();
            }
            else if (MainMenuButton[Program.PosY] == "Skins")
            {
                Program.PosY = 0;
                Program.PosX = 0;
                RemoveMainMenu();
                new LangMenu().WriteLangMenu();
            }
            else if (MainMenuButton[Program.PosY] == "Languages")
            {
                Program.PosY = 0;
                Program.PosX = 0;
                RemoveMainMenu();
                new LangMenu().WriteLangMenu();
            }
            else if (MainMenuButton[Program.PosY] == "Themes")
            {
                Program.PosY = 0;
                Program.PosX = 0;
                RemoveMainMenu();
                new ColorMenu().WriteColorMenu();
            }
            else if (MainMenuButton[Program.PosY] == Program.BACK)
            {
                Program.PosY = 0;
                Program.PosX = 0;
                RemoveMainMenu();
                new LangMenu().WriteLangMenu();
            }
        }
    }
}
