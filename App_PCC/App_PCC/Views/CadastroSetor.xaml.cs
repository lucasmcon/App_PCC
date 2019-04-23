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
	public partial class CadastroSetor : ContentPage
	{
		public CadastroSetor ()
		{
			InitializeComponent ();
		}

        private void BtSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //cad_tb_setor cad_tb_setor = new cad_tb_setor();
                //cad_tb_setor.set_st_desc = etDesc.Text;

                //ServiceCadSetor serviceSetor = new ServiceCadSetor(App.Caminho);
                //serviceSetor.Inserir(cad_tb_setor);
                //DisplayAlert("Aviso: ", serviceSetor.Mensagem, "OK");

            }catch(Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}