using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class UserDao
    {
        private OnlineShopDbContext dbContext = null;

        public UserDao()
        {
            dbContext = new OnlineShopDbContext();
        }

        public long Insert(User entity)
        {
            dbContext.Users.Add(entity);
            dbContext.SaveChanges();
            return entity.ID;
        }

        public int Login(string username, string password)
        {
            var result = dbContext.Users.SingleOrDefault(x => x.UserName == username);
            if (result == null) return 0;
            else
            {
                if (result.Status == false) return -1;
                else
                {
                    if (result.Password == password)
                        return 1;
                    return -2;
                }
            }

        }

        public IEnumerable<User> GetListPaging(string searchString, int pages, int pageSize)
        {
            IQueryable<User> model = dbContext.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));

            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(pages, pageSize);
        }

        public User GetByUserName(string username)
        {
            return dbContext.Users.SingleOrDefault(x => x.UserName == username);
        }

        public bool Update(User entity)
        {
            try
            {
                var user = dbContext.Users.Find(entity.ID);
                user.Name = entity.UserName;
                user.Email = entity.Email;
                user.Address = entity.Address;
                user.Phone = entity.Phone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log
                return false;
            }

        }

        public User ViewDetail(int id)
        {
            return dbContext.Users.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var user = dbContext.Users.Find(id);
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
