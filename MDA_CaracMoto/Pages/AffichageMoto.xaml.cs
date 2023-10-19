using MDA_CaracMoto.Facto;
using Plugin.Maui.Audio;
using System.Collections.ObjectModel;

namespace MDA_CaracMoto.Pages;

public partial class AffichageMoto : ContentPage
{
	public readonly IDataService _dataService;

    public AffichageMoto()
	{
		InitializeComponent();
        _dataService = Application.Current.MainPage
                .Handler
                .MauiContext
                .Services
                .GetService<IDataService>();
        var moto = _dataService.GetMoto();
        ObservableCollection<CaracMoto> motos = new ObservableCollection<CaracMoto>(moto);
        ListMoto.ItemsSource = motos;
    }
    public void DeleteBTN_Clicked(object sender, EventArgs e)
    {
        var item = (int)(sender as ImageButton).CommandParameter;
        _dataService.DelMoto(item);
        var moto = _dataService.GetMoto();
        ObservableCollection<CaracMoto> motos = new ObservableCollection<CaracMoto>(moto);
        ListMoto.ItemsSource = motos;
    }
    public void ModifBTN_Clicked(object sender, EventArgs e)
    {
        var item = (int)(sender as ImageButton).CommandParameter;
        //To ModifPage
        Navigation.PushAsync(new ModifPage(item));
    }
}
