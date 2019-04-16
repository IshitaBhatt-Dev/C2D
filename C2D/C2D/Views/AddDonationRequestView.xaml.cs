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
	public partial class AddDonationRequest : ContentPage
	{
        private bool requestStatus;
		public AddDonationRequest ()
		{
            if (Application.Current.Properties["UserName"] != null)
                InitializeComponent();
            else
                Navigation.PushAsync(new C2D.RequestsOfRecipientView());
		}
        public void btnAddNewRequest(object sender, EventArgs e)
        {
            DonationRequestsViewModel request = new DonationRequestsViewModel();
            DonationRequests donationRequest = new DonationRequests();

            donationRequest.title = title.Text;
            donationRequest.description = description.Text;
            donationRequest.username = Application.Current.Properties["UserName"].ToString();
            donationRequest.keyword1 = key1.Text;
            donationRequest.keyword2 = key2.Text;
            donationRequest.status = requestStatus;
            request.AddNewDonationRequest(donationRequest);
            
        }
        private void btnViewRequests(object sender, ToggledEventArgs e)
        {
            Navigation.PushAsync(new RequestsOfRecipientView());
        }
        private void switch_Toggled(object sender, ToggledEventArgs e)
        {
            requestStatus = e.Value;
        }

        private void btnViewResponses(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResponseFromDonorToRecipientView());
        }
    }
}