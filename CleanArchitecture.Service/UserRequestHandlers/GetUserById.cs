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
    public class GetUserByIdRequest: IRequest<GetUserByIdResponse>
    {
        public int Id { get; set; }
    }

    public class GetUserByIdResponse: BaseResponse
    {
        public UserOverview User { get; set; }
    }

    public class GetUserByIdRequestValidator : RequestValidator<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IRepository<User> _userRepository;
        public GetUserByIdRequestValidator(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<ValidationBag> Validate(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var bag = new ValidationBag();

            var user = await _userRepository.Single(_ => _.Id == request.Id);
            if (user == null)
            {
                bag.AddError(ValidationErrorCode.UserDoesNotExist, $"There is no user for id {request.Id}.");
            }

            return bag;
        }
    }

    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IRepository<User> _userRepository;
        public GetUserByIdRequestHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Single(_ => _.Id == request.Id);

            return new GetUserByIdResponse
            {
                User = new UserOverview
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                }
            };
        }
    }
}
