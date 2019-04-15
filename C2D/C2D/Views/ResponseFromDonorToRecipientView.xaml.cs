using C2D.Model;
using C2D.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C2D.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResponseFromDonorToRecipientView : ContentPage
	{
        int status = 0;
		public ResponseFromDonorToRecipientView ()
		{
			InitializeComponent ();
            BindListView();

        }

        private async void BindListView()
        {
            ResponseRequestViewModel responseRequestViewModel = new ResponseRequestViewModel();
            List<Response> data = await responseRequestViewModel.SearchByRecipientUserName(Application.Current.Properties["UserName"].ToString());
            ListviewResponse.ItemsSource = data;
        }
        //private void btnAccept_Clicked(object sender, EventArgs e)
        //{
        //  //  var button = (Button)sender;
        //   // var row = Grid.GetRow(button);
        //    //var desc = grid.Children.Where(c => Grid.GetRow(c) == row && Grid.GetColumn(c) == 1);
            
        //    status = 1;
        //    ResponseRequestViewModel requestsOfRecipientView = new ResponseRequestViewModel();
        //    requestsOfRecipientView.SetStatus( description.Text, status);
           
        //}

        //private void btnReject_Clicked(object sender, EventArgs e)
        //{
        //    status = -1;
        //}

    }
}