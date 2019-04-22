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
	public partial class CadastroMotivo : ContentPage
	{
		public CadastroMotivo ()
		{
			InitializeComponent ();
            SetorItems();
		}

        public void SetorItems()
        {
            ServiceCadSetor serviceCadSetor = new ServiceCadSetor(App.Caminho);
            pSetor.ItemsSource = serviceCadSetor.Listar();

            //pMotivo.ItemsSource = serviceCadSetor.Listar();
        }

        private void BtSalvar_Clicked(object sender, EventArgs e)
        {
            ServiceCadSetor serviceCadSetor = new ServiceCadSetor(App.Caminho);

            string set_st_desc = pSetor.Items[pSetor.SelectedIndex];
            int id = serviceCadSetor.idSetor(set_st_desc);
            
            //DisplayAlert("Aviso", "Teste: " + id , "OK");
            try
            {
                cad_tb_motivo cad_tb_motivo = new cad_tb_motivo();
                cad_tb_motivo.mot_st_desc = etDesc.Text;
                cad_tb_motivo.set_in_id = Convert.ToInt32(id);
                ServiceCadMotivo serviceMotivo = new ServiceCadMotivo(App.Caminho);
                serviceMotivo.Inserir(cad_tb_motivo);
                DisplayAlert("Aviso: ", serviceMotivo.Mensagem, "OK");

            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}