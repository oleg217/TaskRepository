using MTS.TaskSolution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.TaskSolution.WebApi.ViewModels
{
    public class CustomTaskViewModel
    {
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public static class ViewModelExtensions
    {
        public static CustomTaskViewModel ToViewModel(this CustomTask task)
        {
            return new CustomTaskViewModel()
            {
                Status = task.Status.ToString().ToLower(),
                TimeStamp = task.TimeStamp
            };
        }
    }
}
