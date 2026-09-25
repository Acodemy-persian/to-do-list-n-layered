namespace Application.DTOs.Response;

/// <summary>
/// Represents a standard service response that includes a data payload.
/// </summary>
/// <typeparam name="T">The type of data returned by the service operation.</typeparam>
/// <param name="IsSuccess">Indicates whether the service operation completed successfully.</param>
/// <param name="Message">A descriptive message providing additional information about the operation result.</param>
/// <param name="ErrorCode">The error code associated with the operation result.</param>
/// <param name="Data">The data returned by the service operation, or <c>null</c> when no data is available.</param>
public record BaseServiceDataResponseModel<T>(bool IsSuccess, string Message, ErrorCode ErrorCode,T? Data) : BaseServiceResponseModel(IsSuccess, Message, ErrorCode)
{
    /// <summary>
    /// Creates a successful service response containing the specified data.
    /// </summary>
    /// <param name="data">The data returned by the service operation.</param>
    /// <param name="message">The message describing the successful operation.</param>
    /// <returns>
    /// A successful service response containing the specified data
    /// and <see cref="ErrorCode.None"/>.
    /// </returns>
    public static BaseServiceDataResponseModel<T> Success(T data, string message = "Operation successful.")
    {
        return new BaseServiceDataResponseModel<T>(true, message, ErrorCode.None, data);
    }

    /// <summary> 
    /// Creates a failed service response without a data payload. 
    /// </summary> 
    /// <param name="message">The message describing the failed operation.</param> 
    /// <param name="errorCode">The error code associated with the failure.</param> 
    /// <returns> A failed service response with the specified message and error code, and no data payload. </returns>
    public static BaseServiceDataResponseModel<T> Failure(string message = "Operation failed.", ErrorCode errorCode = ErrorCode.GeneralError)
    {
        return new BaseServiceDataResponseModel<T>(false, message, errorCode, default);
    }
}
