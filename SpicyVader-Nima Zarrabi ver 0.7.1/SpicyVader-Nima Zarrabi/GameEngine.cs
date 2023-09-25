using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpicyVader_Nima_Zarrabi
{
    internal class GameEngine
    {
        public void Timer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            foreach (char c in LangMenu.LANGSELECT)
            {
                LangMenu.langSelectLength++;
            }
            foreach (char c in ColorMenu.COLORSELECT)
            {
                ColorMenu.colorSelectLength++;
            }
            LangMenu.selectedLanguage = Program.BACK;
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

        // Specify what you want to happen when the Elapsed event is raised.
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("Hello World!");
        }
    }
}
