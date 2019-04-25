using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_PCC.Views;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace App_PCC
{
    public partial class MainPage : ContentPage
    {

        private string verifLogin = "";
        private string user_in_id = "";
        private string user_st_nome = "";
        private string cur_st_desc = "";
        private string alu_in_ra;



        public async Task loginMobile(string login, string senha)
        {
            
            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/login.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("login", login),
                new KeyValuePair<string, string>("senha", senha)
            };
            
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();
            
            dynamic json = JsonConvert.DeserializeObject(content);
            foreach (var item in json)
            {
                user_in_id = item.user_in_id;
                verifLogin = item.user_st_login;
                alu_in_ra = item.alu_in_ra;
                user_st_nome = item.user_st_nome;
                cur_st_desc = item.cur_st_desc;
            }
        }

        public async Task sessaoMobile()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/sessao.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", user_in_id)
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic json = JsonConvert.DeserializeObject(content);
            foreach (var item in json)
            {
                string sessao = item.Message.ToString();
            }
        }

        public async void LoginAsync(object sender, EventArgs e)
        {  
            if(etLogin.Text == "" || etSenha.Text == "")
            {
                await DisplayAlert("Erro", "Preencha todos os campos!", "OK");
            }
            else
            {
                string validaLogin = etLogin.Text;
                await loginMobile(etLogin.Text, etSenha.Text);

                if (validaLogin == verifLogin)
                {
                    App.user_in_id = Convert.ToInt32(user_in_id);
                    App.alu_in_ra = Convert.ToInt32(alu_in_ra);
                    App.user_st_nome = user_st_nome;
                    App.cur_st_desc = cur_st_desc;

                    await sessaoMobile();

                    await DisplayAlert("Aviso", "Login efetuado com sucesso.", "OK");
                    App.Current.MainPage = new Home();
                }
                else
                {
                    await DisplayAlert("Erro", "Login/Senha inválido", "OK");
                    etLogin.Text = "";
                    etSenha.Text = "";
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            
            //DisplayAlert("AVISO", "Você foi desconectado do App :(", "OK");
            //App.user_in_id = 0;
            
        }

        protected override async void OnAppearing()
        {
            if(App.user_in_id == -1)
            {
                App.user_in_id = 0;
                await DisplayAlert("AVISO", "Você foi desconectado do App :(", "OK");
            }
            
        }

    }
}
