using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFRibbonWorkplaceContracts;

namespace WPFRibbonWorkplace.Menu
{
    public class ButtonBuilderDirector
    {
        Control c;

        public Control Control
        {
            get
            {
                return this.c;
            }
        }

        //Type ButtonType;

        public ButtonBuilderDirector(IFunction t)
        {
            TypeSwitch ts = new Menu.TypeSwitch()
                .Case<WPFRibbonWorkplaceContracts.Controls.Button>(() => this.c = new ButtonBuilder().Build(t))
                .Case<WPFRibbonWorkplaceContracts.Controls.Combo>(() => this.c = new ComboBuilder().Build(t));
            ts.Switch(t.Control);
            //switch (t.Control)
            //{
            //    case WPFRibbonWorkplaceContracts.Button.Button:

            //        break;
            //    case WPFRibbonWorkplaceContracts.Button.Combo:
            //        this.c = new ComboBuilder().Build(t);
            //        break;
            //    default:
            //        break;
            //}

            //    .Case(t.ButtonType, () => 
            //ts.Switch(t.ButtonType);
            //ts.Switch(42);
            //ts.Switch(false);
            //ts.Switch("hello");

            //switch (t)
            //{
            //    case Type intType when intType == typeof(int):
            //    case Type decimalType when decimalType == typeof(decimal):
            //    this.value = Math.Max(Math.Min(this.value, Maximum), Minimum);
            //    break;
            //}
            //// this.ButtonType = t;

            // switch (typeof(t))
            // {
            //    case typeof(Button):

            // break;
            //     default:
            //         break;
            // }
        }
    }
}
