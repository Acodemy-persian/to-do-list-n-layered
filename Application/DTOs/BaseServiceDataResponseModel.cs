using System;

namespace Application.DTOs;

public record BaseServiceDataResponseModel<T>(bool IsSuccess, string Message, ErrorCode ErrorCode,T? Data) : BaseServiceResponseModel(IsSuccess, Message, ErrorCode)
{
    public static BaseServiceDataResponseModel<T> Success(T data, string message = "Operation successful.")
    {
        return new BaseServiceDataResponseModel<T>(true, message, ErrorCode.None, data);
    }

    public static BaseServiceDataResponseModel<T> Failure(string message = "Operation failed.", ErrorCode errorCode = ErrorCode.GeneralError)
    {
        return new BaseServiceDataResponseModel<T>(false, message, errorCode, default(T));
    }
}
