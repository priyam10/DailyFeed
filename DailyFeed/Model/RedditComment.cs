using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyFeed.Model
{

    public class RedditComment : INotifyPropertyChanged
    {
        private string Content { get; set; }
        private string Writer { get; set; }
        private string Avatar { get; set; }
        private string Time { get; set; }

        public string content
        {
            get { return Content; }
            set { Content = value; OnPropertyChanged("content"); }
        }

        public string writer
        {
            get { return Writer; }
            set { Writer = value; OnPropertyChanged("writer"); }
        }

        public string avatar
        {
            get { return Avatar; }
            set { Avatar = value; OnPropertyChanged("avatar"); }
        }

        public string time
        {
            get { return Time; }
            set { Time = value; OnPropertyChanged("time"); }
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

    }
}
