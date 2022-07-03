using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Models.Enums;

namespace Business.Services
{
    public class AnalyzerService : StatusService
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
    }
}
