using System.ComponentModel;

namespace todo_ConsoleApp
{
    static class Program
    {
        static List<Task> tasks = new List<Task>();


        static void Main(string[] args)
        {
            AddTask();
            AddTask();
            ShowTasks();

            
            

        }

        static public void AddTask()
        {
            Console.WriteLine("Podaj nazwe");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Zadanie nie może być puste!");
                return;
            }

            Console.WriteLine("Podaj opis");
            string description = Console.ReadLine() ?? "brak";
            if (string.IsNullOrWhiteSpace(description))
                description = "brak";
            

            tasks.Add(new Task(name, description));
            Console.WriteLine("Pomyślnie dodano zadanie");

        }

        static public void SetAsDone()
        {
            if (tasks.Count != 0)
            {
                Console.WriteLine("Podaj id");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var task = tasks.Find(t => t.id == id);
                    if (task != null)
                    {
                        if(task.isCompleted)
                            task.isCompleted = false;
                        else
                            task.isCompleted = true;
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono zadania o takim ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowe id");
                }
            }
            else
                Console.WriteLine("Brak zadań do zrobienia");
        }

        static public void DeleteTask()
        {
            if(tasks.Count != 0)
            {
                Console.WriteLine("Podaj id");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var task = tasks.Find(t => t.id == id);
                    if (task != null)
                    {
                        tasks.Remove(task);
                        Console.WriteLine("Zadanie usunięte.");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono zadania o takim ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowe id");
                }
            }
            else
                Console.WriteLine("Brak zadań do usunięcia");

        }

        static public void ShowTasks()
        {
            foreach (var task in tasks)
            {
                if (task.isCompleted == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    task.GetInfo();
                }
                else
                    task.GetInfo();
                Console.ForegroundColor= ConsoleColor.White;
            }
        }
    }
}
