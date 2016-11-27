using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }


        public void SaveBook(User user)
        {
            if (user.ID == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users.Find(user.ID);
                if (dbEntry != null)
                {
                    dbEntry.UserName = user.UserName;
                    dbEntry.DepartmentName = user.DepartmentName;
                }
            }
            context.SaveChanges();
        }

        public User DeleteUser(int userId)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
