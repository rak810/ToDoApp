using System;
using System.Linq;
using System.Collections.Generic;


namespace ToDoApp
{
    public class ToDoCtrl
    {
        private readonly static ToDoDbCtrl dbCtrl = new ToDoDbCtrl();
        private static List<int> ProcessInputList(List<string> commList, out string errMsg)
        {
            List<int> taskIds = null;
            errMsg = string.Empty;

            try
            {
                taskIds = commList[1].Split(',').Select( val => int.Parse(val)).ToList();
            }
            catch (System.FormatException e)
            {
                errMsg = e.Message;
                return null;
            }

            return taskIds;
        }
        public static void AddTask()
        {
            ToDo toDo = IOCtrl.CreateATodo();
            // AddTaskToDb method
            if ( toDo != null)
            {
                dbCtrl.AddTaskToDb(toDo);
            }
            else 
            {
                // handle error
                Console.WriteLine("Invalid Input");
            }
        }

        public static void DeleteTasks(List<string> commList)
        {
            List<int> ids;
            switch (commList[1])
            {
                case "done":
                    //RemoveDoneFromDb method
                    dbCtrl.RemoveDoneFromDb();
                    // handle removal status
                    break;
                default:
                    ids = ProcessInputList(commList, out string errMsg);
                    if(ids == null) Console.WriteLine(errMsg); // error Handling
                    else 
                    {
                        // RemoveByIdsFromDb method
                        dbCtrl.RemoveByIdsFromDb(ids);
                        // // handle removal status
                    } 
                    break;
            }
             

        }

        public static void UpdateTask(List<string> commList)
        {

            if (!int.TryParse(commList[2], out int taskId))
            {
                // error handling
                Console.WriteLine("Interger parsing failed.");
                return;
            }

            object val;
            switch (commList[1])
            {
                case "title":
                    //Get Updated valued
                    val = IOCtrl.CreateUpdate("title");
                    // UpdateTasksInDb
                    dbCtrl.UpdateTasksInDb(taskId, "Title", val);
                    // handle update status
                    break;
                case "date":
                    // UpdateTasksInDb
                    val = IOCtrl.CreateUpdate("date");
                    if ( val != null)
                    {
                        dbCtrl.UpdateTasksInDb(taskId, "Date", val);
                    }
                    else 
                    {
                        Console.WriteLine("Invalid Date");
                        // error handle
                    }
                    // handle update status
                    break;
                case "note":
                    //Get Updated valued
                    val = IOCtrl.CreateUpdate("note");  
                    // UpdateTasksInDb
                    dbCtrl.UpdateTasksInDb(taskId, "Note", val);
                    // handle update status
                    break;
                case "status":
                    // Get Updated valued
                    val = IOCtrl.CreateUpdate("status");
                    // UpdateTasksInDb
                    dbCtrl.UpdateTasksInDb(taskId, "IsDone", val);
                    // handle update status
                    break;
                default:
                    // error Handling
                    Console.WriteLine("Unknown option. Try again.");
                    break;
            }
        }

        public static void ShowTasks(List<string> commList)
        {
            List<int> ids;
            List<ToDo> res;
            switch (commList[1])
            {
                case "done":
                    // GetTasksByStatusFromDb
                    res = dbCtrl.GetTasksByStatusFromDb("done");
                    // print result
                    IOCtrl.PrintTasks(res);
                    // print result
                    break;
                case "doing":
                    // GetTasksByStatusFromDb
                    res = dbCtrl.GetTasksByStatusFromDb("doing");
                    // print result
                    IOCtrl.PrintTasks(res);
                    break;
                case "not-done":
                    // GetTasksByStatusFromDb
                    res = dbCtrl.GetTasksByStatusFromDb("not-done");
                    // print result 
                    IOCtrl.PrintTasks(res);
                    break;
                case "all":
                    // GetAllTasksFromDb
                    res = dbCtrl.GetAllTasksFromDb();
                    // print result
                    IOCtrl.PrintTasks(res);
                    break;
                case "detail":
                    var detail = dbCtrl.GetDetailByIdFromDb(int.Parse(commList[2]));
                    IOCtrl.PrintSingleTask(detail);
                    break;
                default:
                    ids = ProcessInputList(commList, out string errMsg);
                    if(ids == null) Console.WriteLine(errMsg); // error Handling
                    else 
                    {
                        // GetTasksByIdsFromDb
                        res = dbCtrl.GetTasksByIdsFromDb(ids);
                        // print result
                        IOCtrl.PrintTasks(res);
                        
                    } 
                    break;
            }

        }
    }
}