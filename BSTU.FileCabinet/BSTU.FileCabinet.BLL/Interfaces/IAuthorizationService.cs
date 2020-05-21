using BSTU.FileCabinet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTU.FileCabinet.BLL.Interfaces
{
    public enum WindowType
    {
        Admin,
        User,
    }

    public interface IAuthorizationService
    {
        WindowType GetWindow(string login, string password);
    }
}
