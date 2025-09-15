using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_ConsoleApp
{
    class Task
    {
        public static int nextId = 1; // automatyczne id
        public int id {get; set;}
        public string title { get; set; }
        public string description { get; set; }
        //private DateTime? DueDate;
        public bool isCompleted = false;

        public Task(string title, string description)
        {
            this.id = nextId++;
            this.title = title;
            this.description = description;
            /*this.DueDate = dueDate;*/
        }

        // Konstruktor pomocniczy - bez daty
        /*public Task(string title, string description)
            : this(title, description, null) // wywołuje główny konstruktor z dueDate = null
        {
            
        }*/


        public void GetInfo()
        {
            Console.WriteLine($"{id}. {title} ({description}) {(isCompleted ? "[✓]" : "[ ]")} ");
        }

        /*public string GetDueDateString()
        {
            return DueDate.HasValue ? DueDate.Value.ToString("yyyy-MM-dd") : "Brak daty";
        }*/
    }
}
