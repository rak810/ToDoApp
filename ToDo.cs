using System;
using System.Collections.Generic;

namespace ToDoApp
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get;  set; } 
        public string Note { get; set; }
        public string IsDone { get; set;} = "not-done";

    }
}