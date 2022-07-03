using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Models;
using DataContracts.Models.Enums;

namespace Business.Services
{
    public class StatusService
    {
        internal Analyzer ApproveStatusA(Analyzer analyzer)
        {
            var checkWarning = false;
            var checkData = 0;
            foreach (var channel in analyzer.Channels)
            {

                if (channel.StatusC != StatusChannel.Warning)
                {
                    if (channel.StatusC == StatusChannel.NoData)
                        checkData++;
                }
                else
                {
                    checkWarning = true;
                    break;
                }
            }
            if (checkWarning == true)
                analyzer.StatusA = StatusAnalyzer.Warning;
            else
            {
                if (checkData < analyzer.Channels.Count)
                    analyzer.StatusA = StatusAnalyzer.Active;
            }
            return analyzer;
        }

        internal Analyzer ApproveStatusC(Analyzer analyzer)
        {
            foreach (var channel in analyzer.Channels)
            {
                if (channel.IsHot < analyzer.MeasureInterval)
                {
                    channel.StatusC = StatusChannel.Normal;
                    break;
                }
                else
                {
                    if (channel.IsHot > analyzer.MeasureInterval)
                    {
                        channel.StatusC = StatusChannel.Warning;
                    }
                    if (channel.IsHot == 0)
                        channel.StatusC = StatusChannel.NoData;
                }
            }
            return analyzer;
        }
    }
}
