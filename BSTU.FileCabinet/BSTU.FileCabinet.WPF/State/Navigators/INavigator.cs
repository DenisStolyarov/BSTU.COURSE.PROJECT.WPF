using BSTU.FileCabinet.WPF.ViewModels;
using System.Windows.Input;

namespace BSTU.FileCabinet.WPF.State.Navigators
{
    public enum ViewType
    {
        Authorization,
        Faculty,
        Group,
        Pulpit,
        Speciality,
        Student,
        Subject,
        TeacherSubject,
        Teacher,
        Home,
        UserGroup,
        UserSubject,
    }

    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
