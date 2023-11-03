using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class CursorPositionSynchronizer
    {
        static object sync = new();

        static public void SyncWriteAtPosition(int x, int y,string content)
        {
            lock (sync)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(content);
            }
        }
    }
}
