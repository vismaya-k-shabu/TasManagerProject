using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITaskManager taskService = new TaskManagerServices();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Task Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Get By Id");
                Console.WriteLine("3. View All  Tasks");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5.Exit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddTask(taskService);
                        break;
                    case "2":
                        GetTaskById(taskService);
                        return;
                    case "3":
                        ViewAllTasks(taskService);
                        return;
                    case "4":
                        DeleteTask(taskService);
                        return;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Try Again!!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        private static void AddTask(ITaskManager taskService)
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();

            Console.Write("Enter task description: ");
            string description = Console.ReadLine();

            Console.Write("Enter due date (yyyy-MM-dd): ");
            DateTime dueDate;
            while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                Console.Write("Invalid date format. Try again (yyyy-MM-dd): ");
            }
            Console.Write("Task is completed Yes/No: ");
            string completedInput = Console.ReadLine();

            bool isCompleted =  false;
            if (completedInput == "yes")
            {
                isCompleted = true;
            }
            TaskManagerModel newTask = new TaskManagerModel
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                IsCompleted = isCompleted
            };

            taskService.AddTask(newTask);
        }
        private static void GetTaskById(ITaskManager taskService)
        {
            Console.Write("Enter task ID: ");
            string idInput = Console.ReadLine();

            if (Guid.TryParse(idInput, out Guid id))
            {
                taskService.GetTaskById(id);
                Console.WriteLine("\n Press any key to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid GUID format.");
                Console.WriteLine("\n Press any key to continue.");
                Console.ReadLine();
            }
        }
        private static void ViewAllTasks(ITaskManager taskservices)
        {
            var tasks = taskservices.GetAllTasks();
            if(tasks.Count==0)
            {
                Console.WriteLine("Tasks Not Found");
            }
            else
            {
                Console.WriteLine("All Tasks :");
                foreach (var task in tasks)
                {
                    Console.WriteLine("-------------------------------------------------------------------------");
                   // Console.WriteLine($"ID :{task.Id}");
                    Console.WriteLine($"Title:{task.Title}");
                    Console.WriteLine($"Description:{task.Description}");
                    Console.WriteLine($"DueDate:{task.DueDate}");
                    Console.WriteLine($"IsCompleted:{task.IsCompleted}");
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            
        }
        private static void DeleteTask(ITaskManager taskservices)
        {
            Console.WriteLine("Enter Task Id to Delete :");
            if (Guid.TryParse(Console.ReadLine(), out Guid id))
            {
                Console.WriteLine(taskservices.DeleteTask(id));
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }

        }
    }
}
