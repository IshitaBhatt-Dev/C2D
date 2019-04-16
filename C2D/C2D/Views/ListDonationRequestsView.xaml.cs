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
    public partial class ListDonationRequestsView : ContentPage
    {
        List<DonationRequests> allItems;
        public ListDonationRequestsView()
        {
            InitializeComponent();

            bindListView();

        }
        public async void bindListView()
        {
            ListDonationRequestsViewModel list = new ListDonationRequestsViewModel();

            allItems = await list.GetAllItems();
            ListviewRequests.ItemsSource = allItems;
          

            }

            private void SearchbarRequests_SearchButtonPressed(object sender, EventArgs e)
            {
            string keyword = SearchbarRequests.Text;
            if(!keyword.Equals(null))
                ListviewRequests.ItemsSource = allItems.Where(i=>(i.keyword1.ToLower().Contains(keyword.ToLower())) || (i.keyword2.ToLower().Contains(keyword.ToLower())));
            else
                ListviewRequests.ItemsSource = allItems;
        }

            private void ListviewRequests_ItemTapped(object sender, ItemTappedEventArgs e)
            {
            var itemDetails = e.Item as DonationRequests;
            string title = itemDetails.title.ToString();
            string desc = itemDetails.description.ToString();
            string recipientUsername = itemDetails.username.ToString();
            string requestId =itemDetails.Id.ToString();
            Navigation.PushAsync(new ResponseDonationRequests(title,desc, recipientUsername,requestId));
            }
        }
    }