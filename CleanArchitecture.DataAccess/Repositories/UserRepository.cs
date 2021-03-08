using CleanArchitecture.Domain;

namespace CleanArchitecture.DataAccess.Repositories
{
    public class UserRepository: Repository<User>
    {
        public UserRepository(CleanArchitectureDbContext dbContext) : base(dbContext, dbContext.User)
        {

        }
    }
}
