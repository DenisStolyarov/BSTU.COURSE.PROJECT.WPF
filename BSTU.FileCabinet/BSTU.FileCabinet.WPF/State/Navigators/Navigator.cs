using BSTU.FileCabinet.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyChanged;
using System.Windows.Input;
using BSTU.FileCabinet.WPF.Commands;
using BSTU.FileCabinet.WPF.ViewModels.Factories;

namespace BSTU.FileCabinet.WPF.State.Navigators
{
    [AddINotifyPropertyChangedInterface]
    public class Navigator : INavigator
    {
        private readonly ISimpleViewModelFactory viewModelFactory;

        public Navigator(ISimpleViewModelFactory viewModelFactory)
        {
            this.viewModelFactory = viewModelFactory;
        }

        public BaseViewModel CurrentViewModel { get; set; }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this, this.viewModelFactory);
    }
}
