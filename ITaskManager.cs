using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public interface ITaskManager
    {

        void AddTask(TaskManagerModel task);
        TaskManagerModel GetTaskById(Guid Id);
        bool DeleteTask(Guid Id);
        List<TaskManagerModel> GetAllTasks();
        

    }
}
