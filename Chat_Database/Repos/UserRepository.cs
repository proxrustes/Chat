using Chat_Database.Models;

namespace Chat_Database.Repositories
{
    public class UserRepository : GenericRerository<UserEntity>
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

    }
}
