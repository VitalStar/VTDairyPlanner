using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTDairyTasks.Classes.Entities;

namespace VTDairyTasks.Classes
{
    public class DummyTaskFactory
    {
        public List<DairyTask> Tasks = new[]
            {
                new DairyTask {Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Title = "Root Task", 
                    ParentId = new Guid("00000000-0000-0000-0000-000000000001"), 
                    Description = "Description Root"},
                new DairyTask {Id = new Guid("00000000-0000-0000-0000-000000000002"), 
                    ParentId = new Guid("00000000-0000-0000-0000-000000000001"),
                    Title = "Removed", 
                    Description = "Description Rucled"},
                new DairyTask {Id = new Guid("363ABA59-EAC3-4952-90E5-E3B05ACB48CF"), 
                    ParentId = new Guid("00000000-0000-0000-0000-000000000001"),
                    Title = "Title 1",
                    Description = "Description 1"},
                new DairyTask {Id = new Guid("CEB64EB9-246C-4FF5-A20F-CCCBDB7484AA"), 
                    ParentId = new Guid("00000000-0000-0000-0000-000000000001"),
                    Title = "Title 2",
                    Description = "Description 2", 
                    Status = 3},
                new DairyTask {Id = new Guid("A4DD0EE0-8213-4B34-A14A-9E3DF1644876"), 
                    ParentId = new Guid("363ABA59-EAC3-4952-90E5-E3B05ACB48CF"),
                    Title = "Title 11",
                    Description = "Description 11"},    
                new DairyTask {Id = new Guid("742011D0-F27B-4FD1-A48A-4A34305B7B9C"), 
                    ParentId = new Guid("CEB64EB9-246C-4FF5-A20F-CCCBDB7484AA"),
                    Title = "Title 12",
                    Description = "Description 12",
                    Status = 3},
                new DairyTask {Id = new Guid("62EA25ED-0A6C-4895-A829-45E5A39A8287"), 
                    ParentId = new Guid("CEB64EB9-246C-4FF5-A20F-CCCBDB7484AA"),
                    Title = "Title 111",
                    Description = "Description 111"},
                new DairyTask {Id = new Guid("1BF4FA69-D3A4-4967-833B-90574340C04B"), 
                    ParentId = new Guid("742011D0-F27B-4FD1-A48A-4A34305B7B9C"),
                    Title = "Title 112",
                    Description = "Description 112"},

            }.ToList();
    }
}


