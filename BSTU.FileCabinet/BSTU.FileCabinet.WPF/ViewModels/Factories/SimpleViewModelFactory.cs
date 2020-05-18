using BSTU.FileCabinet.DAL.Interfaces;
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
        private readonly IUnitOfWork unitOfWork;

        public SimpleViewModelFactory(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public BaseViewModel CreateViewModel(ViewType view)
        {
            switch (view)
            {
                case ViewType.Authorization:
                    return new AuthorizationViewModel(unitOfWork.Authorizations);
                case ViewType.Faculty:
                    return new FacultyViewModel(unitOfWork.Faculties);
                default:
                    throw new Exception();
            }
        }
    }
}
