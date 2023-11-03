using MySql.Data.MySqlClient;

namespace SpicyVader_Nima_Zarrabi
{
    internal class Classement
    {
        ////////////////////////////////////////////////// Déclaration des variables //////////////////////////////////////////////////

        public static bool Enter = false;
        public static int LongestClassementButton = 0;
        public static int LongestClassementButtonMinusCurrent = 0;
        public static int CurrentClassementButtonLength = 0;
        public static int MaxNameCharAllowed = 9;
        public static string? selectedClassementOption;
        public int distanceJouPseudoToJouNombrePoint = 3;
        public int distanceJouIdToJouPseudo = 3;
        public int nombreplayer = 0;
        public string? LongestPlayerId;
        public string? LongestPlayerName;
        public string? LongestPlayerPoints;
        public int currentPlayer = 0;

        ////////////////////////////////////////////////// Déclaration des constants //////////////////////////////////////////////////

        const byte NUMBERCLASSEMENTMENU = 2;                                                   // Nombre de bouton dans le menu principal
        const byte CLASSMENUTOCLASSINFO = 2;                                                   // Distance entre le menu de classement et les informations du classement

        ///////////////////////////////////////////////////// Programme principal /////////////////////////////////////////////////////

        static internal string[] CommandSQL = new string[17];
        static internal string[] IdJoueurTab = new string[5];
        static internal string[] NomJoueurTab = new string[5];
        static internal string[] pointJoueurTab = new string[5];
        public static string[] ClassementButton = new string[NUMBERCLASSEMENTMENU];
        public void CommandeStatch()
        {
            CommandSQL[0] = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
            CommandSQL[1] = "SELECT AVG(armPrix) MAX(armPrix) MIN(armPrix) FROM t_arme;";
            CommandSQL[2] = "DarkGreen";
            CommandSQL[3] = "DarkCyan";
            CommandSQL[4] = "DarkRed";
            CommandSQL[5] = "DarkMagenta";
            CommandSQL[6] = "DarkYellow";
            CommandSQL[7] = "Gray";
            CommandSQL[8] = "DarkGray";
            CommandSQL[9] = "Blue";
            CommandSQL[10] = "Green";
            CommandSQL[11] = "Cyan";
            CommandSQL[12] = "Red";
            CommandSQL[13] = "Magenta";
            CommandSQL[14] = "Yellow";
            CommandSQL[15] = "White";
            CommandSQL[16] = "Back";
        }
        public void ConnectToDataBase()
        {
            MySqlConnection conn;
            string InfoConnect = "server=127.0.0.1;port=6033;user=root;password=root;database=db_space_invaders";
            conn = new MySql.Data.MySqlClient.MySqlConnection(InfoConnect);
            try
            {

                CommandeStatch();
                conn.Open();
                Program.PosY = 0;
                Program.PosY = (NUMBERCLASSEMENTMENU + 2);
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                Console.ForegroundColor = ColorMenu.consoleColor;
                Console.WriteLine("Connexion OK");
                Console.ForegroundColor = ConsoleColor.White;
                Program.PosY = 0;
                MySqlCommand cmd = new MySqlCommand(CommandSQL[0], conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX + CLASSMENUTOCLASSINFO + LongestClassementButton + Program.ARROW.Length, Program.DISTANCEMENUUP + Program.PosY);
                    //IdJoueurTab[currentPlayer] = (rdr["idJoueur"].ToString());
                    NomJoueurTab[currentPlayer] = (rdr["jouPseudo"].ToString());
                    pointJoueurTab[currentPlayer] = (rdr["jouNombrePoints"].ToString());
                    currentPlayer++;
                }
                foreach (string h in IdJoueurTab)
                {
                    nombreplayer++;
                }
                LongestPlayerId = IdJoueurTab.OrderByDescending(s => s.Length).First();
                LongestPlayerName = NomJoueurTab.OrderByDescending(a => a.Length).First();
                LongestPlayerPoints = pointJoueurTab.OrderByDescending(b => b.Length).First();

                foreach (char h in LongestPlayerName)
                {
                    distanceJouPseudoToJouNombrePoint++;
                }
                /*
                foreach (char h in LongestPlayerId)
                {
                    distanceJouIdToJouPseudo++;
                }
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                for (int o = 0; o < nombreplayer; o++)
                {
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                    Console.Write(IdJoueurTab[o]);
                    Program.PosY++;
                }*/
                Program.PosY = 0;
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX + CLASSMENUTOCLASSINFO + LongestClassementButton + Program.ARROW.Length + distanceJouIdToJouPseudo, Program.DISTANCEMENUUP + Program.PosY);
                for (int o = 0; o < nombreplayer; o++)
                {
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX + CLASSMENUTOCLASSINFO + LongestClassementButton + Program.ARROW.Length + distanceJouIdToJouPseudo, Program.DISTANCEMENUUP + Program.PosY);
                    Console.Write(NomJoueurTab[o]);
                    Program.PosY++;
                }
                Program.PosY = 0;
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX + CLASSMENUTOCLASSINFO + LongestClassementButton + Program.ARROW.Length + distanceJouIdToJouPseudo + distanceJouPseudoToJouNombrePoint, Program.DISTANCEMENUUP + Program.PosY);
                for (int o = 0; o < nombreplayer; o++)
                {
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX + CLASSMENUTOCLASSINFO + LongestClassementButton + Program.ARROW.Length + distanceJouIdToJouPseudo + distanceJouPseudoToJouNombrePoint, Program.DISTANCEMENUUP + Program.PosY);
                    Console.Write(pointJoueurTab[o]);
                    Program.PosY++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        public void WriteClassement()
        {
            Program.PosY = 0;
            Program.PosX = 0;
            LongestClassementButton = 0;
            String LongestMainButtonString = ClassementButton.OrderByDescending(x => x.Length).First();
            Enum.TryParse(ColorMenu.Colors[Convert.ToInt16(ColorMenu.selectedColor)], out ColorMenu.consoleColor);
            foreach (char c in LongestMainButtonString)
            {
                LongestClassementButton++;
            }
            LongestClassementButtonMinusCurrent = LongestClassementButton;
            for (int i = 0; i < NUMBERCLASSEMENTMENU; i++)
            {
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
                Console.WriteLine(ClassementButton[i]);
                Program.PosY++;
            }
            Program.PosY = 0;
            Program.PosX = 0;
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            WriteNewClassementButton();
            ConnectToDataBase();
            Program.PosY = 0;
            Program.PosX = 0;
            do
            {
                ConsoleKeyInfo pressKeyInfo = Console.ReadKey(true);
                ConsoleKey Key1 = pressKeyInfo.Key;

                //When enter
                if (ConsoleKey.Enter == Key1 || ConsoleKey.Spacebar == Key1)
                {
                    Enter = true;
                    selectedClassementOption = ClassementButton[Program.PosY];
                }
                //When up arrow
                if (ConsoleKey.UpArrow == Key1)
                {
                    GetLongestClassementButtonMinusCurrent();
                    if (Program.PosY <= 0)
                    {
                        RemoveCurrentClassmentButton();
                        //Change selected language
                        Program.PosY = (Program.PosY + NUMBERCLASSEMENTMENU - 1);
                        WriteNewClassementButton();
                    }
                    else
                    {
                        RemoveCurrentClassmentButton();
                        //Change selected language
                        Program.PosY--;
                        WriteNewClassementButton();
                    }
                }
                //When down arrow
                if (ConsoleKey.DownArrow == Key1)
                {
                    GetLongestClassementButtonMinusCurrent();
                    if (Program.PosY >= NUMBERCLASSEMENTMENU - 1)
                    {
                        RemoveCurrentClassmentButton();
                        //Change selected language
                        Program.PosY = Program.PosY - NUMBERCLASSEMENTMENU + 1;
                        WriteNewClassementButton();
                    }
                    else
                    {
                        RemoveCurrentClassmentButton();
                        //Change selected language
                        Program.PosY++;
                        WriteNewClassementButton();
                    }
                }
            } while (!Enter);
            Enter = false;
            CurrentClassementButtonLength = 0;
            LeaveClassement();
        }

        // Methode pour calculer la longeur du plus long string dans la table des boutons du menu principal, moins la taille du bouton séléctionné
        public void GetLongestClassementButtonMinusCurrent()
        {
            LongestClassementButtonMinusCurrent = LongestClassementButton;
            for (int i = 0; i < ClassementButton[Program.PosY].Length; i++)
            {
                LongestClassementButtonMinusCurrent--;
            }
        }
        public void ClassementButtons()
        {
            ClassementButton[0] = Program.BACK;
            ClassementButton[1] = "Reload classement";
        }
        public void WriteNewClassementButton()
        {
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            //Write selected language
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ColorMenu.consoleColor;
            Console.Write(ClassementButton[Program.PosY]);
            //Add Red between language and arrow
            LongestClassementButtonMinusCurrent = LongestClassementButton;
            for (int i = 0; i < ClassementButton[Program.PosY].Length; i++)
            {
                LongestClassementButtonMinusCurrent--;
            }
            //Write arrow
            for (int i = 0; i <= LongestClassementButtonMinusCurrent; i++)
            {
                Console.Write(" ");
            }
            Console.Write(Program.ARROW);
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void RemoveCurrentClassmentButton()
        {
            CurrentClassementButtonLength = 0;
            Program.PosX = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Write Language in black and white
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            Console.Write(ClassementButton[Program.PosY]);
            //Move to space between text and arrow
            for (int i = 0; i < ClassementButton[Program.PosY].Length; i++)
            {
                CurrentClassementButtonLength++;
            }
            //Remove red background
            for (int i = 0; i <= LongestClassementButtonMinusCurrent; i++)
            {
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX + CurrentClassementButtonLength, Program.DISTANCEMENUUP + Program.PosY);
                Console.Write(" ");
                Program.PosX++;
            }
            //Remove arrow
            for (int i = 0; i < Program.ARROW.Length; i++)
            {
                Console.Write(" ");
                Program.PosX++;
                Console.SetCursorPosition(Program.DISTANCEMENULEFT + CurrentClassementButtonLength + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            }
            Program.PosX = 0;
            CurrentClassementButtonLength = 0;
        }
        public void RemoveClassement()
        {
            Program.PosX = 0;
            Program.PosY = 0;
            // Change colors to black and white
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            //Erase language
            Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
            //Remove red background
            for (int j = 0; j < NUMBERCLASSEMENTMENU; j++)
            {
                for (int z = 0; z <= LongestClassementButton; z++)
                {
                    //Remove langages
                    Console.SetCursorPosition(Program.DISTANCEMENULEFT + Program.PosX, Program.DISTANCEMENUUP + Program.PosY);
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
        public void LeaveClassement()
        {
            if (selectedClassementOption == Program.BACK)
            {
                Program.PosY = 0;
                Program.PosX = 0;
                RemoveClassement();
                new MainMenu().WriteMainMenu();
            }
            else if (selectedClassementOption == "Reload classement")
            {
                //conn.Close();
                RemoveClassement();
                WriteClassement();
            }
        }
    }
}
