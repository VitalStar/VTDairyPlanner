namespace VTDairyTasks.Classes.Factories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using VTDairyTasks.Classes.Entities;

    public class DairyTaskFactory
    {
        private readonly string filePath;
        List<DairyTask> taskCollection;

        public DairyTaskFactory(string taskFilePath)
        {
            this.filePath = taskFilePath;
            this.taskCollection = new List<DairyTask>();
            this.LoadAllTasks();
        }

        public List<DairyTask> AllTasks
        {
            get
            {
                return this.taskCollection;
            }
        }

        public List<DairyTask> GetChildTasks(Guid parentId)
        {
            return this.taskCollection.Where(t => t.ParentId == parentId).ToList();
        }
        
        public DairyTask GetTask(Guid id)
        {
            return this.taskCollection.FirstOrDefault(tsk => tsk.Id == id);
        }
        

        public DairyTask GetTask(String title)
        {
            return this.taskCollection.FirstOrDefault(tsk => tsk.Title == title);
        }

        public void AddTask(DairyTask task)
        {
            try
            {
                this.taskCollection.Add(task);
                this.SaveAllTasks();
            }
            catch (Exception ex)
            {
                // LogEvent
            }
        }

        public void RemoveTask(Guid id)
        {
            var remTask = this.GetTask(id);
            this.taskCollection.Remove(remTask);
            this.SaveAllTasks();
        }

        public bool UpdateTask(DairyTask task)
        {
            var updTask = this.GetTask(task.Id);
            if (updTask != null)
            {
                updTask.Copy(task);
                updTask.LastChange = DateTime.Now;
                this.SaveAllTasks();
                return true;
            }

            return false;
        }

        public int Size()
        {
            return this.taskCollection.Count;
        }

        private void SaveAllTasks()
        {
            using (var fs = new FileStream(this.filePath, FileMode.Create))
            {
                if ((this.taskCollection != null) && (this.taskCollection.Count > 0))
                {
                    var xs = new XmlSerializer(typeof(List<DairyTask>), new XmlRootAttribute("tasks"));
                    xs.Serialize(fs, this.taskCollection);
                }
            }
        }

        private void LoadAllTasks()
        {
            if (File.Exists(this.filePath))
            {
                using (var sr = new StreamReader(this.filePath, Encoding.UTF8))
                {
                    var xs = new XmlSerializer(typeof(List<DairyTask>), new XmlRootAttribute("tasks"));
                    try
                    {
                        this.taskCollection = (List<DairyTask>)xs.Deserialize(sr);
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