using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using EmployeeManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Filters
{
    public class HandleApiErrorsAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;

            var errorResponse = new ApiErrorResponse
            {
                ErrorMessage = new List<string> { context.Exception.Message }
            };

            context.Result = new JsonResult(errorResponse);
        }
    }
}
