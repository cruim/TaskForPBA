using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        void SaveBook(User user);
        User DeleteUser(int userId);
    }
}
