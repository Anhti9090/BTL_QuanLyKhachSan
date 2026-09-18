using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
namespace API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [Route("get-all-users")]
        [HttpGet]
        public List<User> GetAll()
        {
            return _userBusiness.GetAllUsers();
        }

        [Route("create-user")]
        [HttpPost]
        public User CreateUser([FromBody] User thongtin)
        {
            thongtin.User_Id = Guid.NewGuid().ToString();
            _userBusiness.Create(thongtin);
            return thongtin;
        }
    }
}
