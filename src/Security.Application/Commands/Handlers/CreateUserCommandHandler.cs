using MediatR;
using Security.Application.Interfaces;
using Security.Application.DTOs;

namespace Security.Application.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = new UserDto(request.Name, request.Email);
            return await _userService.CreateUserAsync(userDto);
        }
    }
}
