using Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFRibbonWorkplace.Menu;
using WPFRibbonWorkplaceContracts;

namespace WPFRibbonWorkplace
{
    class RibbonManager
    {
        private Ribbon Ribbon;
        private System.Windows.Controls.Grid MainGrid;
        public RibbonManager(Ribbon ribbon, System.Windows.Controls.Grid mainGrid)
        {
            this.Ribbon = ribbon;
            this.MainGrid = mainGrid;
        }

        //private void LoadPlugin(IPluginMainWindow element)
        //{
        //    var c = element as System.Windows.Controls.UserControl;
        //    this.MainGrid.Children.Clear();
        //    this.MainGrid.Children.Add(c);
        //    System.Windows.Controls.Grid.SetColumn(c, 1);
        //    System.Windows.Controls.Grid.SetRow(c, 1);

        //    //AddMenu(element);
        //}

        public void ClearRibbon()
        {
            Ribbon.Tabs.Clear();
        }

        public void AddFunction(IFunction function)
        {
            var tb = Ribbon.Tabs.FirstOrDefault(x => x.Header.ToString() == function.TabName);
            if (tb == null)
            {
                tb = new RibbonTabItem();
                tb.Header = function.TabName;
                Ribbon.Tabs.Add(tb);
            }

            var ribbonGroupBox = tb.Groups.FirstOrDefault(x => x.Header == function.FunctionName);
            if (ribbonGroupBox == null)
            {
                ribbonGroupBox = new RibbonGroupBox();
                ribbonGroupBox.Header = function.SectionName;
                tb.Groups.Add(ribbonGroupBox);
            }

            ButtonBuilderDirector director = new ButtonBuilderDirector(function);
            

            // function.LoadPlugin = LoadPlugin;
            ribbonGroupBox.Items.Add(director.Control);

        }

        public void RemoveRibbonTab(string ribbonTabName)
        {
            var tb = Ribbon.Tabs.FirstOrDefault(x => x.Header.ToString() == ribbonTabName);
            this.Ribbon.Tabs.Remove(tb);
        }

        public void SelectTab()
        {
            this.Ribbon.Tabs.First().IsSelected = true;
        }

        private void B_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
