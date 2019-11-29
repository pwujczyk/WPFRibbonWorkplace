using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFRibbonWorkplaceContracts.Controls;

namespace WPFRibbonWorkplaceContracts
{
    public interface IFunction
    { 

        LoadPluginToWindow LoadPlugin { get; set; }

        string TabName { get; }
        string SectionName { get; }
        string FunctionName { get; }

        ControlBase Control { get; }

        void Method(ControlBase controlbase);
        //XElement Configuration { get; }


    }
}
