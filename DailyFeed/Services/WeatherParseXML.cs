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
    class WeatherParseXML
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
    
        public Weather parseXMLDoc()
        {
            Weather tempWeather = new Weather();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(xml_string);
            XmlNodeList itemRefList = xml.GetElementsByTagName("temperature");
            Console.WriteLine("Temp value: " + itemRefList[0].Attributes["value"].Value);
            tempWeather.currDegrees = Math.Round(Double.Parse(itemRefList[0].Attributes["value"].Value)).ToString();
            XmlNodeList itemDescList = xml.GetElementsByTagName("weather");         
            Console.WriteLine("Description: " + itemDescList[0].Attributes["value"].Value);
            tempWeather.currDesc = itemDescList[0].Attributes["value"].Value;
            XmlNodeList itemPlaceList = xml.GetElementsByTagName("city");
            Console.WriteLine("City value: " + itemPlaceList[0].Attributes["name"].Value);
            tempWeather.currLocation = itemPlaceList[0].Attributes["name"].Value;

            return tempWeather;
        }

        public ObservableCollection<Weather> parseForecastXMLDoc()
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml_string);
            ObservableCollection<Weather> lvwTemps = new ObservableCollection<Weather>();
            // Loop throuh the time entries.
            string last_day = "";
            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {
                // Get the start date and time.
                XmlAttribute time_attr = time_node.Attributes["from"];
                DateTime start_time = DateTime.Parse(time_attr.Value);

                // Convert from UTC to local time.
                start_time = start_time.ToLocalTime();

                // Add 90 minutes to get to the middle of the interval.
                start_time += new TimeSpan(1, 30, 0);

                // Get weather description
                XmlNode desc_node = time_node.SelectSingleNode("symbol");
                XmlAttribute desc_attr = desc_node.Attributes["name"];

                // Get the temperature node.
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                XmlAttribute temp_attr = temp_node.Attributes["value"];
                float temp = 0;
                if (temp_attr != null)
                    temp = float.Parse(temp_attr.Value.ToString());

                Weather item = new Weather();
                if (start_time.DayOfWeek.ToString() == last_day)
                    item.forecastTime = "";
                else
                {
                    last_day = start_time.DayOfWeek.ToString();
                    item.forecastTime = last_day;
                }
                item.forecastTime = start_time.ToShortTimeString();
                item.currDegrees = temp.ToString("00") + " °F";
                item.currDesc = desc_attr.Value.ToUpper();
                lvwTemps.Add(item);
                //Console.WriteLine("Forecast Time: "+ item.forecastTime + "\nCurr degrees: "+ item.currDegrees + "\nDesc: "+ item.currDesc);
            }
            return lvwTemps;
        }
    }
}
