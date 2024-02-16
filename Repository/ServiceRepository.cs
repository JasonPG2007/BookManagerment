using DataAccess;
using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ServiceRepository : IServiceRepository
    {
        public IEnumerable<Service> GetServices() => ServiceDAO.Instance.GetServices();
        public Service GetServiceById(int id) => ServiceDAO.Instance.GetServiceById(id);
        public bool InsertService(Service service) => ServiceDAO.Instance.InsertService(service);
        public bool UpdateService(Service service) => ServiceDAO.Instance.UpdateService(service);
        public bool DeleteService(int id) => ServiceDAO.Instance.DeleteService(id);
    }
}
