using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class ColorMenu
    {

        //Version:
        const string VERSION = "0.6";

        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static bool Enter = false;
        public static int PosY = 0;                                                                // Positionement horizontal du curseur
        public static int PosX = 0;                                                                // Positionement vertical du curseur
        public static int LongestColor = 0;
        public static int LongestColorMinusCurrent = 0;
        public static int CurrentColorLength = 0;
        public static int selectedColor = 12;


        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        const int DISTANCEMENULEFT = 0;                                                  // Distance du plateau de jeu depuis la gauche
        const int DISTANCEMENUUP = 6;                                                    // Distance du plateau de jeu depuis le haut
        const byte NUMBERCOLORS = 17;                                                     // Nombre de couleurs disponible
        public const byte NUMBERLANGUAGES = 5;
        const string ARROW = "  <-";                                                     // Design de la flèche de séléction pour menus

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        public string[] Colors = new string[NUMBERCOLORS];
        public string[] colorSelectionText = new string[NUMBERLANGUAGES];
        public static ConsoleColor consoleColor;
        public void WriteColorMenu()
        {
            LongestColor = 0;
            String LongestColorString = Colors.OrderByDescending(x => x.Length).First();
            Enum.TryParse(new ColorMenu().Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            foreach (char c in LongestColorString)
            {
                LongestColor++;
            }
            LongestColorMinusCurrent = LongestColor;
            // COLOR MENU
            new MainMenu().RemoveMainMenu();
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            for (int i = 0; i < NUMBERCOLORS; i++)
            {
                Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
                Console.WriteLine(Colors[i]);
                PosY++;
            }
            PosY = -1;
            PosY++ ;
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            Console.Write("Couleur actuel: "); ///// MAKE VARIABLE
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX + 16, DISTANCEMENUUP + PosY);
            for (int i = 0; i < LongestColorMinusCurrent; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX + 16, DISTANCEMENUUP + PosY);
            Console.Write(consoleColor);
            PosY = 0;
            PosX = 0;
            WriteNewColor();
            do
            {
                ConsoleKeyInfo pressKeyInfo = Console.ReadKey(true);
                ConsoleKey Key1 = pressKeyInfo.Key;

                //When enter
                if (ConsoleKey.Enter == Key1)
                {
                    Enter = true;
                    Enum.TryParse(new ColorMenu().Colors[1], out ColorMenu.consoleColor);
                }

                //When up arrow
                if (ConsoleKey.UpArrow == Key1)
                {
                    GetLongestColorMinusCurrent();
                    if (PosY <= 0)
                    {
                        RemoveCurrentColor();
                        //Change selected language
                        PosY = (PosY + NUMBERCOLORS - 1);
                        WriteNewColor();
                    }
                    else
                    {
                        RemoveCurrentColor();
                        //Change selected language
                        PosY--;
                        WriteNewColor();
                    }
                }
                //When down arrow
                if (ConsoleKey.DownArrow == Key1)
                {
                    GetLongestColorMinusCurrent();
                    if (PosY >= NUMBERCOLORS - 1)
                    {
                        RemoveCurrentColor();
                        //Change selected language
                        PosY = PosY - NUMBERCOLORS + 1;
                        WriteNewColor();
                    }
                    else
                    {
                        RemoveCurrentColor();
                        //Change selected language
                        PosY++;
                        WriteNewColor();
                    }
                }
            }
            while (!Enter);
            Enter = false;
            CurrentColorLength = 0;
            LeaveColorMenu();
        }
        public void RemoveColorMenu()
        {
            PosX = 0;
            PosY = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Erase language
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            //Remove red background
            for (int j = 0; j < NUMBERCOLORS; j++)
            {
                for (int z = 0; z <= LongestColor; z++)
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
        public void RemoveCurrentColor()
        {
            PosX = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Write Language in black and white
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            Console.Write(Colors[PosY]);
            //Move to space between text and arrow
            for (int i = 0; i < Colors[PosY].Length;i++)
            {
                CurrentColorLength++;
            }
            //Remove red background
            for (int i = 0; i <= LongestColorMinusCurrent; i++)
            {
                Console.SetCursorPosition(DISTANCEMENULEFT + PosX + CurrentColorLength, DISTANCEMENUUP + PosY);
                Console.Write(" ");
                PosX++;
            }
            //Remove arrow
            for (int i = 0; i < ARROW.Length; i++)
            {
                Console.Write(" ");
                PosX++;
                Console.SetCursorPosition(DISTANCEMENULEFT + CurrentColorLength + PosX, DISTANCEMENUUP + PosY);
            }
            PosX = 0;
            CurrentColorLength = 0;
        }

        public void WriteNewColor()
        {
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
            //Write selected language
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = consoleColor;
            Console.Write(Colors[PosY]);
            //Add Red between language and arrow
            LongestColorMinusCurrent = LongestColor;
            for (int i = 0; i < Colors[PosY].Length; i++)
            {
                LongestColorMinusCurrent--;
            }
            //Write arrow
            for (int i = 0; i <= LongestColorMinusCurrent; i++)
            {
                Console.Write(" ");
            }
            Console.Write(ARROW);
        }
        public void GetLongestColorMinusCurrent()
        {
            LongestColorMinusCurrent = LongestColor;
            for (int i = 0; i < Colors[PosY].Length; i++)
            {
                LongestColorMinusCurrent--;
            }
        }

        public void Color()
        {
            Colors[0] = "Black";
            Colors[1] = "DarkBlue";
            Colors[2] = "DarkGreen";
            Colors[3] = "DarkCyan";
            Colors[4] = "DarkRed";
            Colors[5] = "DarkMagenta";
            Colors[6] = "DarkYellow";
            Colors[7] = "Gray";
            Colors[8] = "DarkGray";
            Colors[9] = "Blue";
            Colors[10] = "Green";
            Colors[11] = "Cyan";
            Colors[12] = "Red";
            Colors[13] = "Magenta";
            Colors[14] = "Yellow";
            Colors[15] = "White";
            Colors[16] = "Back";
        }
        public void LeaveColorMenu()
        {
            if (Colors[PosY] == "Black")
            {
                PickColor();
            }
            else if (Colors[PosY] == "DarkBlue")
            {
                PickColor();
            }
            else if (Colors[PosY] == "DarkGreen")
            {
                PickColor();
            }
            else if (Colors[PosY] == "DarkCyan")
            {
                PickColor();
            }
            else if (Colors[PosY] == "DarkRed")
            {
                PickColor();
            }
            else if (Colors[PosY] == "DarkMagenta")
            {
                PickColor();
            }
            else if (Colors[PosY] == "DarkYellow")
            {
                PickColor();
            }
            else if (Colors[PosY] == "Gray")
            {
                PickColor();
            }
            else if (Colors[PosY] == "DarkGray")
            {
                PickColor();
            }
            else if (Colors[PosY] == "Blue")
            {
                PickColor();
            }
            else if (Colors[PosY] == "Green")
            {
                PickColor();
            }
            else if (Colors[PosY] == "Cyan")
            {
                PickColor();
            }
            else if (Colors[PosY] == "Red")
            {
                PickColor();
            }
            else if (Colors[PosY] == "Magenta")
            {
                PickColor();
            }
            else if (Colors[PosY] == "Yellow")
            {
                PickColor();
            }
            else if (Colors[PosY] == "White")
            {
                PickColor();
            }
            else if (Colors[PosY] == "Back")
            {
                RemoveColorMenu();
                new MainMenu().WriteMainMenu();
            }
        }
        public void SetNewColor()
        {
            Enum.TryParse(Colors[Convert.ToInt16(selectedColor)], out ColorMenu.consoleColor);
            for (int i = 0; i < LongestColor; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.WriteLine("\nyour selected Color:");
            Console.WriteLine(selectedColor);
            Console.SetCursorPosition(DISTANCEMENULEFT + PosX, DISTANCEMENUUP + PosY);
        }

        public void PickColor()
        {
            selectedColor = PosY;
            PosY = 0;
            new Program().Title();
            RemoveColorMenu();
            WriteColorMenu();
        }
    }
}
