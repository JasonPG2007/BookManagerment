using DataAccess;
using ObjectBusiness;

namespace Repository
{
    public class CategoryBookRepository : ICategoryBookRepository
    {
        public void DeleteCategory(int id) => CategoryBookDAO.Instance.DeleteCategory(id);

        public IEnumerable<CategoryBook> GetCategories() => CategoryBookDAO.Instance.GetCategories();

        public CategoryBook GetCategoryById(int id) => CategoryBookDAO.Instance.GetCategoryById(id);

        public void InsertCategory(CategoryBook category) => CategoryBookDAO.Instance.InsertCategory(category);

        public void UpdateCategory(CategoryBook category) => CategoryBookDAO.Instance.UpdateCategory(category);
    }
}
