using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyFeed.Model
{
    class RedditUser : INotifyPropertyChanged
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public string username
        {
            get { return Username; }
            set { Username = value; OnPropertyChanged("username"); }
        }

        public string password
        {
            get { return Password; }
            set { Password = value; OnPropertyChanged("password"); }
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
