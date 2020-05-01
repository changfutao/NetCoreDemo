using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CFT.NetCore.WebAppDemo.Models;
using CFT.NetCore.WebAppDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CFT.NetCore.WebAppDemo.Controllers
{
    public class TestController : Controller
    {
        private readonly IOperationTransient _operationTransient;
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationSingleton _operationSingleton;
        public TestController(
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton
            )
        {
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
        }
        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <returns></returns>
        public IActionResult DIIndex()
        {
            var operation = HttpContext.RequestServices.GetService<IOperationScoped>();
            var operationViewModel = new OperationViewModel
            {
                OperationTransient = _operationTransient.OperationId.ToString("d"),
                OperationScoped = _operationScoped.OperationId.ToString("d"),
                OperationSingleton = _operationSingleton.OperationId.ToString("d"),
                ManualOperation = operation.OperationId.ToString("d")
            };
            return View(operationViewModel);
        }
    }
}