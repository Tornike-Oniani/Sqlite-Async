using SqliteAsync.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteAsync.ViewModels
{
    public class ViewViewModel : Base
    {
        // Public properties
        public ObservableCollection<Book> Books { get; set; }


        // Constructor
        public ViewViewModel()
        {
            this.Books = new ObservableCollection<Book>();
        }
    }
}
