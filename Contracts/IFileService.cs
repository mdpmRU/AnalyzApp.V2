using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContracts.Models;

namespace Contracts
{
    public interface IFileService
    {
        public List<Analyzer> Open(string filename);
        public void Save(string filename, List<Analyzer> analyzersList);
    }
}
