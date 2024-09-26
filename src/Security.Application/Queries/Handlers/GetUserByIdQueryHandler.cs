using MediatR;
using Security.Application.DTOs;
using Security.Application.Interfaces;

namespace Security.Application.Queries.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _userService.GetUserById(request.Id);
        }
    }
}
