using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_PCC.Views;
using App_PCC.Services;

namespace App_PCC
{
    public partial class MainPage : ContentPage
    {

        public void Login(object sender, EventArgs e)
        {
            //App.Current.MainPage = new Home();
            if(etLogin.Text == "" || etSenha.Text == "")
            {
                DisplayAlert("Erro", "Preencha todos os campos!", "OK");
            }
            else
            {
                ServiceCadUser serviceCadUser = new ServiceCadUser(App.Caminho);

                if (serviceCadUser.verifUsuario(etLogin.Text, etSenha.Text))
                {
                    App.user_in_id = serviceCadUser.idUser(etLogin.Text, etSenha.Text);
                    DisplayAlert("Aviso", "Login efetuado com sucesso.", "OK");
                    App.Current.MainPage = new Home();
                }
                else
                {
                    DisplayAlert("Erro", "Login ou senha Inválidos", "OK");
                    etLogin.Text = "";
                    etSenha.Text = "";
                }
            }

        }

        public MainPage()
        {
            InitializeComponent();
            //Teste.Text = App.Caminho;
        }
    }
}
