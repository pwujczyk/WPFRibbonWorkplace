using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFRibbonWorkplaceContracts
{
    public delegate void LoadMenu(List<IFunction> functions);
    public delegate void UnLoadMenu(string tabName);
    public interface IPlugin
    {
        List<IFunction> Functions { get; }
        LoadMenu LoadMenu { set; }
        UnLoadMenu UnLoadMenu { set; }
    }
}
