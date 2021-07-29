using System;

namespace ToDoApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");
            CmdPrompt cmdPrompt = new CmdPrompt();
            cmdPrompt.Run();
        }
    }
}
