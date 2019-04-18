using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_PCC.Models;
using App_PCC.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_PCC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroUsuario : ContentPage
	{
		public CadastroUsuario ()
		{
			InitializeComponent ();
		}

        private void BtSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                cad_tb_user cad_tb_user = new cad_tb_user();
                cad_tb_user.user_st_nome = etNome.Text;
                cad_tb_user.user_st_login = etLogin.Text;
                cad_tb_user.user_st_senha = etSenha.Text;
                cad_tb_user.user_st_email = etEmail.Text;
                cad_tb_user.user_dt_cad = DateTime.Now;
                cad_tb_user.user_in_status = 1;
                
                ServiceCadUser serviceCad = new ServiceCadUser(App.Caminho);

                serviceCad.Inserir(cad_tb_user);
                DisplayAlert("Aviso: ", serviceCad.Mensagem, "OK");

                
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void BtCancelar_Clicked(object sender, EventArgs e)
        {

        }
    }
}