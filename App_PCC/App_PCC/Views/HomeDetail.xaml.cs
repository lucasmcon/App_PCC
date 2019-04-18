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
            this.etNome.Text = "Lucas Menezes";
            this.etRA.Text = Convert.ToString(App.user_in_id);
            this.etCurso.Text = "ADS";
		}
	}
}