using BSTU.FileCabinet.WPF.State.Navigators;
using BSTU.FileCabinet.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.WPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; }

        public MainViewModel(INavigator navigator = null)
        {
            Navigator = new Navigator(new SimpleViewModelFactory());//navigator;

            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Authorization);
        }
    }
}
