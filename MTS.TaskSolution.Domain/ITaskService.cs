using MTS.TaskSolution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.TaskSolution.Services
{
    public interface ITaskService
    {
        Task<Guid> CreateTask();
        Task<CustomTask> GetTaskByUid(Guid uid);
    }
}
