using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.WPF.ViewModels.User
{
    public class UserHomeViewModel : BaseViewModel
    {
        private readonly IUnitOfWork unitOfWork;
        public Student CurrentStudent { get; set; }

        public UserHomeViewModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException();
            this.CurrentStudent = unitOfWork.Students.Get(1);
        }
    }
}
