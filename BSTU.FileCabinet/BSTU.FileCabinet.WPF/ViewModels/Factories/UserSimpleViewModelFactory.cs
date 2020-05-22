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
        private readonly int userId;

        public UserSimpleViewModelFactory(IUnitOfWork unitOfWork, int? userId)
        {
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException();
            this.userId = userId ?? throw new NullReferenceException();
        }

        public BaseViewModel CreateViewModel(ViewType view)
        {
            switch (view)
            {
                case ViewType.Home:
                    return new UserHomeViewModel(unitOfWork, userId);
                case ViewType.UserGroup:
                    return new UserGroupViewModel(unitOfWork, userId);
                case ViewType.UserSubject:
                    return new UserSubjectViewModel(unitOfWork, userId);
                default:
                    throw new Exception();
            }
        }
    }
}
