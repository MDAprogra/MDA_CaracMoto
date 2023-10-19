using MDA_CaracMoto.Facto;
using MDA_CaracMoto.Pages_Fun;

namespace MDA_CaracMoto
{
    public partial class MainPage : ContentPage
    {
        private readonly IDataService _dataService;
        public MainPage()
        {
            InitializeComponent();
            _dataService = Application.Current.MainPage
                .Handler
                .MauiContext
                .Services
                .GetService<IDataService>();
        }

        private async void ClickImg(object sender, TappedEventArgs e)
        {
            await Lb_Slt.FadeTo(0, 250);
            await ImgMoto.FadeTo(0,250);
            var Gmoto = new GirlMoto();
            await Navigation.PushAsync(Gmoto);  
            await ImgMoto.FadeTo(100,0);
            await Lb_Slt.FadeTo(100,0);
        }
    }
}