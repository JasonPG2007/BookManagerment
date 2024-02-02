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
        public CategoryBook GetCategoryById(int id)
        {
            using var context = new BookContext();
            var categoryBook = context.CategoryBooks.FirstOrDefault(c => c.CategoryId == id);
            return categoryBook;
        }
        public void InsertCategory(CategoryBook category)
        {
            using var context = new BookContext();
            try
            {
                context.CategoryBooks.Add(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateCategory(CategoryBook category)
        {
            using var context = new BookContext();
            var checkContains = GetCategoryById(category.CategoryId);
            if (checkContains != null)
            {
                try
                {
                    context.Entry<CategoryBook>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void DeleteCategory(int id)
        {
            using var context = new BookContext();
            var checkContains = GetCategoryById(id);
            if (checkContains != null)
            {
                try
                {
                    context.CategoryBooks.Remove(checkContains);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
