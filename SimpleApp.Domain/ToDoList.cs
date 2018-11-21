using System.Collections.Generic;

namespace SimpleApp.Domain
{
    public class ToDoList
    {
        public ToDoList()
        {
            ToDoLists = new List<Task>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Task> ToDoLists { get; set; }
        public ScretIdentity ScretIdentity { get; set; }
    }
}
