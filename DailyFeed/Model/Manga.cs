using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DailyFeed.Services;

namespace DailyFeed.Model
{
    class Manga : INotifyPropertyChanged
    {
        private const string url = "https://mangastream.com/rss";
        private string MangaName { get; set; }
        private string MangaLink { get; set; }
        private string PubDate { get; set; }
        private string ChapterDesc { get; set; }
        // publicly currDegrees, privately CurrentDegrees
        public string mangaName
        {
            get
            {
                return MangaName;
            }
            set
            {
                MangaName = value;
                OnPropertyChanged("mangaName");
            }
        }

        // publicly currDesc, privately CurrentDesc
        public string mangaLink
        {
            get
            {
                return MangaLink;
            }
            set
            {
                MangaLink = value;
                OnPropertyChanged("mangaLink");
            }
        }

        // publicly currLocation, privately CurrentLocation
        public string pubDate
        {
            get
            {
                return PubDate;
            }
            set
            {
                PubDate = value;
                OnPropertyChanged("pubDate");
            }
        }

        public string chapterDesc
        {
            get
            {
                return ChapterDesc;
            }
            set
            {
                ChapterDesc = value;
                OnPropertyChanged("chapterDesc");
            }
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


        //Update stuff
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        private class Updater : ICommand
        {
            #region ICommand Members
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
            }
            #endregion
        }

        public static ObservableCollection<Manga> fetchMangaList()
        {

            MangaParseXML parser = new MangaParseXML();
            try
            {
                parser.GetFormattedXml(url);
            }
            catch (Exception e)
            {
                return null;
            }
            ObservableCollection<Manga> test = new ObservableCollection<Manga>();
            test = parser.parseMangaXMLDoc();
            return test;
        }


    }
}