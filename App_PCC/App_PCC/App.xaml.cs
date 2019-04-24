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

        public static String BancoDados;
        public static String Caminho;
        public static int user_in_id;
        public static int alu_in_ra;
        public static string user_st_nome;
        public static string cur_st_desc;
        public static string notifica_resume;
        public static string notifica_sleep;

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
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(5);

            var timer = new System.Threading.Timer(async (e) =>
            {
                await notificaSleep();
                if (notifica_sleep != "ERRO")
                {
                    CrossLocalNotifications.Current.Show("Secretaria UNIFAAT", "Sua senha foi chamada! Consulte os detalhes no App :)");
                }

            }, null, startTimeSpan, periodTimeSpan);

            //CrossLocalNotifications.Current.Show("Secretaria UNIFAAT", "Sua vez está chegando! Consulte sua senha :)");
        }

        protected override void OnResume()
        {
             //Handle when your app resumes

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(5);

            var timer = new System.Threading.Timer(async (e) =>
            {
                await notificaResume();
                if(notifica_resume != "ERRO")
                {
                    CrossLocalNotifications.Current.Show("Secretaria UNIFAAT", "Sua senha foi chamada! Consulte os detalhes no App :)");
                }
                
            }, null, startTimeSpan, periodTimeSpan);
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
    }
}
