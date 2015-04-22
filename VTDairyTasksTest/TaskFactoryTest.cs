namespace VTDairyTasksTest
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using VTDairyTasks.Classes;
    using VTDairyTasks.Classes.Factories;

    [TestClass]
    public class TaskFactoryTest
    {
        private DairyTaskFactory dairyTaskFactory;

        public TaskFactoryTest()
        {
            this.dairyTaskFactory = new DairyTaskFactory(ConstantStorage.GetTaskPath("TestAccount"));
        }

        [TestMethod]
        public void OpenSaveTest()
        {
            int taskCount = 0;

            var dummy = new DummyTaskFactory();
            foreach (var dairyTask in dummy.Tasks)
            {
                this.dairyTaskFactory.AddTask(dairyTask);
                taskCount++;
            }

            Assert.AreEqual(this.dairyTaskFactory.Size(), taskCount);

            File.Delete(ConstantStorage.GetTaskPath("TestAccount"));

        }
    }
}
