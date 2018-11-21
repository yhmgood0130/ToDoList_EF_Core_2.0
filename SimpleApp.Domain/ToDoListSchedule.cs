using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Domain
{
    public class ToDoListSchedule
    {
        public int ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
