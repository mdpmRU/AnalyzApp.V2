using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Models.Enums;
using RepositoriesXml;
using Contracts;

namespace Business.Services
{
    public class AnalyzerService : StatusService
    {
        private IFileService _fileService;
        delegate List<Analyzer> StatusHandler (List<Analyzer> analyzers);

        private event StatusHandler StatusCheck;
        public AnalyzerService(IFileService fileService)
        {
            this._fileService = fileService;
        }
        public List<Analyzer> Open(string filename)
        {
            StatusCheck += CheckStatus;
            var list = StatusCheck(CheckStatus(_fileService.Open(filename)));
            return list;
        }

        public void Save(string filename, List<Analyzer> analyzers)
        {
            _fileService.Save(filename, analyzers);
        }

        private List<Analyzer> CheckStatus(List<Analyzer> list)
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
