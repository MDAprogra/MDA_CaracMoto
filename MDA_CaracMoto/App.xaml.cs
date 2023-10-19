namespace MDA_CaracMoto
{
    //public partial class App : Application
    //{
    //    public App()
    //    {
    //        InitializeComponent();

    //        MainPage = new AppShell();
    //    }



    //}
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState) =>
            new Window(new AppShell())
            {
                Width = 1920,  // Remplacez 1920 par la largeur de votre écran
                Height = 1080, // Remplacez 1080 par la hauteur de votre écran
                X = 0,         // Position X de la fenêtre (0 pour le coin supérieur gauche de l'écran)
                Y = 0

            };   
    }
}