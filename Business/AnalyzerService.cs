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
                ApproveStatusA(analyzer);
                //if (analyzer.StatusA == null)
                //{
                    
                //}
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


                //if (channel.StatusC == StatusChannel.Warning)
                //{
                //    analyzer.StatusA = StatusAnalyzer.Warning;
                //}
                //else
                //{

                //}
                //switch (channel.StatusC)
                //{
                //    case StatusChannel.Warning:
                //        analyzer.StatusA = StatusAnalyzer.Warning;
                //        break;
                //    case StatusChannel.Normal:
                //        analyzer.StatusA = StatusAnalyzer.Active;
                //        break;
                //    default:
                //        analyzer.StatusA = StatusAnalyzer.Locked;
                //        break;
                //}

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

        //private Channel ApproveStatusC(Channel channel)
        //{
        //    switch ()
        //    {
                
        //    }
        //}
    }
}