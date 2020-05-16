using BSTU.FileCabinet.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyChanged;
using System.Windows.Input;

namespace BSTU.FileCabinet.WPF.State.Navigators
{
    [AddINotifyPropertyChangedInterface]
    public class Navigator : INavigator
    {
        public BaseViewModel CurrentViewModel { get; set; }

        public ICommand UpdateCurrentViewModelCommand => throw new NotImplementedException();
    }
}
