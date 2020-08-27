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
        public void SaveBook(Book book)
        {
            using (SQLiteConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Open();
                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    List<int> authorIds = new List<int>();

                    // 1. Add book
                    conn.Execute("INSERT INTO tblBooks (Title) VALUES(@Title);", new { }, transaction: transaction);
                    int id = (int)conn.LastInsertRowId;

                    // 2. Add authors
                    (book.Authors.Split(new string[] { ", " }, StringSplitOptions.None).ToList()).ForEach((author) =>
                     {
                         int authorId = conn.QuerySingleOrDefault<int>("SELECT Id FROM tblAuthors WHERE Name=@Name;",
                             new { Name = author }, transaction: transaction);

                        // If author does not exist add
                        if (authorId == 0)
                        {
                             conn.Execute("INSERT INTO tblAuthors (Name) VALUES(@Name);",
                                 new { Name = author }, transaction: transaction);
                             authorId = (int)conn.LastInsertRowId;
                        }

                         authorIds.Add(authorId);
                     });

                    // 3. Bind relationships
                    authorIds.ForEach((cur) =>
                    {
                        conn.Execute("INSERT INTO jntBookAuthor (Book_Id, Author_Id) VALUES (@Book_Id, @Author_Id);",
                            new { Book_Id = id, Author_Id = cur }, transaction: transaction);
                    });

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
