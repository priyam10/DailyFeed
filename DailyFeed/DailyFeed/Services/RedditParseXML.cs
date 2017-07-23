using DailyFeed.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Xml;
using RedditSharp;

namespace DailyFeed.Services
{
    class RedditParseXML
    {
        string html_string;
        private RedditSharp.Reddit reddit = new RedditSharp.Reddit("yungmula420", "juugo123");


        public void GetFormattedXml(string url)
        {
            try {
                // Create a web client.
                using (WebClient client = new WebClient())
                {
                    // Get the response string from the URL.
                    string html = client.DownloadString(url);

                    // Load the response into an XML document.
                    HtmlDocument html_document = new HtmlDocument();
                    html_document.LoadHtml(html);
                    this.html_string = html_document.DocumentNode.OuterHtml;
                    // Format the XML.
                    //using (StringWriter string_writer = new StringWriter())
                    //{
                    //    XmlTextWriter xml_text_writer = new XmlTextWriter(string_writer);
                    //    xml_text_writer.Formatting = Formatting.Indented;
                    //    xml_document.WriteTo(xml_text_writer);

                    //    // Return the result.
                    //    this.xml_string = string_writer.ToString();
                }
            }catch(Exception e)
            {
                Console.WriteLine("u wut m8");
            }

        }


        /*
        public IEnumerable<RedditSharp.Things.Post> getRedditPosts(string subname)
        {
            ObservableCollection<RedditPost> tempPost = new ObservableCollection<RedditPost>();
            var subreddit = reddit.GetSubreddit(subname);
            Listing<RedditSharp.Things.Post> hot_posts = subreddit.Hot;
            RedditSharp.Things.Post ps;
            
            subreddit.Subscribe();
            return hot_posts.Take(25);
           
        }
        */


        public ObservableCollection<RedditPost> parseXMLDoc(string subname)
        {
            //ObservableCollection<RedditPost> tempPost = new ObservableCollection<RedditPost>();
            //var subreddit = reddit.GetSubreddit(subname);
            //Listing<RedditSharp.Things.Post> hot_posts = subreddit.Hot;

            //subreddit.Subscribe();
            //foreach (var post in hot_posts.Take(25))
            //{
            //    RedditPost rp = new RedditPost();
            //    rp.upVotes = post.Upvotes.ToString();
            //    TimeSpan t = post.TimeSinceFetch;
            //    string author_string;
            //    if(t.TotalDays > 30)
            //    {
            //        author_string = "Submitted " + Math.Floor(t.TotalDays/30).ToString() + " months ago by " + post.Author.Name;
            //    }
            //    if (t.TotalDays >= 1)
            //    {
            //        author_string = "Submitted " + Math.Floor(t.TotalDays).ToString() + " days ago by " + post.Author.Name;
            //    }
            //    if (t.TotalHours >= 1)
            //    {
            //        author_string = "Submitted " + Math.Round(t.TotalHours).ToString() + " days ago by " + post.Author.Name;
            //    }
            //    else
            //    {
            //        author_string = "Submitted " + Math.Round(t.TotalMinutes).ToString() + " minutes ago by " + post.Author.Name;
            //    }
            //    if(post.Thumbnail != null)
            //    {
            //        rp.thumbnail = post.Thumbnail.ToString();
            //        rp.showThumbnail = "Visible";
            //    }
            //    else
            //    {
            //        rp.showThumbnail = "Collapsed";
            //    }
            //    rp.title = post.Title;
            //    rp.author = author_string;
            //    tempPost.Add(rp);
            //}
            //return tempPost;


            ObservableCollection<RedditPost> tempPost = new ObservableCollection<RedditPost>();
            HtmlDocument doc = new HtmlDocument();
            HtmlNodeCollection nodelist;
            try
            {
                doc.LoadHtml(html_string);
                nodelist = doc.DocumentNode.SelectNodes("//entry");
            }
            catch (Exception ex)
            {
                return null;
            }


            foreach (HtmlNode node in nodelist)
            {
                try
                {
                    string author = node.SelectSingleNode("author//name").InnerText;
                    string title = node.SelectSingleNode("title").InnerText;
                    if (title.Contains("&quot;") || title.Contains(""))
                    {
                        title = title.Replace("&quot;", "\"");
                    }
                    string time = node.SelectSingleNode("updated").InnerText;
                    string comments = node.SelectSingleNode("link").OuterHtml;
                    RedditPost reddit_entry = new RedditPost();
                    reddit_entry.title = title;
                    if (author.Contains("/u/"))
                    {
                        author = author.Substring(3);
                    }
                    var regex = new Regex(Regex.Escape("T"));
                    string parsedTime = regex.Replace(time, " ", 1);
                    DateTime writeTime = DateTime.ParseExact(parsedTime.Substring(0, parsedTime.Length - 6), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    writeTime.AddHours(3.0);
                    reddit_entry.author = "Submitted " + calcTime(writeTime) + " by " + author;
                    string[] url_parse = comments.Split('"');
                    comments = url_parse[1];
                    reddit_entry.commentsUrl = comments + ".rss";

                    reddit_entry.showThumbnail = "Collapsed";
                    string img_node = node.SelectSingleNode("content").InnerHtml;
                    if (!String.IsNullOrEmpty(img_node) && img_node.Contains("img src"))
                    {
                        int start_thumb = img_node.IndexOf("img src=&quot;") + 14;
                        int end_thumb = img_node.IndexOf(".jpg", start_thumb);
                        if (start_thumb != -1 && end_thumb != -1)
                        {
                            string thumb_url = img_node.Substring(start_thumb, end_thumb - start_thumb + 4);
                            reddit_entry.thumbnail = thumb_url;
                            //Console.WriteLine("title: " + title + "thumb: " + thumb_url);
                            reddit_entry.showThumbnail = "Visible";
                        }

                    }

                    tempPost.Add(reddit_entry);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }

            }

            return tempPost;
        }


        public ObservableCollection<RedditComment> parseCommentsXml()
        {
            ObservableCollection<RedditComment> tempComment = new ObservableCollection<RedditComment>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html_string);
            DateTime currTime = DateTime.Now;
            HtmlNodeCollection nodelist = doc.DocumentNode.SelectNodes("//entry");

            foreach (HtmlNode node in nodelist)
            {
                //Regex for extracting all urls from content tag
                //var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                //var rawString = node.ChildNodes.Item(2).InnerText;
                //foreach (Match m in linkParser.Matches(rawString))
                //{
                //    MessageBox.Show(m.Value);
                //}


                try
                {
                    string writer = node.SelectSingleNode("author//name") == null? null : node.SelectSingleNode("author//name").InnerText;
                    string content = node.SelectSingleNode("content").InnerHtml;
                    //content = content.Replace("&lt;", "");
                    //content = content.Replace("&gt;", "");
                    //content = content.Replace("p&gt;", "");
                    //content = content.Replace("&quot;", "");
                    //content = Regex.Replace(content, "&.*?;", String.Empty);
                    //content = content.Replace("!-- SC_OFF --div class=mdp",String.Empty);
                    //content = content.Replace("/p /div!-- SC_ON --", String.Empty);
                    //content = content.Replace("#39;", "'");
                    content = WebUtility.HtmlDecode(content);
                    content = Regex.Replace(content, @"<[^>]+>|&nbsp;", "").Trim();
                    string time = node.SelectSingleNode("updated").InnerText;
                    RedditComment reddit_comment = new RedditComment();
                    if (writer != null && writer.Contains("/u/"))
                    {
                        writer = writer.Substring(3);
                    }
                    reddit_comment.writer = writer;
                    reddit_comment.content = content;
                    //string date_time = time.Split(T);
                    var regex = new Regex(Regex.Escape("T"));
                    string parsedTime = regex.Replace(time, " ", 1);                    
                    DateTime writeTime = DateTime.ParseExact(parsedTime.Substring(0, parsedTime.Length - 6), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    writeTime.AddHours(3.0);
                    time = calcTime(writeTime);
                    /*int hours = (currTime - writeTime).Hours;
                    if (hours >= 24)
                    {
                        time = (currTime - writeTime).Days.ToString() + " days ago";
                    }
                    else
                    {
                        time = (currTime - writeTime).Hours.ToString() + " hours ago";
                    }
                    */
                    reddit_comment.time = time;
                    tempComment.Add(reddit_comment);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return tempComment;
        }

        private string parseTime(string time)
        {
            DateTime currTime = DateTime.Now;
            string output;
            var regex = new Regex(Regex.Escape("T"));
            string parsedTime = regex.Replace(time, " ", 1);
            DateTime writeTime = DateTime.ParseExact(parsedTime.Substring(0, parsedTime.Length - 6), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            int hours = (currTime - writeTime).Hours;
            if (hours >= 24)
            {
                output = (currTime - writeTime).Days.ToString() + " days ago";
            }
            else
            {
                output = (currTime - writeTime).Hours.ToString() + " hours ago";
            }
            return output;
        }

        public static string calcTime(DateTime yourDate)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - yourDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }
    }
}
