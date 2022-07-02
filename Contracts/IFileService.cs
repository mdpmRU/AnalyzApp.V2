using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Entities;

namespace Contracts
{
    public interface IFileService
    {
        List<Analyzer> Open(string filename);
        void Save(string filename, List<Analyzer> analyzersList);
    }
}
