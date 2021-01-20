using System;
using Prism.Navigation;
using Prism.Services;
using XamarinInterviewTask.Models;

namespace XamarinInterviewTask.ViewModels
{
    public class MasterViewPageDetailViewModel : ViewModelBase
    {
        #region Variable
        private Hit newsDetail;
        #endregion

        public MasterViewPageDetailViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
        }
        #region Properties
        public Hit NewsDetail
        {
            get { return newsDetail; }
            set { SetProperty(ref newsDetail, value); }
        }
        #endregion

        #region Method
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            if(parameters!=null)
            {
                NewsDetail = parameters["model"] as Hit;
            }
        }
        #endregion
    }
}
