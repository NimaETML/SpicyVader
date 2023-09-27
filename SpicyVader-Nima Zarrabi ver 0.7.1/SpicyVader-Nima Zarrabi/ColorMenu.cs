using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class ColorMenu
    {

        public const string COLORSELECT = "your selected color: ";

        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static int colorSelectLength = 0;
        public static bool Enter = false;
        public static int LongestColor = 0;
        public static int LongestColorMinusCurrent = 0;
        public static int CurrentColorLength = 0;
        public static int selectedColor = 12;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        const byte NUMBERCOLORS = 17;                                                     // Nombre de couleurs disponible
        const string ARROW = "  <-";                                                     // Design de la flèche de séléction pour menus

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        public static string[] Colors = new string[NUMBERCOLORS];
        public static ConsoleColor consoleColor;
        public void WriteColorMenu()
        {
            LongestColor = 0;
            String LongestColorString = Colors.OrderByDescending(x => x.Length).First();
            Enum.TryParse(ColorMenu.Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            foreach (char c in LongestColorString)
            {
                LongestColor++;
            }
            LongestColorMinusCurrent = LongestColor;
            // COLOR MENU
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            for (int i = 0; i < NUMBERCOLORS; i++)
            {
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                Console.WriteLine(Colors[i]);
                Program.PosY++;
            }
            SetNewColor();
            Program.PosY = 0;
            Program.PosX = 0;
            WriteNewColor();
            do
            {
                ConsoleKeyInfo pressKeyInfo = Console.ReadKey(true);
                ConsoleKey Key1 = pressKeyInfo.Key;

                //When enter
                if (ConsoleKey.Enter == Key1)
                {
                    Enter = true;
                    Enum.TryParse(ColorMenu.Colors[1], out ColorMenu.consoleColor);
                }

                //When up arrow
                if (ConsoleKey.UpArrow == Key1)
                {
                    GetLongestColorMinusCurrent();
                    if (Program.PosY <= 0)
                    {
                        RemoveCurrentColor();
                        //Change selected language
                        Program.PosY = (Program.PosY + NUMBERCOLORS - 1);
                        WriteNewColor();
                    }
                    else
                    {
                        RemoveCurrentColor();
                        //Change selected language
                        Program.PosY--;
                        WriteNewColor();
                    }
                }
                //When down arrow
                if (ConsoleKey.DownArrow == Key1)
                {
                    GetLongestColorMinusCurrent();
                    if (Program.PosY >= NUMBERCOLORS - 1)
                    {
                        RemoveCurrentColor();
                        //Change selected language
                        Program.PosY = Program.PosY - NUMBERCOLORS + 1;
                        WriteNewColor();
                    }
                    else
                    {
                        RemoveCurrentColor();
                        //Change selected language
                        Program.PosY++;
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
            Program.PosX = 0;
            Program.PosY = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Erase language
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            //Remove red background
            for (int j = 0; j < NUMBERCOLORS; j++)
            {
                for (int z = 0; z <= LongestColor; z++)
                {
                    //Remove langages
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                    Console.Write(" ");
                    Program.PosX++;
                    //Remove arrows
                    foreach (char e in ARROW)
                    {
                        Console.Write(" ");
                        Program.PosX++;
                        Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                    }
                }
                Program.PosY++;
                Program.PosX = 0;
            }
            Program.PosY = 0;
            Program.PosX = 0;
        }
        public void RemoveCurrentColor()
        {
            Program.PosX = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Write Language in black and white
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            Console.Write(Colors[Program.PosY]);
            //Move to space between text and arrow
            for (int i = 0; i < Colors[Program.PosY].Length;i++)
            {
                CurrentColorLength++;
            }
            //Remove red background
            for (int i = 0; i <= LongestColorMinusCurrent; i++)
            {
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX + CurrentColorLength, Program.DISTANCEMENUUP + Program.PosY);
                Console.Write(" ");
                Program.PosX++;
            }
            //Remove arrow
            for (int i = 0; i < ARROW.Length; i++)
            {
                Console.Write(" ");
                Program.PosX++;
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + CurrentColorLength + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            }
            Program.PosX = 0;
            CurrentColorLength = 0;
        }

        public void WriteNewColor()
        {
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            //Write selected language
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = consoleColor;
            Console.Write(Colors[Program.PosY]);
            //Add Red between language and arrow
            LongestColorMinusCurrent = LongestColor;
            for (int i = 0; i < Colors[Program.PosY].Length; i++)
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
            for (int i = 0; i < Colors[Program.PosY].Length; i++)
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
            Colors[16] = Program.BACK;
        }
        public void LeaveColorMenu()
        {
            if (Colors[Program.PosY] == "Black")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "DarkBlue")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "DarkGreen")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "DarkCyan")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "DarkRed")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "DarkMagenta")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "DarkYellow")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "Gray")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "DarkGray")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "Blue")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "Green")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "Cyan")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "Red")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "Magenta")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "Yellow")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == "White")
            {
                PickColor();
            }
            else if (Colors[Program.PosY] == Program.BACK)
            {
                RemoveColorMenu();
                RemoveNewColor1();
                RemoveNewColor2();
                new MainMenu().WriteMainMenu();
            }
        }
        public void SetNewColor()
        {
            RemoveNewColor1();
            Console.Write(COLORSELECT);
            RemoveNewColor2();
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + colorSelectLength + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERCOLORS);
            Console.Write(Colors[selectedColor]);
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERCOLORS);
        }

        public void RemoveNewColor1()
        {
            Program.PosX = 0;
            Program.PosY = 0;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERCOLORS);
            Program.PosY++;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERCOLORS);
            foreach (char d in COLORSELECT)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERCOLORS);
        }
        public void RemoveNewColor2()
        {

            for (int x = 0; x <= LongestColor; x++)
            {
                Console.Write(" ");
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + colorSelectLength + Program.PosX, Program.DISTANCEMENUUP + Program.PosY + NUMBERCOLORS);
                Program.PosX++;
            }
            Program.PosX = 0;
        }

        public void PickColor()
        {
            selectedColor = Program.PosY;
            Program.PosY = 0;
            new Program().Title();
            RemoveColorMenu();
            WriteColorMenu();
        }
    }
}
