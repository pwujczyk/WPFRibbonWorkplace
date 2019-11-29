using Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFRibbonWorkplaceContracts;

namespace WPFRibbonWorkplace.Menu
{
    class ButtonBuilder
    {
        internal System.Windows.Controls.Control Build(IFunction function)
        {
            Fluent.Button b = new Fluent.Button();
            b.Header = function.FunctionName;
            b.Content = function.FunctionName;
            b.ToolTip = function.FunctionName;

            b.Click += (s, e) => function.Method(function.Control);
            return b; 
        }
    }
}
