using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleApp.Data;
using SimpleApp.Domain;

namespace SimpleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertToDoList();
            InsertMultipleTasks();
            SimpleToDoListQuery();
        }
        private static void InsertMultipleTasks()
        {
            int id = InsertToDoList();
            var task = new Task { Text = "Thanksgiving", ToDoListId = id };
            var task2 = new Task { Text = "Christmas", ToDoListId = id };
            using (var context = new ToDoListContext())
            {
                context.AddRange(task,task2);
                context.SaveChanges();
            }
        }
        private static int InsertToDoList()
        {
            var todolist = new ToDoList { Name = "Duck" };
            using (var context = new ToDoListContext())
            {
                var id = context.Add(todolist);
                context.SaveChanges();

                return todolist.Id;
            }
        }
        private static void SimpleToDoListQuery()
        {
            using (var context = new ToDoListContext())
            {
                var todolist = context.ToDoLists.ToList();
            }
        }
    }
}
