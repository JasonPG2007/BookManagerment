using ObjectBusiness;

namespace DataAccess
{
    public class CategoryBookDAO
    {
        private static CategoryBookDAO instance = null;
        private static readonly object Lock = new object();
        public static CategoryBookDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryBookDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<CategoryBook> GetCategories()
        {
            using var context = new BookContext();
            var list = context.CategoryBooks.ToList();
            return list;
        }
    }
}
