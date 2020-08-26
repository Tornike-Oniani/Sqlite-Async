using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAsync.Models
{
    public class Author : Base
    {
        // Private members
        private string _name;

        // Public properties
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        // Constructor
        public Author(string name)
        {
            this.Name = name;
        }

    }
}
