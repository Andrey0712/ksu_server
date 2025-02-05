using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebKsu.Constants;
using WebKsu.Data;
using WebKsu.Data.Entities.Identity;
using WebKsu.Model;
using WebKsu.Servise;

namespace WebKsu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppEFContext _context;
        private IHostEnvironment _host;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<AppUser> userManeger, SignInManager<AppUser> signInManager,
            AppEFContext context, IMapper mapper, IJwtTokenService jwtTokenService, IHostEnvironment host,
            ILogger<AccountController> logger, RoleManager<AppRole> roleManager)
        {
            _userManager = userManeger;
            _signInManager = signInManager;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
            _context = context;
            _host = host;
            _logger = logger;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Реєстрація юзера
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає токен авторизації</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Register user</response>
        /// <response code="400">Register has missing/invalid values</response>
        /// <response code="500">Oops! Can't Register right now</response>

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            //string fileName = String.Empty;
            var rez = _roleManager.CreateAsync(new AppRole
            {
                Name = Roles.User
            }).Result;
            var user = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                result = _userManager.AddToRoleAsync(user, Roles.User).Result;
            }

            if (!result.Succeeded)
                return BadRequest(new { errors = result.Errors });


            return Ok(new { token = _jwtTokenService.CreateToken(user) });


        }

        /// <summary>
        /// Лист юзерів
        /// </summary>
        /// <returns>Повертає list</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">List users</response>
        /// <response code="400">List users has missing/invalid values</response>
        /// <response code="500">Oops! Can't get  users list right now</response>

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Users()
        {
            //Thread.Sleep(2000);
            var list = await _context.Users
                .Select(x => _mapper.Map<UserItemViewModel>(x))
                .AsQueryable().ToListAsync();

            return Ok(list);
        }

        /// <summary>
        /// Вхід на сайт
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає токен авторизації</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Login user</response>
        /// <response code="400">Login has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your login right now</response>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponceViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Login([FromBody] LoginUserModel model)
        {
            _logger.LogInformation("Login user");
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                //throw new AppException("Bad login user");
                if (await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    return Ok(new TokenResponceViewModel { token = _jwtTokenService.CreateToken(user) });
                }
            }
            return BadRequest(new { error = "Користувача не знайдено" });
        }

        /// <summary>
        /// Видалення юзера
        /// </summary>
        /// <param name="id">Понель із даними</param>
        /// <returns>Повертає message</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Delete user</response>
        /// <response code="400">Delete user has missing/invalid values</response>
        /// <response code="500">Oops! Can't delete user now</response>

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [Route("delete")]

        public IActionResult Delete([FromBody] int id)
        {
            
            var res = _context.Users.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                return BadRequest(new { message = "Check id!" });
            }

            _context.Users.Remove(res);
            _context.SaveChanges();
            return Ok(new { message = "User deleted" });
        }

        /// <summary>
        /// Редагування юзера
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає токен авторизації</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Edit user</response>
        /// <response code="400">Edit user has missing/invalid values</response>
        /// <response code="500">Oops! Can't edit user now</response>
        /// 

        [Authorize(Roles = Roles.User)]
        //[Authorize]
        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditUser([FromForm] UserEditViewModel model)

        {
            try
            {
                string userName = User.Claims.FirstOrDefault().Value;
                var res = await _userManager.FindByNameAsync(userName);
                //var res = _context.Users.FirstOrDefault(x => x.Id == model.Id);

                if (model == null)
                {
                    return BadRequest(new { message = "Не зашла инфа" });
                }
                if (model.Email != null)
                {
                    res.Email = model.Email;
                    res.UserName = model.Email;
                }
                if (model.Phone != null)
                {
                    res.Phone = model.Phone;
                }

                if (model.Owner != null)
                {
                    res.Owner = model.Owner;
                }

                if (model.Address != null)
                {
                    res.Address = model.Address;
                }

                _context.SaveChanges();

                return Ok(new TokenResponceViewModel { token = _jwtTokenService.CreateToken(res) });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    invalid = ex.Message
                });
            }
        }

        /// <summary>
        /// Редагування юзера адміном
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає токен авторизації</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Edit user</response>
        /// <response code="400">Edit user has missing/invalid values</response>
        /// <response code="500">Oops! Can't edit user now</response>
        /// 
        [Authorize(Roles = Roles.Admin)]
        //[Authorize]
        [HttpPost]
        [Route("editUserAdmin")]
        public async Task<IActionResult> EditUserAdmin([FromForm] UserEditViewModel model)

        {
            try
            {
               
                var res = _context.Users.FirstOrDefault(x => x.Id == model.Id);

                if (model == null)
                {
                    return BadRequest(new { message = "Не зашла инфа" });
                }
                if (model.Email != null)
                {
                    res.Email = model.Email;
                    res.UserName = model.Email;
                }
                if (model.Phone != null)
                {
                    res.Phone = model.Phone;
                }

                if (model.Owner != null)
                {
                    res.Owner = model.Owner;
                }

                if (model.Address != null)
                {
                    res.Address = model.Address;
                }

                _context.SaveChanges();

                return Ok(new TokenResponceViewModel { token = _jwtTokenService.CreateToken(res) });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    invalid = ex.Message
                });
            }
        }

    }
}
