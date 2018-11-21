using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SimpleApp.Data;
using SimpleApp.Domain;

namespace SimpleUI
{
    class Program
    {
        private static ToDoListContext _context = new ToDoListContext();
        static void Main(string[] args)
        {
            //InsertToDoList();
            InsertMultipleTasks();
            SimpleToDoListQuery();
            //RetrieveAndUpdateTask();
            RetrieveAndUpdateMultipleTasks();
            RetrieveAndDeleteTask();
            InsertNewPkFkGraph();
        }
        private static void InsertMultipleTasks()
        {
            int id = InsertToDoList();
            var task = new Task { Text = "Thanksgiving", ToDoListId = id };
            var task2 = new Task { Text = "Christmas", ToDoListId = id };
            _context.AddRange(task,task2);
            _context.SaveChanges();
        }
        private static int InsertToDoList()
        {
            var todolist = new ToDoList { Name = "Duck" };
            var id = _context.Add(todolist);
            _context.SaveChanges();

            return todolist.Id;
        }
        private static void SimpleToDoListQuery()
        {
            var todolist = _context.ToDoLists.ToList();
        }
        private static void RetrieveAndUpdateTask()
        {
            var task = _context.Tasks.Where(t => t.Text == "Christmas").FirstOrDefault();
            task.Text += "Hej";
            _context.SaveChanges();
        }
        private static void RetrieveAndUpdateMultipleTasks()
        {
            var tasks = _context.Tasks.Where(t => t.Text == "Christmas").ToList();
            tasks.ForEach(t => t.Text += "Eve");
            _context.SaveChanges();
        }
        private static void RetrieveAndDeleteTask()
        {
            //var task = _context.Tasks.FirstOrDefault(t => t.Text == "Cool daddy cool");
            //_context.Remove(task);
            //_context.SaveChanges();
            var tasks = _context.Tasks.Where(t => t.Text == "ChristmasHej").ToList();
            using(var contextNewAppInstance = new ToDoListContext())
            {
                contextNewAppInstance.Tasks.RemoveRange(tasks);
                contextNewAppInstance.SaveChanges();
            }
        }
        private static void DeleteById(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            _context.Remove(task);
            _context.SaveChanges();
            // alternate: call a stored procedure
            // _context.Database.ExecutSqlCommand("exec DeleteById {0}", taskId);
        }
        private static void InsertNewPkFkGraph()
        {
            var task = new Task
            {
                Text = "New Task Force",
                ToDoList = new ToDoList { Name = "The time has come" }
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        private static void ModifyingRelatedDatatWhenNotTracked()
        {
            var task = _context.Tasks.Include(t => t.ToDoList).FirstOrDefault();
            var todolist = task.ToDoList;
            todolist.Name += " Did you get this?";
            using (var newContext = new ToDoListContext())
            {
                // newContext.ToDoList.Update(todolist);
                newContext.Entry(todolist).State = EntityState.Modified;
                newContext.SaveChanges();
            }

        }
    }
}
