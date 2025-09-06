using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using User.Entities.Read;
using User.Infrastructure.Constants;
using User.Infrastructure.EF.Context;
using User.Infrastructure.EF.Entities;
using User.Infrastructure.EF.Helpers;
using User.Infrastructure.EF.Interfaces;
using User.Infrastructure.EF.Repositories;

namespace User.Test
{
    [TestFixture]
    public class LoginTest
    {
        private InmoSysCoreContext _context;
        private IConfiguration _config;
        private Mock<IJwtAuthRepository> _jwtAuthRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _jwtAuthRepositoryMock = new Mock<IJwtAuthRepository>();
                        
            _jwtAuthRepositoryMock
                .Setup(j => j.GenerateToken(It.IsAny<string>(), It.IsAny<int>(), JwtAuthConstants.JWT_MODULE))
                .Returns(Task.FromResult("fake-jwt-token"));

            _config = new ConfigurationBuilder().Build();
                        
            var options = new DbContextOptionsBuilder<InmoSysCoreContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new InmoSysCoreContext(options);
                        
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
            var service = new UserRepository(_config, _context, _jwtAuthRepositoryMock.Object);

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
            var service = new UserRepository(_config, _context, _jwtAuthRepositoryMock.Object);

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
            var service = new UserRepository(_config, _context, _jwtAuthRepositoryMock.Object);

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
            var service = new UserRepository(_config, _context, _jwtAuthRepositoryMock.Object);

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
