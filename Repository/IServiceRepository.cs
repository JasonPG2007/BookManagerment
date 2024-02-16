using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IServiceRepository
    {
        public IEnumerable<Service> GetServices();
        public Service GetServiceById(int id);
        public bool InsertService(Service service);
        public bool UpdateService(Service service);
        public bool DeleteService(int id);
    }
}
