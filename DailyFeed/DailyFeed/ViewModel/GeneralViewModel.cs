using DailyFeed.Model;
using DailyFeed.Services;
using DeskApp.ViewModel;
using RedditSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DailyFeed.ViewModel
{
    class GeneralViewModel : INotifyPropertyChanged //,ObservableCollection<RedditPost>
    {
        private Weather NowWeather;
        private ObservableCollection<Weather> WeatherList;
        private string MySubreddit;
        private RedditUser redditUser;
        private ObservableCollection<RedditPost> RedditPostList;
        private RedditParseXML parser = new RedditParseXML();
        private Visibility PostsView;
        private Visibility CommentsView;
        private Visibility BackButton;
        private ObservableCollection<RedditComment> CommentsList;
        private ObservableCollection<Manga> MangaList;
        private string ClickedMangaUrl;
        BooleanToVisibilityConverter converter;

        public GeneralViewModel()
        {
            converter = new BooleanToVisibilityConverter();
            backButton = Visibility.Hidden;
            commentsView = Visibility.Collapsed;
            NowWeather = new Weather();
            WeatherList = new ObservableCollection<Weather>();
            redditUser = new RedditUser();
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Username))
            {
                redditUser.username = Properties.Settings.Default.Username;
            }
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Password))
            {                
                redditUser.password = Properties.Settings.Default.Password;
            }            
            RedditPostList = new ObservableCollection<RedditPost>();
            CommentsList = new ObservableCollection<RedditComment>();
            MangaList = new ObservableCollection<Manga>();
            // Manga Fetch
            OnMangaListFetch();
            // Weather Fetch
            if (!String.IsNullOrEmpty(Properties.Settings.Default.FavLocation))
            {
                nowWeather.currLocation = Properties.Settings.Default.FavLocation;
                NowWeather.fetchCurrentWeather();
                ObservableCollection<Weather> temp_list = Weather.fetchWeatherForecast(NowWeather.currLocation);
                //WeatherList.Clear();
                foreach (Weather w in temp_list)
                {
                    Weather weather_item = new Weather();
                    weather_item.currDegrees = w.currDegrees;
                    weather_item.currDesc = w.currDesc;
                    weather_item.forecastTime = w.forecastTime;
                    WeatherList.Add(weather_item);
                }

            }
            // Reddit Fetch
            if (!String.IsNullOrEmpty(Properties.Settings.Default.LastSubreddit))
            {
                MySubreddit = Properties.Settings.Default.LastSubreddit;
                /*PrivRedditPostList = parser.getRedditPosts(MySubreddit);
                foreach(var post in PrivRedditPostList)
                {
                    Console.WriteLine("Post title: "+ post.Title);
                    RedditSharp.Things.Comment[] arr  = post.Comments;
                    foreach (RedditSharp.Things.Comment com in arr)
                    {
                        Console.WriteLine("Created: "+ com.Created.ToString() + "\nBody: "+ com.Body);
                    }
                    Console.WriteLine("------------------------");
                }
                */
                ObservableCollection<RedditPost> temp_posts = RedditPost.fetchRedditPosts(MySubreddit);
                RedditPostList.Clear();
                foreach (RedditPost rp in temp_posts)
                {
                    RedditPost new_redditpost = new RedditPost();
                    new_redditpost.title = rp.title;
                    new_redditpost.author = rp.author;
                    new_redditpost.showThumbnail = rp.showThumbnail;
                    new_redditpost.commentsUrl = rp.commentsUrl;
                    new_redditpost.upVotes = rp.upVotes;
                    RedditPostList.Add(new_redditpost);
                }
            }
        }

        public Weather nowWeather
        {
            get { return NowWeather; }
            set { NowWeather = value; OnPropertyChanged("nowWeather"); }
        }

        public ObservableCollection<Weather> weatherList
        {
            get
            {
                if (WeatherList == null)
                {
                    WeatherList = new ObservableCollection<Weather>();
                }
                return WeatherList;
            }
            set
            {
                if (WeatherList == null)
                {
                    WeatherList = new ObservableCollection<Weather>();
                }
                foreach (Weather w in value)
                {
                    WeatherList.Add(w);
                }
                OnPropertyChanged("weatherList");
            }
        }


        public string mySubreddit
        {
            get { return MySubreddit; }
            set { MySubreddit = value; OnPropertyChanged("mySubreddit"); }
        }


        public ObservableCollection<RedditPost> redditPostList
        {
            get
            {
                if (RedditPostList == null)
                {
                    RedditPostList = new ObservableCollection<RedditPost>();
                }
                return RedditPostList;
            }
            set
            {
                if (RedditPostList == null)
                {
                    RedditPostList = new ObservableCollection<RedditPost>();
                }
                foreach (RedditPost rp in value)
                {
                    RedditPostList.Add(rp);
                }
                OnPropertyChanged("redditPostList");
            }
        }

        public ObservableCollection<RedditComment> commentsList
        {
            get
            {
                if (CommentsList == null)
                {
                    CommentsList = new ObservableCollection<RedditComment>();
                }
                return CommentsList;
            }
            set
            {
                if (CommentsList == null)
                {
                    CommentsList = new ObservableCollection<RedditComment>();
                }
                foreach (RedditComment rc in value)
                {
                    CommentsList.Add(rc);
                }
                OnPropertyChanged("commentsList");
            }
        }

        public ObservableCollection<Manga> mangaList
        {
            get
            {
                if (MangaList == null)
                {
                    MangaList = new ObservableCollection<Manga>();
                }
                return MangaList;
            }
            set
            {
                if (MangaList == null)
                {
                    MangaList = new ObservableCollection<Manga>();
                }
                foreach (Manga m in value)
                {
                    MangaList.Add(m);
                }
                OnPropertyChanged("mangaList");
            }
        }

        public string clickedMangaUrl
        {
            get { return ClickedMangaUrl; }
            set { ClickedMangaUrl = value; OnPropertyChanged("clickedMangaUrl"); }
        }

        public Visibility postsView
        {
            get { return PostsView; }
            set { PostsView = value; OnPropertyChanged("postsView"); }
        }

        public Visibility commentsView
        {
            get { return CommentsView; }
            set { CommentsView = value; OnPropertyChanged("commentsView"); }
        }
        public Visibility backButton
        {
            get { return BackButton; }
            set { BackButton = value; OnPropertyChanged("backButton"); }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private ICommand _getCurrWeatherClick;

        public ICommand GetCurrWeatherClick
        {
            get
            {
                if (_getCurrWeatherClick == null)
                {
                    _getCurrWeatherClick = new RelayCommand(
                        param => this.SaveObject(),
                        param => this.CanSave()
                    );
                }
                return _getCurrWeatherClick;
            }
        }

        private bool CanSave()
        {
            // Verify command can be executed here
            return true;
        }

        private void SaveObject()
        {
            // Save command execution logic
            Properties.Settings.Default.FavLocation = nowWeather.currLocation;
            Properties.Settings.Default.Save();
            NowWeather.fetchCurrentWeather();
            //Fetch forecast
            ObservableCollection<Weather> temp_list = Weather.fetchWeatherForecast(NowWeather.currLocation);
            //WeatherList.Clear();
            foreach (Weather w in temp_list)
            {
                Weather weather_item = new Weather();
                weather_item.currDegrees = w.currDegrees;
                weather_item.currDesc = w.currDesc;
                weather_item.forecastTime = w.forecastTime;
                WeatherList.Add(weather_item);
            }
        }


        private ICommand _getSubredditClick;

        public ICommand GetSubredditClick
        {
            get
            {
                if (_getSubredditClick == null)
                {
                    _getSubredditClick = new RelayCommand(
                        param => this.SaveRedditObject(),
                        param => this.RedditCanSave()
                    );
                }
                return _getSubredditClick;
            }
        }

        private bool RedditCanSave()
        {
            return true;
        }

        private void SaveRedditObject()
        {
            BackClick();
            // Save command execution logic
            Properties.Settings.Default.LastSubreddit = MySubreddit;
            Properties.Settings.Default.Save();
            //PrivRedditPostList = parser.getRedditPosts(MySubreddit);
            ObservableCollection<RedditPost> temp_list = RedditPost.fetchRedditPosts(MySubreddit);
            RedditPostList.Clear();
            foreach (RedditPost rp in temp_list)
            {
                RedditPost new_redditpost = new RedditPost(rp.title, rp.author, rp.thumbnail);
                new_redditpost.showThumbnail = rp.showThumbnail;
                new_redditpost.commentsUrl = rp.commentsUrl;
                new_redditpost.upVotes = rp.upVotes;
                RedditPostList.Add(new_redditpost);
            }
            //RedditPostList = temp_list;
        }


        private ICommand openRedditPost;

        public ICommand OpenRedditPost
        {
            get
            {
                if (openRedditPost == null)
                {
                    openRedditPost = new RelayCommand(
                        param => this.OnRedditPostClick(param)
                    );
                }
                return openRedditPost;
            }
        }

        //Gets called when user clicks a reddit post.
        public void OnRedditPostClick(object e)
        {
            backButton = Visibility.Visible;
            postsView = Visibility.Collapsed;
            commentsView = Visibility.Visible;

            string url = (e as string); 
            RedditParseXML parser = new RedditParseXML();
            try
            {
                parser.GetFormattedXml(url);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            ObservableCollection<RedditComment> temp_list = parser.parseCommentsXml();
            CommentsList.Clear();
            foreach (RedditComment rp in temp_list)
            {
                RedditComment new_redditcomment = new RedditComment();
                new_redditcomment.writer = rp.writer;
                new_redditcomment.content = rp.content;
                new_redditcomment.time = rp.time;
                CommentsList.Add(new_redditcomment);
            }
        }


        private ICommand _backButtonClick;

        public ICommand BackButtonClick
        {
            get
            {
                if (_backButtonClick == null)
                {
                    _backButtonClick = new RelayCommand(
                        param => this.BackClick()
                    );
                }
                return _backButtonClick;
            }
        }

        public void BackClick()
        {
            backButton = Visibility.Hidden;
            postsView = Visibility.Visible;
            commentsView = Visibility.Collapsed;
        }


        // Manga stuff  /////////////////////////
        private ICommand openMangaList;

        public ICommand OpenMangaList
        {
            get
            {
                if (openMangaList == null)
                {
                    openMangaList = new RelayCommand(
                        param => this.OnMangaListFetch()
                    );
                }
                return openMangaList;
            }
        }

        //Gets called when user clicks a reddit post.
        public void OnMangaListFetch()
        {

            ObservableCollection<Manga> temp_list = Manga.fetchMangaList();
            MangaList.Clear();
            foreach (Manga m in temp_list)
            {
                Manga new_manga = new Manga();
                new_manga.mangaName = m.mangaName;
                new_manga.mangaLink = m.mangaLink;
                new_manga.pubDate = m.pubDate;
                new_manga.chapterDesc = m.chapterDesc;
                MangaList.Add(new_manga);
            }
        }

        private ICommand openMangaPage;

        public ICommand OpenMangaPage
        {
            get
            {
                if (openMangaPage == null)
                {
                    openMangaPage = new RelayCommand(
                        param => this.OnMangaClick(param)
                    );
                }
                return openMangaPage;
            }
        }

        //Gets called when user clicks a reddit post.
        public void OnMangaClick(object e)
        {
            string selectedMangaUrl = e as string;
            System.Diagnostics.Process.Start(selectedMangaUrl);
      
        }


    }

}