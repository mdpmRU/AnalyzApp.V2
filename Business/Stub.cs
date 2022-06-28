using DataContracts.Entities;
using DataContracts.Entities.Enums;

namespace Business
{
    public static class Stub
    {
        public static List<Analyzer> Analyzers = new List<Analyzer>()
        {
            new Analyzer()
            {
                Name = "FirstAlyzer",
                Type = "FirstType",
                MeasureInterval = 99,
                StatusA = StatusAnalyzer.Warning,
                Channels = new List<Channel>()
                {
                    new Channel()
                    {
                        Name = "FirstChannel",
                        StatusC = StatusChannel.Warning,
                        IsHot = 100,
                    },
                    new Channel()
                    {
                        Name = "SecondChannel",
                        StatusC = StatusChannel.Normal,
                        IsHot = 89,
                    }

                }
            },
            new Analyzer()
            {
                Name = "SecondAlyzer",
                Type = "SecondType",
                MeasureInterval = 89,
                StatusA = StatusAnalyzer.Active,
                Channels = new List<Channel>()
                {
                    new Channel()
                    {
                        Name = "1Channel",
                        IsHot = 13,
                    },
                    new Channel()
                    {
                        Name = "2Channel",
                        IsHot = 88,
                    }

                }
            }
        };
    }
}