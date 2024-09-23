using MediatR;
using Security.Application.Interfaces;
using Security.Application.DTOs;

namespace Security.Application.Commands.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = new UserDto(request.Name, request.Email, 0);
            return await _userService.CreateUserAsync(userDto);
        }
    }
}
