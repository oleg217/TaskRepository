using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.TaskSolution.Domain
{
    public class CustomTask
    {
        public CustomTask()
        {
            Uid = Guid.NewGuid();
            SetStatus(CustomTaskStatus.Created);
        }

        public CustomTask(Guid uid, CustomTaskStatus status, DateTime timeStamp)
        {
            Uid = uid;
            Status = status;
            TimeStamp = timeStamp;
        }

        public void SetStatus(CustomTaskStatus status)
        {
            Status = status;
            TimeStamp = DateTime.Now;
        }

        public Guid Uid { get; set; }
        public CustomTaskStatus Status { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
