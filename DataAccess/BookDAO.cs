using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BookDAO
    {
        private static BookDAO instance = null;
        private static readonly object Lock = new object();
        public static BookDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new BookDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Book> GetBooks()
        {
            using var context = new BookContext();
            var list = context.Books.ToList();
            return list;
        }
        public Book GetBookById(int id)
        {
            using var context = new BookContext();
            var book = context.Books.FirstOrDefault(b => b.BookId == id);
            return book;
        }
        public void InsertBook(Book book)
        {
            using var context = new BookContext();
            try
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateBook(Book book)
        {
            using var context = new BookContext();
            try
            {
                var checkContains = GetBookById(book.BookId);
                if (checkContains != null)
                {
                    context.Entry<Book>(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteBook(int id)
        {
            using var context = new BookContext();
            try
            {
                var checkContains = GetBookById(id);
                if (checkContains != null)
                {
                    context.Books.Remove(checkContains);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
