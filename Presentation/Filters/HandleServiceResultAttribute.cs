using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters;

/// <summary>
/// A result filter that automatically maps service error codes
/// to appropriate HTTP status codes.
/// </summary>
public class HandleServiceResultAttribute : Attribute, IAsyncResultFilter
{
    private readonly bool _treatDuplicateAsConflict;

    /// <summary>
    /// Initializes a new instance of the <see cref="HandleServiceResultAttribute"/> class.
    /// </summary>
    /// <param name="treatDuplicateAsConflict">
    /// Determines whether <see cref="ErrorCode.Duplicate"/> is mapped to
    /// HTTP 409 Conflict. If false, it is mapped to HTTP 400 Bad Request.
    /// </param>
    public HandleServiceResultAttribute(bool treatDuplicateAsConflict = true)
    {
        _treatDuplicateAsConflict = treatDuplicateAsConflict;
    }

    /// <summary>
    /// Executes the result filter and maps unsuccessful service responses
    /// to the corresponding HTTP status codes.
    /// </summary>
    /// <param name="context">The context for result execution.</param>
    /// <param name="next">The delegate that executes the next result filter or result.</param>
    /// <returns>A task representing the asynchronous filter execution.</returns>
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult objectResult &&
            objectResult.Value is BaseServiceResponseModel response)
        {
            if (!response.IsSuccess)
            {
                int statusCode = response.ErrorCode switch
                {
                    ErrorCode.NotFound => StatusCodes.Status404NotFound,

                    ErrorCode.Duplicate => _treatDuplicateAsConflict
                        ? StatusCodes.Status409Conflict
                        : StatusCodes.Status400BadRequest,

                    _ => StatusCodes.Status500InternalServerError
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = statusCode
                };
            }
        }

        await next();
    }
}
