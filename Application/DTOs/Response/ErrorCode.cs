namespace Application.DTOs.Response;

/// <summary>
/// Defines the error codes that can be returned by application services.
/// </summary>
public enum ErrorCode
{
/// <summary>
/// Indicates that the operation completed without an error.
/// </summary>
None = 0,

/// <summary>
/// Indicates that an unspecified or general error occurred.
/// </summary>
GeneralError = 1,

/// <summary>
/// Indicates that the requested resource could not be found.
/// </summary>
NotFound = 2,

/// <summary>
/// Indicates that the operation could not be completed because the resource already exists.
/// </summary>
Duplicate = 3
}
