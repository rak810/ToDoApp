using System;
using System.Collections.Generic;

namespace ToDoApp
{
    public class IOCtrl
    {

        public static void PrintTasks(List<ToDo> todoList)
        {
            foreach(var todo in todoList)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", todo.ToDoId, todo.Title, todo.IsDone, todo.Date.ToShortDateString());
            }
        }
        public static void PrintSingleTask(ToDo todo)
        {
            Console.WriteLine("Task Id : {0}", todo.ToDoId);
            Console.WriteLine("Task Title : {0}", todo.Title);
            Console.WriteLine("Task Status : {0}", todo.IsDone);
            Console.WriteLine("Due Date : {0}", todo.Date.ToShortDateString());
            Console.WriteLine("Details : ");
            Console.WriteLine(todo.Note);
        }
        public static ToDo CreateATodo()
        {
            Console.WriteLine("Enter Task Detail --> ");
            Console.Write("Title : ");
            string title = Console.ReadLine();
            Console.Write("Date : ");
            string date = Console.ReadLine();
            Console.Write("Note : ");
            string note = Console.ReadLine();

            object dt = UpdateDate(date);
            if(dt == null) return null;
        
            return new ToDo{
                Title = title,
                Date = (DateTime)dt,
                Note = note
            };
        }

        public static object CreateUpdate(string updateName)
        {
            Console.Write($"New {updateName} : ");
            string res = Console.ReadLine();
            if (updateName == "date")
            {
                object dt = UpdateDate(res);
                if (dt == null) return null;
                return (DateTime)dt;
            }
            return res;
        }

        private static object UpdateDate(string res)
        {
            if (!DateTime.TryParse(res, out DateTime dt))
            {
                return null;
            }
            return dt;
        }

       
    }
}