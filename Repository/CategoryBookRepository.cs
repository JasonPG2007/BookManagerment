using DataAccess;
using ObjectBusiness;

namespace Repository
{
    public class CategoryBookRepository : ICategoryBookRepository
    {
        public IEnumerable<CategoryBook> GetCategories() => CategoryBookDAO.Instance.GetCategories();
    }
}
