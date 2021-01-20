using Prism;
using Prism.Ioc;
using XamarinInterviewTask.ViewModels;
using XamarinInterviewTask.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using DryIoc;
using Prism.DryIoc;
using XamarinInterviewTask.Services;

namespace XamarinInterviewTask
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }
        protected override async void OnInitialized()
        {
            InitializeComponent();
            if (Device.Idiom == TargetIdiom.Phone)
            {
                await NavigationService.NavigateAsync("NavigationPage/MasterViewPageMaster");
            }
            else
            {
                await NavigationService.NavigateAsync("NavigationPage/MasterViewPage");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterForNavigation<MasterViewPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterViewPageDetail, MasterViewPageDetailViewModel>();
            containerRegistry.RegisterForNavigation<MasterViewPageMaster>();
            //containerRegistry.RegisterSingleton<MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
           
        }

        
    }
}
