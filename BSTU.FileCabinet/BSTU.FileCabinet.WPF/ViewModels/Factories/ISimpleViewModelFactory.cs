using BSTU.FileCabinet.WPF.State.Navigators;

namespace BSTU.FileCabinet.WPF.ViewModels.Factories
{
    public interface ISimpleViewModelFactory
    {
        BaseViewModel CreateViewModel(ViewType view);
    }
}
