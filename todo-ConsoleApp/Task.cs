using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_ConsoleApp
{
    class Task
    {
        public static int nextId = 1; 
        public int id {get; set;}
        public string title { get; set; }
        public string description { get; set; }
        
        public bool isCompleted = false;

        public Task(string title, string description)
        {
            this.id = nextId++;
            this.title = title;
            this.description = description;
        }

        public void GetInfo()
        {
            Console.WriteLine($"{id}. {title} ({description}) {(isCompleted ? "[X]" : "[ ]")} ");
        }
    }
}
