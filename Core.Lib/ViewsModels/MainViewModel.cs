using Core.Lib.OS;
using Sysne.Core.MVVM;
using Sysne.Core.OS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Lib.ViewsModels
{
    public class MainViewModel : ViewModelBase
    {

        private string currentState = "Normal";
        public string CurrentState { get => currentState; set => Set(ref currentState, value); }


        RelayCommand switchStateCommand = null;
        public RelayCommand SwitchStateCommand
        {
            get => switchStateCommand ?? (switchStateCommand = new RelayCommand(() =>
            {
                CurrentState = (CurrentState == "Normal") ? "Invalid" : "Normal";
            }, () => { return true; }));
        }

        RelayCommand goAdaptiveCommand = null;
        public RelayCommand GoAdaptiveCommand
        {
            get => goAdaptiveCommand ?? (goAdaptiveCommand = new RelayCommand(async () =>
            {
                await DependencyService.Get<INavigationService>().NavigateTo(PagesKeys.Adaptive);
            }, () => { return true; }));
        }
    }
}
