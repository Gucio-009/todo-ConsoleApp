using System.ComponentModel;
using System.ComponentModel.Design;
using System.Xml.Serialization;
using System.Threading;

namespace todo_ConsoleApp
{
    static class Program
    {
        static List<Task> tasks = new List<Task>();


        static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 5)
            {
                ShowTasks();
                Console.WriteLine("Press  ->  |  1 - Add Task  |  2 - Mark as Done  |  3 - Edit Task  |  4 - Delete Task  |");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddTask(); break;

                        case 2:
                            SetAsDone(); break;
                        case 3:
                            EditTask();
                            break;
                        case 4:
                            DeleteTask(); break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("There is no such operation");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }                  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no such operation");
                    Console.ForegroundColor = ConsoleColor.White;
                }
               
                Thread.Sleep(1200);
                Console.Clear();
            }
        }

        static public void AddTask()
        {
            Console.WriteLine("Input Name:");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name can't be empty!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.WriteLine("Input description:");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
                description = "None";
            

            tasks.Add(new Task(name, description));

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task Saccesfully Added !!");
            Console.ForegroundColor = ConsoleColor.White;

        }

        static public void SetAsDone()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (tasks.Count != 0)
            {
                Console.WriteLine("Input id:");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Clear();
                    var task = tasks.Find(t => t.id == id);
                    if (task != null)
                    {
                        if(task.isCompleted)
                            task.isCompleted = false;
                        else
                            task.isCompleted = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Status sacesfully changed!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find a task with this id");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong id!!");
                }
                    
                }
            else
            {
                Console.Clear();
                Console.WriteLine("There are no tasks to do!!");
            }                

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static public void EditTask()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (tasks.Count != 0)
            {
                Console.WriteLine("Input id:");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Clear();
                    var task = tasks.Find(t => t.id == id);
                    if (task != null)
                    {
                        Console.Write($"Input new name (Current: {task.title}): ");
                        string input = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(input))
                        {
                            task.title = input; 
                        }

                        Console.Write($"Input new description (Current: {task.description}): ");
                        input = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(input))
                        {
                            task.description = input; 
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Edited sacesfully!!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find a task with this id");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong id!!");
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("There are no tasks to edit!!");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static public void DeleteTask()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (tasks.Count != 0)
            {
                Console.WriteLine("Input id:");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.Clear();
                    var task = tasks.Find(t => t.id == id);
                    if (task != null)
                    {
                        tasks.Remove(task);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Task deleted.");
                    }
                    else
                    {
                        
                        Console.WriteLine("Couldn't find a task with this id");
                        
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong id!!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There are no tasks to delete!!");
            }
                

            Console.ForegroundColor = ConsoleColor.White;
        }

        static public void ShowTasks()
        {
            foreach (var task in tasks)
            {
                if (!task.isCompleted)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    task.GetInfo();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    task.GetInfo();
                }
                    
                Console.ForegroundColor= ConsoleColor.White;
            }
        }
    }
}
