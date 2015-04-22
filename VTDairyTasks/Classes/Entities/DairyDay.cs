namespace VTDairyTasks.Classes.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DairyDay
    {
        public DateTime Date { get; set; }

        public List<DairyTaskTime> Tasks { get; set; }

        public DairyDay()
        {
            Date = DateTime.Today;
            Tasks = new List<DairyTaskTime>();
        }
    }
}