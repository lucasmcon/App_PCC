using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_PCC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Teste : ContentPage
	{
		public Teste ()
		{
			InitializeComponent ();
		}

        private void Teste_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("UNIFAAT", "Sua vez está chegando!");
        }
    }
}