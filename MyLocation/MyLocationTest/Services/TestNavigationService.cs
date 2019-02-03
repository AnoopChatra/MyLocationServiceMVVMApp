using System;
using MyLocation.ViewModels;

namespace MyLocationTest.Services
{
    public class TestNavigationService : INavigationService
    {
        public object ViewModelNavigate;
        public bool isMyPopExcuted;

        public TestNavigationService()
        {
        }

        public void MyPop()
        {
            isMyPopExcuted = true;         
        }

        public void MyPush(object viewModelTobeNavigate)
        {
            ViewModelNavigate = viewModelTobeNavigate;
        }
    }
}
