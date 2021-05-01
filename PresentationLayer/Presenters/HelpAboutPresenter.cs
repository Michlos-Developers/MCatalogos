using PresentationLayer.Views;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
    public class HelpAboutPresenter : IHelpAboutPresenter
    {
        IHelpAboutView _helpAboutView;

        public HelpAboutPresenter(IHelpAboutView helpAboutView)
        {
            _helpAboutView = helpAboutView;
            SbuscribeToEventsSetup();
        }

        public IHelpAboutView GetHelpAboutView()
        {
            return _helpAboutView;
        }

        private void SbuscribeToEventsSetup()
        {
            _helpAboutView.HelpAboutViewLoadEventRaised += new EventHandler(OnHelpAboutViewLoadEventRaised);
        }

        public void OnHelpAboutViewLoadEventRaised(object sender, EventArgs e)
        {
            _helpAboutView.SetAboutValues(
                                          AssemblyTitle(),
                                          AssemblyProduct(),
                                          AssemblyVersion(),
                                          AssymblyCopyright(),
                                          AssemblyCompany(),
                                          AssemblyDescription()
                                          );
        }

        private string AssemblyTitle()
        {
            dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false).First();
            return attribute.Title;
        }
        private string AssemblyProduct()
        {
            dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false).First();
            return attribute.Product;
        }
        private string AssemblyVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        private string AssymblyCopyright()
        {
            dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false).First();
            return attribute.Copyright;
        }
        private string AssemblyCompany()
        {
            dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false).First();
            return attribute.Company;
        }
        private string AssemblyDescription()
        {
            dynamic attribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false).First();
            return attribute.Description;
        }


    }
}
