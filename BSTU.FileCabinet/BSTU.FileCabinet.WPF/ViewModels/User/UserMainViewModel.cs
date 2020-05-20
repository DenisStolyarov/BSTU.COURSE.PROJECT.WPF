using BSTU.FileCabinet.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.WPF.ViewModels.User
{
    public class UserMainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; }

        public UserMainViewModel(INavigator navigator)
        {
            this.Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
