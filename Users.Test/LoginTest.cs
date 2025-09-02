using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using User.Entities.Read;
using User.Infrastructure.EF.Context;
using User.Infrastructure.EF.Entities;
using User.Infrastructure.EF.Helpers;
using User.Infrastructure.EF.Repositories;

namespace User.Test
{
    [TestFixture]
    public class LoginTest
    {
        private InmoSysCoreContext _context;
        private IConfiguration _config;

        [SetUp]
        public void Setup()
        {
            // Configuración fake JWT
            var inMemorySettings = new Dictionary<string, string>
            {
                {"Jwt:Secret", "supersecretkeysupersecretkey123456"},
                {"Jwt:TokenExpirationMinutes", "30"},
                {"Jwt:Issuer", "testIssuer"},
                {"Jwt:Audience", "testAudience"}
            };
            _config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();

            // DbContext en memoria
            var options = new DbContextOptionsBuilder<InmoSysCoreContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new InmoSysCoreContext(options);

            // Limpiar datos previos y agregar usuarios de prueba
            _context.Users.RemoveRange(_context.Users);
            _context.Users.Add(new Users
            {
                Id = 1,
                Email = "test@test.com",
                Password = SecurityHelper.Hash("123456")
            });
            _context.SaveChanges();
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Dispose();
        }

        [Test]
        public async Task LoginAsync_EmailOrPasswordEmpty_ReturnsError()
        {
            var service = new UserRepository(_config, _context);

            var result = await service.LoginAsync(new UserLoginRequest
            {
                Email = "",
                Password = ""
            });

            Assert.IsFalse(result.Success);
            Assert.AreEqual("El correo y la contraseña son obligatorios.", result.Message);
        }

        [Test]
        public async Task LoginAsync_UserNotFound_ReturnsError()
        {
            var service = new UserRepository(_config, _context);

            var result = await service.LoginAsync(new UserLoginRequest
            {
                Email = "notfound@test.com",
                Password = "123456"
            });

            Assert.IsFalse(result.Success);
            Assert.AreEqual("El usuario no existe.", result.Message);
        }

        [Test]
        public async Task LoginAsync_WrongPassword_ReturnsError()
        {
            var service = new UserRepository(_config, _context);

            var result = await service.LoginAsync(new UserLoginRequest
            {
                Email = "test@test.com",
                Password = SecurityHelper.Hash("wrongpass") 
            });

            Assert.IsFalse(result.Success);
            Assert.AreEqual("La contraseña es incorrecta.", result.Message);
        }

        [Test]
        public async Task LoginAsync_ValidCredentials_ReturnsToken()
        {
            var service = new UserRepository(_config, _context);

            var result = await service.LoginAsync(new UserLoginRequest
            {
                Email = "test@test.com",
                Password = "123456"
            });

            Assert.IsTrue(result.Success);
            Assert.AreEqual("Login exitoso.", result.Message);
            Assert.IsNotNull(result.Token);
        }
    }
}
