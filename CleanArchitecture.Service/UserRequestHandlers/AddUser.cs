using CleanArchitecture.Contracts;
using CleanArchitecture.DataAccess.Repositories.Interfaces;
using CleanArchitecture.Domain;
using CleanArchitecture.Enum;
using CleanArchitecture.Service.Validation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.UserRequestHandlers
{
    public class AddUserRequest: IRequest<AddUserResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class AddUserResponse: BaseResponse
    {

    }

    public class AddUserRequestValidator : RequestValidator<AddUserRequest, AddUserResponse>
    {
        private readonly IRepository<User> _userRepository;
        public AddUserRequestValidator(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<ValidationBag> Validate(AddUserRequest request, CancellationToken cancellationToken)
        {
            var bag = new ValidationBag();

            if (string.IsNullOrEmpty(request.Name))
            {
                bag.AddError(ValidationErrorCode.InvalidName);
            }

            if (string.IsNullOrEmpty(request.Email))
            {
                bag.AddError(ValidationErrorCode.InvalidEmail);
            }

            return bag;
        }
    }

    public class AddUserRequestHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly IRepository<User> _userRepository;
        public AddUserRequestHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email);

            await _userRepository.Create(user);

            return new AddUserResponse
            {
            };
        }
    }
}
