using System;
using System.Linq;
using System.Collections.Generic;

namespace ToDoApp
{
    public class ToDoDbCtrl
    {
        
        private readonly ToDoDbContext db;
        
        public ToDoDbCtrl()
        {
            db = new ToDoDbContext();
        }
        
        public void AddTaskToDb(ToDo todo)
        {
            db.ToDos.Add(todo);
            db.SaveChanges();
        }

        public void RemoveDoneFromDb()
        {
            var doneList = db.ToDos.Select(td => td)
                                   .Where(res => res.IsDone == "done")
                                   .ToList();
            db.RemoveRange(doneList);
            db.SaveChanges();
        }

        public void RemoveByIdsFromDb(List<int> ids)
        {
            var idList = db.ToDos.Select(td => td)
                                 .Where(res => ids.Contains(res.ToDoId))
                                 .ToList();
            db.RemoveRange(idList);
            db.SaveChanges();
        }

        public void UpdateTasksInDb(int taskId, string propName, object val)
        {
            var todo = db.ToDos.Select(td => td).Where( ts => ts.ToDoId == taskId).First();
            if(todo != null)
            {
                try
                {
                    var propInfo = typeof(ToDo).GetProperty(propName);
                    propInfo?.SetValue(todo, val, null);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Error : {0}", e.Message);
                    Console.WriteLine("{0}", e.TargetSite);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : {0}", e.Message);
                    Console.WriteLine("{0}", e.TargetSite);
                    return; 
                }
                
                db.Entry(todo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                // Error Handling
                Console.WriteLine("Not Found");
            }
        }

        public List<ToDo> GetTasksByStatusFromDb(string status)
        {
            var idList = db.ToDos.Select(td => td)
                                 .Where(res => res.IsDone == status)
                                 .ToList();
            
            return idList;
        }

        public List<ToDo> GetAllTasksFromDb()
        {
            var allTasks = db.ToDos.Select(td => td).ToList();
            return allTasks;
        }

        public List<ToDo> GetTasksByIdsFromDb(List<int> ids)
        {
            var idList = db.ToDos.Select(td => td)
                                 .Where(res => ids.Contains(res.ToDoId))
                                 .ToList();

            return idList;
        }

        public ToDo GetDetailByIdFromDb(int taskId)
        {
            var todo = db.ToDos.Select(td => td).Where( ts => ts.ToDoId == taskId).First();
            return todo;
        }
    }
}