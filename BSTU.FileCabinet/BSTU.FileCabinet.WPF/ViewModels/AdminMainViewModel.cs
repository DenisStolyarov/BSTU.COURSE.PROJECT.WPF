using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.WPF.State.Navigators;
using BSTU.FileCabinet.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.WPF.ViewModels
{
    public class AdminMainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; }

        public AdminMainViewModel(INavigator navigator)
        {
            this.Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Authorization);
        }
    }
}
