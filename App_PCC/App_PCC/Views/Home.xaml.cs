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

        string message;

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
            //sairApp();
            App.Current.MainPage = new MainPage();
        }

        public Home()
        {
            InitializeComponent();
            Detail = new NavigationPage(new HomeDetail());
        }


        public async Task sairApp()
        {
            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/sair_app.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(App.user_in_id))
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic sair = JsonConvert.DeserializeObject(content);
            foreach (var item in sair)
            {
                message = item.Message;
            }
        }
    }
}