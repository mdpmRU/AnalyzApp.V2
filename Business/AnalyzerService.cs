﻿using DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities.Enums;

namespace Business
{
    public class AnalyzerService
    {
        public List<Analyzer> CheckStatus(List<Analyzer> list)
        {
            foreach (var analyzer in list)
            {
                ApproveStatusC(analyzer);
                ApproveStatusA(analyzer);
            }
            return list;
        }

        private Analyzer ApproveStatusA(Analyzer analyzer)
        {
            var checkwarning = false;
            var checkdata = 0;
            foreach (var channel in analyzer.Channels)
            {
                
                if (channel.StatusC != StatusChannel.Warning)
                {
                    if (channel.StatusC == StatusChannel.NoData)
                        checkdata++;
                }
                else
                {
                    checkwarning = true;
                    break;
                }
            }

            if (checkwarning == true)
                analyzer.StatusA = StatusAnalyzer.Warning;
            else
            {
                if (checkdata < analyzer.Channels.Count)
                    analyzer.StatusA = StatusAnalyzer.Active;
            }
            return analyzer;
        }

        private Analyzer ApproveStatusC(Analyzer analyzer)
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
                    if (channel.IsHot == null)
                        channel.StatusC = StatusChannel.NoData;
                }

            }
            return analyzer;
        }
    }
}
