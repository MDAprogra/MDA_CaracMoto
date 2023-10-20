using MDA_CaracMoto.Facto;
using Microsoft.Identity.Client;
using Plugin.Maui.Audio;
using System.Collections.ObjectModel;

namespace MDA_CaracMoto.Pages;

public partial class ModifPage : ContentPage
{
    public readonly IDataService _dataService;
    public readonly IAudioManager audioManager;
    public int idMoto { get; set;}
    public ModifPage(int id)
    {
        InitializeComponent();
        this.audioManager = audioManager;
        idMoto = id;
        _dataService = Application.Current.MainPage
                .Handler
                .MauiContext
                .Services
                .GetService<IDataService>();
        var moto = _dataService.GetMotoID(id);
        ModifAnnee.Text = moto.Annee.ToString();
        ModifCV.Text = moto.CV.ToString();
        ModifKW.Text = moto.KW.ToString();
        ModifMarque.Text = moto.Marque;
        ModifModele.Text = moto.Modele;
        ModifPoids.Text = moto.Poids.ToString();
        ModifPrix.Text = moto.Prix.ToString();
        ModifRef.Text = moto.Ref;
    }
    public void ModifButton_Clicked(object sender, EventArgs e)
    {
        
        CaracMoto moto = new CaracMoto
        {
            Ref = ModifRef.Text,
            Marque = ModifMarque.Text,
            Modele = ModifModele.Text,
            Annee = Convert.ToInt32(ModifAnnee.Text),
            Prix = Convert.ToInt32(ModifPrix.Text),
            CV = Convert.ToInt32(ModifCV.Text),
            KW = Convert.ToInt32(ModifKW.Text),
            Poids = Convert.ToInt32(ModifPoids.Text)
        };
        if (moto.Ref.Trim() == "" || moto.Marque.Trim() == "" || moto.Modele.Trim() == "")
        {
            DisplayAlert("Erreur", "Veuillez remplir tous les champs", "OK");
            return;
        }
        _dataService.ModifMoto(moto, idMoto);
        Navigation.PushAsync(new AffichageMoto(audioManager));
    }
}