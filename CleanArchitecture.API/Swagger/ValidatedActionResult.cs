using CleanArchitecture.Service.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;

namespace CleanArchitecture.API.Swagger
{
    public class ValidatedActionResult<T> : IConvertToActionResult
    {
        private readonly BaseResponse _response;
        private readonly T _data;

        public ValidatedActionResult(BaseResponse response, T data)
        {
            _response = response;
            _data = data;
        }

        public IActionResult Convert()
        {
            if (_response.IsValid)
            {
                return new OkObjectResult(_data);
            }

            return new BadRequestObjectResult(_response.Bag);
        }
    }

    public static class ConvertValidatedActionResult
    {
        public static IActionResult ToActionResult<TResponse, TData>(this TResponse response, Func<TResponse, TData> selector) where TResponse : BaseResponse
        {
            return new ValidatedActionResult<TData>(response, selector(response)).Convert();
        }
    }
}
