using ObjectBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EventCategoryDAO
    {
        private static EventCategoryDAO instance = null;
        private static readonly object Lock = new object();
        public static EventCategoryDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new EventCategoryDAO();
                    }
                    return instance;
                }
            }
        }

        #region GetEventCategory function
        public IEnumerable<EventCategory> GetEventCategory()
        {
            using var context = new BookContext();
            var list = context.EventCategories.ToList();
            return list;
        }
        #endregion

        #region GetEventCategoryById
        public EventCategory GetEventCategoryById(int id)
        {
            using var context = new BookContext();
            var category = context.EventCategories.FirstOrDefault(e => e.CategoryId == id);
            return category;
        }
        #endregion

        #region InsertCategory fuction
        public bool InsertCategory(EventCategory category)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                context.EventCategories.Add(category);
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
        #endregion

        #region UpdateCategory function
        public bool UpdateCategory(EventCategory category)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                var checkContains = GetEventCategoryById(category.CategoryId);
                if (checkContains != null)
                {
                    context.Entry<EventCategory>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
        #endregion

        #region DeleteCategory function
        public bool DeleteCategory(int id)
        {
            bool status = false;
            using var context = new BookContext();
            try
            {
                var checkContains = GetEventCategoryById(id);
                if (checkContains != null)
                {
                    context.EventCategories.Remove(checkContains);
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
