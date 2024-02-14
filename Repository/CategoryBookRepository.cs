using DataAccess;
using ObjectBusiness;

namespace Repository
{
    public class CategoryBookRepository : ICategoryBookRepository
    {
        public bool DeleteCategory(int id) => CategoryBookDAO.Instance.DeleteCategory(id);

        public IEnumerable<CategoryBook> GetCategories() => CategoryBookDAO.Instance.GetCategories();

        public CategoryBook GetCategoryById(int id) => CategoryBookDAO.Instance.GetCategoryById(id);

        public bool InsertCategory(CategoryBook category) => CategoryBookDAO.Instance.InsertCategory(category);

        public bool UpdateCategory(CategoryBook category) => CategoryBookDAO.Instance.UpdateCategory(category);
    }
}
