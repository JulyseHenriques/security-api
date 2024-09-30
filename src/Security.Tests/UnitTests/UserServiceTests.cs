using Moq;
using AutoMapper;
using FluentAssertions;
using Security.Application.DTOs;
using Security.Application.Services;
using Security.Domain.Entities;
using Security.Infrastructure.Interfaces;
using Xunit;

namespace Security.Tests.UnitTests
{
    public class UserServiceTests
    {
        private readonly UserService _userService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IUserRepository> _mockRepository;

        public UserServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockMapper.Object, _mockRepository.Object);
        }

        [Fact]
        public async Task CriarUsuario_DeveChamarMetodoCreate()
        {
            // Arrange
            var userDto = new UserDto() { Name = "João Silva", Email = "joao_silva@example.com" };

            // Act
            await _userService.CreateUserAsync(userDto);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<UserEntity>()), Times.Once);
        }

        [Fact]
        public async Task ObterUsuarioPorId_DeveRetornarUsuarioCorreto()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Maria Fonseca";
            var email = "maria_fonseca@gmail.com";
            var userEntity = new UserEntity(name, email) { Id = id };
            _mockRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(userEntity);

            // Act
            var result = await _userService.GetUserByIdAsync(id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(id);
            result.Name.Should().Be(name);
            result.Email.Should().Be(email);
        }
    }
}


