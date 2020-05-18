using BSTU.FileCabinet.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.WPF.ViewModels.Factories
{
    public class SimpleViewModelFactory : ISimpleViewModelFactory
    {
        public BaseViewModel CreateViewModel(ViewType view)
        {
            switch (view)
            {
                case ViewType.Authorization:
                    return new AuthorizationViewModel();
                case ViewType.Faculty:
                    return new FacultyViewModel();
                default:
                    throw new Exception();
            }
        }
    }
}
