using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyVader_Nima_Zarrabi
{
    internal class CursorPositionSynchronizer
    {
        static object semaphore = new();

        static public void SyncWriteAtPosition(int x, int y,string content)
        {
            lock (semaphore)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(content);
            }
        }
    }
}
