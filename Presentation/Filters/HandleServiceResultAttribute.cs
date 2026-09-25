using Application.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters
{
    /// <summary>
    /// فیلتری که بر اساس پراپرتی‌های ResponseModelBase، کد وضعیت HTTP را به‌صورت خودکار تنظیم می‌کند.
    /// </summary>
    public class HandleServiceResultAttribute : Attribute, IAsyncResultFilter
    {
        private readonly bool _treatDuplicateAsConflict;

        /// <param name="treatDuplicateAsConflict">
        /// اگر true باشد، ErrorCode.DuplicateEntity را به 409 (Conflict) و اگر false باشد به 400 (BadRequest) نگاشت می‌کند.
        /// </param>
        public HandleServiceResultAttribute(bool treatDuplicateAsConflict = true)
        {
            _treatDuplicateAsConflict = treatDuplicateAsConflict;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // اگر نتیجه از نوع ObjectResult است و مقدار آن از نوع ResponseModelBase می‌باشد
            if (context.Result is ObjectResult objectResult && objectResult.Value is BaseServiceResponseModel response)
            {
                // اگر عملیات موفقیت‌آمیز نبود، کد وضعیت را تنظیم کن
                if (!response.IsSuccess)
                {
                    int statusCode = response.ErrorCode switch
                    {
                        ErrorCode.NotFound => StatusCodes.Status404NotFound,
                        ErrorCode.Duplicate => _treatDuplicateAsConflict
                                                        ? StatusCodes.Status409Conflict
                                                        : StatusCodes.Status400BadRequest,
                        _ => StatusCodes.Status500InternalServerError // پیش‌فرض جدید: 500
                    };

                    // جایگزین کردن نتیجه با کد وضعیت جدید
                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = statusCode
                    };
                }
                // اگر IsSuccess == true بود، نتیجه را دست نخورده نگه می‌داریم (حتی اگر CreatedAtAction باشد)
            }

            await next();
        }
    }
}