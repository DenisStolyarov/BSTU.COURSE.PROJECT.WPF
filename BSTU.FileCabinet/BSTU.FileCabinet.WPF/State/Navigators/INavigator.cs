﻿using BSTU.FileCabinet.WPF.ViewModels;
using System.Windows.Input;

namespace BSTU.FileCabinet.WPF.State.Navigators
{
    public enum ViewType
    {
        Authorization,
        Faculty,
    }

    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
