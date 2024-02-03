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
        public void InsertBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(int id);
    }
}
