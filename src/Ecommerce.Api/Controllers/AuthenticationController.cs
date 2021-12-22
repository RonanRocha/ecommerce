using AutoMapper;
using Eccomerce.Domain.Entities;
using Ecommerce.Api.Builders;
using Ecommerce.Api.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenBuilder _tokenBuilder;
        private readonly IMapper _mapper;

        public AuthenticationController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenBuilder tokenBuilder,
            IMapper mapper
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenBuilder = tokenBuilder;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]

        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {

            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password,
                 isPersistent: false, lockoutOnFailure: false);

            if(!result.Succeeded)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            var token = _tokenBuilder.Build(user);

            return Ok(token);


        }


        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] LoginDto loginDto)
        {

            var user = new User { UserName = loginDto.Email, Email = loginDto.Email };
            var result = await _userManager.CreateAsync(user, loginDto.Password);
            if (result.Succeeded)
            {
                var token = _tokenBuilder.Build(user);
                return Ok(token);
            }
            else
            {
                return BadRequest("Usuário ou senha inválidos");
            }
        }


    }
}
