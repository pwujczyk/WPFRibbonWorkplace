using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFRibbonWorkplaceContracts
{
    public delegate void LoadPluginToWindow(IPlugin element);
    public class BaseFunction
    {
        public LoadPluginToWindow LoadPlugin { get; set; }
    }
}
