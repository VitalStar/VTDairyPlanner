namespace VTDairyTasks.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using VTDairyTasks.Classes;
    using VTDairyTasks.Classes.Entities;
    using VTDairyTasks.Classes.Factories;

    public class DairyDaysController : ApiController
    {
        public DairyDayFactory DayFactory;

        public DairyDaysController()
        {
               
        }

        [Route("DairyTask/GetDay")]
        public DairyDay GetDay()
        {
            this.DayFactory = new DairyDayFactory(ConstantStorage.GetPlanFilePath("TestAccount"));
            return this.DayFactory.GetDay(DateTime.Today);
        }

        [Route("DairyTask/GetDay/{date:datetime}")]
        public DairyDay GetDay(DateTime date)
        {
            this.DayFactory = new DairyDayFactory(ConstantStorage.GetPlanFilePath("TestAccount"));
            return this.DayFactory.GetDay(DateTime.Today);
        }

        [Route("DairyTask/GetHistoryDay/{date:datetime}")]
        public DairyDay GetHistoryDay(DateTime date)
        {
            this.DayFactory = new DairyDayFactory(ConstantStorage.GetHistoryFilePath("TestAccount"));
            return this.DayFactory.GetDay(DateTime.Today);
        }
       

    }
}
