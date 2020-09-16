using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part01_4
{
    // Observer Pattern
    class InputManager
    {
        public delegate void OnInputKey();
        public event OnInputKey Inputkey;

        public void Update()
        {
            if (Console.KeyAvailable == false)
                return;

            ConsoleKeyInfo info = Console.ReadKey();
            if(info.Key == ConsoleKey.A)
            {
                // 모두한테 알려준다!
                Inputkey();
            }
        }
    }
}
