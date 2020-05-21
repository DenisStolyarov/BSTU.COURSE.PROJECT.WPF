using BSTU.FileCabinet.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BSTU.FileCabinet.WPF.Windows.Factories
{
    public interface ISimpleWindowFactory
    {
        Window CreateWindow(WindowType type);
    }
}
