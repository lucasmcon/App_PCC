using App_PCC.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_PCC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Historico : ContentPage
	{
        List<String> itens = new List<String>();

        public Historico ()
		{
			InitializeComponent ();
        }

        protected override async void OnAppearing()
        {
            if (!NetworkCheck.IsInternet())
            {
                await DisplayAlert("ERRO", "Sem conexão com a internet :(", "OK");
                App.Current.MainPage = new Home();
            }
            else
            {
                if (NetworkCheck.IsInternet())
                {
                    await carregaHistorico();
                    listaHistorico.ItemsSource = itens;
                    
                }
                else
                {
                    await DisplayAlert("ERRO", "Sem conexão com a internet :(", "OK");
                }
            }
        }

        public async Task carregaHistorico()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/historico.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(App.user_in_id))
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic historico = JsonConvert.DeserializeObject(content);
            
            foreach (var item in historico)
            {
                itens.Add("Senha: " + item.senha.ToString() + " | Setor: " + item.setor.ToString() + " | Data: "+ item.data.ToString());
            }
        }
    }
}