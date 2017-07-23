using DailyFeed.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DailyFeed.Services
{
    class MangaParseXML
    {
        string xml_string;

        public void GetFormattedXml(string url)
        {
            // Create a web client.
            using (WebClient client = new WebClient())
            {
                // Get the response string from the URL.
                string xml = client.DownloadString(url);

                // Load the response into an XML document.
                XmlDocument xml_document = new XmlDocument();
                xml_document.LoadXml(xml);

                // Format the XML.
                using (StringWriter string_writer = new StringWriter())
                {
                    XmlTextWriter xml_text_writer = new XmlTextWriter(string_writer);
                    xml_text_writer.Formatting = Formatting.Indented;
                    xml_document.WriteTo(xml_text_writer);

                    // Return the result.
                    this.xml_string = string_writer.ToString();
                }
            }

        }

        public ObservableCollection<Manga> parseMangaXMLDoc()
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml_string);
            ObservableCollection<Manga> lvwTemps = new ObservableCollection<Manga>();
            XmlNodeList list = xml_doc.SelectNodes("//item");
            foreach (XmlNode item_node in list)
            {
                string mangaTitle = item_node.SelectSingleNode("title").InnerText;
                string mangaLink = item_node.SelectSingleNode("link").InnerText;
                string pubDate = item_node.SelectSingleNode("pubDate").InnerText;
                string[] time_arr = pubDate.Split(' ');
                pubDate = time_arr[0] + " " + time_arr[1] + " " + time_arr[2] + " " + time_arr[3];
                string chapterDesc = item_node.SelectSingleNode("description").InnerText;
                
                Manga item = new Manga();
                item.mangaName = mangaTitle;
                item.mangaLink = mangaLink;
                item.pubDate = pubDate;
                item.chapterDesc = chapterDesc;
                lvwTemps.Add(item);
               
            }
            return lvwTemps;
        }
    }
}
