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
            var xdoc = new XDocument();
            var root = new XElement("Analyzers");
            foreach (Analyzer item in analyzers)
            {
                var analyzerEL = new XElement("Analyzer");
                analyzerEL.Add(new XAttribute("Name", item.Name));
                analyzerEL.Add(new XAttribute("Type", item.Type));
                analyzerEL.Add(new XAttribute("MeasureInterval", item.MeasureInterval));
                foreach (var itemCh in item.Channels)
                {
                    var channelEL = new XElement("Channel");
                    channelEL.Add(new XAttribute("Name", itemCh.Name));
                    channelEL.Add(new XAttribute("IsHot", itemCh.IsHot));
                    analyzerEL.Add(channelEL);
                }
                root.Add(analyzerEL);
            }
            xdoc.Add(root);
            xdoc.Save(filename);
        }
    }
}
