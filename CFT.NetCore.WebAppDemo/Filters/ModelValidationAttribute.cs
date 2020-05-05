using CFT.NetCore.WebAppDemo.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                ResultModel resultModel = new ResultModel
                {
                    Status = 500,
                    ErrorMessages = new List<ErrorMessage>()
                };

                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    foreach (var error in state.Errors)
                    {
                        ErrorMessage errorMessage = new ErrorMessage
                        {
                            ErrorName = "错误字段: " + key,
                            ErrorInfo = error.ErrorMessage
                        };
                        resultModel.ErrorMessages.Add(errorMessage);
                    }
                }

                context.Result = new ObjectResult(resultModel);
            }
            base.OnActionExecuting(context);
        }
    }
}
