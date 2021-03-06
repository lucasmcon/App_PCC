﻿using App_PCC.Services;
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
	public partial class NovoChamado : ContentPage
	{

        string confirmaChamado = "";

        public NovoChamado ()
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
                await carregaSetor();
            }  
        }
        public async Task carregaSetor()
        {
      
            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/setor.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("set_in_id", "0"),
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic setor = JsonConvert.DeserializeObject(content);
            foreach (var item in setor)
            {
                pSetor.Items.Add(item.set_st_desc.ToString());
            }
        }

        public async Task carregaMotivo()
        {
            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/motivo.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("set_st_desc", pSetor.Items[pSetor.SelectedIndex]), // $_POST['set_st_desc'] = Valor selecionado no Picker
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic motivo = JsonConvert.DeserializeObject(content);
            foreach (var item in motivo)
            {
                pMotivo.Items.Add(item.mot_st_desc.ToString());
            }
        }

        private async Task salvarChamado()
        {
            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/atendimento.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(App.user_in_id)),
                new KeyValuePair<string, string>("set_st_desc", pSetor.Items[pSetor.SelectedIndex]),
                new KeyValuePair<string, string>("mot_st_desc", pMotivo.Items[pMotivo.SelectedIndex]),
                new KeyValuePair<string, string>("at_st_desc", Desc.Text)
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic atendimento = JsonConvert.DeserializeObject(content);
            foreach (var item in atendimento)
            {
                confirmaChamado = item.Message.ToString();   
            }
        }


        private async Task senhaFrenteSetor()
        {
            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/total_atend_aberto_setor.php");
            var postData = new List<KeyValuePair<string, string>>
            { 
                new KeyValuePair<string, string>("set_st_desc", pSetor.Items[pSetor.SelectedIndex])
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic qtd_senha = JsonConvert.DeserializeObject(content);
            foreach (var item in qtd_senha)
            {
                lbSenhaFrente.Text = "Senhas na frente: " + item.qtd.ToString();
            }
        }


        private async void PSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!NetworkCheck.IsInternet())
            {
                pMotivo.Items.Clear();
                await DisplayAlert("ERRO", "Sem conexão com a internet :(", "OK");
            }
            else
            {
                pMotivo.Items.Clear();
                if (!NetworkCheck.IsInternet())
                {
                    await DisplayAlert("ERRO", "Sem conexão com a internet :(", "OK");
                }
                else
                {
                    await carregaMotivo();
                    await senhaFrenteSetor();
                }
            }
        }

        private async void Salvar_ClickedAsync(object sender, EventArgs e)
        {
            if (!NetworkCheck.IsInternet())
            {
                await DisplayAlert("ERRO", "Sem conexão com a internet :(", "OK");
            }
            else
            {
                actInd.IsVisible = true;
                if (pSetor.SelectedIndex == -1 || pMotivo.SelectedIndex == -1)
                {
                    await DisplayAlert("AVISO", "Informe o setor e o motivo.", "OK");
                    actInd.IsVisible = false;
                }
                else
                {
                    actInd.IsVisible = true;
                    await salvarChamado();
                    if (confirmaChamado == "Success")
                    {
                        await DisplayAlert("AVISO", "Senha gerada com sucesso. Você será chamado em breve", "OK");
                        actInd.IsVisible = false;
                        App.Current.MainPage = new Home();
                    }
                    else if (confirmaChamado == "Warning")
                    {
                        await DisplayAlert("AVISO - SENHA PENDENTE!", "Você possui uma senha pendente, finalize antes.", "OK");
                        actInd.IsVisible = false;
                        App.Current.MainPage = new Home();
                    }
                    else
                    {
                        await DisplayAlert("ERRO", "Ops. A senha não foi gerada. Tente novamente", "OK");
                        actInd.IsVisible = false;
                    }
                }
            }
        }
    }
}