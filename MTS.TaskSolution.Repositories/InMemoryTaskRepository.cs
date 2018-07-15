using MTS.TaskSolution.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTS.TaskSolution.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private static ConcurrentDictionary<Guid, CustomTask> _data = new ConcurrentDictionary<Guid, CustomTask>();

        public async Task<CustomTask> GetTaskByUid(Guid uid)
        {
            if (_data.ContainsKey(uid))
                return _data[uid];
            return null;
        }

        public async Task<Guid> SaveTask(CustomTask task)
        {
            _data.AddOrUpdate(task.Uid, task, (key, value) => task);
            return task.Uid;
        }
    }
}
