using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ServiceDAO
    {
        private static ServiceDAO instance = null;
        private static readonly object Lock = new object();
        public static ServiceDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceDAO();
                    }
                    return instance;
                }
            }
        }

        #region GetServices function
        public IEnumerable<Service> GetServices()
        {
            using var context = new BookContext();
            var list = context.Services.ToList();
            return list;
        }
        #endregion

        #region GetServiceById function
        public Service GetServiceById(int id)
        {
            using var context = new BookContext();
            var service = context.Services.FirstOrDefault(s => s.ServiceId == id);
            return service;
        }
        #endregion

        #region InsertService function
        public bool InsertService(Service service)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                context.Add(service);
                int isSuccessfullt = context.SaveChanges();
                if (isSuccessfullt > 0)
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
        #endregion

        #region UpdateService function
        public bool UpdateService(Service service)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetServiceById(service.ServiceId);
            try
            {
                if (checkContains != null)
                {
                    context.Entry<Service>(service).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    int isSuccessfullt = context.SaveChanges();
                    if (isSuccessfullt > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        #endregion

        #region DeleteService function
        public bool DeleteService(int id)
        {
            bool status = false;
            using var context = new BookContext();
            var checkContains = GetServiceById(id);
            try
            {
                if (checkContains != null)
                {
                    context.Services.Remove(checkContains);
                    int isSuccessfullt = context.SaveChanges();
                    if (isSuccessfullt > 0)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        #endregion
    }
}
