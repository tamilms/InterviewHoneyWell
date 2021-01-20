using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinInterviewTask.ViewModels;

namespace XamarinInterviewTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterViewPageDetail : ContentPage
    {
        public MasterViewPageDetail()
        {
            InitializeComponent();
            ViewModelLocationProvider.Register<MasterViewPageDetail, MasterViewPageDetailViewModel>();

        }

    }
}
