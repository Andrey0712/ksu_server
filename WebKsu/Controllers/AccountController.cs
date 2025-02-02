using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebKsu.Data.Entities.Identity;

namespace WebKsu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public AccountController(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager= userManager;
        }
    }
}
