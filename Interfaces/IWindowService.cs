using Snake.Base;
using Snake.Models;

namespace Snake.Interfaces
{
    public interface IWindowService
    {
        WindowModel<ContentView, BaseViewModel> CreateContentView<TViewModel>() where TViewModel : BaseViewModel;
        WindowModel<ContentView, BaseViewModel> GetView<TViewModel>() where TViewModel : BaseViewModel;
        WindowModel<ContentPage, BaseViewModel> GetAndCreateContentPage<TViewModel>() where TViewModel : BaseViewModel;
    }
}
