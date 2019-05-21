using App_PCC.Services;
using Newtonsoft.Json;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App_PCC
{
    public partial class App : Application
    {
        
        public static int user_in_id = 0;
        public static int alu_in_ra;
        public static string user_st_nome;
        public static string cur_st_desc;
        public static string notifica_resume;
        public static string notifica_sleep;
        public static string alerta_sleep;
        public static string alerta_resume;
        public static string monitora_sessao;
        public static string ausente_sleep;

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts

            if (!NetworkCheck.IsInternet())
            {
                MainPage.DisplayAlert("ERRO", "Sem conexão com a internet :(", "OK");
            }
            else
            {
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(5);
                var timer = new System.Threading.Timer(async (e) =>
                {
                    if (NetworkCheck.IsInternet())
                    {
                        await monitoraSessao();
                        if (monitora_sessao == "Error" && user_in_id > 0)
                        {
                            user_in_id = -1;
                            App.Current.MainPage = new MainPage();
                        }

                    }
                }, null, startTimeSpan, periodTimeSpan);

            }

        }
        
        protected override void OnSleep()
        {
            // Handle when your app sleeps

            if (!NetworkCheck.IsInternet())
            {
                CrossLocalNotifications.Current.Show("Secretaria UNIFAAT", "Sem conexão com a internet. Reinicie o App :(");
            }
            else
            {
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(5);
                var timer = new System.Threading.Timer(async (e) =>
                {
                    if (NetworkCheck.IsInternet())
                    {
                        await notificaSleep();
                        await alertaSleep();
                        //await ausenciaSleep();
                        if (notifica_sleep != "ERRO")
                        {
                            CrossLocalNotifications.Current.Show("Secretaria UNIFAAT", "Sua senha foi chamada! Consulte os detalhes no App :)");
                        }
                        if (alerta_sleep != "ERRO")
                        {
                            CrossLocalNotifications.Current.Show("Secretaria UNIFAAT", "Sua vez está chegando! Dirija-se à secretaria :)");
                        }
                    }
                }, null, startTimeSpan, periodTimeSpan);

            }
        }
        protected override void OnResume()
        {
            //Handle when your app resumes

            if (!NetworkCheck.IsInternet())
            {
                MainPage.DisplayAlert("ERRO", "Sem conexão com a internet :(", "OK");
            }
            else
            {
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(5);
                var timer = new System.Threading.Timer(async (e) =>
                {
                    if (NetworkCheck.IsInternet())
                    {
                        await notificaResume();
                        await alertaResume();
                        if (notifica_resume != "ERRO")
                        {
                            CrossLocalNotifications.Current.Show("Secretaria UNIFAAT", "Sua senha foi chamada! :)");
                        }
                        if(alerta_resume != "ERRO")
                        {
                            CrossLocalNotifications.Current.Show("Secretaria UNIFAAT", "Sua vez está chegando! Dirija-se à secretaria :)");
                        }
                    }
                }, null, startTimeSpan, periodTimeSpan);

            }
        }

        private async Task monitoraSessao()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/monitora_sessao.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(user_in_id))
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic chamado = JsonConvert.DeserializeObject(content);
            foreach (var item in chamado)
            {
                monitora_sessao = item.Message.ToString();
            }

        }

        private async Task notificaResume()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/notifica_atendimento.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(user_in_id)),
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic chamado = JsonConvert.DeserializeObject(content);
            foreach (var item in chamado)
            {
                notifica_resume = item.at_in_id.ToString();
            }   
        }

        private async Task notificaSleep()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/notifica_atendimento.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(user_in_id)),
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic chamado = JsonConvert.DeserializeObject(content);
            foreach (var item in chamado)
            {
                notifica_sleep = item.at_in_id.ToString();
            }
        }

        private async Task alertaSleep()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/alerta_atendimento.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(user_in_id)),
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic chamado = JsonConvert.DeserializeObject(content);
            foreach (var item in chamado)
            {
                alerta_sleep = item.Message.ToString();
            }
        }

        private async Task alertaResume()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/alerta_atendimento.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(user_in_id)),
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic chamado = JsonConvert.DeserializeObject(content);
            foreach (var item in chamado)
            {
                alerta_resume = item.Message.ToString();
            }
        }

        private async Task ausenciaSleep()
        {

            Uri uri = new Uri("http://suportefinancas.com.br/pcc/services/mobile/ausencia_atendimento.php");
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_in_id", Convert.ToString(user_in_id)),
            };

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new FormUrlEncodedContent(postData);
            HttpClient client = new HttpClient();
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();

            dynamic chamado = JsonConvert.DeserializeObject(content);
            foreach (var item in chamado)
            {
                ausente_sleep = item.Message.ToString();
            }
        }

    }
}
