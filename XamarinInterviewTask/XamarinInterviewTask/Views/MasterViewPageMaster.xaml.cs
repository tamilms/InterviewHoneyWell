using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinInterviewTask.ViewModels;

namespace XamarinInterviewTask.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterViewPageMaster : ContentPage
    {
        public ListView ListView;

        public MasterViewPageMaster()
        {
            InitializeComponent();

            ViewModelLocationProvider.Register<MasterViewPageMaster, MainPageViewModel>();

        }

    }
}
