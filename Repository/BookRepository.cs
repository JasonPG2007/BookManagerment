using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository : IBookRepository
    {
        public bool DeleteBook(int id) => BookDAO.Instance.DeleteBook(id);

        public Book GetBookById(int id) => BookDAO.Instance.GetBookById(id);

        public IEnumerable<Book> GetBooks() => BookDAO.Instance.GetBooks();

        public bool InsertBook(Book book) => BookDAO.Instance.InsertBook(book);

        public bool UpdateBook(Book book) => BookDAO.Instance.UpdateBook(book);
    }
}
