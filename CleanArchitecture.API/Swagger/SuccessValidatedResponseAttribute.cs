using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CleanArchitecture.API.Swagger
{
    public class SuccessValidatedResponseAttribute : ProducesResponseTypeAttribute
    {
        public SuccessValidatedResponseAttribute(Type type) : base(type, StatusCodes.Status200OK)
        {
        }
    }
}
