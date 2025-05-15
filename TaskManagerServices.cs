using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class TaskManagerServices :ITaskManager
    {
        private readonly List<TaskManagerModel> _tasks = new List<TaskManagerModel>();


        public void AddTask(TaskManagerModel task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));
            _tasks.Add(task);
            Console.WriteLine("Task Added Succesfully");
            
        }
       
        public TaskManagerModel GetTaskById(Guid Id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == Id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return null;
            }

            Console.WriteLine("Task Found:");
            Console.WriteLine($"ID: {task.Id}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Due Date: {task.DueDate:yyyy-MM-dd}");
            Console.WriteLine($"Completed: {task.IsCompleted}");

            return task;
        }
       
        public bool DeleteTask(Guid Id)
        {
            var task = _tasks.FirstOrDefault(t =>t.Id == Id);
            if (task == null)
            {
                Console.WriteLine("Task Not Found");
                return false;
            }
            else
            {
                _tasks.Remove(task);
                Console.WriteLine("Task Deleted Succesfully");
                return true;
            }

        }
        public List<TaskManagerModel> GetAllTasks()
        {
            return _tasks;
        }
    }
}
