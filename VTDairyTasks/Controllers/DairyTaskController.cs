using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VTDairyTasks.Classes;
using VTDairyTasks.Classes.Entities;

namespace VTDairyTasks.Controllers
{
    using VTDairyTasks.Classes.Factories;

    public class DairyTaskController : ApiController
    {
        public DairyTaskFactory TaskFactory;

        public DairyTaskController()
        {
            TaskFactory = new DairyTaskFactory(ConstantStorage.GetTaskPath("TestAccount"));    
        }

        [Route("DairyTask/GetTasks")]
        public IEnumerable<DairyTask> GetTasks()
        {
            return this.TaskFactory.AllTasks;
        }

        [Route("DairyTask/GetTasks/{id:guid}")]
        public DairyTask GetTask(Guid id)
        {
            return this.TaskFactory.GetTask(id);            
        }

        [Route("DairyTask/GetChildTasks/{id:guid}")]
        public IEnumerable<DairyTask> GetChildTasks(Guid id)
        {
            return this.TaskFactory.GetChildTasks(id);
        }

        [Route("DairyTask/GetRootTasks")]
        public IEnumerable<DairyTask> GetRootTasks()
        {
            return this.TaskFactory.GetChildTasks(ConstantStorage.RootId);
        }


    }
}
