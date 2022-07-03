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
    public class AnalyzerService : StatusService, IMediator
    {
        private IFileService _fileService;
        public AnalyzerService(IFileService fileService)
        {
            this._fileService = fileService;
        }
        public List<Analyzer> Open(string filename)
        {
           return CheckStatus(_fileService.Open(filename));
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
