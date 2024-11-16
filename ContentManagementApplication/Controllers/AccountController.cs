using ContentManagementApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;


namespace ContentManagementApplication.Controllers
{
    public class AccountController : ControllerBase
    {
        private IUserRepository userRepository;
        public AccountController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
    }
}
