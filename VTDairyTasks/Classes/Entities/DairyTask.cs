using System;

namespace VTDairyTasks.Classes.Entities
{
    public class DairyTask
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public int Order { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastChange { get; set; }
        public double Estimation { get; set; }
        public double Duration { get; set; }

        public void Copy(DairyTask task)
        {
            this.Id = task.Id;
            this.ParentId = task.ParentId;
            this.Title = task.Title;
            this.Description = task.Description;
            this.Status = task.Status;
            this.Priority = task.Priority;
            this.Order = task.Order;
            this.Created = task.Created;
            this.LastChange = task.LastChange;
            this.Estimation = task.Estimation;
            this.Duration = task.Duration;
            
            this.Priority = task.Priority;
        }

        public DairyTaskTime ToTaskTime()
        {
            return new DairyTaskTime
            {
                Id = Guid.NewGuid(),
                TaskId = this.Id,
                Title = this.Title,
                Priority = this.Priority,
                Description = this.Description,
                Status = this.Status
            };

        }

        public bool IsEqaul(DairyTask task)
        {
            return this.Id.Equals(task.Id) && this.ParentId.Equals(task.ParentId)
                   && string.Equals(this.Title, task.Title, StringComparison.InvariantCultureIgnoreCase)
                   && string.Equals(this.Description, task.Description, StringComparison.InvariantCultureIgnoreCase)
                   && this.Status.Equals(task.Status) && this.Priority.Equals(task.Priority)
                   && this.Priority.Equals(task.Priority)
                   && this.Created.Equals(task.Created) && this.LastChange.Equals(task.LastChange)
                   && this.Estimation.Equals(task.Estimation) && this.Duration.Equals(task.Duration);

        }
    }
}