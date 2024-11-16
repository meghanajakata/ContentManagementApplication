using ContentManagementApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementApplication.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context context;
        public UserRepository(Context _context) 
        {
            this.context = _context;
        }
    }
}
