using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VTDairyTasksTest
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using VTDairyTasks.Classes;
    using VTDairyTasks.Classes.Entities;
    using VTDairyTasks.Classes.Factories;

    [TestClass]
    public class DayFactoryTest
    {
        private DairyDayFactory DayFactory;

        public DayFactoryTest()
        {
        }
        
        [TestMethod]
        public void OpenSaveTest()
        {
            int taskCount = 0;

            var day = this.GenerateTodayFromTestData();
            taskCount = day.Tasks.Count();

            DayFactory = new DairyDayFactory(ConstantStorage.GetPlanFilePath("TestAccount"));

            DayFactory.AddDay(day);
            var loadedDay = DayFactory.GetDay(day.Date);

            Assert.IsNotNull(loadedDay);
            Assert.AreEqual(loadedDay.Tasks.Count(), taskCount);

            try
            {
                day = this.GenerateTodayFromTestData();
                DayFactory.AddDay(day);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Day already exist");
            }
            finally
            {
                File.Delete(ConstantStorage.GetPlanFilePath("TestAccount"));
            }
        }

        [TestMethod]
        public void CreateTestFiles()
        {
            DayFactory = new DairyDayFactory(ConstantStorage.GetPlanFilePath("TestAccount"));
            DayFactory.AddDay(this.CreatePlan());
            DayFactory.AddDay(this.CreateToday());

            DayFactory = new DairyDayFactory(ConstantStorage.GetHistoryFilePath("TestAccount"));
            DayFactory.AddDay(this.CreateYesturday());
            
        }

        //"Title 12"
        //"Title 2"
        //"Title 111"
        private DairyDay CreateToday()
        {
            var dummy = new DummyTaskFactory();
            var task11 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 11"));
            var task12 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 12"));
            var task2 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 2"));
            var task111 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 111"));
            var task112 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 112"));

            return new DairyDay
                       {
                           Date = DateTime.Today,
                           Tasks = { task11.ToTaskTime(), task112.ToTaskTime(),
                               task2.ToTaskTime(), task12.ToTaskTime(), task111.ToTaskTime() }
                       };
        }

        //"Title 12"
        //"Title 2"
        //"Title 111"
        private DairyDay CreateYesturday()
        {
             var dummy = new DummyTaskFactory();
            var task12 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 12"));
            var task2 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 2"));
            var task111 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 111"));

            return new DairyDay
                            {
                                Date = DateTime.Today.AddDays(-1),
                                Tasks = { task2.ToTaskTime(), task12.ToTaskTime(), task111.ToTaskTime() }
                            };
        }


        //"Title 12"
        //"Title 112"
        //"Title 111"
        private DairyDay CreatePlan()
        {
            var dummy = new DummyTaskFactory();
            var task12 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 12"));
            var task112 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 112"));
            var task111 = dummy.Tasks.First(task => task.Title.Trim().Equals("Title 111"));

            return new DairyDay
                       {
                           Date = DateTime.Today.AddDays(1),
                           Tasks = { task112.ToTaskTime(), task12.ToTaskTime(), task111.ToTaskTime() }
                       };
        }

        private DairyDay GenerateTodayFromTestData()
        {
            var dummy = new DummyTaskFactory();
            return new DairyDay
            {
                Date = DateTime.Today,
                Tasks =
                    dummy.Tasks.Where(
                        t => t.ParentId == new Guid("00000000-0000-0000-0000-000000000001"))
                    .Select(tsk => tsk.ToTaskTime())
                    .ToList()
            };
        }

        
    }
}
