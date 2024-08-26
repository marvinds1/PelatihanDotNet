using Persistence.Dtos;
using Persistence.Dtos.Auth;
using Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Authorize]
    public class AuthController : BaseController
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        [Route("AddRoleToUser")]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _authService.AddRoleToUserAsync(model);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await _authService.CreateRole(model);
            if (!response.Succeeded) return BadRequest(response);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _authService.Login(model);
            if (!result.Success) return Unauthorized();

            var response = new MainResponse
            {
                Content = new AuthenticationResponse
                {
                    RefreshToken = result.RefreshToken,
                    AccessToken = result.AccessToken
                },
                IsSuccess = true,
                ErrorMessage = ""
            };

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var response = new MainResponse();

            if (refreshTokenRequest is null)
            {
                response.ErrorMessage = "Permintaan Invalid";
                response.IsSuccess = false;

                return BadRequest(response);
            }

            var refreshToken = await _authService.RefreshToken(refreshTokenRequest);

            if (!refreshToken.Success)
            {
                response.IsSuccess = false;
                return BadRequest(response);
            }

            response.IsSuccess = true;
            response.Content = new AuthenticationResponse
            {
                RefreshToken = refreshToken.RefreshToken,
                AccessToken = refreshToken.AccessToken,
                Success = true
            };

            return Ok(response);
        }
    }
}
