using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppResponsive.Views.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdaptivePage : ContentPage
    {
        public AdaptivePage()
        {
            InitializeComponent();
            SizeChanged += (s, e) =>
            {
                if (Width > Height) //Horizontal
                    VisualStateManager.GoToState(Main, "Horizontal");
                else //Vertical
                    VisualStateManager.GoToState(Main, "Vertical");
            };
        }
    }
}