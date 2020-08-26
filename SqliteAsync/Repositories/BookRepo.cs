using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using SqliteAsync.Models;

namespace SqliteAsync.Repositories
{
    public class BookRepo : Base
    {
        public void AddBook(Book book)
        {
            using (SQLiteConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();
                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    // 1. Add book
                    conn.Execute("INSERT INTO tblBooks (Title) VALUES(@Title);", new { }, transaction: transaction);
                    int id = (int)conn.LastInsertRowId;

                    // 2. Add authors
                    book.Authors.Split(new string[] { ", "}, StringSplitOptions.None).ToList

                    // 3. Bind relationships

                    transaction.Commit();
                }
            }
        }

        public List<Book> GetBooks()
        {
            throw new NotImplementedException("Getting books is not implemented");
        }
    }
}
