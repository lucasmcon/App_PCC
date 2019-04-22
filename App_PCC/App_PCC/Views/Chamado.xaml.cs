using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_PCC.Models;
using App_PCC.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_PCC
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Chamado : ContentPage
	{
        glo_tb_atendimento glo_tb_atendimento = new glo_tb_atendimento();
        ServiceCadSetor serviceCadSetor = new ServiceCadSetor(App.Caminho);
        ServiceCadMotivo serviceCadMotivo = new ServiceCadMotivo(App.Caminho);


        public Chamado ()
		{
			InitializeComponent ();
            SetorItems();
		}

        public void SetorItems()
        {
            //ServiceCadSetor serviceCadSetor = new ServiceCadSetor(App.Caminho);
           // ServiceCadMotivo serviceCadMotivo = new ServiceCadMotivo(App.Caminho);
            pSetor.ItemsSource = serviceCadSetor.Listar();
            //pMotivo.ItemsSource = serviceCadMotivo.Listar();    
        }

        private void PSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ServiceCadSetor serviceCadSetor = new ServiceCadSetor(App.Caminho);
            //ServiceCadMotivo serviceCadMotivo = new ServiceCadMotivo(App.Caminho);

            string set_st_desc = pSetor.Items[pSetor.SelectedIndex];
            int id = serviceCadSetor.idSetor(set_st_desc);
            pMotivo.ItemsSource = serviceCadMotivo.Listar(id);
        }

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            //glo_tb_atendimento glo_tb_atendimento = new glo_tb_atendimento();
            string set_st_desc = pSetor.Items[pSetor.SelectedIndex];
            glo_tb_atendimento.set_in_id = serviceCadSetor.idSetor(set_st_desc);
            glo_tb_atendimento.at_in_aluno = App.user_in_id;

            
        }
    }
}