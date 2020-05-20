using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.WPF.State.Navigators;
using BSTU.FileCabinet.WPF.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.WPF.ViewModels.Factories
{
    public class UserSimpleViewModelFactory : ISimpleViewModelFactory
    {
        private readonly IUnitOfWork unitOfWork;

        public UserSimpleViewModelFactory(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BaseViewModel CreateViewModel(ViewType view)
        {
            switch (view)
            {
                case ViewType.Home:
                    return new UserHomeViewModel(unitOfWork);
                case ViewType.UserGroup:
                    return new UserGroupViewModel();
                case ViewType.UserSubject:
                    return new UserSubjectViewModel();
                default:
                    throw new Exception();
            }
        }
    }
}
