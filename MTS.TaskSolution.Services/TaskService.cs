using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MTS.TaskSolution.Domain;

namespace MTS.TaskSolution.Services
{
    public class TaskService : ITaskService
    {
        ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomTask> GetTaskByUid(Guid uid)
        {
            return await _repository.GetTaskByUid(uid);
        }

        public async Task<Guid> CreateTask()
        {
            var task = new CustomTask();
            await _repository.SaveTask(task);
            var executeTask = ExecuteTask(task);
            return task.Uid;
        }

        private async Task ExecuteTask(CustomTask task)
        {
            if (task.Status != CustomTaskStatus.Created)
                throw new Exception("Wrong task status");
            await UpdateTaskStatus(task, CustomTaskStatus.Running);
            await Task.Delay(1000 * 60 * 2);
            await UpdateTaskStatus(task, CustomTaskStatus.Finished);
        }

        private async Task UpdateTaskStatus(CustomTask task, CustomTaskStatus status)
        {
            task.SetStatus(status);
            await _repository.SaveTask(task);
        }

    }
}
