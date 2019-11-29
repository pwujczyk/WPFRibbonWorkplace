using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFRibbonWorkplace.Menu
{
    public class TypeSwitch
    {
        Dictionary<Type, Action> matches = new Dictionary<Type, Action>();
        public TypeSwitch Case<T>(Action action)
        {
            matches.Add(typeof(T), () => action());
            return this;
        }
        public void Switch(object x)
        {
            matches[x.GetType()]();
        }
    }
}
