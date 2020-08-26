using SqliteAsync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAsync.ViewModels
{
    public class InsertViewModel : Base
    {
        // Public properties
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
        public InsertViewModel()
        {

        }
    }
}
