using System;
using System.Collections.Generic;

namespace SimpleApp.Domain
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<ToDoListSchedule> ToDoListSchedules { get; set; }
    }
}
