using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App_PCC
{
    public partial class App : Application
    {

        public static String BancoDados;
        public static String Caminho;
        public static int user_in_id;
        

        public App(string Caminho, string BancoDados)
        {
            InitializeComponent();
            App.BancoDados = BancoDados;
            App.Caminho = Caminho;

            MainPage = new MainPage();
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
