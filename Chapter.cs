using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _2016NovelBase
{

    sealed class Chapter
    {
        public string backgroundGraphPath;
        public List<INodeType> story;

        public Chapter(string filename)
        {
            var reader = new XmlDocument();
            reader.Load(filename);
            var chapter = reader.DocumentElement as XmlElement;
            backgroundGraphPath = chapter.GetAttribute("background");
            story = readXml(chapter.ChildNodes);
        }

        private List<INodeType> readXml(XmlNodeList list)
        {
            var result = new List<INodeType>();
            foreach (XmlElement node in list)
            {
                switch (node.Name)
                {
                    case "paragraph":
                        var para = new Paragraph();
                        para.speaker = node.GetAttribute("speaker");
                        para.text = node.InnerText;
                        result.Add(para);
                        break;
                    case "options":
                        var options = new Options();
                        foreach (XmlElement e in node.ChildNodes)
                        {
                            var item = new Item();
                            item.value = e.GetAttribute("value");
                            item.story = readXml(e.ChildNodes);
                            options.items.Add(item);
                        }
                        result.Add(options);
                        break;
                    case "load":
                        var load = new Load();
                        load.filename = node.GetAttribute("from");
                        result.Add(load);
                        break;
                }
            }
            return result;
        }

        public interface INodeType { }

        public class Paragraph : INodeType
        {
            public string speaker;
            public string text;
        }
        public class Load : INodeType { public string filename; }
        public class Options : INodeType { public List<Item> items = new List<Item>(); }
        public class Item : INodeType
        {
            public string value;
            public List<INodeType> story;
        }
    }
}
