using Microsoft.EntityFrameworkCore;

namespace getting_registrations_user1.Models.DAL
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;

        public DataService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<string>> GetRegistrationsUsers()
        {
            var users = await _dbContext.User.Select(x => x.Email).ToListAsync();

            List<string> result = new List<string>();

            foreach (var item in users)
            {
                result.Add(item);
            }

            return result;
        }
    }
}
