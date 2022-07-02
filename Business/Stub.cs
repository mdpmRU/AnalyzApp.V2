using DataContracts.Models;
using DataContracts.Models.Enums;
using System.Collections.ObjectModel;

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
                Channels = new ObservableCollection<Channel>()
                {
                    new Channel()
                    {
                        Name = "FirstChannel",
                        IsHot = 100,
                    },
                    new Channel()
                    {
                        Name = "SecondChannel",
                        IsHot = 89,
                    }

                }
            },
            new Analyzer()
            {
                Name = "SecondAlyzer",
                Type = "SecondType",
                MeasureInterval = 89,
                Channels = new ObservableCollection<Channel>()
                {
                    new Channel()
                    {
                        Name = "1Channel",
                        IsHot = 13,
                    },
                    new Channel()
                    {
                        Name = "2Channel",
                        IsHot = 0,
                    }
                }
            }
        };
    }
}