using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App_PCC.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_PCC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlterarSenha : ContentPage
	{

        private string retorno = "";

        public AlterarSenha ()
		{
			InitializeComponent ();
            etRA.Text = Convert.ToString(App.alu_in_ra);
            etNome.Text = App.user_st_nome;
		}

        private async void BtAlterarSenha_Clicked(object sender, EventArgs e)
        {
            if (!NetworkCheck.IsInternet())
            {
                await DisplayAlert("ERRO", "Sem conexão com a internet :(", "OK");
            }
            else
            {
                if (NetworkCheck.IsInternet())
                {
                    actInd.IsVisible = true;
                    if (etSenhaAtual.Text == null || etNovaSenha.Text == null || etConfirmaSenha.Text == null)
                    {
                        await DisplayAlert("ERRO", "Preencha todos os campos.", "OK");
                        actInd.IsVisible = false;
                    }
                    else if (etNovaSenha.Text != etConfirmaSenha.Text)
                    {
                        await DisplayAlert("ERRO", "As novas senhas não coincidem.", "OK");
                        actInd.IsVisible = false;
                        etNovaSenha.Text = "";
                        etConfirmaSenha.Text = "";
                        etNovaSenha.Focus();
                    }
                    else
                    {
                        await alteraSenha();
                        if (retorno == "Error")
                        {
                            await DisplayAlert("ERRO", "Senha antiga incoreta.", "OK");
                            actInd.IsVisible = false;
                            etSenhaAtual.Text = "";
                            etSenhaAtual.Focus();
                        }
                        else
                        {
                            await DisplayAlert("AVISO", "Senha atualizada com sucesso.", "OK");
                            actInd.IsVisible = false;
                            App.Current.MainPage = new Home();
                        }
                    }
                }
                else
                {
                    await DisplayAlert("ERRO", "Sem conexão com a internet :(", "OK");
                }
            }
        }

        private async Task alteraSenha()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/atualiza_senha.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(App.user_in_id)),
                new KeyValuePair<string, string>("user_st_senha", etSenhaAtual.Text),
                new KeyValuePair<string, string>("senha_nova", etNovaSenha.Text)
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic chamado = JsonConvert.DeserializeObject(content);
            foreach (var item in chamado)
            {
                retorno = item.Message.ToString();
            }
        }
    }
}