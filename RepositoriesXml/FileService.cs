using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataContracts.Models;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;

namespace RepositoriesXml
{
    public class FileService : IFileService
    {
        public List<Analyzer> Open(string filename)
        {
            var analyzers = new List<Analyzer>();//объявление коллекций
            var doc = XDocument.Load(filename);//Загружаем
            var root = doc.Element("Analyzers");
            foreach (XElement analyzer in root.Elements("Analyzer"))
            {
                var aName = analyzer.Attribute("Name");
                var type = analyzer.Attribute("Type");
                var measureInterval = analyzer.Attribute("MeasureInterval");
                ObservableCollection<Channel> channels = new ObservableCollection<Channel>();
                foreach (var channel in analyzer.Elements("Channel"))
                {
                    var cName = channel.Attribute("Name");
                    var isHot = channel.Attribute("IsHot");
                    channels.Add(new Channel { Name = cName.Value, IsHot = Int32.Parse(isHot.Value) });
                }
                analyzers.Add(new Analyzer { Name = aName.Value, Type = type.Value, MeasureInterval = Int32.Parse(measureInterval.Value), Channels = channels });
            }


            return analyzers;
        }

        public void Save(string filename, List<Analyzer> analyzers)
        {
            var xDocument = new XDocument();
            var root = new XElement("Analyzers");
            foreach (Analyzer item in analyzers)
            {
                var analyzerEl = new XElement("Analyzer");
                analyzerEl.Add(new XAttribute("Name", item.Name));
                analyzerEl.Add(new XAttribute("Type", item.Type));
                analyzerEl.Add(new XAttribute("MeasureInterval", item.MeasureInterval));
                foreach (var itemCh in item.Channels)
                {
                    var channelEl = new XElement("Channel");
                    channelEl.Add(new XAttribute("Name", itemCh.Name));
                    channelEl.Add(new XAttribute("IsHot", itemCh.IsHot));
                    analyzerEl.Add(channelEl);
                }
                root.Add(analyzerEl);
            }
            xDocument.Add(root);
            xDocument.Save(filename);
        }
    }
}
