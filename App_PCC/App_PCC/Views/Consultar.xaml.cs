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
	public partial class Consultar : ContentPage
	{

        private string avisoCancelamento = "";

		public Consultar ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            await carregaChamado();
            if(etSenha.Text == "Null")
            {
                await DisplayAlert("ERRO", "Você não possui nenhuma solicitação aberta.", "OK");
                App.Current.MainPage = new Home();
            }

            if (etAtendente.Text != "Não atribuido")
            {
                lbSituacao.Text = "Chegou sua vez! Compareça à secretaria...";
                lbSituacao.BackgroundColor = Color.ForestGreen;
                lbSituacao.FontSize = 17;
                lbSituacao.FontAttributes = FontAttributes.Bold;
                Cancelar.IsVisible = false;
            }
            else if (etAtendente.Text == "Não atribuido")
            {
                lbSituacao.Text = "Aguarde sua vez...";
                lbSituacao.BackgroundColor = Color.Yellow;
                lbSituacao.FontSize = 17;
                lbSituacao.FontAttributes = FontAttributes.Bold;
            }
            else
            {
                lbSituacao.IsVisible = false;
            }

               
            
        }

        public async Task carregaChamado()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/consulta_atendimento.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(App.user_in_id)),
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic chamado = JsonConvert.DeserializeObject(content);
            foreach (var item in chamado)
            {
                etSenha.Text = item.senha.ToString();
                etAtendente.Text = item.atendente.ToString();
                etQtd.Text = item.senha_frente.ToString();
                etMesa.Text = item.mesa.ToString();
                etSetor.Text = item.setor.ToString();

            }
        }

        public async Task cancelarChamado()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/exclui_atendimento.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(App.user_in_id)),
                new KeyValuePair<string, string>("at_in_id", etSenha.Text)
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic chamado = JsonConvert.DeserializeObject(content);
            foreach (var item in chamado)
            {
                avisoCancelamento = item.Message.ToString();
            }
        }



        private async void Cancelar_Clicked(object sender, EventArgs e)
        {

            if(etAtendente.Text != "Não atribuido")
            {
                await DisplayAlert("ERRO", "Ei! Sua senha foi chamada, você não pode mais cancelar :(", "OK");
            }
            else
            {
                await cancelarChamado();

                if (avisoCancelamento == "Success")
                {
                    await DisplayAlert("AVISO", "Senha cancelada com sucesso.", "OK");
                    App.Current.MainPage = new Home();
                }
                else
                {
                    await DisplayAlert("AVISO", "Ops. Algo deu errado :(. Tente novamente", "OK");
                }
            }
        }
    }
}