using MDA_CaracMoto.Facto;
using Plugin.Maui.Audio;
using System.Collections.ObjectModel;

namespace MDA_CaracMoto.Pages;

public partial class AffichageMoto : ContentPage
{
	public readonly IDataService _dataService;
    private readonly IAudioManager audioManager;


    public AffichageMoto(IAudioManager audioManager)
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

        //Audio
        this.audioManager = audioManager;
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
        Navigation.PushAsync(new ModifPage(item));
    }
    public async void Btn_Play_Clicked(object sender, EventArgs e)
    {
        //var NomAudio = (string)(sender as ImageButton).CommandParameter;
        //var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(NomAudio));
        var NomAudio = (string)(sender as ImageButton).CommandParameter;

        //var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sound_sv650.mp3"));
        try
        {
            //var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sound_sv650.mp3"));

            //var NomAudio = (string)(sender as ImageButton).CommandParameter;
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(NomAudio));
            player.Play();

        }
        catch (Exception)
        {
            await DisplayAlert("Erreur", "Audio Introuvable. Veuillez v�rifier le nom de l'audio.", "OK");
        }
    }    
}
