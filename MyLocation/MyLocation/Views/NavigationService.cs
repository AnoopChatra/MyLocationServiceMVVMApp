using System;
using System.Collections.Generic;
using MyLocation.ViewModels;
using Xamarin.Forms;

namespace MyLocation.Views
{
    public class NavigationService : INavigationService
    {
        Dictionary<Type, Type> viewModelMapping;

        public NavigationService()
        {
            viewModelMapping = new Dictionary<Type, Type>();
            viewModelMapping.Add(typeof(FirstVM), typeof(FirstPage));
            viewModelMapping.Add(typeof(SecondVM), typeof(SecondPage));
        }

        public void MyPush(object viewModeltobenavigate)
        {
            var viewModelType = viewModeltobenavigate.GetType();
            if(viewModelMapping.ContainsKey(viewModelType)){
                var viewtype = viewModelMapping[viewModelType];

                ContentPage instance = (ContentPage)Activator.CreateInstance(viewtype);
                instance.BindingContext = viewModeltobenavigate;

                Application.Current.MainPage.Navigation.PushAsync(instance);
            }else{
                throw new Exception("not found");
            }
           
        }

        public void MyPop(){
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
