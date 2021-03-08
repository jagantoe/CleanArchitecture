using CleanArchitecture.Enum;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Service.Validation
{
    public class ValidationBag
    {
        private readonly List<Error> _errors;
        public IEnumerable<Error> Errors => _errors.AsEnumerable();

        public ValidationBag()
        {
            _errors = new List<Error>();
        }

        public void AddError(ValidationErrorCode error)
        {
            _errors.Add(new Error(error));
        }

        public void AddError(ValidationErrorCode error, object parameters)
        {
            _errors.Add(new Error(error, parameters));
        }

        public bool IsValid => !_errors.Any();
    }
}
