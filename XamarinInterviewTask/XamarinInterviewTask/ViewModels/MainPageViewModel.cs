using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinInterviewTask.Constants;
using XamarinInterviewTask.Models;
using XamarinInterviewTask.Services;
using XamarinInterviewTask.Views;

namespace XamarinInterviewTask.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region privateVariable
        private INavigationService _navigationService { get; }
        private IPageDialogService _dialogService;
      
        private ObservableCollection<Hit> countryList;
        private Hit selectedItem;
        private string searchTopic;
        private bool showLoadingIndicator;
        #endregion

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            PageTitle = " Page";
            _navigationService = navigationService;
            _dialogService = dialogService;
            ItemTappedCommand = new DelegateCommand<Hit>(ItemTapped);
            SearchCommand = new DelegateCommand(async()=> await GetSearchTopic());
        }

        #region Properties
        public bool ShowLoadingIndicator
        {
            get => showLoadingIndicator;
            set { SetProperty(ref showLoadingIndicator, value); }
        }
        public Hit SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        public string SearchTopic
        {
            get { return searchTopic; }
            set
            {

                SetProperty(ref searchTopic, value);


            }
        }


        public ObservableCollection<Hit> CountryList
        {
            get => countryList;
            set { SetProperty(ref countryList, value); }
        }
        #endregion

        #region Methods
        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            await GetListOfNewsHeadlines();
        }

        private void ItemTapped(Hit item)
        {
            SelectedItem = item;
            //PageTitle = item.name;

            if (Device.Idiom == TargetIdiom.Phone)
            {
                var navigationParams = new NavigationParameters();
                navigationParams.Add("model", item);
                _navigationService.NavigateAsync("MasterViewPageDetail", navigationParams);
                
            }

        }

        private async Task GetListOfNewsHeadlines(string search="")
        {
            ShowLoadingIndicator = true;
            var searchString = string.Empty;
            if(search!="")
            {
                searchString = string.Format(AppConstants.SearchTopic, search, 1);
            }
            else
            {
                searchString = AppConstants.NewArticleFrontPage;
            }
            var responseData = await WebServices.RestCalls<NewsHeadlinesModel, string>(searchString, HttpMethod.Get, "");

            if (responseData != null)
            {
                ShowLoadingIndicator = false;
                if (responseData.Message != null && !responseData.IsSuccess)
                {
                    await _dialogService.DisplayAlertAsync("Alert", responseData.Message, "OK");
                }
                else
                {
                    if(CountryList!=null)
                    {
                        CountryList.Clear();

                    }
                    var data = responseData.Data;
                    CountryList = new ObservableCollection<Hit>(data.hits);
                }
            }
        }

        private async Task GetSearchTopic()
        {
            await GetListOfNewsHeadlines(SearchTopic);
        }

       
        #endregion

        #region Command
        public DelegateCommand<Hit> ItemTappedCommand { get; }
        public DelegateCommand SearchCommand { get; }
        public DelegateCommand<string> NavigateCommand { get; }
       
        #endregion

    }
}
