﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace financial.Api.Filters;

public class ApiResponseFilter : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            var apiResponse = new
            {
                Success = true,
                Data = objectResult.StatusCode.Equals(200) ? objectResult.Value : null
            };

            context.Result = new ObjectResult(apiResponse)
            {
                StatusCode = objectResult.StatusCode
            };
        }
    }
}
