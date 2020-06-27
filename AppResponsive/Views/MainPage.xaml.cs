using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppResponsive
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ViewModel.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(ViewModel.CurrentState):
                        VisualStateManager.GoToState(MyStackLayout, ViewModel.CurrentState);
                        VisualStateManager.GoToState(WelcomeLabel, ViewModel.CurrentState);
                        VisualStateManager.GoToState(ToggleValidButton, ViewModel.CurrentState);
                        break;
                    default:
                        break;
                }
            };
        }

    }
}
