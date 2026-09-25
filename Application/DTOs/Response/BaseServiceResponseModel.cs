namespace Application.DTOs.Response;

public record BaseServiceResponseModel(bool IsSuccess, string Message, ErrorCode ErrorCode)
{
    // public bool IsSuccess { get; set; }
    // public string Message { get; set; }
    // public ErrorCode ErrorCode { get; set; }

    // public BaseServiceResponseModel

    public static BaseServiceResponseModel Success(string message = "Operation successful.")
    {
        return new BaseServiceResponseModel(true, message, ErrorCode.None);
    }

    public static BaseServiceResponseModel Failure(string message = "Operation failed.", ErrorCode errorCode = ErrorCode.GeneralError)
    {
        return new BaseServiceResponseModel(false, message, errorCode);
    }

}
