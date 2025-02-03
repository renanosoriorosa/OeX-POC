using Asp.Versioning;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OeX.Auth.API.Extensions;
using OeX.Auth.API.Interfaces;
using OeX.Auth.Application.Notificacoes.Interfaces;
using OeX.Auth.Application.Usuarios.Dtos;
using OeX.Auth.Domain.Usuarios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OeX.Auth.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class AutenticacaoController : MainController
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly AppSettings _appSettings;
        private readonly AuthenticationService _authenticationService;
        private readonly ILogger _logger;

        public AutenticacaoController(SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager,
            AuthenticationService authenticationService,
            IOptions<AppSettings> appSettings,
            IOptions<AppTokenSettings> appTokenSettings,
            INotificador notificador,
            IUser user,
            ILogger<AutenticacaoController> logger) : base(notificador, user)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost(Name = "Registrar")]
        public async Task<ActionResult> Registrar(RegisterUserDto registerUser)
        {
            if (!ModelState.IsValid)
                return CustomResponse<bool>(ModelState);

            if (registerUser.ConfirmPassword != registerUser.Password)
                return SendBadRequest<bool>("As senhas não conferem.");

            var user = new Usuario(registerUser.Nome, registerUser.EmpresaId, registerUser.Email);

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            foreach (var error in result.Errors)
                NotificarErro(error.Description);

            return CustomResponse(registerUser);
        }

        [AllowAnonymous]
        [HttpPost(Name = "Login")]
        public async Task<ActionResult> Login(LoginUserDto loginUser)
        {
            if (!ModelState.IsValid)
                return CustomResponse<bool>(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuário " + loginUser.Email + " logado com sucesso");
                return CustomResponse(await GerarJWT(loginUser.Email));
            }

            if (result.IsLockedOut)
            {
                NotificarErro("O usuário foi bloqueado temporariamente");
                return CustomResponse<LoginResponseDto>();
            }

            NotificarErro("Usuário ou senha incorretos");
            return CustomResponse<LoginResponseDto>();
        }

        [HttpDelete(Name = "Remover")]
        public async Task<ActionResult> Remover(string emailUsuario)
        {
            if (string.IsNullOrEmpty(emailUsuario))
            {
                NotificarErro($"informe o e-mail do usuário.");
                return CustomResponse<bool>();
            }

            var user = await _userManager.FindByEmailAsync(emailUsuario);

            if (user == null)
            {
                NotificarErro($"O usuário {emailUsuario} não foi encontrado.");
                return CustomResponse<bool>();
            }

            try
            {
                await _userManager.DeleteAsync(user);
                return CustomResponse<bool>();
            }
            catch (Exception e)
            {
                return SendExceptionRequest<bool>(e);
            }
        }

        [HttpGet(Name = "ListagemUsuarios")]
        public ActionResult ListagemUsuarios()
        {
            var users = _userManager.Users;

            return CustomResponse(users);
        }

        private async Task<LoginResponseDto> GerarJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandle = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandle.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandle.WriteToken(token);

            var response = new LoginResponseDto
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimDto { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
