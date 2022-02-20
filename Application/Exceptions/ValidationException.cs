using FluentValidation.Results;
using System.Linq;

namespace Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("There have been one or more validation error")
    {
        Errors = new List<string>();
    }
    public List<string> Errors { get;}

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        foreach (var failure in failures)  
        {
            Errors.Add(failure.ErrorMessage);
        }
    }
}