namespace VTDairyTasks.Classes.Factories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using VTDairyTasks.Classes.Entities;

    public class DairyDayFactory
    {
        private readonly string filePath;

        private List<DairyDay> days; 

        public DairyDayFactory(string filePath)
        {
            this.filePath = filePath;
            days = new List<DairyDay>();
            this.LoadAllDays();
        }

        public List<DairyDay> Days
        {
            get
            {
                return this.days;
            }
        }

        public DairyDay GetDay(DateTime date)
        {
            return this.days.FirstOrDefault(dt => dt.Date.Date.Equals(date.Date));
        }

        public List<DairyDay> GetDaysWithTask(Guid taskId, DateTime fromDate, DateTime toDate)
        {
            var dateRange = this.days.Where(dt => (dt.Date >= fromDate.Date) && (dt.Date <= toDate.Date)).ToList();
            return dateRange.Where(day => day.Tasks.Any(tsk => tsk.TaskId == taskId)).ToList();
        }

        public void AddDay(DairyDay day)
        {
            var existingCheck = this.GetDay(day.Date);
            if (existingCheck != null) 
                throw new Exception("Day already exist");
            this.days.Add(day);
            this.SaveAllDays();
        }

        public void UpdateDay(DairyDay day)
        {
            var updDay = this.GetDay(day.Date);
            if (updDay != null)
            {
                updDay.Tasks = day.Tasks;
                this.SaveAllDays();
            }
            else
            {
                // LOG ERROR
            }
        }

        public void RemoveDay(DateTime date)
        {
            var removeDay = this.GetDay(date);
            if (removeDay != null)
            {
                this.days.Remove(removeDay);
                this.SaveAllDays();
            }
        }

        public void SaveAllDays()
        {
            using (var fs = new FileStream(this.filePath, FileMode.Create))
            {
                var xs = new XmlSerializer(typeof(List<DairyDay>), new XmlRootAttribute("days"));

                if ((this.days != null) && (this.days.Count > 0))
                {
                    xs.Serialize(fs, this.days);
                }
            }
        }

        private void LoadAllDays()
        {
            if (File.Exists(this.filePath))
            {
                using (var sr = new StreamReader(this.filePath, Encoding.UTF8))
                {
                    var xs = new XmlSerializer(typeof(List<DairyDay>), new XmlRootAttribute("days"));
                    try
                    {
                        this.days = (List<DairyDay>)xs.Deserialize(sr);
                    }
                    catch (Exception e)
                    {
                        // LogError
                        string ex = e.Message;
                    }
                }
            }
        }
    }
}