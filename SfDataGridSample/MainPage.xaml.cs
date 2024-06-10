using SfDataGridSample.ViewModel;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected  override void OnAppearing()
        {
            base.OnAppearing();
            _stockViewModel.InitialyzeAsync();
        }

    }

}
