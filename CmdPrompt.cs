using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp
{
    public class CmdPrompt
    {
        private bool isExited = false;
        private static readonly string msg = "type \"help\" for usage information";
        public void Run() 
        {
            PrintMsg();
            while(!isExited)
            {
                
                Prompt();
                string input = Console.ReadLine();
                List<string> inList = input?.Split(' ').ToList();
                if (inList == null) Console.WriteLine("No Commands Provided");
                else 
                {
                    ExecOperation(inList);
                }
            }
        }

        private void ExecOperation(List<string> inputList)
        {
            switch (inputList[0])
            {
                case "add":
                    ToDoCtrl.AddTask();
                    break;
                case "remove":
                    ToDoCtrl.DeleteTasks(inputList);
                    break;
                case "update":
                    ToDoCtrl.UpdateTask(inputList);
                    break;
                case "help":
                    PrintHelp();
                    break;
                case "show":
                    ToDoCtrl.ShowTasks(inputList);
                    break;
                case "exit":
                    isExited = true;
                    break;
                default:
                    Console.WriteLine("Invalid Command");
                    PrintMsg();
                    break;
            }
        }

        private static void PrintHelp()
        {
            string helpStr = @"
            [command] [option]
            Commands:
            add     Add new task
            remove  Remove tasks
            show    Show selected task
            update  Update a task
            exit    Exit prompt
            help    Show Usage information
            Options:
            add     No options
            remove  done, taskId(int) list
            show    done, doing, not-done, all, taskId(int) list
            update  taskId(int)
            Example:
            remove  done
            show    1,4,3,5   
            ";
            Console.WriteLine(helpStr);
        }
        private static void Prompt()
        {
            Console.Write("> ");
        }

        private static void PrintMsg()
        {
            Console.WriteLine(msg);
        }



        


    }
}