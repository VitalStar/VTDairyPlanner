using System;

namespace VTDairyTasks.Classes.Entities
{
    public class DairyTaskTime
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string Resume { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int Order { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public void Copy(DairyTaskTime taskTime)
        {
            this.Id = taskTime.Id;
            this.TaskId = taskTime.TaskId;
            this.Resume = taskTime.Resume;
            this.Title = taskTime.Title;
            this.Description = taskTime.Description;
            this.Status = taskTime.Status;
            this.Priority = taskTime.Priority;
            this.Order = taskTime.Order;
            this.StartTime = taskTime.StartTime;
            this.EndTime = taskTime.EndTime;
            
           
            this.Priority = taskTime.Priority;
        }

        public bool IsEqaul(DairyTaskTime taskTime)
        {
            return this.Id.Equals(taskTime.Id)
                   && this.TaskId.Equals(taskTime.TaskId)
                   && string.Equals(this.Resume, taskTime.Resume, StringComparison.InvariantCultureIgnoreCase)
                   && string.Equals(this.Title, taskTime.Title, StringComparison.InvariantCultureIgnoreCase)
                   && string.Equals(this.Description, taskTime.Description, StringComparison.InvariantCultureIgnoreCase)
                   && this.Status.Equals(taskTime.Status)
                   && this.Priority.Equals(taskTime.Priority)
                   && this.Order.Equals(taskTime.Order)
                   && this.StartTime.Equals(taskTime.StartTime)
                   && this.EndTime.Equals(taskTime.EndTime);
        }
    }
}