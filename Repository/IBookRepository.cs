using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBookById(int id);
        public bool InsertBook(Book book);
        public bool UpdateBook(Book book);
        public bool DeleteBook(int id);
    }
}
