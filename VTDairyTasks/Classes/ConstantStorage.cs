namespace VTDairyTasks.Classes
{
    using System;
    using System.Configuration;

    public static class ConstantStorage
    {
        public static readonly Guid RootId = new Guid("00000000-0000-0000-0000-000000000001");

        public static readonly Guid RycledID = new Guid("00000000-0000-0001-0000-000000000002");

        
        public static string GetTaskPath(string accountName)
        {
            return ConfigurationManager.AppSettings["appFolder"] + @"\" +
                ConfigurationManager.AppSettings["taskFile"];
        }

        public static string GetPlanFilePath(string accountName)
        {
            return ConfigurationManager.AppSettings["appFolder"] +  @"\" +
                   ConfigurationManager.AppSettings["planFile"];
        }

        public static string GetHistoryFilePath(string accountName)
        {
            return ConfigurationManager.AppSettings["appFolder"] + @"\" +
                ConfigurationManager.AppSettings["historyFile"];
        }

        public enum DayTypes
        {
            Today = 0,
            History = 1,
            Plan = 2
        }

        public enum Status
        {
            Created = 0,

            Soon = 1,

            Active = 2,

            Resolved = 3,

            Canceled = 4,

            Everyday = 5,

            ToThink = 6,

            LookInet = 7,

            Folder = 8,
        }
    }
}