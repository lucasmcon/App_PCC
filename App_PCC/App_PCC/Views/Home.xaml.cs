using App_PCC.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_PCC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : MasterDetailPage
    {

        public void AbrirChamado(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new NovoChamado());
            IsPresented = false;
        }

        public void ConsultarChamado(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new Consultar());
            IsPresented = false;
        }

        public void Historico(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new Historico());
            IsPresented = false;
        }

        public void AlterarSenha(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new AlterarSenha());
            IsPresented = false;
        }

        public void Sair(object sebder, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        public Home()
        {
            InitializeComponent();
            Detail = new NavigationPage(new HomeDetail());
        }
    }
}