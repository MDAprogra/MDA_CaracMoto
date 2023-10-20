using MDA_CaracMoto.Facto;
using System.Security;
using System.Text.RegularExpressions;

namespace MDA_CaracMoto.Pages;

public partial class AjouterMoto : ContentPage
{
    public string Extension { get; set; }

    private readonly IDataService _dataService;
    public AjouterMoto()
    {
        InitializeComponent();
        _dataService = Application.Current.MainPage
                .Handler
                .MauiContext
                .Services
                .GetService<IDataService>();
    }
    async void Btn_Valider(object sender, EventArgs e)
    {
        if (Marque.Text == null || Modele.Text == null || Reference.Text == null)
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs", "OK");
            return;
        }
        Extension=ChoixExt.SelectedItem.ToString();
        CaracMoto moto = new CaracMoto
        {
            Ref = Reference.Text,
            Marque = Marque.Text,
            Modele = Modele.Text,
            Annee = Convert.ToInt32(Annee.Text),
            Prix = Convert.ToInt32(Prix.Text),
            CV = Convert.ToInt32(CV.Text),
            KW = Convert.ToInt32(KW.Text),
            Poids = Convert.ToInt32(Poids.Text),
            Img = Image.Text.Trim() + Extension,
            Audio = Audio.Text.Trim()
        };
        _dataService.AddMoto(moto);
        await DisplayAlert("Ajout", "Moto ajoutée", "OK");
        await Navigation.PopAsync();
        Reference.Text = "";
        Marque.Text = "";
        Modele.Text = "";
        Annee.Text = "";
        Prix.Text = "";
        CV.Text = "";
        KW.Text = "";
        Poids.Text = "";
        ChoixExt.SelectedItem = null;
        Image.Text = "";
        Audio.Text = "";
    }
}