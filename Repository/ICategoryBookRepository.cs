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
    }
}
