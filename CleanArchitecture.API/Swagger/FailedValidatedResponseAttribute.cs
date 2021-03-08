using CleanArchitecture.Service.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Swagger
{
    public class FailedValidatedResponseAttribute : ProducesResponseTypeAttribute
    {
        public FailedValidatedResponseAttribute() : base(typeof(ValidationBag), StatusCodes.Status400BadRequest)
        {
        }
    }
}
