using BSTU.FileCabinet.BLL.Interfaces;
using BSTU.FileCabinet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BSTU.FileCabinet.BLL.Services.Exceptions;
using BSTU.FileCabinet.Domain.Models;

namespace BSTU.FileCabinet.BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private const string AdminRole = "Admin";
        private const string UserRole = "User";

        private readonly IUnitOfWork unitOfWork;
        public AuthorizationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new NullReferenceException();
        }

        public WindowType GetWindow(string login, string password)
        {
            var user = this.unitOfWork.Authorizations.Get(login);

            if (user is null)
            {
                throw new WrongAuthorizationParameterException("User not found.", nameof(login));
            }

            if (IsNotEqual(user.Password, password))
            {
                throw new WrongAuthorizationParameterException("Wrong password.", nameof(password));
            }

            switch (user.Role)
            {
                case AdminRole:
                    return WindowType.Admin;
                case UserRole:
                    return WindowType.User;
                default:
                    throw new ArgumentException();
            }
        }

        private bool IsNotEqual(string instanse, string value)
        {
            return !instanse.Equals(value);
        }
    }
}
