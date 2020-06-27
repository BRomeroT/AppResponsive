using System;
using System.Linq;
using System.Threading.Tasks;
using AppResponsive.Views.Views;
using Core.Lib.OS;
using Xamarin.Forms;

namespace AppResponsive.Views.OS
{
    internal class NavigationService : INavigationService
    {
        internal INavigation Navigation { get; set; }

        public async Task GoBack() => await Navigation.PopAsync(true);

        public async Task Home() => await Navigation.PopToRootAsync(true);

        public async void NavigatePop() => await Navigation.PopAsync();

        public async Task NavigateTo(string pageKey)
        {
            if (pageKey == PagesKeys.Main)
            {
                await Navigation.PopToRootAsync(true);
                return;
            }

            var paginaPorNavegar = pageKey switch
            {
                PagesKeys.Adaptive => typeof(AdaptivePage),
                _ => typeof(MainPage)
            };

            var ultimaPagina = Navigation.NavigationStack.Where(p => p.GetType() == paginaPorNavegar).FirstOrDefault();
            if (ultimaPagina == null)
            {
                switch (pageKey)
                {
                    case PagesKeys.Main:
                        await Navigation.PopToRootAsync(true); break;
                    case PagesKeys.Adaptive:
                        await Navigation.PushAsync(new AdaptivePage(), true); break;
                }
            }
        }

        public async Task NavigateTo(string pageKey, params object[] parameter)
        {
            switch (pageKey)
            {
                case PagesKeys.Main:
                    await Navigation.PushAsync(new MainPage()/*(parameter)*/, true); break;
                case PagesKeys.Adaptive:
                    await Navigation.PushAsync(new AdaptivePage()/*(parameter)*/, true); break;
            }
        }

        public async void NavigateToUrl(string url) => await Xamarin.Essentials.Launcher.OpenAsync(new Uri(url));

        public Task PopModal() => throw new NotImplementedException();

        public Task PushModal(string pageKey) => null;
    }
}