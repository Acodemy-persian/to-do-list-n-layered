namespace Application.DTOs.Response;

/// <summary>
/// Represents the standard response returned by an application service operation.
/// </summary>
/// <param name="IsSuccess">Indicates whether the service operation completed successfully.</param>
/// <param name="Message">A descriptive message providing additional information about the operation result.</param>
/// <param name="ErrorCode">The error code associated with the operation result.</param>
public record BaseServiceResponseModel(bool IsSuccess, string Message, ErrorCode ErrorCode)
{
    // <summary>
    /// Creates a successful service response.
    /// </summary>
    /// <param name="message">The message describing the successful operation.</param>
    /// <returns>A successful service response with <see cref="ErrorCode.None"/>.</returns>
    public static BaseServiceResponseModel Success(string message = "Operation successful.")
    {
        return new BaseServiceResponseModel(true, message, ErrorCode.None);
    }

    /// <summary> 
    /// Creates a failed service response. 
    /// </summary> 
    /// <param name="message">The message describing the failed operation.</param>  
    /// <param name="errorCode">The error code associated with the failure.</param> 
    /// <returns>A failed service response with the specified message and error code.</returns>
    public static BaseServiceResponseModel Failure(string message = "Operation failed.", ErrorCode errorCode = ErrorCode.GeneralError)
    {
        return new BaseServiceResponseModel(false, message, errorCode);
    }
}
