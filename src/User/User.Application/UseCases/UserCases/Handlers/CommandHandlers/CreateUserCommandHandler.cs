using MediatR;
using User.Application.Abstractions;
using User.Application.UseCases.UserCases.Commands;
using User.Domain.Entities;

namespace User.Application.UseCases.UserCases.Handlers.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel>
    {
        private readonly IUserDbContext _context;

        public CreateUserCommandHandler(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var user = new UserInfo
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Username = request.Username,
                    Email = request.Email,
                    Password = request.Password,
                    PhoneNumber = request.PhoneNumber
                };

                await _context.Users.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Username} => User Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Something went null or wrong",
                StatusCode = 400
            };
        }
    }
}
