using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Domain
{
    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ToDoList ToDoList { get; set; }
        public int ToDoListId { get; set; }
    }
}
