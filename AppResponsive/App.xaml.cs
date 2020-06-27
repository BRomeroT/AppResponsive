using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OS = Sysne.Core.OS;
using Core.Lib.OS;
using AppResponsive.Views.OS;

namespace AppResponsive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            OS.DependencyService.Register<NavigationService, INavigationService>(OS.DependencyService.ServiceLifetime.Singleton);
            OS.DependencyService.Register<SettingsStorage, ISettingsStorage>();

            MainPage = new NavigationPage(new MainPage());
            (OS.DependencyService.Get<INavigationService>() as NavigationService).Navigation = Current.MainPage.Navigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
