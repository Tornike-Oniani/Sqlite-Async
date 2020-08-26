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
        private List<Author> _authors;

        // Public properties
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("Title"); }
        }
        public string Authors
        {
            get
            {
                return string.Join(", ", _authors.Select(cur => cur.Name));
            }
        }

        // Constructor
        public Book(string title)
        {
            this.Title = title;
            _authors = new List<Author>();
        }

        // Public methods
        public void AddAuthors(List<Author> authors)
        {
            this._authors.Clear();
            foreach (Author author in authors)
                this._authors.Add(author);
        }

    }
}
