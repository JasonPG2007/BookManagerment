using ObjectBusiness;
using System.Net.NetworkInformation;

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
        public bool InsertCategory(CategoryBook category)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                context.CategoryBooks.Add(category);
                int isSuccessfully = context.SaveChanges();
                if (isSuccessfully > 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        public bool UpdateCategory(CategoryBook category)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetCategoryById(category.CategoryId);
            if (checkContains != null)
            {
                try
                {
                    context.Entry<CategoryBook>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    int isSuccessfully = context.SaveChanges();
                    if (isSuccessfully > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return status;
        }
        public bool DeleteCategory(int id)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetCategoryById(id);
            if (checkContains != null)
            {
                try
                {
                    context.CategoryBooks.Remove(checkContains);
                    int isSuccessfully = context.SaveChanges();
                    if (isSuccessfully > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return status;
        }
    }
}
