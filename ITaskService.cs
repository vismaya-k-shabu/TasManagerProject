namespace TaskManager.Interfaces
{
    using System;
    using TaskManager.Models;

    public interface ITaskService
    {
        void AddTask(string Title, string Description, DateTime DueDate);
    }
}
