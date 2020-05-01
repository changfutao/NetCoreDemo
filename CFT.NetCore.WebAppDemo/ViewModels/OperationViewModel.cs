using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFT.NetCore.WebAppDemo.ViewModels
{
    public class OperationViewModel
    {
        public string OperationTransient { get; set; }
        public string OperationScoped { get; set; }
        public string OperationSingleton { get; set; }
        public string ManualOperation { get; set; }
    }
}
