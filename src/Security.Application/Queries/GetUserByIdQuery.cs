using Security.Application.DTOs;
using MediatR;

namespace Security.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id) { Id = id; }
    }
}
