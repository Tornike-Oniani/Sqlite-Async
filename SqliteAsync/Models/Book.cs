using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAsync.Models
{
    public class Book : Base
    {
        // Private members
        private string _title;
        private string _authors;

        // Public properties
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("Title"); }
        }
        public string Authors
        {
            get { return _authors; }
            set { _authors = value; OnPropertyChanged("Authors"); }
        }

        // Constructor
        public Book(string title, string authors)
        {
            this.Title = title;
            this.Authors = authors;
        }

    }
}
