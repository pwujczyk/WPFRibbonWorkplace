using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFRibbonWorkplaceContracts;

namespace WPFRibbonWorkplace.Menu
{
    class ComboBuilder
    {
        internal Control Build(IFunction t)
        {
            Fluent.ComboBox b = new Fluent.ComboBox();
            var combo=t.Control as WPFRibbonWorkplaceContracts.Controls.Combo;
            foreach(var item in combo.Items)
            {
                b.Items.Add(item);
            }
            //b.Header = function.FunctionName;
            //b.Content = function.FunctionName;
            //b.ToolTip = function.FunctionName;

            //b.Click += (s, e) => function.Method();
            b.SelectionChanged += (object sender, SelectionChangedEventArgs e) => t.Method(t.Control);
            return b;
        }
    }
}
