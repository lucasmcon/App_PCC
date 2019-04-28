using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_PCC
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeDetail : ContentPage
	{
		public HomeDetail ()
		{
			InitializeComponent ();
            this.etRA.Text = Convert.ToString(App.alu_in_ra);
            this.etNome.Text = App.user_st_nome;
            this.etCurso.Text = App.cur_st_desc;
		}
	}
}