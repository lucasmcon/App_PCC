using App_PCC.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Detail.Navigation.PushAsync(new Chamado());
            IsPresented = false;
        }

        public void ConsultarChamado(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new Consultar());
            IsPresented = false;
        }

        public void CadastroUsuario(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new CadastroUsuario());
            IsPresented = false;
        }

        public void CadastroSetor(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new CadastroSetor());
            IsPresented = false;
        }

        public void CadastroMotivo(object sender, EventArgs e)
        {
            Detail.Navigation.PushAsync(new CadastroMotivo());
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