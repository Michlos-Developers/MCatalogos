using PresentationLayer.Presenters;
using PresentationLayer.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Unity;
using Unity.Lifetime;

namespace PresentationLayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer UnityC;

            string _connectionString = "Data Source = " +
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\MCatalogo\MCatalogo.sqlite;Version= 3;";

            UnityC =
                new UnityContainer()
                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager())
                .RegisterType<IHelpAboutPresenter, HelpAboutPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IHelpAboutView, HelpAboutView>(new ContainerControlledLifetimeManager())
                ;


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMainPresenter mainPresenter = UnityC.Resolve<MainPresenter>();

            IMainView mainView = mainPresenter.GetMainView();


            Application.Run((MainView)mainView);
        }
    }
}
