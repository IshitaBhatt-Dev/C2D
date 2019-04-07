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
	public partial class UpdateDonationRequest : ContentPage
	{
        private bool requestStatus;
        private String id;


        public UpdateDonationRequest(string s)
        {
            InitializeComponent();
            id = s;
            getUser();
        }
        public async void getUser()
        {
            ListDonationRequestsViewModel listDonationRequestsViewModel = new ListDonationRequestsViewModel();
            DonationRequests d = await listDonationRequestsViewModel.SearchById(id);

            title.Text = d.title;
            description.Text = d.description;
            key1.Text = d.keyword1;
            key2.Text = d.keyword2;

            if (d.status)
            {
                requestSwitch.IsToggled = true;
            }
            else
            {
                requestSwitch.IsToggled = false;
            }



        }
        public void btnUpdateDonationRequest(object sender, EventArgs e)
        {

            ListDonationRequestsViewModel listDonationRequestsViewModel = new ListDonationRequestsViewModel();
            DonationRequests dr = new DonationRequests
            {
                title = title.Text,
                description = description.Text,
                keyword1 = key1.Text,
                keyword2 = key2.Text,
                username = Application.Current.Properties["UserName"].ToString(),
                status = requestSwitch.IsToggled

            };
             listDonationRequestsViewModel.UpdateItem(dr, id);

             Navigation.PushAsync(new RequestsOfRecipientView());


        }

        private void switch_Toggled(object sender, ToggledEventArgs e)
        {
            requestStatus = e.Value;
        }

    }
}
