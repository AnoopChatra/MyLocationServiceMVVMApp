using System;
namespace MyLocation.ViewModels
{
    public interface INavigationService
    {
        void MyPush(object viewModelTobeNavigate);

        void MyPop();
    }
}
