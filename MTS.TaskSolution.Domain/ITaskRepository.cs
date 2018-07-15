using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTS.TaskSolution.Domain
{
    public interface ITaskRepository
    {
        Task<Guid> SaveTask(CustomTask task);
        Task<CustomTask> GetTaskByUid(Guid uid);
    }
}
