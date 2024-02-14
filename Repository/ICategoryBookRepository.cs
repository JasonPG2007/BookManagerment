using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICategoryBookRepository
    {
        public IEnumerable<CategoryBook> GetCategories();
        public CategoryBook GetCategoryById(int id);
        public bool InsertCategory(CategoryBook category);
        public bool UpdateCategory(CategoryBook category);
        public bool DeleteCategory(int id);
    }
}
