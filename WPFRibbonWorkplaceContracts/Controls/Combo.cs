using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFRibbonWorkplaceContracts.Controls
{
    public class Combo : ControlBase
    {
        public  Combo()
        {
            this.Items = new List<string>();
        }
        public List<string> Items { get; private set; }
        public void AddItem(string item)
        {
            this.Items.Add(item);
        }
    }
}
