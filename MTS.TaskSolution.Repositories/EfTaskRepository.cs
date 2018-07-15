using MTS.TaskSolution.Domain;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MTS.TaskSolution.Repositories
{
    public class EfTaskRepository : ITaskRepository
    {
        CustomTaskDbContext _context { get; set; }

        public EfTaskRepository(CustomTaskDbContext context)
        {
            _context = context;
        }
        public Task<CustomTask> GetTaskByUid(Guid uid)
        {
            return _context.CustomTasks.FindAsync(uid);
        }

        public async Task<Guid> SaveTask(CustomTask task)
        {
            await _context.CustomTasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task.Uid;
        }
    }
}
