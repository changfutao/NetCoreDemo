using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.Models
{
    public interface IOperation
    { 
        Guid OperationId { get; }
    }

    public interface IOperationTransient:IOperation
    { }

    public interface IOperationScoped : IOperation
    { }

    public interface IOperationSingleton : IOperation
    { }

    public class Operation:IOperationTransient,IOperationScoped,IOperationSingleton
    {
        public Operation()
        {
            OperationId = Guid.NewGuid();
        }

        public Guid OperationId { get; }
    }
}
