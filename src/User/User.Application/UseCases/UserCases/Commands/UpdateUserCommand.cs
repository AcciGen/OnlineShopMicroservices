using MediatR;
using User.Domain.Entities;

namespace User.Application.UseCases.UserCases.Commands
{
    public class UpdateUserCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
