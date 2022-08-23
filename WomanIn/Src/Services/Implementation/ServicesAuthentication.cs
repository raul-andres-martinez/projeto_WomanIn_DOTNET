using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;
using WomanInAPI.Src.Repo;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace WomanInAPI.Src.Services.Implementation
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IAutenticacao</para>
    /// <para>Criado por: Generation</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 17/08/2022</para>
    /// </summary>
    public class ServicesAuthentication : IAuthentication
    {
         
        #region Attributes
        private IUser _repo;
        public IConfiguration Configuration { get; }
        #endregion
        #region Constructors
        public ServicesAuthentication(IUser repo, IConfiguration
        configuration)
        {
            _repo = repo;
            Configuration = configuration;
        }
        #endregion
        #region Methods

        /// <summary>
        /// <para>Resumo: Método assíncrono responsavel por criar usuario sem duplicar no banco</para>
        /// </summary>
        /// <param name="usuario">Construtor para cadastrar usuario</param>
        public async Task CreateNoDuplicateUserAsync(User user)
        {
                var auxiliar = await _repo.GetUserByEmailAsync(user.Email);
                if (auxiliar != null) throw new Exception("Este email já está sendo utilizado");
                user.Password = EncodePassword(user.Password);
                await _repo.NewUserAsync(user);
        }
        public string GenerateToken(User user)
        {
            var tokenManipulator = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                new Claim(ClaimTypes.Role, user.Type.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
            )
            };
            var token = tokenManipulator.CreateToken(tokenDescription);
            return tokenManipulator.WriteToken(token);
        }

        /// <summary>
        /// <para>Resumo: Método responsavel por criptografar senha</para>
        /// </summary>
        /// <param name="senha">Senha a ser criptografada</param>
        /// <returns>string</returns>
        public string EncodePassword(string password)
        {
                var bytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(bytes);
        }

        #endregion
    }
}


