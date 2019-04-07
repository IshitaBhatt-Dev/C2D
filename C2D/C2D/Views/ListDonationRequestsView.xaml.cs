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
		public ListDonationRequestsView ()
		{
			InitializeComponent ();
            Get_All();

        }
        protected async void Get_All()
        {
            ListDonationRequestsViewModel list = new ListDonationRequestsViewModel();
            var allItems = await list.GetAllItems();;

            var lbl = new Label
            {

                Text = "TITLE",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl, 1, 0);
            var lbl1 = new Label
            {
                Text = "DESCRIPTION",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl1, 3, 0);
            var lbl6 = new Label
            {
                Text = "",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            gridLayout.Children.Add(lbl6, 5, 0);

            int rowIndex = 1;
            foreach (var item in allItems)
            {
                if (item.status)
                {
                    var label = new Label
                    {

                        Text = item.title,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    gridLayout.Children.Add(label, 1, rowIndex);
                    var label1 = new Label
                    {
                        Text = item.description,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    gridLayout.Children.Add(label1, 3, rowIndex);
                    var label6 = new Button
                    {
                        Text = "Response",
                        BindingContext = item.Id.ToString() + "," + item.username.ToString(),
                        // CommandParameter = item.Id,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    label6.Clicked += new EventHandler(btn_Clicked);
                    gridLayout.Children.Add(label6, 5, rowIndex);
                    rowIndex++;
                }
            }

             async void btn_Clicked(object sender, EventArgs e)
            {
                string data = ((Button)sender).BindingContext as string;
                // var newToDo = new DonationRequests { Title = "ark", UserName = "abc" };

                // await DbManager.InsertItem(newToDo);

                await Navigation.PushAsync(new ResponseDonationRequests(data));



            }

        }
    }
}