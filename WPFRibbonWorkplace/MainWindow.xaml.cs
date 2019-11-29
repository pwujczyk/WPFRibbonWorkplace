using Autofac;
using Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFRibbonWorkplaceContracts;

namespace WPFRibbonWorkplace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                LoadAssemblies();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        private void LoadAssemblies()
        {
            var builder = new ContainerBuilder();

            Assembly[] assemblies = GetAssembliesFromApplicationBaseDirectory(x => x.FullName.EndsWith("WorkplacePlugin.dll"));

            builder.RegisterAssemblyTypes(assemblies).Where(t => t.Name == "IPluginMainWindow").AsImplementedInterfaces();

            builder.RegisterAssemblyModules(assemblies);

            //var assemblies = AppDomain.CurrentDomain.GetAssemblies();z


            //var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.GetInterfaces()
                .Any(i => i.IsAssignableFrom(typeof(IPluginMainWindow))))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            //.Where(t => t.IsAssignableFrom(typeof(IPluginMainWindow)))
            //.As<IPluginMainWindow>();

            var container = builder.Build();
            var pluginClasses = container.Resolve<IEnumerable<IPluginMainWindow>>();
            var element = pluginClasses.First(x => x.Main == true);
            //AddMenu(element);
            LoadPlugin(element);
        }

        private void LoadPlugin(IPlugin element)
        {
            
            //this.MainGrid.Children.Clear();
           // c.Tag += "WPFMeetingsPlugin";
            List<Control> toRemove = new List<Control>();
            foreach (var item in this.MainGrid.Children)
            {
                var uc = item as IPlugin;
                if (uc!=null)
                {
                    toRemove.Add(uc as UserControl);
                }
            }
            toRemove.ForEach(x => this.MainGrid.Children.Remove(x));

            Control c = element as UserControl;
            this.MainGrid.Children.Add(c);
            Grid.SetColumn(c, 1);
            Grid.SetRow(c, 1);

            AddMenu(element);
        }

        private void AddMenu(IPlugin mainPlugin)
        {
            RibbonManager manager = new WPFRibbonWorkplace.RibbonManager(this.FluentRibbon, this.MainGrid);
            manager.ClearRibbon();
            mainPlugin.Functions.ForEach(x => { x.LoadPlugin = LoadPlugin; manager.AddFunction(x); });
            mainPlugin.LoadMenu = LoadAdHocMenu;
            mainPlugin.UnLoadMenu = UnloadAdHocMenu;
            manager.SelectTab();
        }

        private void LoadAdHocMenu(List<IFunction> functions)
        {
            RibbonManager manager = new WPFRibbonWorkplace.RibbonManager(this.FluentRibbon, this.MainGrid);
            functions.ForEach(x => manager.AddFunction(x));
        }

        private void UnloadAdHocMenu(string tabName)
        {
            RibbonManager manager = new WPFRibbonWorkplace.RibbonManager(this.FluentRibbon, this.MainGrid);
            manager.RemoveRibbonTab(tabName);
        }

        private static Assembly[] GetAssembliesFromApplicationBaseDirectory(Func<AssemblyName, bool> condition)
        {
            try
            {
                string baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

                Func<string, bool> isAssembly = file => string.Equals(System.IO.Path.GetExtension(file), ".dll", StringComparison.OrdinalIgnoreCase);

                var files = Directory.GetFiles(baseDirectoryPath);
                var assemby = files.Where(isAssembly);
                var conditionAssembly = assemby.Where(f => condition(new AssemblyName(System.IO.Path.GetFileName(f))));
                var result = conditionAssembly.Select(Assembly.LoadFrom).ToArray();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
